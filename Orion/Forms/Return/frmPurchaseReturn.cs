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
    public partial class frmPurchaseReturn : Form
    {
        public frmPurchaseReturn()
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
                        XmlNode l1092 = languageNode["l1092"];
                        lbl1092.Text = l1092.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        lbl1067.Text = l1067.InnerText;

                        XmlNode l1093 = languageNode["l1093"];
                        lbl1093.Text = l1093.InnerText;

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

                        XmlNode ctrlCollect = languageNode["ctrlCollect"];
                        txtCollect.Text = ctrlCollect.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        XmlNode l1053 = languageNode["l1053"];
                        XmlNode l1183 = languageNode["l1183"];
                        XmlNode l1046 = languageNode["l1046"];
                        XmlNode l1042 = languageNode["l1042"];
                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1183.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1046.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1042.InnerText;

                        dataGridView2.Columns["dataGridViewTextBoxColumn2"].HeaderText = l1030.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn3"].HeaderText = l1053.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn5"].HeaderText = l1183.InnerText;
                        dataGridView2.Columns["dataGridViewTextBoxColumn7"].HeaderText = l1042.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmPurchaseReturn_Load(object sender, EventArgs e)
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

        private void ReturnPurchaseItem(string DATA_ROW_ID, double QTY) {
            clsUtility.ExecuteSQLQuery(" SELECT * FROM Purchase  WHERE ID = '" + DATA_ROW_ID + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                double ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                double Qty = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["QTY"]);
                double Price = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["TotalPrice"]);
                double WarehouseID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["WarehouseID"]);
                string ExprDate = clsUtility.sqlDT.Rows[0]["ExpDate"].ToString();

                double UnitPrice = Price / Qty;


                clsUtility.ExecuteSQLQuery(" SELECT *  FROM  Purchase  WHERE ID = '" + DATA_ROW_ID + "' AND ITEM_ID = '" + ITEM_ID + "' AND QTY = '" + QTY + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM Purchase WHERE ID =  '" + DATA_ROW_ID + "' ");
                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }
                else
                {
                    clsUtility.ExecuteSQLQuery(" UPDATE  Purchase SET QTY = QTY - '" + QTY + "' ,TotalPrice= TotalPrice -'" + UnitPrice * QTY + "'  " +
                                               " WHERE ID = '" + DATA_ROW_ID + "' ");
                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM  PurchaseReturn  WHERE (PUCHSE_ID = '" + txtBillNO.Text + "') AND (ITEM_ID = '" + ITEM_ID + "') AND WarehouseID = '" + WarehouseID + "'  ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.ExecuteSQLQuery(" UPDATE  PurchaseReturn SET QTY = QTY + '" + QTY + "' ,TotalPrice= TotalPrice +'" + UnitPrice * QTY + "'  " +
                                                " WHERE ITEM_ID = '" + ITEM_ID + "' AND PUCHSE_ID = '" + txtBillNO.Text + "' AND WarehouseID = '" + WarehouseID + "'  ");
                }
                else
                {
                    clsUtility.ExecuteSQLQuery(" INSERT INTO PurchaseReturn  (PUCHSE_ID,   ITEM_ID,  QTY,  TotalPrice,  WarehouseID) VALUES  " +
                                               " ('" + txtBillNO.Text + "',  '" + ITEM_ID + "',  '" + QTY + "',  '" + UnitPrice * QTY + "',  '" + WarehouseID + "') ");
                }
            }

            string SUPP_ID;
            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseInfo  WHERE (PUCHSE_ID='" + txtBillNO.Text + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0) { SUPP_ID = clsUtility.sqlDT.Rows[0]["SUPP_ID"].ToString(); } else { SUPP_ID = "0"; }
            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseReturnInfo  WHERE  (PUCHSE_ID='" + txtBillNO.Text + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0) {  }
            else
            {
                clsUtility.ExecuteSQLQuery(" INSERT INTO PurchaseReturnInfo ( PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  Total,  EntreBy,  CashPay,  CardPay, SUPP_ID) VALUES ( '" + txtBillNO.Text + "',  '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "',  0,  '" + clsUtility.UserName + "',  0,  0, '" + SUPP_ID + "') ");
            }

        }

        private void LoadPurchaseItem(string PUCHSE_ID) {
            clsUtility.FillDataGrid(" SELECT    ID, ItemName, QTY, UnitOfMeasure, TotalPrice, ExpDate, WarehouseName  FROM     Purchase LEFT OUTER JOIN " +
                                    " ItemInformation ON Purchase.ITEM_ID = ItemInformation.ITEM_ID LEFT OUTER JOIN    Warehouse ON Purchase.WarehouseID = Warehouse.WarehouseID  WHERE        (Purchase.PUCHSE_ID = '" + PUCHSE_ID + "') ", dataGridView1);

            clsUtility.FillDataGrid(" SELECT ItemName, QTY, UnitOfMeasure, TotalPrice, WarehouseName FROM  PurchaseReturn  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = PurchaseReturn.ITEM_ID " +
                                    "  INNER JOIN Warehouse ON Warehouse.WarehouseID = PurchaseReturn.WarehouseID WHERE  (PurchaseReturn.PUCHSE_ID = '" + PUCHSE_ID + "') ", dataGridView2);

            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseReturnInfo  WHERE (PUCHSE_ID = '" + PUCHSE_ID + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                txtCard.Text = clsUtility.sqlDT.Rows[0]["CardPay"].ToString();
                txtCash.Text = clsUtility.sqlDT.Rows[0]["CashPay"].ToString();
                txtTotal.Text = clsUtility.sqlDT.Rows[0]["Total"].ToString();
            }
            else { txtCard.Text = "0"; txtCash.Text = "0"; txtTotal.Text = "0"; }

            clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseReturn   WHERE (PUCHSE_ID = '" + PUCHSE_ID + "') ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                clsUtility.ExecuteSQLQuery(" SELECT SUM(TotalPrice) AS Expr1  FROM PurchaseReturn   WHERE (PUCHSE_ID = '" + PUCHSE_ID + "') ");
                txtTotal.Text = Math.Round(Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Expr1"]), 2).ToString();
            }
            else { txtTotal.Text = "0"; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.InvoiceNo.Text))
            { errorProvider.SetError(InvoiceNo, "Required"); }
            else
            {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseInfo WHERE PUCHSE_ID='" + InvoiceNo.Text + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtBillNO.Text = clsUtility.sqlDT.Rows[0]["PUCHSE_ID"].ToString();
                    dtpSalesDate.Text = clsUtility.sqlDT.Rows[0]["PurchaseDate"].ToString();
                    LoadPurchaseItem(txtBillNO.Text);
                }
                else
                {
                    LoadPurchaseItem("0");
                    txtBillNO.Text = "";
                    dtpSalesDate.Value = DateTime.Today;
                    txtCard.Text = "";
                    txtCash.Text = "";
                    txtTotal.Text = "";
                    clsUtility.MesgBoxShow("msgNotFound", "info");
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            pnlQty.Visible = false;
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

        private void txtCollect_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtBillNO.Text) | string.IsNullOrWhiteSpace(this.txtCash.Text) | string.IsNullOrWhiteSpace(this.txtCard.Text))
                { errorProvider.SetError(InvoiceNo, "Required"); }
                else
                {
                    errorProvider.Clear();

                    string SUPP_ID;
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseInfo  WHERE (PUCHSE_ID='" + txtBillNO.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0) { SUPP_ID = clsUtility.sqlDT.Rows[0]["SUPP_ID"].ToString(); } else { SUPP_ID = "0"; }


                    clsUtility.ExecuteSQLQuery(" SELECT * FROM PurchaseReturnInfo  WHERE  (PUCHSE_ID='" + txtBillNO.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE PurchaseReturnInfo SET   Total='" + txtTotal.Text + "', SUPP_ID= '" + SUPP_ID + "'  , CashPay='" + txtCash.Text + "',  CardPay='" + txtCard.Text + "'  WHERE (PUCHSE_ID='" + txtBillNO.Text + "')");
                    }
                    else
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO PurchaseReturnInfo ( PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  Total,  EntreBy,  CashPay,  CardPay, SUPP_ID) VALUES ( '" + txtBillNO.Text + "',  '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "',  '" + txtTotal.Text + "',  '" + clsUtility.UserName + "',  '" + txtCard.Text + "',  '" + txtCard.Text + "', '" + SUPP_ID + "') ");
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
                    ReturnPurchaseItem(txtRowID.Text, Convert.ToDouble(txtQty.Text));
                    LoadPurchaseItem(txtBillNO.Text);
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
                    frmPurchaseReturnReport frmPurchaseReturnReport = new frmPurchaseReturnReport(txtBillNO.Text);
                    frmPurchaseReturnReport.ShowDialog();
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
