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
    public partial class frmEmployeePayment : Form
    {
        public frmEmployeePayment()
        {
            InitializeComponent();
        }

        private void frmEmployeePayment_Load(object sender, EventArgs e)
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
                        XmlNode l1113 = languageNode["l1113"];
                        lbl1113.Text = l1113.InnerText;

                        XmlNode l1114 = languageNode["l1114"];
                        lbl1114.Text = l1114.InnerText;

                        XmlNode l1104 = languageNode["l1104"];
                        lbl1104.Text = l1104.InnerText;

                        XmlNode l1115 = languageNode["l1115"];
                        lbl1115.Text = l1115.InnerText;


                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1005.Text = l1005.InnerText;

                        XmlNode l1116 = languageNode["l1116"];
                        lbl1116.Text = l1116.InnerText;

                        XmlNode l1065 = languageNode["l1065"];
                        lbl1065.Text = l1065.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

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

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        dataGridView1.Columns["Column2"].HeaderText = l1104.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1005.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1065.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1115.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1116.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            clsUtility.FillComboBox(" SELECT  EMP_ID, EmployeeName  FROM  Employee  ORDER BY EmployeeName", "EMP_ID", "EmployeeName", cmbEmployee);
            clsUtility.FillDataGrid(" SELECT EMP_PAY_ID, EmployeeName, PhoneNo,PaidDate,Description,PaidAmount  FROM EmployeePayment " +
                                    " LEFT OUTER JOIN Employee ON (Employee.EMP_ID = EmployeePayment.EMP_ID) ", dataGridView1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtPaymentID.Text = "";
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
            txtPaidAmount.Text = "";
            dtpPaidDate.Value = DateTime.Today;
            txtDescription.Text = "";
            cmbEmployee.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
        }

        private void cmbEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cmbEmployee.SelectedValue == null) | !(cmbEmployee.SelectedIndex == -1))
            {
                clsUtility.ExecuteSQLQuery("SELECT * FROM Employee  WHERE  EMP_ID= '" + cmbEmployee.SelectedValue.ToString() + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtAddress.Text = clsUtility.sqlDT.Rows[0]["Address"].ToString();
                    txtPhoneNo.Text = clsUtility.sqlDT.Rows[0]["PhoneNo"].ToString();
                }
            }
            else { txtAddress.Text = ""; txtPhoneNo.Text = ""; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (cmbEmployee.SelectedValue == null | cmbEmployee.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtPaidAmount.Text))
                { errorProvider.SetError(txtPaidAmount, "Required"); }
                else if (!int.TryParse(txtPaidAmount.Text, out parsedValue))
                { errorProvider.SetError(txtPaidAmount, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO EmployeePayment (EMP_ID, PaidDate,Description,PaidAmount) VALUES ('" + cmbEmployee.SelectedValue.ToString() + "', '" + dtpPaidDate.Value.Date.ToString("yyyy-MM-dd") + "' ,'" + txtDescription.Text + "' , '" + clsUtility.num_repl(txtPaidAmount.Text) + "') ");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
            clsUtility.FillDataGrid(" SELECT EMP_PAY_ID, EmployeeName, PhoneNo,PaidDate,Description,PaidAmount  FROM EmployeePayment " +
                                    " LEFT OUTER JOIN Employee ON (Employee.EMP_ID = EmployeePayment.EMP_ID) " +
                                    " WHERE        (EmployeePayment.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND EmployeePayment.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", dataGridView1);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtPaymentID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  EmployeePayment  WHERE   (EMP_PAY_ID = '" + txtPaymentID.Text + "') ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    dtpPaidDate.Text = clsUtility.sqlDT.Rows[0]["PaidDate"].ToString();
                    txtDescription.Text = clsUtility.sqlDT.Rows[0]["Description"].ToString();
                    txtPaidAmount.Text = clsUtility.sqlDT.Rows[0]["PaidAmount"].ToString();
                    cmbEmployee.SelectedValue = clsUtility.sqlDT.Rows[0]["EMP_ID"].ToString();
                }
                btnSubmit.Enabled = false;
                btnDelete.Enabled = true;
                btnAlter.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (cmbEmployee.SelectedValue == null | cmbEmployee.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtPaidAmount.Text))
                { errorProvider.SetError(txtPaidAmount, "Required"); }
                else if (!int.TryParse(txtPaidAmount.Text, out parsedValue))
                { errorProvider.SetError(txtPaidAmount, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE  EmployeePayment SET  EMP_ID='" + cmbEmployee.SelectedValue.ToString() + "', PaidDate='" + dtpPaidDate.Value.Date.ToString("yyyy-MM-dd") + "',Description='" + txtDescription.Text + "',PaidAmount='" + clsUtility.num_repl(txtPaidAmount.Text) + "'  WHERE   (EMP_PAY_ID = '" + txtPaymentID.Text + "')  ");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtPaymentID.Text))
                { errorProvider.SetError(txtPaymentID, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  EmployeePayment  WHERE  EMP_PAY_ID ='" + txtPaymentID.Text + "'  ");
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

    }
}
