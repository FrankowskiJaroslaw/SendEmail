using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;


namespace SendMail
{
    public partial class UF_Outlook : MetroForm
    {
        //Outlook.MailItem
        public UF_Outlook()
        {
            InitializeComponent();
        }

        private void Bttn_Przycisk_Click(object sender, EventArgs e)
        {
            Outlook.Application app = new Outlook.Application();


            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.To = @"frankowski.jaroslaw2@gmail.com";
            mailItem.CC = "";
            mailItem.Subject = "Test";
            mailItem.Body = "Test wysyłki email";


            Outlook.Attachment attachment = mailItem.Attachments.Add(@"C:\Users\user\Desktop\kosmos.jpg", Outlook.OlAttachmentType.olEmbeddeditem, null, "Some image display name");

            string imageCid = "kosmos.jpg";

            attachment.PropertyAccessor.SetProperty(
              "http://schemas.microsoft.com/mapi/proptag/0x3712001E"
             , imageCid
             );

            mailItem.HTMLBody = String.Format(
              "<body><img src=\"cid:{0}\"></body>"
             , imageCid
             );

            mailItem.Display();


            MetroMessageBox.Show(this, "Cześć kotek ;*", "Aplikacja do wysyłania Mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Bttn_Przycisk2_Click(object sender, EventArgs e)
        {
            OutlookApp outlookApp = new OutlookApp();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "This is the subject";
            mailItem.HTMLBody = "<html><body>This is the <strong>funky</strong> message body</body></html>";

            //Set a high priority to the message
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display();

        }
    }
}