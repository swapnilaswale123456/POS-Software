using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orion
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void LoadLanguegePack()
        {
            if (Properties.Settings.Default.App_Default_Language)
            {
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                    XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                    foreach (XmlNode languageNode in languageNodes)
                    {
                        XmlNode l1179 = languageNode["l1179"];
                        lbl1179.Text = l1179.InnerText;

                        XmlNode l1180 = languageNode["l1180"];
                        lbl1180.Text = l1180.InnerText;

                        XmlNode l1181 = languageNode["l1181"];
                        lbl1181.Text = l1181.InnerText;

                        XmlNode l1162 = languageNode["l1162"];
                        lbl1162.Text = l1162.InnerText;

                        XmlNode l1163 = languageNode["l1163"];
                        lbl1163.Text = l1163.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) | string.IsNullOrWhiteSpace(txtNewPassword.Text) | string.IsNullOrWhiteSpace(txtRepassword.Text))
            { errorProvider.SetError(txtCurrentPassword, "Required"); errorProvider1.SetError(txtNewPassword, "Required"); errorProvider2.SetError(txtRepassword, "Required"); }
            else if (!(txtNewPassword.Text == txtRepassword.Text))
            { errorProvider1.SetError(txtNewPassword, "Required"); errorProvider2.SetError(txtRepassword, "Required"); }
            else
            {
                errorProvider.Clear();
                errorProvider1.Clear();
                errorProvider2.Clear();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Users  WHERE  (USER_ID = '" + clsUtility.UserID + "') AND (Password = '" + txtCurrentPassword.Text + "') ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.ExecuteSQLQuery("UPDATE Users SET Password = '" + clsUtility.CreateMD5(txtNewPassword.Text) + "'  WHERE  (USER_ID = '" + clsUtility.UserID + "')  ");
                    txtCurrentPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtRepassword.Text = "";
                    clsUtility.MesgBoxShow("msgUpdate", "info");
                }
                else { errorProvider.SetError(txtCurrentPassword, "Required"); }
            }
        }
    }
}
