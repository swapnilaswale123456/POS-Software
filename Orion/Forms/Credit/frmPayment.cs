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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
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
                        XmlNode l1098 = languageNode["l1098"];
                        lbl1098.Text = l1098.InnerText;

                        XmlNode l1099 = languageNode["l1099"];
                        lbl1099.Text = l1099.InnerText;

                        XmlNode l1100 = languageNode["l1100"];
                        lbl1100.Text = l1100.InnerText;

                        XmlNode l1071 = languageNode["l1071"];
                        lbl1071.Text = l1071.InnerText;

                        XmlNode l1101 = languageNode["l1101"];
                        lbl1101.Text = l1101.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;

                        XmlNode l1073 = languageNode["l1073"];
                        lbl1073.Text = l1073.InnerText;
                        lbl1073_2.Text = l1073.InnerText;

                        XmlNode l1074 = languageNode["l1074"];
                        lbl1074.Text = l1074.InnerText;
                        lbl1074_2.Text = l1074.InnerText;

                        XmlNode l1095 = languageNode["l1095"];
                        lbl1095.Text = l1095.InnerText;

                        XmlNode l1018 = languageNode["l1018"];
                        lbl1018.Text = l1018.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlDelete = languageNode["ctrlDelete"];
                        btnDelete.Text = ctrlDelete.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;
                        btnSrcCollection.Text = ctrlSearch.InnerText;


                        XmlNode l1182 = languageNode["l1182"];
                        XmlNode l1188 = languageNode["l1188"];
                        XmlNode l1097 = languageNode["l1097"];

                        dataGridView1.Columns["Column1"].HeaderText = l1182.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1101.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1188.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1018.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1100.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1097.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1073.InnerText;
                        dataGridView1.Columns["Column8"].HeaderText = l1074.InnerText;
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

        private void btnSrcCollection_Click(object sender, EventArgs e)
        {
            clsUtility.FillDataGrid(" SELECT PAYM_ID, PUCHSE_ID, Payment.SUPP_ID, SupplierName, EntryDate, EnteredBy, Cash, Card FROM Payment  LEFT JOIN Supplier ON Supplier.SUPP_ID = Payment.SUPP_ID " +
                        " WHERE  Payment.EntryDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND Payment.EntryDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", dataGridView1);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            txtInvoiceNo.Text = "";
            txtSalesDate.Text = "";
            txtBillCash.Text = "";
            txtBillCard.Text = "";
            txtBillTotal.Text = "";
            if (string.IsNullOrWhiteSpace(this.txtCustID.Text)) { errorProvider.SetError(txtCustID, "Required"); }
            else
            {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM Supplier  WHERE SUPP_ID='" + txtCustID.Text + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    double Opening_Balance = 0;
                    txtCustomerName.Text = clsUtility.sqlDT.Rows[0]["SupplierName"].ToString(); 
                    txtAddress.Text = clsUtility.sqlDT.Rows[0]["Address"].ToString();
                    Opening_Balance = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Balance"]);
                    GetBill(txtCustID.Text);
                    txtDue.Text = Math.Round((Convert.ToDouble(txtDue.Text) + Opening_Balance), 2).ToString();
                }
                else { clsUtility.MesgBoxShow("msgNotFound", "info"); }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnSrcCollection.PerformClick();
            txtInvoiceNo.Text = "";
            txtSalesDate.Text = "";
            txtBillCash.Text = "";
            txtBillCard.Text = "";
            txtDue.Text = "";
            txtCustomerName.Text = "";
            txtCustID.Text = "";
            txtColID.Text = "";
            txtAddress.Text = "";
            txtCash.Text = "";
            txtCard.Text = "";
            txtBillTotal.Text = "";
            dtpEntryDate.Value = DateTime.Today;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
        }

        private void txtCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtInvoiceNo.Text))
            {
                errorProvider.SetError(txtInvoiceNo, "Required");
            }
            else
            {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseInfo WHERE PUCHSE_ID='" + txtInvoiceNo.Text + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtSalesDate.Text = clsUtility.sqlDT.Rows[0]["PurchaseDate"].ToString();
                    txtBillTotal.Text = clsUtility.sqlDT.Rows[0]["GrandTotal"].ToString();
                    txtBillCash.Text = clsUtility.sqlDT.Rows[0]["CashPay"].ToString();
                    txtBillCard.Text = clsUtility.sqlDT.Rows[0]["CardPay"].ToString();
                    txtCustID.Text = clsUtility.sqlDT.Rows[0]["SUPP_ID"].ToString();

                    //Get Customer name
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Supplier  WHERE SUPP_ID='" + txtCustID.Text + "' ");
                    if (clsUtility.sqlDT.Rows.Count > 0) { txtCustomerName.Text = clsUtility.sqlDT.Rows[0]["SupplierName"].ToString(); txtAddress.Text = clsUtility.sqlDT.Rows[0]["Address"].ToString(); }

                    GetBill(txtCustID.Text);
                }
                else { 
                    btnReset.PerformClick();
                    clsUtility.MesgBoxShow("msgNotFound", "info");
                }
            }
        }


        public void GetBill(string CUST_ID)
        {
            double MyPayment, PurchaseDue, RetrnBill;
            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseInfo  WHERE SUPP_ID='" + txtCustID.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                clsUtility.ExecuteSQLQuery("SELECT Sum(GrandTotal - CashPay + CardPay ) AS PurchaseDue  FROM  PurchaseInfo WHERE   (SUPP_ID = '" + txtCustID.Text + "') ");
                PurchaseDue = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["PurchaseDue"]);
            }
            else
            {
                PurchaseDue = 0;
            }

            clsUtility.ExecuteSQLQuery(" SELECT * FROM Payment  WHERE SUPP_ID='" + txtCustID.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                clsUtility.ExecuteSQLQuery("SELECT  Sum(Cash + Card) AS MyPayment  FROM  Payment WHERE   (SUPP_ID = '" + txtCustID.Text + "') ");
                MyPayment = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["MyPayment"]);
            }
            else
            {
                MyPayment = 0;
            }

            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseReturnInfo  WHERE SUPP_ID='" + txtCustID.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                clsUtility.ExecuteSQLQuery("SELECT  Sum(CashPay + CardPay) AS RetrnBill  FROM  PurchaseReturnInfo WHERE   (SUPP_ID = '" + txtCustID.Text + "') ");
                RetrnBill = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["RetrnBill"]);
            }
            else
            {
                RetrnBill = 0;
            }

            txtDue.Text = Math.Round((PurchaseDue - MyPayment - RetrnBill), 2).ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" INSERT INTO Payment (PUCHSE_ID,  SUPP_ID,  EntryDate,  EnteredBy,  Cash, Card) VALUES ('" + clsUtility.num_repl(txtInvoiceNo.Text) + "',  '" + clsUtility.num_repl(txtCustID.Text) + "',  '" + dtpEntryDate.Value.Date.ToString("yyyy-MM-dd") + "',  '" + clsUtility.UserName + "',  '" + clsUtility.num_repl(txtCash.Text) + "', '" + clsUtility.num_repl(txtCard.Text) + "') ");
                btnReset.PerformClick();
                clsUtility.MesgBoxShow("msgSaved", "info");
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtCustID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            btnFindCustomer.PerformClick();
            dtpEntryDate.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            txtCash.Text = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            txtCard.Text = dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtColID.Text)) { errorProvider.SetError(txtColID, "Required"); }
                else
                {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM Payment WHERE (PAYM_ID='" + txtColID.Text + "') ");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSrcCollection.PerformClick();
        }


    }
}
