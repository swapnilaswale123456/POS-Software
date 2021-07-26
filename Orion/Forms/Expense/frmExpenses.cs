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
    public partial class frmExpenses : Form
    {
        public frmExpenses()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            clsUtility.FillComboBox(" SELECT  EXP_AC_ID, ExpenditureAccount  FROM  ExpenditureAccount  ORDER BY ExpenditureAccount", "EXP_AC_ID", "ExpenditureAccount", cmbExpense);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        XmlNode l1116 = languageNode["l1116"];
                        lbl1116.Text = l1116.InnerText;

                        XmlNode l1073 = languageNode["l1073"];
                        lbl1073.Text = l1073.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode l1115 = languageNode["l1115"];
                        lbl1115.Text = l1115.InnerText;

                        XmlNode l1120 = languageNode["l1120"];
                        lbl1120.Text = l1120.InnerText;

                        XmlNode l1119 = languageNode["l1119"];
                        lbl1119.Text = l1119.InnerText;

                        XmlNode l1118 = languageNode["l1118"];
                        lbl1118.Text = l1118.InnerText;

                        XmlNode l1117 = languageNode["l1117"];
                        lbl1117.Text = l1117.InnerText;

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

                        XmlNode l1185 = languageNode["l1185"];
                        dataGridView1.Columns["Column1"].HeaderText = l1185.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1119.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1120.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1115.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1116.InnerText;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            btnSearch.PerformClick();
            txtDescription.Text = "";
            txtPaidAmount.Text = "";
            dtpPaidDate.Value = DateTime.Today;
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                clsUtility.FillDataGrid(" SELECT Expense_ID, ExpenditureAccount, PaidDate, Description, Amount  FROM  Expense " +
                                        " LEFT JOIN ExpenditureAccount ON Expense.EXP_AC_ID = ExpenditureAccount.EXP_AC_ID " +
                                        " WHERE        (Expense.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND Expense.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", dataGridView1);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (cmbExpense.SelectedValue == null | cmbExpense.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtPaidAmount.Text))
                { errorProvider.SetError(txtPaidAmount, "Required"); }
                else if (!int.TryParse(txtPaidAmount.Text, out parsedValue))
                { errorProvider.SetError(txtPaidAmount, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO Expense (EXP_AC_ID, PaidDate, Description,  Amount) VALUES ('" + cmbExpense.SelectedValue.ToString() + "', '" + dtpPaidDate.Value.Date.ToString("yyyy-MM-dd") + "' ,'" + txtDescription.Text + "' , '" + clsUtility.num_repl(txtPaidAmount.Text) + "') ");
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

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            frmExpenditureAccount frmExpenditureAccount = Application.OpenForms["frmExpenditureAccount"] as frmExpenditureAccount;
            if (frmExpenditureAccount != null)
            {
                frmExpenditureAccount.WindowState = FormWindowState.Normal;
                frmExpenditureAccount.BringToFront();
                frmExpenditureAccount.Activate();
            }
            else
            {
                frmExpenditureAccount = new frmExpenditureAccount();
                frmExpenditureAccount.MdiParent = this.ParentForm;
                frmExpenditureAccount.Dock = DockStyle.Fill;
                frmExpenditureAccount.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtExpenseID.Text))
                { errorProvider.SetError(txtExpenseID, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Expense  WHERE Expense_ID ='" + txtExpenseID.Text + "'  ");
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
                int parsedValue;
                if (cmbExpense.SelectedValue == null | cmbExpense.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtPaidAmount.Text))
                { errorProvider.SetError(txtPaidAmount, "Required"); }
                else if (!int.TryParse(txtPaidAmount.Text, out parsedValue))
                { errorProvider.SetError(txtPaidAmount, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE  Expense SET  EXP_AC_ID='" + cmbExpense.SelectedValue.ToString() + "', PaidDate='" + dtpPaidDate.Value.Date.ToString("yyyy-MM-dd") + "', Description='" + txtDescription.Text + "',  Amount= '" + clsUtility.num_repl(txtPaidAmount.Text) + "'  WHERE Expense_ID ='" + txtExpenseID.Text + "'   ");
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
            try
            {
                txtExpenseID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Expense  WHERE   (Expense_ID = '" + txtExpenseID.Text + "') ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    dtpPaidDate.Text = clsUtility.sqlDT.Rows[0]["PaidDate"].ToString();
                    txtDescription.Text = clsUtility.sqlDT.Rows[0]["Description"].ToString();
                    txtPaidAmount.Text = clsUtility.sqlDT.Rows[0]["Amount"].ToString();
                    cmbExpense.SelectedValue = clsUtility.sqlDT.Rows[0]["EXP_AC_ID"].ToString();
                }
                btnSubmit.Enabled = false;
                btnDelete.Enabled = true;
                btnAlter.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
