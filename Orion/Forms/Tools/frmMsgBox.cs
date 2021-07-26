using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Orion
{
    public partial class frmMsgBox : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmMsgBox(string msg, string alertType)
        {
            InitializeComponent();

            if (msg == "msgSaved") {
                //////////////////Saved//////////////
                string save_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                { 
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1190= languageNode["l1190"];
                            save_msg = l1190.InnerText;
                        }
                        lblMsg.Text = save_msg.ToString();
                    }
                    catch (Exception)
                    {
                        lblMsg.Text = "Information has been saved successfully.";
                    }
                }
                else { lblMsg.Text = "Information has been saved successfully."; }
                //////////////////Saved//////////////
            }
            if (msg == "msgUpdate") {
                //////////////////Update//////////////
                string update_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1191 = languageNode["l1191"];
                            update_msg = l1191.InnerText;
                        }
                        lblMsg.Text = update_msg.ToString();
                    }
                    catch (Exception )
                    {
                        lblMsg.Text = "Information has been updated successfully.";
                    }
                }
                else { lblMsg.Text = "Information has been updated successfully."; }
                //////////////////Update//////////////
            }
            if (msg == "msgDelete") {
                //////////////////Delete//////////////
                string delete_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1192 = languageNode["l1192"];
                            delete_msg = l1192.InnerText;
                        }
                        lblMsg.Text = delete_msg.ToString();
                    }
                    catch (Exception )
                    {
                        lblMsg.Text = "Information has been deleted successfully.";
                    }
                }
                else { lblMsg.Text = "Information has been deleted successfully."; }
                //////////////////Delete//////////////
            }

            if (msg == "msgNotFound")
            {
                //////////////////Delete//////////////
                string NotFound_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1193 = languageNode["l1193"];
                            NotFound_msg = l1193.InnerText;
                        }
                        lblMsg.Text = NotFound_msg.ToString();
                    }
                    catch (Exception )
                    {
                        lblMsg.Text = "No data found.";
                    }
                }
                else { lblMsg.Text = "No data found."; }
                //////////////////Delete//////////////
            }

            if (msg == "msgAlreadyInStock")
            {
                //////////////////Delete//////////////
                string AlreadyInStock_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1194 = languageNode["l1194"];
                            AlreadyInStock_msg = l1194.InnerText;
                        }
                        lblMsg.Text = AlreadyInStock_msg.ToString();
                    }
                    catch (Exception )
                    {
                        lblMsg.Text = "This product has already been added to the Stock.";
                    }
                }
                else { lblMsg.Text = "This product has already been added to the Stock."; }
                //////////////////Delete//////////////
            }

            if (msg == "msgPermission") {
                //////////////////Permission//////////////
                string permission_msg = "";
                if (Properties.Settings.Default.App_Default_Language)
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                        XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                        foreach (XmlNode languageNode in languageNodes)
                        {
                            XmlNode l1189 = languageNode["l1189"];
                            permission_msg = l1189.InnerText;
                        }
                        lblMsg.Text = permission_msg.ToString();
                    }
                    catch (Exception )
                    {
                        lblMsg.Text = "No permission.";
                    }
                }
                else { lblMsg.Text = "No permission."; }

                //////////////////Permission//////////////
            }



            if (alertType == "err") { pictureBox1.Image = Orion.Properties.Resources.msg_error; MessageBoxCaption.Text = "Error"; System.Media.SystemSounds.Beep.Play(); }
            else if (alertType == "info") { pictureBox1.Image = Orion.Properties.Resources.msg_info; MessageBoxCaption.Text = "Information"; System.Media.SystemSounds.Asterisk.Play(); }
            else if (alertType == "que") { pictureBox1.Image = Orion.Properties.Resources.msg_ques; MessageBoxCaption.Text = "Question"; System.Media.SystemSounds.Question.Play(); }
            else if (alertType == "exc") { pictureBox1.Image = Orion.Properties.Resources.msg_exc; MessageBoxCaption.Text = "Exclamation"; System.Media.SystemSounds.Exclamation.Play(); }
            else { pictureBox1.Image = Orion.Properties.Resources.msg_info; MessageBoxCaption.Text = "Information"; System.Media.SystemSounds.Asterisk.Play(); }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MessageBoxCaption_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
