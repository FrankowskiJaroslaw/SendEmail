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
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using System.Collections;
using System.Web;



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
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            //Copy();
            //mailItem.Body = GetCurrentDocument.Text ;
            mailItem.HTMLBody = HtmlConverter(GetCurrentDocument);
            //
            //mailItem.HTMLBody  = $"< p >< font color = {ColorConverterExtensions.ToRgbString(GetCurrentDocument.SelectionColor)} > This is some text!</ font ></ p >";
            //mailItem.HTMLBody = $"<p><span style=color:{ColorConverterExtensions.ToRgbString(GetCurrentDocument.SelectionColor)} > This is some text!</ span ></ p >";
            //mailItem.HTMLBody = $"<p><font color={ColorConverterExtensions.ToHexString(GetCurrentDocument.SelectionColor)} > This is some text!</font ></p >";
            //GetCurrentDocument.Copy();

            //Outlook.Attachment attachment = mailItem.Attachments.Add(@"C:\Users\user\Desktop\kosmos.jpg", Outlook.OlAttachmentType.olEmbeddeditem, null, "Some image display name");

            //string imageCid = "kosmos.jpg";

            //attachment.PropertyAccessor.SetProperty(
            //  "http://schemas.microsoft.com/mapi/proptag/0x3712001E"
            // , imageCid
            // );

            //mailItem.HTMLBody += String.Format(
            //  "<body><img src=\"cid:{0}\"></body>"
            // , imageCid
            // );

            GetCurrentDocument.Text += mailItem.HTMLBody;
            mailItem.Display();

            //MetroMessageBox.Show(this, "Cześć kotek", "Aplikacja do wysyłania Mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //public static string TextToHtml(string text)
        //{
        //    //text = "<pre>" + HttpUtility.HtmlEncode(text) + "</pre>";
        //    //return text;
        //}


        private void Bttn_Przycisk2_Click(object sender, EventArgs e)
        {
            //OutlookApp outlookApp = new OutlookApp();
            //Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            //mailItem.Subject = "This is the subject";
            //mailItem.HTMLBody = "<html><body>This is the <strong>funky</strong> message body</body></html>";

            ////Set a high priority to the message
            //mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            //mailItem.Display();
            //Rect rect;
            //rect.Left = 10;
            //rect.Top = 10;
            //rect.Right = 10;
            //rect.Bottom = 10;

            //RichTextBoxMargin = rect;

            string htmlstr = "";

            GetCurrentDocument.Text = GetCurrentDocument.Text + Environment.NewLine + htmlstr;

        }

        #region HtmlConvert
        private string HtmlConverter(RichTextBox rtb)
        {

            byte R, G, B;

            string BackCorAtual = "";
            string BackCorAnterior = "";

            string CorAtual = "";
            string CorAnterior = "";

            string FontAtual = "";
            string FontAnterior = "";

            float TamantoAtual = 0;
            float TamantoAnterior = 0;

            //FontStyle EstiloAtual = 0;
            //FontStyle EstilAnterior = 0;
            FontStyle FontStylePriv = 0;
            FontStyle FontStyleAktual = 0;
            List<string> listEnds = new List<string>();

            string htmlBody = "";
            int Spam = 0;

            for (int i = 0; i < rtb.Text.Length; i++)
            {
                rtb.Select(i, 1);
                if (rtb.SelectedText == "\n")
                {
                    htmlBody += "<br>";
                }
                else
                {
                    if (rtb.SelectedText != "")
                    {
                        R = rtb.SelectionColor.R;
                        G = rtb.SelectionColor.G;
                        B = rtb.SelectionColor.B;
                        CorAtual = ColorConverterExtensions.ToHexString(rtb.SelectionColor);

                        R = rtb.SelectionBackColor.R;
                        G = rtb.SelectionBackColor.G;
                        B = rtb.SelectionBackColor.B;
                        BackCorAtual = ColorConverterExtensions.ToHexString(rtb.SelectionBackColor);

                        FontAtual = rtb.SelectionFont.Name;
                        TamantoAtual = rtb.SelectionFont.Size;
                        FontStyleAktual = rtb.SelectionFont.Style;

                        //color
                        if (CorAtual != CorAnterior)
                        {
                            htmlBody += "<span style=color:" + CorAtual + ">";
                            Spam += 1;
                        }
                        //background
                        if (BackCorAtual != BackCorAnterior)
                        {
                            htmlBody += "<span style=background-color:" + BackCorAtual + ">";
                            Spam += 1;
                        }
                        //Font
                        if (FontAtual != FontAnterior)
                        {
                            htmlBody += "<span style=font:" + FontAtual + ">";
                            Spam += 1;
                        }
                        //Size
                        if (TamantoAtual != TamantoAnterior)
                        {
                            htmlBody += "<span style=font-size:" + TamantoAtual + ">";
                            Spam += 1;
                        }
                        //foreach (FontStyle fs in Style)
                        //{
                        //    // FontFamily.Source contains the font family name.

                        //}
                        if (FontStylePriv != FontStyleAktual)
                        {
                            if (listEnds.Count != 0)
                            {
                                foreach (string item in listEnds)
                                {
                                    htmlBody += item;
                                }
                                listEnds.Clear();
                            }

                            foreach (FontStyle fs in Enum.GetValues(typeof(FontStyle)))
                            {
                                // ...
                                if (FontStyleAktual.ToString().Contains(fs.ToString()))
                                {
                                    GetFontStyle(fs, out string sBegin, out string sEnd);
                                    htmlBody += sBegin;
                                    listEnds.Add(sEnd);
                                }
                            }
                        }

                        htmlBody += rtb.SelectedText;

                        //set previous variable
                        TamantoAnterior = TamantoAtual;
                        FontAnterior = FontAtual;
                        CorAnterior = CorAtual;
                        BackCorAnterior = BackCorAtual;
                        FontStylePriv = FontStyleAktual;

                    }

                }

            }

            //Final spam
            for (int i = 0; i < Spam; i++)
            {
                htmlBody += "</span>";
            }
            htmlBody += "</div>";

            return htmlBody;

        }

        private string HTML_RGBHex(byte R, byte G, byte B)
        {
            object HexR, HexB, HexG = new object();

            HexR = string.Format("{0:X}", R);
            if (HexR.ToString().Length < 2) { HexR = "0" + HexR; }


            HexB = string.Format("{0:X}", R);
            if (HexB.ToString().Length < 2) { HexB = "0" + HexR; }

            HexG = string.Format("{0:X}", R);
            if (HexG.ToString().Length < 2) { HexG = "0" + HexR; }

            //return "\"#ff0000\""; //"" + "rgb(201, 76, 76)" + """"; //"rgb(0, 191, 255)";
            return "\"#" + HexR + HexG + HexB + "\"";
        }

        private void GetFontStyle(FontStyle fs, out string sBegin, out string sEnd)
        {
            switch (fs)
            {
                case FontStyle.Bold:
                    sBegin = "<strong>";
                    sEnd = "</strong>";
                    break;
                case FontStyle.Italic:
                    sBegin = "<em>";
                    sEnd = "</em>";
                    break;
                case FontStyle.Underline:
                    sBegin = "<u>";
                    sEnd = "</u>";
                    break;
                case FontStyle.Strikeout:
                    sBegin = "<strike>";
                    sEnd = "</strike>";
                    break;
                default:
                    sBegin = "";
                    sEnd = "";
                    break;
            }
            //switch (EstiloAtual)
            //{
            //    case FontStyle.Regular:
            //        break;
            //    case FontStyle.Bold:
            //        htmlBody += "<strong>" + rtb.SelectedText + "</strong>";
            //        break;
            //    case FontStyle.Italic:
            //        htmlBody += "<em>" + rtb.SelectedText + "</em>";
            //        break;
            //    case FontStyle.Underline:
            //        htmlBody += "<u>" + rtb.SelectedText + "</u>";
            //        break;
            //    case FontStyle.Strikeout:
            //        htmlBody += "<strike>" + rtb.SelectedText + "</strike>";
            //        break;
            //    default:
            //        htmlBody += rtb.SelectedText;
            //        break;
            //}
        }


        #endregion






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

            //marginesy
            RichTextBoxExtensions.SetInnerMargins(Body, 20, 15, 10, 10);
            //Body.Cursor = 
            //Body.MouseEnter += new EventHandler(button1_MouseMove);
            //Body.MouseLeave += new EventHandler(button1_MouseMove);
            Body.MouseMove += new MouseEventHandler(button1_MouseMove);
            //System.Windows.Forms.MauseEventHandler
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

        private void FontTextAlign(HorizontalAlignment align)
        {
            GetCurrentDocument.SelectionAlignment = align;
        }
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
        #region Paragraph
        private void ParagraphNew()
        {
            //bool IsBullet = GetCurrentDocument.SelectionBullet;
            bool IsBullet = !GetCurrentDocument.SelectionBullet; // == true ? false : true;

            if (IsBullet)
            {
                GetCurrentDocument.SelectionBullet = true;
                GetCurrentDocument.SelectionIndent = 8;
                GetCurrentDocument.SelectionHangingIndent = 3;
                GetCurrentDocument.SelectionRightIndent = 12;
                GetCurrentDocument.SelectionCharOffset = 11;
            }
            else
            {
                GetCurrentDocument.SelectionBullet = false;
                GetCurrentDocument.SelectionIndent = 0;
                GetCurrentDocument.SelectionHangingIndent = 0;
                GetCurrentDocument.SelectionRightIndent = 0;
                GetCurrentDocument.SelectionCharOffset = 0;
            }

        }
        #endregion
        #endregion

        #region Properties
        public RichTextBox GetCurrentDocument
        { get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; } }

        #endregion

        #region MyEvents

        #region ControlStripLeft


        private void nowyToolStripButton1_Click(object sender, EventArgs e)
        {
            AddTab();
        }
        private void RemoveTabToolStripButton_Click(object sender, EventArgs e)
        {
            RemoveTab();
        }
        private void zapiszToolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void otwórzToolStripButton1_Click(object sender, EventArgs e)
        {
            Open();
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

        #endregion

        #region ContextMenu
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RemoveAllTabs();
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
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
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region MainMenuStripFile

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


        #endregion

        #region MainMenuStripEdit

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
        #endregion

        #region FontStyle
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
        #endregion

        #region FontSize
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
        #endregion

        #region FontColor
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FontForeColor();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            FontHighlight();
        }
        #endregion

        #region ComboFontSize
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontChange();
        }
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontSize();
        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetCurrentDocument.Text.Length > 0)
            {
                toolStripStatusLabel1.Text = GetCurrentDocument.Text.Length.ToString();
            }
        }
        #endregion

        #region FontAlignment

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FontTextAlign(HorizontalAlignment.Left);
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FontTextAlign(HorizontalAlignment.Center);
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            FontTextAlign(HorizontalAlignment.Right);
        }
        #endregion

        #region GetCurrentDocument
        private void button1_MouseMove(object sender, System.EventArgs e)
        {
            // Add event handler code here.  
            //MessageBox.Show(this, "Test", "Klikanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Control.MousePosition
            //PointToClient(Cursor.Position);
            int pos = GetCurrentDocument.PointToClient(Cursor.Position).X;
            if (pos < 10)
            {
                FunChangeCursor(GetCurrentDocument, Cursors.PanNE);
            }
            else
            {
                FunChangeCursor(GetCurrentDocument, Cursors.Default);
            }
        }
        private void FunChangeCursor(RichTextBox CurPriv, Cursor CurNext)
        {
            if (CurPriv.Cursor != CurNext)
            {
                CurPriv.Cursor = CurNext;
            }
        }
        #endregion

        #region Paragraph


        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            ParagraphNew();
        }


        #endregion

        #endregion
    }

    #region RTBMargin


    public static class RichTextBoxExtensions
    {
        public static void SetInnerMargins(this TextBoxBase textBox, int left, int top, int right, int bottom)
        {
            var rect = textBox.GetFormattingRect();

            var newRect = new Rectangle(left, top, rect.Width - left - right, rect.Height - top - bottom);
            textBox.SetFormattingRect(newRect);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;

            private RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }
        }

        [DllImport(@"User32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessageRefRect(IntPtr hWnd, uint msg, int wParam, ref RECT rect);

        [DllImport(@"user32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);

        private const int EmGetrect = 0xB2;
        private const int EmSetrect = 0xB3;

        private static void SetFormattingRect(this TextBoxBase textbox, Rectangle rect)
        {
            var rc = new RECT(rect);
            SendMessageRefRect(textbox.Handle, EmSetrect, 0, ref rc);
        }

        private static Rectangle GetFormattingRect(this TextBoxBase textbox)
        {
            var rect = new Rectangle();
            SendMessage(textbox.Handle, EmGetrect, (IntPtr)0, ref rect);
            return rect;
        }
    }
    #endregion

    public static class ColorConverterExtensions
    {
        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        public static string ToRgbString(this Color c) => $"RGB({c.R}, {c.G}, {c.B})";
    }
}




