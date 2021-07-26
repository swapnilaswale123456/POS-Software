using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orion
{
    public partial class frmEmployee : Form
    {
        string fileExtension = ".jpg";

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
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
                        XmlNode l1102 = languageNode["l1102"];
                        lbl1102.Text = l1102.InnerText;

                        XmlNode l1103 = languageNode["l1103"];
                        lbl1103.Text = l1103.InnerText;

                        XmlNode l1104 = languageNode["l1104"];
                        lbl1104.Text = l1104.InnerText;

                        XmlNode l1105 = languageNode["l1105"];
                        lbl1105.Text = l1105.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1005.Text = l1005.InnerText;

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
                        dataGridView1.Columns["Column2"].HeaderText = l1104.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1105.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1004.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1005.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1014.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1015.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadImage(string EMP_ID)
        {
            string DestPath = Application.StartupPath + @"\Upload\Employee\";
            if (!Directory.Exists(DestPath)) { Directory.CreateDirectory(DestPath); }
            System.IO.File.Delete(DestPath + @"\" + EMP_ID + fileExtension);
            string ImageFileName = DestPath + @"\" + openFileDialog.SafeFileName;
            pictureBox1.Image.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);
            System.IO.File.Move(DestPath + @"\" + openFileDialog.SafeFileName, DestPath + @"\" + EMP_ID + fileExtension);
            clsUtility.ExecuteSQLQuery("UPDATE Employee SET PhotoFileName= '" + EMP_ID + fileExtension + "' WHERE EMP_ID ='" + EMP_ID + "' ");
        }

        private void LoadData()
        {
            clsUtility.FillDataGrid(" SELECT  EMP_ID,EmployeeName,Designation,Address,PhoneNo,OpeningDate,Balance, PhotoFileName FROM Employee ", dataGridView1);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtEmployeeName.Text) | string.IsNullOrWhiteSpace(this.txtDesignation.Text))
                { errorProvider.SetError(txtEmployeeName, "Required"); errorProvider.SetError(txtDesignation, "Required"); }
                else
                {
                    try
                    {
                        errorProvider.Clear();
                        string EMP_ID = null;
                        clsUtility.ExecuteSQLQuery(" INSERT INTO Employee(EmployeeName,Designation,Address,PhoneNo,OpeningDate,Balance) VALUES " +
                                                   " ('" + txtEmployeeName.Text + "','" + txtDesignation.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "','" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "','" + clsUtility.num_repl(txtBalance.Text) + "') ");
                        clsUtility.ExecuteSQLQuery("SELECT  EMP_ID   FROM   Employee  ORDER BY EMP_ID DESC");
                        EMP_ID = clsUtility.sqlDT.Rows[0]["EMP_ID"].ToString();
                        UploadImage(EMP_ID);
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgSaved", "info");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtEmployeeName.Text = "";
            txtDesignation.Text = "";
            txtAddress.Text = "";
            txtEmpID.Text = "";
            txtPhoneNo.Text = "";
            txtBalance.Text = "";
            txtCriteria.Text = "";
            dtpOpeningDate.Value = DateTime.Today;
            fileExtension = ".png";
            pictureBox1.Image = Orion.Properties.Resources.No_image_found;
            LoadData();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtEmpID.Text) | string.IsNullOrWhiteSpace(this.txtEmployeeName.Text))
                { errorProvider.SetError(txtEmployeeName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Employee  WHERE EMP_ID ='" + txtEmpID.Text + "'  ");
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

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtEmployeeName.Text) | string.IsNullOrWhiteSpace(this.txtDesignation.Text))
                { errorProvider.SetError(txtEmployeeName, "Required"); errorProvider.SetError(txtDesignation, "Required"); }
                else
                {
                    try
                    {
                        errorProvider.Clear();
                        clsUtility.ExecuteSQLQuery(" UPDATE  Employee SET  EmployeeName='" + txtEmployeeName.Text + "',Designation='" + txtDesignation.Text + "',Address='" + txtAddress.Text + "',PhoneNo='" + txtPhoneNo.Text + "',OpeningDate='" + dtpOpeningDate.Value.Date.ToString("yyyy-MM-dd") + "',Balance='" + clsUtility.num_repl(txtBalance.Text) + "'  " +
                                                   " WHERE EMP_ID ='" + txtEmpID.Text + "'  ");
                        UploadImage(txtEmpID.Text);
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgUpdate", "info");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            txtDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            txtPhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            dtpOpeningDate.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            txtBalance.Text = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            try
            {
                pictureBox1.ImageLocation = Application.StartupPath + @"\Upload\Employee\" + dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
                pictureBox1.InitialImage.Dispose();
                fileExtension = Path.GetExtension(dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString());
            }
            catch (Exception) { pictureBox1.Image = Orion.Properties.Resources.No_image_found; }
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
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
                    clsUtility.FillDataGrid(" SELECT  EMP_ID,EmployeeName,Designation,Address,PhoneNo,OpeningDate,Balance, PhotoFileName FROM Employee WHERE   (" + cmbParameter.Text + " LIKE '%" + txtCriteria.Text + "%') ORDER BY EmployeeName ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
    }
}
