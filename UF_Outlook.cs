using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            AddTab();
            GetFontCollection();
            PopulateFontSize();
            
        }

        private void Bttn_Przycisk_Click(object sender, EventArgs e)
        {
            Outlook.Application app = new Outlook.Application();


            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.To = @"frankowski.jaroslaw2@gmail.com";
            mailItem.CC = "";
            mailItem.Subject = "Test";
            //mailItem.HTMLBody = richTextBox1.Text;


            Outlook.Attachment attachment = mailItem.Attachments.Add(@"C:\Users\user\Desktop\kosmos.jpg", Outlook.OlAttachmentType.olEmbeddeditem, null, "Some image display name");

            string imageCid = "kosmos.jpg";

            attachment.PropertyAccessor.SetProperty(
              "http://schemas.microsoft.com/mapi/proptag/0x3712001E"
             , imageCid
             );

            mailItem.HTMLBody += String.Format(
              "<body><img src=\"cid:{0}\"></body>"
             , imageCid
             );

            mailItem.Display();


            MetroMessageBox.Show(this, "Cześć kotek ;*", "Aplikacja do wysyłania Mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //public static string TextToHtml(string text)
        //{
        //    //text = "<pre>" + HttpUtility.HtmlEncode(text) + "</pre>";
        //    //return text;
        //}


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

        private int TabCount = 0;
        #region Methods
        #region Tabs
        private void AddTab()
        {
            RichTextBox Body = new RichTextBox
            {
                Name = "Body",
                Dock = DockStyle.Fill,
                ContextMenuStrip = contextMenuStrip1
            };

            TabCount += 1;
            string DocumentText = "Document " + TabCount;
            TabPage NewPage = new TabPage
            {
                Name = DocumentText,
                Text = DocumentText
            };
            NewPage.Controls.Add(Body);

            tabControl1.TabPages.Add(NewPage);
        }
        private void RemoveTab()
        {
            if (tabControl1.TabPages.Count != 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AddTab();
            }
        }
        private void RemoveAllTabs()
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tab);
            }
            AddTab();
        }
        private void RemoveAllTabsButThis()
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab != tabControl1.SelectedTab)
                {
                    tabControl1.TabPages.Remove(tab);
                }
            }
        }
        #endregion
        #region SaveAndOpen
        private void Save()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf";
            saveFileDialog1.Title = "Save";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }
        private void SaveAs()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|Word Files|*.docx|All Files|*.*";
            saveFileDialog1.Title = "Save As";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }
        private void Open()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|Word Files|*.docx|All Files|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    tabControl1.SelectedTab.Text = Path.GetFileName(openFileDialog1.FileName);
                }
            }
        }
        #endregion
        #region TextMethods
        private void Undo()
        {
            GetCurrentDocument.Undo();
        }
        private void Redo()
        {
            GetCurrentDocument.Redo();
        }
        private void Cut()
        {
            GetCurrentDocument.Cut();
        }
        private void Copy()
        {
            GetCurrentDocument.Copy();
        }
        private void Paste()
        {
            GetCurrentDocument.Paste();
        }
        private void SelectAll()
        {
            GetCurrentDocument.SelectAll();
        }
        #endregion
        #region GeneralMethods
        private void GetFontCollection()
        {
            InstalledFontCollection InsFonts = new InstalledFontCollection();
            foreach (FontFamily item in InsFonts.Families)
            {
                toolStripComboBox1.Items.Add(item.Name);
            }
            toolStripComboBox1.SelectedIndex = 1;
        }
        private void PopulateFontSize()
        {
            for (int i = 1; i <= 70; i++)
            {
                toolStripComboBox2.Items.Add(i);
            }
            toolStripComboBox2.SelectedIndex = 11;
        }
        #endregion
        #region FontChanges
        private void FontSelection(FontStyle font)
        {
            FontStyle NewFS = GetCurrentDocument.SelectionFont.Style ^ font;
            Font NewFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, GetCurrentDocument.SelectionFont.Style ^ font);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Style == NewFS)
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = NewFont;
            }
        }
        private void Upper()
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToUpper();
        }
        private void Lower()
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToLower();
        }
        private void Increase()
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints + 2;
            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }
        private void Decrease()
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints - 2;
            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }
        private void FontForeColor()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                GetCurrentDocument.SelectionColor = colorDialog1.Color;
            }
        }
        private void FontHighlight()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                GetCurrentDocument.SelectionBackColor = colorDialog1.Color;
            }
        }
        private void FontChange()
        {
            Font NewFont = new Font(toolStripComboBox1.SelectedItem.ToString(), GetCurrentDocument.SelectionFont.Size, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewFont;
        }
        private void FontSize()
        {
            float.TryParse(toolStripComboBox2.SelectedItem.ToString(), out float NewFontSize);
            Font NewFont = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewFont;
        }
        #endregion
        #endregion

        #region Properties
        public RichTextBox GetCurrentDocument
        { get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; } }

        #endregion
        #region MyEvents


        private void nowyToolStripButton1_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void RemoveTabToolStripButton_Click(object sender, EventArgs e)
        {
            RemoveTab();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RemoveAllTabs();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void zapiszjakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.Copy();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.Paste();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void ponówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void zaznaczwszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void wytnijToolStripButton1_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void kopiujToolStripButton1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void wklejToolStripButton1_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FontSelection(FontStyle.Bold);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FontSelection(FontStyle.Italic);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FontSelection(FontStyle.Underline);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FontSelection(FontStyle.Strikeout);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Upper();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Lower();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Increase();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Decrease();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FontForeColor();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            FontHighlight();
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontChange();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontSize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetCurrentDocument.Text.Length > 0)
            {
                toolStripStatusLabel1.Text = GetCurrentDocument.Text.Length.ToString();
            }
        }
        #endregion


    }
}