using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orion
{
    public partial class frmSales : Form
    {
        public frmSales(String SALES_ID)
        {
            InitializeComponent();
            txtInvoiceNo.Text = SALES_ID;
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
                        XmlNode l1066 = languageNode["l1066"];
                        lbl1066.Text = l1066.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        lbl1067.Text = l1067.InnerText;

                        XmlNode l1065 = languageNode["l1065"];
                        lbl1065.Text = l1065.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        rbItem.Text = l1030.InnerText;

                        XmlNode l1051 = languageNode["l1051"];
                        rbBarcode.Text = l1051.InnerText;

                        XmlNode l1053 = languageNode["l1053"];
                        lbl1053.Text = l1053.InnerText;

                        XmlNode l1068 = languageNode["l1068"];
                        lbl1068.Text = l1068.InnerText;

                        XmlNode l1069 = languageNode["l1069"];
                        lbl1069.Text = l1069.InnerText;

                        XmlNode l1070 = languageNode["l1070"];
                        lbl1070.Text = l1070.InnerText;

                        XmlNode l1071 = languageNode["l1071"];
                        lbl1071.Text = l1071.InnerText;

                        XmlNode l1072 = languageNode["l1072"];
                        lbl1072.Text = l1072.InnerText;

                        XmlNode l1073 = languageNode["l1073"];
                        lbl1073.Text = l1073.InnerText;

                        XmlNode l1074 = languageNode["l1074"];
                        lbl1074.Text = l1074.InnerText;

                        XmlNode l1075 = languageNode["l1075"];
                        lbl1075.Text = l1075.InnerText;

                        XmlNode l1076 = languageNode["l1076"];
                        lbl1076.Text = l1076.InnerText;

                        XmlNode ctrlComplete = languageNode["ctrlComplete"];
                        btnComplete.Text = ctrlComplete.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlNew = languageNode["ctrlNew"];
                        btnNew.Text = ctrlNew.InnerText;

                        XmlNode ctrlPrint = languageNode["ctrlPrint"];
                        btnPrintView.Text = ctrlPrint.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSave.Text = ctrlSave.InnerText;

                        XmlNode ctrlShipping = languageNode["ctrlShipping"];
                        btnOptions.Text = ctrlShipping.InnerText;

                        XmlNode ctrlAdd = languageNode["ctrlAdd"];
                        btnAddItem.Text = ctrlAdd.InnerText;

                        XmlNode l1183 = languageNode["l1183"];
                        XmlNode l1046 = languageNode["l1046"];

                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1183.InnerText;
                        dataGridView1.Columns["Column11"].HeaderText = l1071.InnerText;
                        dataGridView1.Columns["Column10"].HeaderText = l1069.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1046.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCalculaion()
        {
            try
            {
                txtGrandTotal.Text = (Math.Round(double.Parse(txtNetAmount.Text) + (double.Parse(txtVAT.Text) - double.Parse(txtDiscount.Text)), 2)).ToString();
                txtDue.Text = (double.Parse(txtGrandTotal.Text) - (double.Parse(txtCash.Text) + double.Parse(txtCard.Text))).ToString();
            }
            catch (Exception) { }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);

            if (txtInvoiceNo.Text == "0") {
                clsUtility.ExecuteSQLQuery("SELECT  * FROM  SalesInfo WHERE  USER_ID = '" + clsUtility.UserID + "' AND Terminal='QuickSale'  ORDER BY SALES_ID DESC");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    string DEC_SALES_ID = clsUtility.sqlDT.Rows[0]["SALES_ID"].ToString();
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM   Sales  WHERE SALES_ID = '" + DEC_SALES_ID + "' ");
                    if (clsUtility.sqlDT.Rows.Count > 0) { CreateNewInvoice(); LoadSalesItem(); } else { txtInvoiceNo.Text = DEC_SALES_ID; }
                }
                else {CreateNewInvoice(); LoadSalesItem();  }
            }
            else { LoadSalesItem(); }

            
        }

        private void CreateNewInvoice()
        {
            clsUtility.ExecuteSQLQuery(" INSERT INTO SalesInfo  ( SalesDate, SalesTime,  ItemPrice,  VAT,  Discount,  GrandTotal,   CashPay, CardPay,  EntreBy,  Due, Comment, Terminal, CUST_ID, TrnsNo, ShippingName, ShippingAddress, ShippingContact, USER_ID) VALUES " +
                   " ('" + dtpSalesDate.Value.Date.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("hh:mm") + "',  '" + clsUtility.num_repl(txtNetAmount.Text) + "',  '" + clsUtility.num_repl(txtVAT.Text) + "',  0,  0, 0, 0, '" + clsUtility.UserName + "', 0, '-', 'QuickSale', 0, '-' , '-', '-', '-', '" + clsUtility.UserID + "') ");
            clsUtility.ExecuteSQLQuery("SELECT  SALES_ID  FROM   SalesInfo    ORDER BY SALES_ID DESC");
            txtInvoiceNo.Text = clsUtility.sqlDT.Rows[0]["SALES_ID"].ToString();
        }

        private void LoadSalesItem()
        {
            clsUtility.FillDataGrid(" SELECT ID, ItemName, QTY, UnitOfMeasure, Sales.Price, TotalPrice, TotalVat, ExprDate " +
                                    " FROM Sales LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID WHERE Sales.SALES_ID = '" + txtInvoiceNo.Text + "' ", dataGridView1);


            clsUtility.ExecuteSQLQuery("SELECT *  FROM  SalesInfo    WHERE (SALES_ID = '" + txtInvoiceNo.Text + "')");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                txtDiscount.Text = clsUtility.sqlDT.Rows[0]["Discount"].ToString();
                txtGrandTotal.Text = clsUtility.sqlDT.Rows[0]["GrandTotal"].ToString();
                txtDue.Text = clsUtility.sqlDT.Rows[0]["Due"].ToString();
                txtVAT.Text = clsUtility.sqlDT.Rows[0]["VAT"].ToString();
                txtCash.Text = clsUtility.sqlDT.Rows[0]["CashPay"].ToString();
                txtCard.Text = clsUtility.sqlDT.Rows[0]["CardPay"].ToString();
            }
            else
            {
                txtDiscount.Text = "0";
                txtCard.Text = "0";
                txtCash.Text = "0";
            }


            clsUtility.ExecuteSQLQuery("SELECT  *  FROM  Sales    WHERE (SALES_ID = '" + txtInvoiceNo.Text + "')");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                clsUtility.ExecuteSQLQuery("SELECT  SUM(TotalPrice) AS Expr1 , SUM(TotalVat) AS Expr2 FROM  Sales  WHERE (SALES_ID = '" + txtInvoiceNo.Text + "')");
                txtNetAmount.Text = clsUtility.sqlDT.Rows[0]["Expr1"].ToString();
                txtVAT.Text = clsUtility.sqlDT.Rows[0]["Expr2"].ToString();
            }
            else { txtNetAmount.Text = "0"; txtVAT.Text = "0"; }

            LoadCalculaion();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (rbItem.Checked)
                {
                    if (cmbItemName.SelectedValue == null | cmbItemName.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtQty.Text))
                    { errorProvider.SetError(cmbItemName, "Required"); errorProvider.SetError(txtQty, "Required"); }
                    else
                    {
                        InsertSalesItem(cmbItemName.SelectedValue.ToString(), Convert.ToDouble(txtQty.Text));
                        errorProvider.Clear();
                        LoadSalesItem();
                        txtQty.Text = "";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtBarcode.Text) | string.IsNullOrWhiteSpace(this.txtQty.Text))
                    { errorProvider.SetError(txtBarcode, "Required"); errorProvider.SetError(txtQty, "Required"); }
                    else
                    {
                        double ITEM_ID;
                        clsUtility.ExecuteSQLQuery("SELECT * FROM ItemInformation WHERE  Barcode = '" + txtBarcode.Text + "'");
                        if (clsUtility.sqlDT.Rows.Count > 0)
                        {
                            ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                            InsertSalesItem(ITEM_ID.ToString(), Convert.ToDouble(txtQty.Text));
                            errorProvider.Clear();
                            LoadSalesItem();
                            txtQty.Text = "";
                            txtBarcode.Text = "";
                        }
                        else
                        {
                            clsUtility.MesgBoxShow("msgNotFound", "info");
                        }
                    }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }


        private void InsertSalesItem(string ITEM_ID, double  QTY)
        {
            double VAT;
            clsUtility.ExecuteSQLQuery("SELECT * FROM Vat");
            if (clsUtility.sqlDT.Rows.Count > 0) { VAT = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Vat"]); } else { VAT = 0; }

            clsUtility.ExecuteSQLQuery(" SELECT * FROM  ItemInformation  WHERE ITEM_ID ='" + ITEM_ID + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                string WarehouseID, ExpiryDate, VAT_Applicable;
                WarehouseID = clsUtility.sqlDT.Rows[0]["WarehouseID"].ToString();
                VAT_Applicable = clsUtility.sqlDT.Rows[0]["VAT_Applicable"].ToString();
                double Cost = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Cost"]);
                double Price = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Price"]);
                double UnitVatAmount;
                if (VAT_Applicable == "Y")
                {
                    UnitVatAmount = Price * VAT / 100;
                }
                else { UnitVatAmount = 0; }

                //Check Warehouse 
                clsUtility.ExecuteSQLQuery(" SELECT * FROM  Stock  WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "' AND  (Quantity >= '" + QTY + "') ");
                if (clsUtility.sqlDT.Rows.Count > 0) {
                    ExpiryDate = clsUtility.sqlDT.Rows[0]["ExpiryDate"].ToString();
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Sales  WHERE ITEM_ID = '" + ITEM_ID + "' AND SALES_ID = '" + txtInvoiceNo.Text + "' ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE  Sales SET QTY = QTY + '" + QTY + "' ,TotalPrice= TotalPrice +'" + QTY * Price + "' ,TotalCost= TotalCost +'" + QTY * Cost + "', TotalVat= TotalVat + '" + QTY * UnitVatAmount + "' " +
                                                   " WHERE ITEM_ID = '" + ITEM_ID + "' AND SALES_ID = '" + txtInvoiceNo.Text + "' ");

                    }
                    else {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO Sales(SALES_ID,Sales_Date,ITEM_ID,QTY,Price,TotalPrice,Cost,TotalCost,Vat,TotalVat,ExprDate, Terminal) VALUES " +
                                                   " ( '" + txtInvoiceNo.Text + "' ,'" + dtpSalesDate.Value.Date.ToString("yyyy-MM-dd") + "' , '" + ITEM_ID + "', '" + QTY + "', '" + Price + "','" + QTY * Price + "','" + Cost + "','" + QTY * Cost + "','" + UnitVatAmount + "','" + QTY * UnitVatAmount + "', '" + ExpiryDate + "', 'QuickSale') ");                   
                    }
                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity - '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }
                else { errorProvider.SetError(txtQty, "Required");}
                //End Warehouse
            }
        }

        private void DeleteSalesItem(string DATA_ROW_ID, double QTY)
        {

            clsUtility.ExecuteSQLQuery(" SELECT * FROM Sales  WHERE ID = '" + DATA_ROW_ID + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                double ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                double Cost = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Cost"]);
                double Price = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Price"]);
                double Vat = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["Vat"]);

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM   ItemInformation  WHERE  ITEM_ID = '" + ITEM_ID + "' ");
                double WarehouseID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["WarehouseID"]);

                clsUtility.ExecuteSQLQuery(" SELECT *  FROM  Sales  WHERE ID = '" + DATA_ROW_ID + "' AND ITEM_ID = '" + ITEM_ID + "' AND QTY = '" + QTY + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    clsUtility.ExecuteSQLQuery(" DELETE FROM Sales WHERE ID =  '" + DATA_ROW_ID + "' ");
                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }
                else {
                    clsUtility.ExecuteSQLQuery(" UPDATE  Sales SET QTY = QTY - '" + QTY + "' ,TotalPrice= TotalPrice -'" + QTY * Price + "' ,TotalCost= TotalCost -'" + QTY * Cost + "', TotalVat= TotalVat - '" + QTY * Vat + "' " +
                                               " WHERE ID = '" + DATA_ROW_ID + "' ");

                    clsUtility.ExecuteSQLQuery(" UPDATE   Stock SET Quantity = Quantity + '" + QTY + "' WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID='" + WarehouseID + "'  ");
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtDiscount.Text)) { txtDiscount.Text = "0"; }
            else { LoadCalculaion(); }
        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" UPDATE  SalesInfo  SET ItemPrice='" + clsUtility.num_repl(txtNetAmount.Text) + "', Discount='" + clsUtility.num_repl(txtDiscount.Text) + "' " +
                                           " , GrandTotal= '" + clsUtility.num_repl(txtGrandTotal.Text) + "', VAT= '" + clsUtility.num_repl(txtVAT.Text) + "', CashPay= '" + clsUtility.num_repl(txtCash.Text) + "', CardPay= '" + clsUtility.num_repl(txtCard.Text) + "' , Due ='" + clsUtility.num_repl(txtDue.Text) + "'    WHERE (SALES_ID = '" + txtInvoiceNo.Text + "') ");
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
                clsUtility.ExecuteSQLQuery("SELECT * FROM Sales WHERE ID =  '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ");
                double ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                InsertSalesItem(ITEM_ID.ToString(), 1);
                LoadSalesItem();
            }
            else if (e.ColumnIndex == 1) {
                DeleteSalesItem(dataGridView1.CurrentRow.Cells[3].Value.ToString(), 1);
                LoadSalesItem();
            }
            else if (e.ColumnIndex == 2) {
                DialogResult msg = new DialogResult();
                msg = MessageBox.Show("Do you really want to delete item?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    clsUtility.ExecuteSQLQuery("SELECT * FROM Sales WHERE ID =  '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ");
                    double ITEM_ID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["ITEM_ID"]);
                    clsUtility.ExecuteSQLQuery(" SELECT *  FROM   ItemInformation  WHERE  ITEM_ID = '" + ITEM_ID + "' ");
                    double WarehouseID = Convert.ToDouble(clsUtility.sqlDT.Rows[0]["WarehouseID"]);
                    clsUtility.ExecuteSQLQuery(" UPDATE Stock SET  Quantity = Quantity + '" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'  WHERE ITEM_ID = '" + ITEM_ID + "' AND WarehouseID = '" + WarehouseID + "' ");
                    clsUtility.ExecuteSQLQuery(" DELETE FROM Sales WHERE ID =  '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ");
                    LoadSalesItem();
                }
            }
        }

        private void btnTransactionNo_Click(object sender, EventArgs e)
        {
            string message, title, defaultValue, myValue;
            message = "Enter Bank Transaction No";
            title = "Transaction No";
            defaultValue = "";
            myValue = Interaction.InputBox(message, title, defaultValue, 100, 100);
            if (myValue == "")
            {
                clsUtility.ExecuteSQLQuery(" SELECT * FROM SalesInfo  WHERE SALES_ID='" + txtInvoiceNo.Text + "' ");
                myValue = clsUtility.sqlDT.Rows[0]["TrnsNo"].ToString();
            }
            else
            {
                clsUtility.ExecuteSQLQuery(" UPDATE SalesInfo SET TrnsNo='" + myValue + "' WHERE SALES_ID='" + txtInvoiceNo.Text + "' ");
            } 
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            frmShippingDetails frmShippingDetails = new frmShippingDetails(txtInvoiceNo.Text);
            frmShippingDetails.ShowDialog();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
           clsUtility.ExecuteSQLQuery(" SELECT * FROM Sales WHERE SALES_ID='" + txtInvoiceNo.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                if (double.Parse(txtCash.Text)  + double.Parse(txtCard.Text) < double.Parse(txtGrandTotal.Text)) 
                {
                    MessageBox.Show("Please confirm the payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                DialogResult msg = new DialogResult();
                msg = MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    CreateNewInvoice();
                    LoadSalesItem();
                    txtBarcode.Focus();
                }
                }
            }
            else
            {
                clsUtility.MesgBoxShow("msgNotFound", "info");
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

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCash.Text)) { txtCash.Text = "0"; }
            else { LoadCalculaion(); }
        }

        private void txtCard_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCard.Text)) { txtCard.Text = "0"; }
            else { LoadCalculaion(); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                DialogResult msg = new DialogResult();
                msg = MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    CreateNewInvoice();
                    LoadSalesItem();
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                frmInvoicePrint frmInvoicePrint = new frmInvoicePrint(txtInvoiceNo.Text, "QuickSale");
                frmInvoicePrint.ShowDialog();
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }


    }
}
