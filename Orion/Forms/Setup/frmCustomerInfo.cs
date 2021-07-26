using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmCustomerInfo : Form
    {
        string fileExtension = ".jpg";
        public frmCustomerInfo()
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
                        XmlNode l1009 = languageNode["l1009"];
                        lbl1009.Text = l1009.InnerText;

                        XmlNode l1010 = languageNode["l1010"];
                        lbl1010.Text = l1010.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1011 = languageNode["l1011"];
                        lbl1011.Text = l1011.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1012.Text = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1013.Text = l1005.InnerText;

                        XmlNode l1015 = languageNode["l1015"];
                        lbl1015.Text = l1015.InnerText;

                        XmlNode l1014 = languageNode["l1014"];
                        lbl1014.Text = l1014.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlAlter = languageNode["ctrlAlter"];
                        btnAlter.Text = ctrlAlter.InnerText;

                        XmlNode ctrlDelete = languageNode["ctrlDelete"];
                        btnDelete.Text = ctrlDelete.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode ctrlBrowsePhoto = languageNode["ctrlBrowsePhoto"];
                        btnBrowosePhoto.Text = ctrlBrowsePhoto.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        dataGridView1.Columns["Column1"].HeaderText = l1182.InnerText;

                        dataGridView1.Columns["Column2"].HeaderText = l1011.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1004.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1005.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1015.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1014.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCustomerInfo_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            clsUtility.FillDataGrid(" SELECT  * FROM Customer ", dataGridView1);
        }

        private void UploadImage(string CUST_ID)
        {
            string DestPath = Application.StartupPath + @"\Upload\Customer\";
            if (!Directory.Exists(DestPath)) { Directory.CreateDirectory(DestPath); }
            System.IO.File.Delete(DestPath + @"\" + CUST_ID + fileExtension);
            string ImageFileName = DestPath + @"\" + openFileDialog.SafeFileName;
            pictureBox1.Image.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);
            System.IO.File.Move(DestPath + @"\" + openFileDialog.SafeFileName, DestPath + @"\" + CUST_ID + fileExtension);
            clsUtility.ExecuteSQLQuery("UPDATE Customer SET PhotoFileName= '" + CUST_ID + fileExtension + "' WHERE CUST_ID ='" + CUST_ID + "' ");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtCustID.Text = "";
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
            txtBalance.Text = "";
            txtCriteria.Text = "";
            dtpOpeningDate.Value = DateTime.Today;
            pictureBox1.Image = Orion.Properties.Resources.No_image_found;
            LoadData();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtCustomerName.Text))
                { errorProvider.SetError(txtCustomerName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    string CUST_ID = null;
                    clsUtility.ExecuteSQLQuery(" INSERT INTO Customer (CustomerName,Address,PhoneNo,OpeningDate,Balance) VALUES " +
                                               " ('" + txtCustomerName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "','" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "','" + clsUtility.num_repl(txtBalance.Text) + "') ");
                    clsUtility.ExecuteSQLQuery("SELECT  CUST_ID   FROM   Customer  ORDER BY CUST_ID DESC");
                    CUST_ID = clsUtility.sqlDT.Rows[0]["CUST_ID"].ToString();
                    UploadImage(CUST_ID.ToString());
                    btnReset.PerformClick();
                    clsUtility.MesgBoxShow("msgSaved", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnBrowosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Browse image";
            OpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = OpenFileDialog.FileName;
                fileExtension = Path.GetExtension(OpenFileDialog.FileName);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtCustomerName.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            txtPhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            txtBalance.Text = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            dtpOpeningDate.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            try {
                pictureBox1.ImageLocation = Application.StartupPath + @"\Upload\Customer\" + dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString() ;
                pictureBox1.InitialImage.Dispose();
                fileExtension = Path.GetExtension(dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString());
            }
            catch (Exception) { pictureBox1.Image = Orion.Properties.Resources.No_image_found; }
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtCustID.Text) | string.IsNullOrWhiteSpace(this.txtCustomerName.Text))
                { errorProvider.SetError(txtCustomerName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" UPDATE Customer SET  CustomerName='" + txtCustomerName.Text + "',Address='" + txtAddress.Text + "',PhoneNo='" + txtPhoneNo.Text + "',OpeningDate='" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "',Balance= '" + clsUtility.num_repl(txtBalance.Text) + "' " +
                                               " WHERE CUST_ID ='" + txtCustID.Text + "'  ");
                    UploadImage(txtCustID.Text);
                    btnReset.PerformClick();
                    clsUtility.MesgBoxShow("msgUpdate", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtCustID.Text) | string.IsNullOrWhiteSpace(this.txtCustomerName.Text))
                { errorProvider.SetError(txtCustomerName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Customer  WHERE CUST_ID ='" + txtCustID.Text + "'  ");
                    btnReset.PerformClick();
                    clsUtility.MesgBoxShow("msgDelete", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.cmbParameter.Text))
            {
                errorProvider.SetError(cmbParameter, "Required");
                LoadData();
            }
            else if (string.IsNullOrWhiteSpace(this.txtCriteria.Text))
            {
                errorProvider.SetError(txtCriteria, "Required");
                LoadData();
            }
            else
            {
                try
                {
                    errorProvider.Clear();
                    clsUtility.FillDataGrid(" SELECT  * FROM Customer WHERE   (" + cmbParameter.Text + " LIKE '%" + txtCriteria.Text + "%') ORDER BY CustomerName ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

  
    }
}
