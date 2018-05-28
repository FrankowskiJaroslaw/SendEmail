namespace SendMail
{
    partial class UF_Outlook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Bttn_Przycisk = new MetroFramework.Controls.MetroButton();
            this.Bttn_Przycisk2 = new MetroFramework.Controls.MetroButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Bttn_Przycisk
            // 
            this.Bttn_Przycisk.Location = new System.Drawing.Point(48, 106);
            this.Bttn_Przycisk.Name = "Bttn_Przycisk";
            this.Bttn_Przycisk.Size = new System.Drawing.Size(215, 83);
            this.Bttn_Przycisk.TabIndex = 0;
            this.Bttn_Przycisk.Text = "Test";
            this.Bttn_Przycisk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Bttn_Przycisk.UseSelectable = true;
            this.Bttn_Przycisk.Click += new System.EventHandler(this.Bttn_Przycisk_Click);
            // 
            // Bttn_Przycisk2
            // 
            this.Bttn_Przycisk2.Location = new System.Drawing.Point(48, 195);
            this.Bttn_Przycisk2.Name = "Bttn_Przycisk2";
            this.Bttn_Przycisk2.Size = new System.Drawing.Size(215, 83);
            this.Bttn_Przycisk2.TabIndex = 1;
            this.Bttn_Przycisk2.Text = "Test";
            this.Bttn_Przycisk2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Bttn_Przycisk2.UseSelectable = true;
            this.Bttn_Przycisk2.Click += new System.EventHandler(this.Bttn_Przycisk2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(317, 121);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 222);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // UF_Outlook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Bttn_Przycisk2);
            this.Controls.Add(this.Bttn_Przycisk);
            this.Name = "UF_Outlook";
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "Send email";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton Bttn_Przycisk;
        private MetroFramework.Controls.MetroButton Bttn_Przycisk2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}