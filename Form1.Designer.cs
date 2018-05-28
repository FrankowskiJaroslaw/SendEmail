namespace SendMail
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_To = new System.Windows.Forms.Label();
            this.Tb_To = new System.Windows.Forms.TextBox();
            this.Lbl_CC = new System.Windows.Forms.Label();
            this.Tb_CC = new System.Windows.Forms.TextBox();
            this.Tb_Subject = new System.Windows.Forms.TextBox();
            this.Lbl_Subject = new System.Windows.Forms.Label();
            this.Tb_Message = new System.Windows.Forms.TextBox();
            this.Lbl_Message = new System.Windows.Forms.Label();
            this.Gbox_Setting = new System.Windows.Forms.GroupBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Chb_SSL = new System.Windows.Forms.CheckBox();
            this.Tb_Smtp = new System.Windows.Forms.TextBox();
            this.Lb_Smtp = new System.Windows.Forms.Label();
            this.Tb_Port = new System.Windows.Forms.TextBox();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Tb_Password = new System.Windows.Forms.TextBox();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Tb_UserName = new System.Windows.Forms.TextBox();
            this.Lbl_UserName = new System.Windows.Forms.Label();
            this.Btn_Send2 = new System.Windows.Forms.Button();
            this.Bttn_Send3 = new System.Windows.Forms.Button();
            this.Gbox_Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_To
            // 
            this.Lbl_To.AutoSize = true;
            this.Lbl_To.Location = new System.Drawing.Point(37, 12);
            this.Lbl_To.Name = "Lbl_To";
            this.Lbl_To.Size = new System.Drawing.Size(20, 13);
            this.Lbl_To.TabIndex = 0;
            this.Lbl_To.Text = "To";
            // 
            // Tb_To
            // 
            this.Tb_To.Location = new System.Drawing.Point(63, 12);
            this.Tb_To.Name = "Tb_To";
            this.Tb_To.Size = new System.Drawing.Size(418, 20);
            this.Tb_To.TabIndex = 1;
            // 
            // Lbl_CC
            // 
            this.Lbl_CC.AutoSize = true;
            this.Lbl_CC.Location = new System.Drawing.Point(36, 38);
            this.Lbl_CC.Name = "Lbl_CC";
            this.Lbl_CC.Size = new System.Drawing.Size(21, 13);
            this.Lbl_CC.TabIndex = 2;
            this.Lbl_CC.Text = "CC";
            // 
            // Tb_CC
            // 
            this.Tb_CC.Location = new System.Drawing.Point(63, 38);
            this.Tb_CC.Name = "Tb_CC";
            this.Tb_CC.Size = new System.Drawing.Size(418, 20);
            this.Tb_CC.TabIndex = 3;
            // 
            // Tb_Subject
            // 
            this.Tb_Subject.Location = new System.Drawing.Point(63, 64);
            this.Tb_Subject.Name = "Tb_Subject";
            this.Tb_Subject.Size = new System.Drawing.Size(418, 20);
            this.Tb_Subject.TabIndex = 5;
            // 
            // Lbl_Subject
            // 
            this.Lbl_Subject.AutoSize = true;
            this.Lbl_Subject.Location = new System.Drawing.Point(14, 64);
            this.Lbl_Subject.Name = "Lbl_Subject";
            this.Lbl_Subject.Size = new System.Drawing.Size(43, 13);
            this.Lbl_Subject.TabIndex = 4;
            this.Lbl_Subject.Text = "Subject";
            // 
            // Tb_Message
            // 
            this.Tb_Message.Location = new System.Drawing.Point(63, 90);
            this.Tb_Message.Multiline = true;
            this.Tb_Message.Name = "Tb_Message";
            this.Tb_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Tb_Message.Size = new System.Drawing.Size(418, 124);
            this.Tb_Message.TabIndex = 7;
            // 
            // Lbl_Message
            // 
            this.Lbl_Message.AutoSize = true;
            this.Lbl_Message.Location = new System.Drawing.Point(7, 90);
            this.Lbl_Message.Name = "Lbl_Message";
            this.Lbl_Message.Size = new System.Drawing.Size(50, 13);
            this.Lbl_Message.TabIndex = 6;
            this.Lbl_Message.Text = "Message";
            // 
            // Gbox_Setting
            // 
            this.Gbox_Setting.Controls.Add(this.Btn_Send);
            this.Gbox_Setting.Controls.Add(this.Chb_SSL);
            this.Gbox_Setting.Controls.Add(this.Tb_Smtp);
            this.Gbox_Setting.Controls.Add(this.Lb_Smtp);
            this.Gbox_Setting.Controls.Add(this.Tb_Port);
            this.Gbox_Setting.Controls.Add(this.Lbl_Port);
            this.Gbox_Setting.Controls.Add(this.Tb_Password);
            this.Gbox_Setting.Controls.Add(this.Lbl_Password);
            this.Gbox_Setting.Controls.Add(this.Tb_UserName);
            this.Gbox_Setting.Controls.Add(this.Lbl_UserName);
            this.Gbox_Setting.Location = new System.Drawing.Point(63, 220);
            this.Gbox_Setting.Name = "Gbox_Setting";
            this.Gbox_Setting.Size = new System.Drawing.Size(418, 114);
            this.Gbox_Setting.TabIndex = 8;
            this.Gbox_Setting.TabStop = false;
            this.Gbox_Setting.Text = "groupBox1";
            // 
            // Btn_Send
            // 
            this.Btn_Send.Location = new System.Drawing.Point(301, 43);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(75, 23);
            this.Btn_Send.TabIndex = 9;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Chb_SSL
            // 
            this.Chb_SSL.AutoSize = true;
            this.Chb_SSL.Location = new System.Drawing.Point(301, 22);
            this.Chb_SSL.Name = "Chb_SSL";
            this.Chb_SSL.Size = new System.Drawing.Size(46, 17);
            this.Chb_SSL.TabIndex = 8;
            this.Chb_SSL.Text = "SSL";
            this.Chb_SSL.UseVisualStyleBackColor = true;
            // 
            // Tb_Smtp
            // 
            this.Tb_Smtp.Location = new System.Drawing.Point(199, 74);
            this.Tb_Smtp.Name = "Tb_Smtp";
            this.Tb_Smtp.Size = new System.Drawing.Size(177, 20);
            this.Tb_Smtp.TabIndex = 7;
            this.Tb_Smtp.Text = "smtp.gmail.com";
            // 
            // Lb_Smtp
            // 
            this.Lb_Smtp.AutoSize = true;
            this.Lb_Smtp.Location = new System.Drawing.Point(164, 74);
            this.Lb_Smtp.Name = "Lb_Smtp";
            this.Lb_Smtp.Size = new System.Drawing.Size(34, 13);
            this.Lb_Smtp.TabIndex = 6;
            this.Lb_Smtp.Text = "Smtp:";
            // 
            // Tb_Port
            // 
            this.Tb_Port.Location = new System.Drawing.Point(73, 74);
            this.Tb_Port.Name = "Tb_Port";
            this.Tb_Port.Size = new System.Drawing.Size(73, 20);
            this.Tb_Port.TabIndex = 5;
            this.Tb_Port.Text = "587";
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Location = new System.Drawing.Point(38, 74);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(29, 13);
            this.Lbl_Port.TabIndex = 4;
            this.Lbl_Port.Text = "Port:";
            // 
            // Tb_Password
            // 
            this.Tb_Password.Location = new System.Drawing.Point(73, 45);
            this.Tb_Password.Name = "Tb_Password";
            this.Tb_Password.PasswordChar = '*';
            this.Tb_Password.Size = new System.Drawing.Size(205, 20);
            this.Tb_Password.TabIndex = 3;
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Location = new System.Drawing.Point(11, 45);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(56, 13);
            this.Lbl_Password.TabIndex = 2;
            this.Lbl_Password.Text = "Password:";
            // 
            // Tb_UserName
            // 
            this.Tb_UserName.Location = new System.Drawing.Point(73, 19);
            this.Tb_UserName.Name = "Tb_UserName";
            this.Tb_UserName.Size = new System.Drawing.Size(205, 20);
            this.Tb_UserName.TabIndex = 1;
            // 
            // Lbl_UserName
            // 
            this.Lbl_UserName.AutoSize = true;
            this.Lbl_UserName.Location = new System.Drawing.Point(6, 19);
            this.Lbl_UserName.Name = "Lbl_UserName";
            this.Lbl_UserName.Size = new System.Drawing.Size(61, 13);
            this.Lbl_UserName.TabIndex = 0;
            this.Lbl_UserName.Text = "User name:";
            // 
            // Btn_Send2
            // 
            this.Btn_Send2.Location = new System.Drawing.Point(349, 357);
            this.Btn_Send2.Name = "Btn_Send2";
            this.Btn_Send2.Size = new System.Drawing.Size(75, 23);
            this.Btn_Send2.TabIndex = 10;
            this.Btn_Send2.Text = "Send";
            this.Btn_Send2.UseVisualStyleBackColor = true;
            this.Btn_Send2.Click += new System.EventHandler(this.Btn_Send2_Click);
            // 
            // Bttn_Send3
            // 
            this.Bttn_Send3.Location = new System.Drawing.Point(245, 375);
            this.Bttn_Send3.Name = "Bttn_Send3";
            this.Bttn_Send3.Size = new System.Drawing.Size(75, 23);
            this.Bttn_Send3.TabIndex = 11;
            this.Bttn_Send3.Text = "Send";
            this.Bttn_Send3.UseVisualStyleBackColor = true;
            this.Bttn_Send3.Click += new System.EventHandler(this.Bttn_Send3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 428);
            this.Controls.Add(this.Bttn_Send3);
            this.Controls.Add(this.Btn_Send2);
            this.Controls.Add(this.Gbox_Setting);
            this.Controls.Add(this.Tb_Message);
            this.Controls.Add(this.Lbl_Message);
            this.Controls.Add(this.Tb_Subject);
            this.Controls.Add(this.Lbl_Subject);
            this.Controls.Add(this.Tb_CC);
            this.Controls.Add(this.Lbl_CC);
            this.Controls.Add(this.Tb_To);
            this.Controls.Add(this.Lbl_To);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send mail";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Gbox_Setting.ResumeLayout(false);
            this.Gbox_Setting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_To;
        private System.Windows.Forms.TextBox Tb_To;
        private System.Windows.Forms.Label Lbl_CC;
        private System.Windows.Forms.TextBox Tb_CC;
        private System.Windows.Forms.TextBox Tb_Subject;
        private System.Windows.Forms.Label Lbl_Subject;
        private System.Windows.Forms.TextBox Tb_Message;
        private System.Windows.Forms.Label Lbl_Message;
        private System.Windows.Forms.GroupBox Gbox_Setting;
        private System.Windows.Forms.TextBox Tb_Smtp;
        private System.Windows.Forms.Label Lb_Smtp;
        private System.Windows.Forms.TextBox Tb_Port;
        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.TextBox Tb_Password;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.TextBox Tb_UserName;
        private System.Windows.Forms.Label Lbl_UserName;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.CheckBox Chb_SSL;
        private System.Windows.Forms.Button Btn_Send2;
        private System.Windows.Forms.Button Bttn_Send3;
    }
}

