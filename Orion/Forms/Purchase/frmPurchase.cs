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
    public partial class frmPurchase : Form
    {
        public frmPurchase(string PUCHSE_ID)
        {
            InitializeComponent();
            txtInvoiceNo.Text = PUCHSE_ID;
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
                        XmlNode l1086 = languageNode["l1086"];
                        lbl1086.Text = l1086.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        lbl1067.Text = l1067.InnerText;

                        XmlNode l1065 = languageNode["l1065"];
                        lbl1065.Text = l1065.InnerText;

                        XmlNode l1040 = languageNode["l1040"];
                        lbl1040.Text = l1040.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        lbl1030.Text = l1030.InnerText;

                        XmlNode l1053 = languageNode["l1053"];
                        lbl1053.Text = l1053.InnerText;

                        XmlNode l1071 = languageNode["l1071"];
                        lbl1071.Text = l1071.InnerText;
                        lbl1071_2.Text = l1071.InnerText;

                        XmlNode l1046 = languageNode["l1046"];
                        chkExp.Text = l1046.InnerText;

                        XmlNode l1070 = languageNode["l1070"];
                        lbl1070.Text = l1070.InnerText;

                        XmlNode l1087 = languageNode["l1087"];
                        lbl1087.Text = l1087.InnerText;

                        XmlNode l1072 = languageNode["l1072"];
                        lbl1072.Text = l1072.InnerText;

                        XmlNode l1073 = languageNode["l1073"];
                        lbl1073.Text = l1073.InnerText;

                        XmlNode l1074 = languageNode["l1074"];
                        lbl1074.Text = l1074.InnerText;

                        XmlNode l1076 = languageNode["l1076"];
                        lbl1076.Text = l1076.InnerText;

                        XmlNode l1018 = languageNode["l1018"];
                        lbl1018.Text = l1018.InnerText;

                        XmlNode ctrlComplete = languageNode["ctrlComplete"];
                        btnComplete.Text = ctrlComplete.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlSaveOnly = languageNode["ctrlSaveOnly"];
                        btnSave.Text = ctrlSaveOnly.InnerText;

                        XmlNode ctrlDeleteAll = languageNode["ctrlDeleteAll"];
                        btnDeleteAll.Text = ctrlDeleteAll.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSave.Text = ctrlSave.InnerText;

                        XmlNode ctrlPrint = languageNode["ctrlPrint"];
                        btnReceipt.Text = ctrlPrint.InnerText;

                        XmlNode ctrlAdd = languageNode["ctrlAdd"];
                        btnAddItem.Text = ctrlAdd.InnerText;


                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1071.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1046.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1040.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();

            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            if (chkExp.Checked) { dtpExpDate.Enabled = true; } else { dtpExpDate.Enabled = false; }
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);
            clsUtility.FillComboBox(" SELECT  SUPP_ID, SupplierName  FROM  Supplier  ORDER BY SupplierName", "SUPP_ID", "SupplierName", cmbSupplier);
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbWarehouse);


            if (txtInvoiceNo.Text == "0")
            {
                clsUtility.ExecuteSQLQuery("SELECT  * FROM  PurchaseInfo WHERE  USER_ID = '" + clsUtility.UserID + "'  ORDER BY PUCHSE_ID DESC");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    string DEC_PUCHSE_ID = clsUtility.sqlDT.Rows[0]["PUCHSE_ID"].ToString();
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM   Purchase  WHERE PUCHSE_ID = '" + DEC_PUCHSE_ID + "' ");
                    if (clsUtility.sqlDT.Rows.Count > 0) { CreateNewInvoice(); LoadPurchaseItem(); } else { txtInvoiceNo.Text = DEC_PUCHSE_ID; }
                }
                else { CreateNewInvoice(); LoadPurchaseItem(); }
            }
            else { LoadPurchaseItem(); }


        }


        private void CreateNewInvoice()
        {
            clsUtility.ExecuteSQLQuery(" INSERT INTO PurchaseInfo( ItemPrice,Discount,GrandTotal, Due,SUPP_ID, PurchaseDate, CardPay, CashPay, USER_ID) " +
                                       " VALUES (0,0, 0, 0, 0 , '" + dtpPurchaseDate.Value.Date.ToString("yyyy-MM-dd") + "', 0, 0, '" + clsUtility.UserID + "') ");
            clsUtility.ExecuteSQLQuery("SELECT  PUCHSE_ID  FROM   PurchaseInfo    ORDER BY PUCHSE_ID DESC");
            txtInvoiceNo.Text = clsUtility.sqlDT.Rows[0]["PUCHSE_ID"].ToString();
        }


        private void LoadPurchaseItem() {
            clsUtility.FillDataGrid(" SELECT    ID, ItemName, QTY, UnitOfMeasure, TotalPrice, ExpDate, WarehouseName  FROM     Purchase LEFT OUTER JOIN " +
                                    " ItemInformation ON Purchase.ITEM_ID = ItemInformation.ITEM_ID LEFT OUTER JOIN    Warehouse ON Purchase.WarehouseID = Warehouse.WarehouseID  WHERE        (Purchase.PUCHSE_ID = '"+ txtInvoiceNo.Text +"') ", dataGridView1);

            clsUtility.ExecuteSQLQuery("SELECT  TotalPrice  FROM  Purchase    WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "')");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                clsUtility.ExecuteSQLQuery("SELECT  SUM(TotalPrice) AS Expr1  FROM  Purchase    WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "')");
                txtTotalAmount.Text = clsUtility.sqlDT.Rows[0]["Expr1"].ToString();
            } else { txtTotalAmount.Text = "0"; }

            clsUtility.ExecuteSQLQuery("SELECT *  FROM  PurchaseInfo    WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "')");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                txtDiscount.Text = clsUtility.sqlDT.Rows[0]["Discount"].ToString();
                txtGrandTotal.Text = clsUtility.sqlDT.Rows[0]["GrandTotal"].ToString();
                txtDue.Text = clsUtility.sqlDT.Rows[0]["Due"].ToString();
                cmbSupplier.SelectedValue = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["SUPP_ID"]);
                txtCash.Text = clsUtility.sqlDT.Rows[0]["CashPay"].ToString();
                txtCard.Text = clsUtility.sqlDT.Rows[0]["CardPay"].ToString();
            }
            else {
                txtDiscount.Text = "0";
                txtCash.Text = "0";
                txtCard.Text = "0";
            }

            LoadCalculaion();
        }

        private void chkExp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExp.Checked) { dtpExpDate.Enabled = true; } else { dtpExpDate.Enabled = false; }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                string ExpDate;
                if (chkExp.Checked) { ExpDate = dtpExpDate.Value.Date.ToString("yyyy-MM-dd"); } else { ExpDate = ""; }
                if (string.IsNullOrWhiteSpace(this.txtInvoiceNo.Text) | cmbItemName.SelectedValue == null | cmbItemName.SelectedIndex == -1 | cmbWarehouse.SelectedValue == null | cmbWarehouse.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtQty.Text) | string.IsNullOrWhiteSpace(this.txtPrice.Text))
                { errorProvider.SetError(txtInvoiceNo, "Required"); errorProvider.SetError(cmbWarehouse, "Required"); errorProvider.SetError(cmbItemName, "Required"); errorProvider.SetError(txtQty, "Required"); errorProvider.SetError(txtPrice, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" SELECT * FROM Purchase  WHERE (PUCHSE_ID='" + txtInvoiceNo.Text + "') AND (ITEM_ID='" + cmbItemName.SelectedValue.ToString() + "') AND (WarehouseID='" + cmbWarehouse.SelectedValue.ToString() + "') ");
                        if (clsUtility.sqlDT.Rows.Count > 0)
                        {
                            clsUtility.ExecuteSQLQuery(" UPDATE Purchase SET QTY = QTY + '" + clsUtility.num_repl(txtQty.Text) + "' ,TotalPrice = TotalPrice + '" + clsUtility.num_repl(txtPrice.Text) + "' ,ExpDate= '" + ExpDate + "' , SoldDate= '" + dtpPurchaseDate.Value.Date.ToString("yyyy-MM-dd") + "' " +
                                                       " WHERE (PUCHSE_ID='" + txtInvoiceNo.Text + "') AND (ITEM_ID='" + cmbItemName.SelectedValue.ToString() + "') AND (WarehouseID='" + cmbWarehouse.SelectedValue.ToString() + "') ");
                        }
                        else { clsUtility.ExecuteSQLQuery(" INSERT INTO Purchase(PUCHSE_ID,ITEM_ID,WarehouseID,QTY,TotalPrice,ExpDate,Stock, SoldDate) VALUES ('" + txtInvoiceNo.Text + "','" + cmbItemName.SelectedValue.ToString() + "','" + cmbWarehouse.SelectedValue.ToString() + "','" + txtQty.Text + "','" + txtPrice.Text + "','" + ExpDate + "','N' , '" + dtpPurchaseDate.Value.Date.ToString("yyyy-MM-dd") + "') "); }
                        LoadPurchaseItem();
                        txtPrice.Text = "";
                        txtQty.Text = "";
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

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPOSReceipt_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                btnSave.PerformClick();
                frmPurchaseReceipt frmPurchaseReceipt = new frmPurchaseReceipt(txtInvoiceNo.Text);
                frmPurchaseReceipt.ShowDialog();
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(this.txtDiscount.Text)) { txtDiscount.Text = "0"; }
           else { LoadCalculaion();}
        }

        private void LoadCalculaion() {
            try { 
                txtGrandTotal.Text = (double.Parse(txtTotalAmount.Text) - double.Parse(txtDiscount.Text)).ToString();
                txtDue.Text = (double.Parse(txtGrandTotal.Text) - double.Parse(txtCash.Text) - double.Parse(txtCard.Text)).ToString();
            }
            catch (Exception) { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" UPDATE  PurchaseInfo SET ItemPrice='" + clsUtility.num_repl(txtTotalAmount.Text) + "', Discount='" + clsUtility.num_repl(txtDiscount.Text) + "' " +
                           " , GrandTotal= '" + clsUtility.num_repl(txtGrandTotal.Text) + "',  CardPay= '" + clsUtility.num_repl(txtCard.Text) + "',  CashPay= '" + clsUtility.num_repl(txtCash.Text) + "' , Due ='" + clsUtility.num_repl(txtDue.Text) + "' , SUPP_ID= '" + clsUtility.fltr_combo(cmbSupplier) + "',  PurchaseDate='" + dtpPurchaseDate.Value.Date.ToString("yyyy-MM-dd") + "'   WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "') ");
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) {
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Purchase  WHERE ID ='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'  AND  Stock='Y' ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    clsUtility.MesgBoxShow("msgAlreadyInStock", "err");
                }
                else {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Purchase  WHERE ID ='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' ");
                    LoadPurchaseItem();
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Purchase  WHERE PUCHSE_ID ='" + txtInvoiceNo.Text + "'  AND  Stock='Y' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.MesgBoxShow("msgAlreadyInStock", "err");
                }
                else
                {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Purchase  WHERE PUCHSE_ID ='" + txtInvoiceNo.Text + "' ");
                    LoadPurchaseItem();
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtInvoiceNo.Text)) { }
            else { LoadPurchaseItem(); }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Purchase  WHERE PUCHSE_ID ='" + txtInvoiceNo.Text + "'  AND  Stock='Y' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.MesgBoxShow("msgAlreadyInStock", "err");
                }
                else
                {
                    //////////////////


                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Purchase WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "') AND  Stock='N' ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i <= clsUtility.sqlDT.Rows.Count - 1; i++)
                        {
                            //Purchase details
                            string ITEM_ID = clsUtility.sqlDT.Rows[i]["ITEM_ID"].ToString();
                            string WarehouseID = clsUtility.sqlDT.Rows[i]["WarehouseID"].ToString();
                            double PUR_QTY = Convert.ToDouble(clsUtility.sqlDT.Rows[i]["QTY"]);
                            double PUR_TotalPrice = Convert.ToDouble(clsUtility.sqlDT.Rows[i]["TotalPrice"]);
                            string PUR_ExpDate = clsUtility.sqlDT.Rows[i]["ExpDate"].ToString();

                            // Stock detail's
                            double STOCK_QTY = 0;
                            clsUtility.ExecuteSQLQuery2(" SELECT  ITEM_ID,  WarehouseID, Quantity  FROM  Stock WHERE ITEM_ID = '" + ITEM_ID + "' AND WarehouseID = '" + WarehouseID + "' ");
                            if (clsUtility.sqlDT2.Rows.Count > 0)
                            {
                                STOCK_QTY = Convert.ToDouble(clsUtility.sqlDT2.Rows[0]["Quantity"]);
                            }

                            // Get Cost from item table
                            double STOCK_COST = 0;
                            clsUtility.ExecuteSQLQuery2(" SELECT * FROM  ItemInformation WHERE ITEM_ID = '" + ITEM_ID + "'  ");
                            if (clsUtility.sqlDT2.Rows.Count > 0)
                            {
                                STOCK_COST = Convert.ToDouble(clsUtility.sqlDT2.Rows[0]["Cost"]);
                            }

                            double T_QTY = STOCK_QTY + PUR_QTY;
                            double T_Price = PUR_TotalPrice + (STOCK_QTY * STOCK_COST);
                            double AVG_COST = T_Price / T_QTY;


                            clsUtility.ExecuteSQLQuery2(" SELECT * FROM Stock WHERE  (WarehouseID ='" + WarehouseID + "')  AND (ITEM_ID ='" + ITEM_ID + "')  ");
                            if (clsUtility.sqlDT2.Rows.Count > 0)
                            { clsUtility.ExecuteSQLQuery2(" UPDATE Stock SET Quantity = '" + Math.Round(T_QTY, 2) + "', Expiry ='" + PUR_ExpDate + "'  WHERE  (WarehouseID ='" + WarehouseID + "')  AND (ITEM_ID ='" + ITEM_ID + "')  "); }
                            else { clsUtility.ExecuteSQLQuery2(" INSERT INTO Stock ( Quantity, WarehouseID, ITEM_ID,  SHELF_ID, Expiry) VALUES  ('" + Math.Round(T_QTY, 2) + "', '" + WarehouseID + "', '" + ITEM_ID + "', 0, '" + PUR_ExpDate + "') "); }

                            clsUtility.ExecuteSQLQuery2(" UPDATE ItemInformation SET Cost='" + Math.Round(AVG_COST, 2) + "' WHERE (ITEM_ID = '" + ITEM_ID + "') ");

                            clsUtility.ExecuteSQLQuery2(" UPDATE Purchase SET  Stock='Y'  WHERE (PUCHSE_ID = '" + txtInvoiceNo.Text + "') AND (ITEM_ID = '" + ITEM_ID + "')  ");
                            //MessageBox.Show("Qty " + T_QTY.ToString());
                            //MessageBox.Show("Price  " + T_Price.ToString());
                            //MessageBox.Show("Cost  " + AVG_COST.ToString());
                        }                  
                        clsUtility.MesgBoxShow("msgSaved", "info");
                    }
                    //////////////////
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

        private void txtCard_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCard.Text)) { txtCard.Text = "0"; }
            else { LoadCalculaion(); }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCash.Text)) { txtCash.Text = "0"; }
            else { LoadCalculaion(); }
        }

		private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
