using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{

    public partial class frmSupplierInfo : Form
    {
        string fileExtension = ".jpg";
        public frmSupplierInfo()
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
                        XmlNode l1016 = languageNode["l1016"];
                        lbl1016.Text = l1016.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1017 = languageNode["l1017"];
                        lbl1017.Text = l1017.InnerText;

                        XmlNode l1018 = languageNode["l1018"];
                        lbl1018.Text = l1018.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1018.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1012.Text = l1004.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1013.Text = l1005.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1005.InnerText;

                        XmlNode l1015 = languageNode["l1015"];
                        lbl1015.Text = l1015.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1015.InnerText;

                        XmlNode l1014 = languageNode["l1014"];
                        lbl1014.Text = l1014.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1014.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        dataGridView1.Columns["Column1"].HeaderText = l1182.InnerText;

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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmSupplierInfo_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnReset.PerformClick();
            LoadLanguegePack();
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

        private void LoadData()
        {
            clsUtility.FillDataGrid(" SELECT  * FROM Supplier ", dataGridView1);
        }

        private void UploadImage(string SUPP_ID)
        {
            string DestPath = Application.StartupPath + @"\Upload\Supplier\";
            if (!Directory.Exists(DestPath)) { Directory.CreateDirectory(DestPath); }
            System.IO.File.Delete(DestPath + @"\" + SUPP_ID + fileExtension);
            string ImageFileName = DestPath + @"\" + openFileDialog.SafeFileName;
            pictureBox1.Image.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);
            System.IO.File.Move(DestPath + @"\" + openFileDialog.SafeFileName, DestPath + @"\" + SUPP_ID + fileExtension);
            clsUtility.ExecuteSQLQuery("UPDATE Supplier SET PhotoFileName= '" + SUPP_ID + fileExtension + "' WHERE SUPP_ID ='" + SUPP_ID + "' ");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtSuppID.Text = "";
            txtSupplierName.Text = "";
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
                if (string.IsNullOrWhiteSpace(this.txtSupplierName.Text))
                { errorProvider.SetError(txtSupplierName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    string SUPP_ID = null;
                    clsUtility.ExecuteSQLQuery(" INSERT INTO Supplier (SupplierName,Address,PhoneNo,OpeningDate,Balance) VALUES " +
                                               " ('" + txtSupplierName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "','" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "','" + clsUtility.num_repl(txtBalance.Text) + "') ");
                    clsUtility.ExecuteSQLQuery("SELECT  SUPP_ID   FROM   Supplier  ORDER BY SUPP_ID DESC");
                    SUPP_ID = clsUtility.sqlDT.Rows[0]["SUPP_ID"].ToString();

                    UploadImage(SUPP_ID.ToString());
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSuppID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtSupplierName.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            txtPhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            txtBalance.Text = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            dtpOpeningDate.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            try
            {
                pictureBox1.ImageLocation = Application.StartupPath + @"\Upload\Supplier\" + dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
                pictureBox1.InitialImage.Dispose();
                fileExtension = Path.GetExtension(dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString());
            }
            catch (Exception) { pictureBox1.Image = Orion.Properties.Resources.No_image_found; }
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
            txtSupplierName.Select();
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtSuppID.Text) | string.IsNullOrWhiteSpace(this.txtSupplierName.Text))
                { errorProvider.SetError(txtSupplierName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" UPDATE Supplier SET  SupplierName='" + txtSupplierName.Text + "',Address='" + txtAddress.Text + "',PhoneNo='" + txtPhoneNo.Text + "',OpeningDate='" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "',Balance= '" + clsUtility.num_repl(txtBalance.Text) + "' " +
                                               " WHERE SUPP_ID ='" + txtSuppID.Text + "'  ");
                    UploadImage(txtSuppID.Text);
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
                if (string.IsNullOrWhiteSpace(this.txtSuppID.Text) | string.IsNullOrWhiteSpace(this.txtSupplierName.Text))
                { errorProvider.SetError(txtSupplierName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Supplier  WHERE SUPP_ID ='" + txtSuppID.Text + "'  ");
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
                    clsUtility.FillDataGrid(" SELECT  * FROM Supplier WHERE   (" + cmbParameter.Text + " LIKE '%" + txtCriteria.Text + "%') ORDER BY SupplierName ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
    }
}
