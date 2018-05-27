using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace SendMail
{
    public partial class Form1 : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(Tb_UserName.Text, Tb_Password.Text);
            client = new SmtpClient(Tb_Smtp.Text)
            {
                UseDefaultCredentials = false,   //dopisane
                Port = Convert.ToInt32(Tb_Port.Text),
                EnableSsl = Chb_SSL.Checked,
                Credentials = login
            };
            //msg = new MailMessage { From = new MailAddress(Tb_UserName.Text + Tb_Smtp.Text, "Jarek", Encoding.UTF8) };
            msg = new MailMessage { From = new MailAddress(Tb_UserName.Text, "Jarek", Encoding.UTF8) };
            msg.To.Add(new MailAddress(Tb_To.Text));
            if (!string.IsNullOrEmpty(Tb_CC.Text))
            {
                msg.CC.Add(new MailAddress(Tb_CC.Text));
            }
            msg.Subject = Tb_Subject.Text;
            msg.Body = Tb_Message.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.EnableSsl = true;
            client.SendCompleted += new SendCompletedEventHandler(SendComplitedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);

        }
        private static void SendComplitedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Tb_To.Text = "frankowski.jaroslaw2@gmail.com";
            Tb_Password.Text = "mypassword";
            Tb_Subject.Text = "Test wysyłki wiadomości";
            Tb_Message.Text = "Textowa wiadomość";
            Tb_UserName.Text = "wertini@wertini.pl";
            Chb_SSL.Checked = true;
            Tb_Port.Text = "587";
            Tb_Smtp.Text = "wertini.home.pl";


        }

        private void Btn_Send2_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.Host = Tb_UserName.Text;
            client.Port = Convert.ToInt32(Tb_Port.Text);

            NetworkCredential credentials = new NetworkCredential(Tb_UserName.Text, Tb_Password.Text);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            msg.From = new MailAddress(Tb_UserName.Text, "Jarek", Encoding.UTF8);
            msg.To.Add(Tb_To.Text);
            msg.Subject = "Test";
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Priority = MailPriority.High;
            msg.Body = "Test";
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(msg);

        }

        private void Bttn_Send3_Click(object sender, EventArgs e)
        {
            using (SmtpClient client = new SmtpClient(Tb_Smtp.Text, Convert.ToInt32(Tb_Port.Text)))
            {
                // Configure the client
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(Tb_UserName.Text, Tb_Password.Text);
                // client.UseDefaultCredentials = true;

                // A client has been created, now you need to create a MailMessage object
                MailMessage message = new MailMessage(
                                         Tb_UserName.Text, // From field
                                         Tb_To.Text, // Recipient field
                                         "Hello", // Subject of the email message
                                         "World!" // Email message body
                                      );

                // Send the message
                client.Send(message);

                /* 
                 * Since I was using Console app, that is why I am able to use the Console
                 * object, your framework would have different ones. 
                 * There is actually no need for these following lines, you can ignore them
                 * if you want to. SMTP protocol would still send the email of yours. */

                // Print a notification message
                Console.WriteLine("Email has been sent.");
                // Just for the sake of pausing the application
                Console.Read();
            }


        }
    }
}
