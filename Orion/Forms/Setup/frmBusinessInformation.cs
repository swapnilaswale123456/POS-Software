using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Orion.Forms.Setup
{
    public partial class frmBusinessInformation : Form
    {

        public frmBusinessInformation()
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
                        XmlNode l1000 = languageNode["l1000"];
                        lbl1000.Text = l1000.InnerText;

                        XmlNode l1001 = languageNode["l1001"];
                        lbl1001.Text = l1001.InnerText;

                        XmlNode l1002 = languageNode["l1002"];
                        lbl1002.Text = l1002.InnerText;

                        XmlNode l1003 = languageNode["l1003"];
                        lbl1003.Text = l1003.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1005.Text = l1005.InnerText;

                        XmlNode l1006 = languageNode["l1006"];
                        lbl1006.Text = l1006.InnerText;

                        XmlNode Credit = languageNode["l1007"];
                        lbl1007.Text = Credit.InnerText;

                        XmlNode l1008 = languageNode["l1008"];
                        lbl1008.Text = l1008.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlBrowsePhoto = languageNode["ctrlBrowsePhoto"];
                        btnBrowosePhoto.Text = ctrlBrowsePhoto.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmBusinessInformation_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            LoadLanguegePack();

            clsUtility.ExecuteSQLQuery("SELECT * FROM BusinessInformation");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                txtCompanyName.Text = clsUtility.sqlDT.Rows[0]["CompanyName"].ToString();
                txtLegalName.Text = clsUtility.sqlDT.Rows[0]["LegalName"].ToString();
                txtAddress.Text = clsUtility.sqlDT.Rows[0]["Address"].ToString();
                txtPhoneNo.Text = clsUtility.sqlDT.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = clsUtility.sqlDT.Rows[0]["Email"].ToString();
                txtWebSite.Text = clsUtility.sqlDT.Rows[0]["WebSite"].ToString();
                txtSlogan.Text = clsUtility.sqlDT.Rows[0]["Slogan"].ToString();

                try
                {
                    pictureBox1.ImageLocation = Application.StartupPath + @"\Upload\Company\" + "BrandLogo.jpg";
                }
                catch (Exception) { pictureBox1.Image = Orion.Properties.Resources.No_image_found; }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();         
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtCompanyName.Text) | string.IsNullOrWhiteSpace(this.txtAddress.Text) | string.IsNullOrWhiteSpace(this.txtPhoneNo.Text))
                {
                    errorProvider.SetError(txtCompanyName, "Required");
                    errorProvider.SetError(txtPhoneNo, "Required");
                    errorProvider.SetError(txtAddress, "Required");
                }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery("SELECT * FROM BusinessInformation");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        try
                        {
                            clsUtility.ExecuteSQLQuery(" UPDATE BusinessInformation SET CompanyName='" + txtCompanyName.Text + "' ,LegalName='" + txtLegalName.Text + "' ,Address='" + txtAddress.Text + "' ," +
                                                       " PhoneNo='" + txtPhoneNo.Text + "', Email='" + txtEmail.Text + "', WebSite='" + txtWebSite.Text + "', Slogan= '" + txtSlogan.Text + "'  ");                       
                            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName.ToString()))
                            {
                                UploadBrandLogo();
                            }
                            clsUtility.MesgBoxShow("msgUpdate", "info");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
                    }
                    else
                    {
                        try
                        {
                            clsUtility.ExecuteSQLQuery(" INSERT INTO BusinessInformation (CompanyName ,LegalName ,Address ,PhoneNo ,Email ,WebSite ,Slogan) VALUES  " +
                                                       " ( '" + txtCompanyName.Text + "', '" + txtLegalName.Text + "', '" + txtAddress.Text + "', '" + txtPhoneNo.Text + "', '" + txtEmail.Text + "', '" + txtWebSite.Text + "', '" + txtSlogan.Text + "' ) ");
                            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName.ToString()))
                            {
                                UploadBrandLogo();
                            }
                            clsUtility.MesgBoxShow("msgSaved", "info");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
                    }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void UploadBrandLogo()
        {
            string DestPath = Application.StartupPath + @"\Upload\Company\";
            if (!Directory.Exists(DestPath)) { Directory.CreateDirectory(DestPath); }
            System.IO.File.Delete(DestPath + @"\" + "BrandLogo.jpg");
            string ImageFileName = DestPath + @"\" + openFileDialog.SafeFileName;
            pictureBox1.Image.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);
            System.IO.File.Move(DestPath + @"\" + openFileDialog.SafeFileName, DestPath + @"\" + "BrandLogo.jpg");
        }

        private void btnBrowosePhoto_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Browse logo";
            openFileDialog.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }
    }
}
