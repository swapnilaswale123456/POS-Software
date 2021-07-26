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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
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
                        XmlNode l1160 = languageNode["l1160"];
                        lbl1160.Text = l1160.InnerText;

                        XmlNode l1162 = languageNode["l1162"];
                        lbl1162.Text = l1162.InnerText;

                        XmlNode l1178 = languageNode["l1178"];
                        chkRememberMe.Text = l1178.InnerText;

                        XmlNode ctrlLogin = languageNode["ctrlLogin"];
                        btnLogIn.Text = ctrlLogin.InnerText;

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

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();

            if (Properties.Settings.Default.App_Default_Conn)
            {
                clsUtility.DBConnectionInitializing();
            }
            else
            {
                frmConfiguration frmConfiguration = new frmConfiguration();
                frmConfiguration.ShowDialog();
            }
            
            lblWaring.Visible = false;

            if (Properties.Settings.Default.App_UserRemember)
            {
                txtUserName.Text = Properties.Settings.Default.App_UserName;
                txtPassword.Text = Properties.Settings.Default.App_UserPassword;
                chkRememberMe.Checked = Properties.Settings.Default.App_UserRemember;
            }

            clsUtility.ExecuteSQLQuery("SELECT * FROM Users");
            if (!(clsUtility.sqlDT.Rows.Count > 0))
            {
                clsUtility.ExecuteSQLQuery("INSERT INTO Users (FullName,UserName,Privilege,RegDate,Password,Can_Add,Can_Edit,Can_Delete,Can_Print) VALUES ('Administrator','admin','Administrator','" + DateTime.Now.ToString("yyyy-MM-dd") + "','827CCB0EEA8A706C4C34A16891F84E7B','Y','Y','Y','Y')");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text)){
                UserNameErrorProvider.SetError(txtUserName, "Username empty!");
                txtUserName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.txtPassword.Text)) {
                PasswordErrorProvider.SetError(txtPassword, "Password empty!");
                txtPassword.Focus();
            }
            else {
                UserNameErrorProvider.Clear();
                PasswordErrorProvider.Clear();
                try {
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Users WHERE  UserName = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    clsUtility.UserID = clsUtility.sqlDT.Rows[0]["USER_ID"].ToString();
                    clsUtility.UserName = clsUtility.sqlDT.Rows[0]["UserName"].ToString();
                    clsUtility.UsersPrivilege = clsUtility.sqlDT.Rows[0]["Privilege"].ToString();
                    if (chkRememberMe.Checked)
                    {
                        Properties.Settings.Default.App_UserName = txtUserName.Text;
                        Properties.Settings.Default.App_UserPassword = txtPassword.Text;
                    }
                    else {
                        Properties.Settings.Default.App_UserName = null;
                        Properties.Settings.Default.App_UserPassword = null;
                    }
                    Properties.Settings.Default.App_UserRemember = chkRememberMe.Checked;
                    Properties.Settings.Default.Save();
                    frmMDIParent frmMDIParent = new frmMDIParent();
                    frmMDIParent.Show();
                    this.Hide();
                }
                else { 
                    lblWaring.Visible = true;
                    lblWaring.Text = "No such user."; 
                }
                }
                catch (Exception) {
                    lblWaring.Visible = true;
                    lblWaring.Text = "Error executing sql statement.";
                }
            }
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
