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
    public partial class frmSalesReturn : Form
    {
        public frmSalesReturn()
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
                        XmlNode l1089 = languageNode["l1089"];
                        lbl1089.Text = l1089.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        lbl1067.Text = l1067.InnerText;

                        XmlNode l1090 = languageNode["l1090"];
                        lbl1090.Text = l1090.InnerText;

                        XmlNode l1091 = languageNode["l1091"];
                        lbl1091.Text = l1091.InnerText;

                        XmlNode l1071 = languageNode["l1071"];
                        lbl1071.Text = l1071.InnerText;

                        XmlNode l1073 = languageNode["l1073"];
                        lbl1073.Text = l1073.InnerText;

                        XmlNode l1074 = languageNode["l1074"];
                        lbl1074.Text = l1074.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlPrint = languageNode["ctrlPrint"];
                        btnPrintPreview.Text = ctrlPrint.InnerText;

                        XmlNode ctrlRefund = languageNode["ctrlRefund"];
                        txtRefund.Text = ctrlRefund.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        XmlNode l1053 = languageNode["l1053"];
                        XmlNode l1183 = languageNode["l1183"];
                        XmlNode l1069 = languageNode["l1069"];
                        XmlNode l1046 = languageNode["l1046"];

                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1183.InnerText;
                        dataGridView1.Columns["Column11"].HeaderText = l1071.InnerText;
                        dataGridView1.Columns["Column10"].HeaderText = l1069.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1046.InnerText;

                        dataGridView2.Columns["dataGridViewTextBoxColumn2"].HeaderText = l1030.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn3"].HeaderText = l1053.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn5"].HeaderText = l1183.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn6"].HeaderText = l1071.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn7"].HeaderText = l1069.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn8"].HeaderText = l1046.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            pnlQty.Visible = false;
            LoadLanguegePack();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.InvoiceNo.Text))
            { errorProvider.SetError(InvoiceNo, "Required"); }
            else {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesInfo WHERE SALES_ID='"+ InvoiceNo.Text +"' ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    txtBillNO.Text = clsUtility.sqlDT.Rows[0]["SALES_ID"].ToString();
                    dtpSalesDate.Text = clsUtility.sqlDT.Rows[0]["SalesDate"].ToString();
                    txtInvoiceType.Text = clsUtility.sqlDT.Rows[0]["Terminal"].ToString();
                    txtUserName.Text = clsUtility.sqlDT.Rows[0]["EntreBy"].ToString();
                    LoadSalesItem(txtBillNO.Text);
                }
                else
                {
                    LoadSalesItem("0");
                    txtBillNO.Text = "";
                    dtpSalesDate.Value = DateTime.Today;
                    txtInvoiceType.Text = "";
                    txtUserName.Text = "";
                    txtCard.Text = "";
                    txtCash.Text = "";
                    txtTotal.Text = "";
                    clsUtility.MesgBoxShow("msgNotFound", "info");
                }
            }
        }

        private void LoadSalesItem(string SALES_ID)
        {
            clsUtility.FillDataGrid(" SELECT ID, ItemName, QTY, UnitOfMeasure, Sales.Price, TotalPrice, TotalVat, ExprDate " +
                                     " FROM Sales LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID WHERE Sales.SALES_ID = '" + SALES_ID + "' ", dataGridView1);
            clsUtility.FillDataGrid(" SELECT  ItemName, QTY, UnitOfMeasure, SalesReturn.Price,  SalesReturn.TotalPrice, TotalVat, ExprDate " +
                                    " FROM  SalesReturn  LEFT JOIN ItemInformation ON SalesReturn.ITEM_ID = ItemInformation.ITEM_ID WHERE  (SalesReturn.SALES_ID = '" + SALES_ID + "') ", dataGridView2);

            clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesRetrnInfo   WHERE (SALES_ID = '" + SALES_ID + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                txtCard.Text = clsUtility.sqlDT.Rows[0]["CardPay"].ToString();
                txtCash.Text = clsUtility.sqlDT.Rows[0]["CashPay"].ToString();
                txtTotal.Text = clsUtility.sqlDT.Rows[0]["Total"].ToString();
            }
            else { txtCard.Text = "0"; txtCash.Text = "0"; txtTotal.Text = "0"; }

            clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesReturn   WHERE (SALES_ID = '" + SALES_ID + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                clsUtility.ExecuteSQLQuery(" SELECT SUM( TotalPrice + TotalVat) AS Expr1  FROM SalesReturn   WHERE (SALES_ID = '" + SALES_ID + "') ");
                txtTotal.Text = Math.Round(Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Expr1"]), 2).ToString();
            }
            else { txtTotal.Text = "0"; }
        }


        private void ReturnSalesItem(string DATA_ROW_ID, double QTY)
        {

            clsUtility.ExecuteSQLQuery(" SELECT * FROM Sales  WHERE ID = '" + DATA_ROW_ID + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                double ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                double Cost = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Cost"]);
                double Price = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Price"]);
                double Vat = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Vat"]);
                string ExprDate = clsUtility.sqlDT.Rows[0]["ExprDate"].ToString();

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM   ItemInformation  WHERE  ITEM_ID = '" + ITEM_ID + "' ");
                double WarehouseID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["WarehouseID"]);

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM  Sales  WHERE ID = '" + DATA_ROW_ID + "' AND ITEM_ID = '" + ITEM_ID + "' AND QTY = '" + QTY + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM Sales WHERE ID =  '" + DATA_ROW_ID + "' ");
                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }
                else
                {
                    clsUtility.ExecuteSQLQuery(" UPDATE  Sales SET QTY = QTY - '" + QTY + "' ,TotalPrice= TotalPrice -'" + QTY * Price + "' ,TotalCost= TotalCost -'" + QTY * Cost + "', TotalVat= TotalVat - '" + QTY * Vat + "' " +
                                               " WHERE ID = '" + DATA_ROW_ID + "' ");

                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM  SalesReturn  WHERE (SALES_ID = '" + txtBillNO.Text + "') AND (ITEM_ID = '" + ITEM_ID + "')  ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    clsUtility.ExecuteSQLQuery(" UPDATE  SalesReturn SET QTY = QTY + '" + QTY + "' ,TotalPrice= TotalPrice +'" + QTY * Price + "' ,TotalCost= TotalCost +'" + QTY * Cost + "', TotalVat= TotalVat + '" + QTY * Vat + "' " +
                                                " WHERE ITEM_ID = '" + ITEM_ID + "' AND SALES_ID = '" + txtBillNO.Text + "' ");
                }
                else
                {
                    clsUtility.ExecuteSQLQuery(" INSERT INTO SalesReturn  (SALES_ID,  SalesReturn_Date,  ITEM_ID,  QTY,  Price,  TotalPrice,  Cost,  TotalCost,  Vat,  TotalVat,  ExprDate) VALUES  " +
                                               " ('" + txtBillNO.Text + "',  '" + DateTime.Now.ToString("yyyy-MM-dd") + "',  '" + ITEM_ID + "',  '" + QTY + "',  '" + Price + "',  '" + QTY * Price + "',  '" + Cost + "',  '" + QTY * Cost + "',  '" + Vat + "',  '" + QTY * Vat + "',  '" + ExprDate + "') ");
                }
                //End Sales Return
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlQty.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                txtRowID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtQty.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                pnlQty.Visible = true;
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (!int.TryParse(txtQty.Text, out parsedValue)) { errorProvider.SetError(txtQty, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    ReturnSalesItem(txtRowID.Text, Convert.ToDouble(txtQty.Text));
                    LoadSalesItem(txtBillNO.Text);
                    txtQty.Text = "";
                    txtRowID.Text = "";
                    pnlQty.Visible = false;
                    clsUtility.MesgBoxShow("msgSaved", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
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

        private void txtRefund_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtBillNO.Text) | string.IsNullOrWhiteSpace(this.txtCash.Text) | string.IsNullOrWhiteSpace(this.txtCard.Text))
                { errorProvider.SetError(InvoiceNo, "Required"); }
                else
                {
                    string CUST_ID;
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesInfo  WHERE (SALES_ID='" + txtBillNO.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0) { CUST_ID = clsUtility.sqlDT.Rows[0]["CUST_ID"].ToString(); } else { CUST_ID = "0"; }

                    clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesRetrnInfo  WHERE (SALES_ID='" + txtBillNO.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE SalesRetrnInfo SET   Total='" + txtTotal.Text + "', CUST_ID='" + CUST_ID + "' , CashPay='" + txtCash.Text + "',  CardPay='" + txtCard.Text + "'  WHERE (SALES_ID='" + txtBillNO.Text + "')");
                    }
                    else
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO SalesRetrnInfo ( SALES_ID,  SalesReturnDate, SalesReturnTime,  Total,  EntreBy,  CashPay,  CardPay, CUST_ID) VALUES ( '" + txtBillNO.Text + "',  '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "',  '" + txtTotal.Text + "',  '" + clsUtility.UserName + "',  '" + txtCard.Text + "',  '" + txtCard.Text + "', '" + CUST_ID + "') ");
                    }
                    clsUtility.MesgBoxShow("msgSaved", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtBillNO.Text))
                { errorProvider.SetError(InvoiceNo, "Required"); }
                else
                {
                    errorProvider.Clear();
                    frmSaleReturnReport frmSaleReturnReport = new frmSaleReturnReport(txtBillNO.Text);
                    frmSaleReturnReport.ShowDialog();
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
