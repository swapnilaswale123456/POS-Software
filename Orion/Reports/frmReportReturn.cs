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
    public partial class frmReportReturn : Form
    {
        public frmReportReturn()
        {
            InitializeComponent();
        }

        private void frmReportReturn_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItem);
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
                        XmlNode l1138 = languageNode["l1138"];
                        lbl1138.Text = l1138.InnerText;

                        XmlNode l1121 = languageNode["l1121"];
                        lbl1121.Text = l1121.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode l1139 = languageNode["l1139"];
                        rbTodaySaleReturn.Text = l1139.InnerText;

                        XmlNode l1140 = languageNode["l1140"];
                        rbTodayPurchaseReturn.Text = l1140.InnerText;

                        XmlNode l1141 = languageNode["l1141"];
                        rbSaleReturnByDate.Text = l1141.InnerText;

                        XmlNode l1142 = languageNode["l1142"];
                        rbPurchaseReturnByDate.Text = l1142.InnerText;

                        XmlNode l1143 = languageNode["l1143"];
                        rbSaleReturnByItem.Text = l1143.InnerText;

                        XmlNode l1144 = languageNode["l1144"];
                        rbPurchaseReturnByItem.Text = l1144.InnerText;

                        XmlNode ctrlPrint = languageNode["ctrlPrint"];
                        btnRefresh.Text = ctrlPrint.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
            if (rbTodaySaleReturn.Checked)
            {
                //Today sale return 
                clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                clsUtility.Preview__SalesReturn(" SELECT  SalesRetrnInfo.SALES_ID,  SalesRetrnInfo.SalesReturnDate,  SalesRetrnInfo.SalesReturnTime,  SalesRetrnInfo.Total, " +
                                                " SalesRetrnInfo.EntreBy,  SalesRetrnInfo.CashPay,  SalesRetrnInfo.CardPay,  SalesRetrnInfo.CUST_ID,  Customer.CustomerName,  Customer.Address, " +
                                                " Customer.PhoneNo,  SalesReturn.ITEM_ID,  ItemInformation.ItemName,  SalesReturn.QTY,  ItemInformation.UnitOfMeasure,  SalesReturn.Price,  SalesReturn.TotalPrice, " +
                                                " SalesReturn.Cost,  SalesReturn.TotalCost,  SalesReturn.Vat,  SalesReturn.TotalVat " +
                                                " FROM  SalesRetrnInfo  LEFT JOIN SalesReturn ON SalesReturn.SALES_ID = SalesRetrnInfo.SALES_ID  LEFT JOIN Customer ON SalesRetrnInfo.CUST_ID = Customer.CUST_ID LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = SalesReturn.ITEM_ID " +
                                                " WHERE (SalesRetrnInfo.SalesReturnDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "') ", crystalReportViewer1);
                // end 
            }
            else if (rbTodayPurchaseReturn.Checked)
            {
                //Today purchase return 
                clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                clsUtility.Preview__PurchaseReturn(" SELECT  PurchaseReturnInfo.PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  PurchaseReturnInfo.EntreBy,  PurchaseReturnInfo.Total, " +
                                                   " PurchaseReturnInfo.CardPay, PurchaseReturnInfo.CashPay,  PurchaseReturnInfo.SUPP_ID, Supplier.SupplierName, Supplier.Address, " +
                                                   " Supplier.PhoneNo,  PurchaseReturn.ITEM_ID,  ItemInformation.ItemName, PurchaseReturn.WarehouseID,  Warehouse.WarehouseAddress, " +
                                                   " PurchaseReturn.QTY, ItemInformation.UnitOfMeasure,  PurchaseReturn.TotalPrice,  Warehouse.WarehouseName " +
                                                   " FROM  PurchaseReturnInfo LEFT JOIN PurchaseReturn ON PurchaseReturn.PUCHSE_ID = PurchaseReturnInfo.PUCHSE_ID " +
                                                   " LEFT JOIN Supplier ON PurchaseReturnInfo.SUPP_ID = Supplier.SUPP_ID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = PurchaseReturn.ITEM_ID " +
                                                   " LEFT JOIN Warehouse ON Warehouse.WarehouseID = PurchaseReturn.WarehouseID " +
                                                   " WHERE  PurchaseReturnInfo.PurchaseReturnDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                // end 
            }
            else if (rbSaleReturnByDate.Checked)
            {
                // sale return  by date
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__SalesReturn(" SELECT  SalesRetrnInfo.SALES_ID,  SalesRetrnInfo.SalesReturnDate,  SalesRetrnInfo.SalesReturnTime,  SalesRetrnInfo.Total, " +
                                                " SalesRetrnInfo.EntreBy,  SalesRetrnInfo.CashPay,  SalesRetrnInfo.CardPay,  SalesRetrnInfo.CUST_ID,  Customer.CustomerName,  Customer.Address, " +
                                                " Customer.PhoneNo,  SalesReturn.ITEM_ID,  ItemInformation.ItemName,  SalesReturn.QTY,  ItemInformation.UnitOfMeasure,  SalesReturn.Price,  SalesReturn.TotalPrice, " +
                                                " SalesReturn.Cost,  SalesReturn.TotalCost,  SalesReturn.Vat,  SalesReturn.TotalVat " +
                                                " FROM  SalesRetrnInfo  LEFT JOIN SalesReturn ON SalesReturn.SALES_ID = SalesRetrnInfo.SALES_ID  LEFT JOIN Customer ON SalesRetrnInfo.CUST_ID = Customer.CUST_ID LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = SalesReturn.ITEM_ID " +
                                                " WHERE  SalesRetrnInfo.SalesReturnDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesRetrnInfo.SalesReturnDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                // end 
            }
            else if (rbPurchaseReturnByDate.Checked)
            {
                // purchase return  by date
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__PurchaseReturn(" SELECT  PurchaseReturnInfo.PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  PurchaseReturnInfo.EntreBy,  PurchaseReturnInfo.Total, " +
                                                   " PurchaseReturnInfo.CardPay, PurchaseReturnInfo.CashPay,  PurchaseReturnInfo.SUPP_ID, Supplier.SupplierName, Supplier.Address, " +
                                                   " Supplier.PhoneNo,  PurchaseReturn.ITEM_ID,  ItemInformation.ItemName, PurchaseReturn.WarehouseID,  Warehouse.WarehouseAddress, " +
                                                   " PurchaseReturn.QTY, ItemInformation.UnitOfMeasure,  PurchaseReturn.TotalPrice,  Warehouse.WarehouseName " +
                                                   " FROM  PurchaseReturnInfo LEFT JOIN PurchaseReturn ON PurchaseReturn.PUCHSE_ID = PurchaseReturnInfo.PUCHSE_ID " +
                                                   " LEFT JOIN Supplier ON PurchaseReturnInfo.SUPP_ID = Supplier.SUPP_ID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = PurchaseReturn.ITEM_ID " +
                                                   " LEFT JOIN Warehouse ON Warehouse.WarehouseID = PurchaseReturn.WarehouseID " +
                                                   " WHERE  PurchaseReturnInfo.PurchaseReturnDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  PurchaseReturnInfo.PurchaseReturnDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                // end 
            }
            else if (rbSaleReturnByItem.Checked)
            {
                // sale return  by item
                if (cmbItem.SelectedIndex == -1 | cmbItem.SelectedValue == null) { errorProvider.SetError(cmbItem, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__SalesReturn(" SELECT  SalesRetrnInfo.SALES_ID,  SalesRetrnInfo.SalesReturnDate,  SalesRetrnInfo.SalesReturnTime,  SalesRetrnInfo.Total, " +
                                                    " SalesRetrnInfo.EntreBy,  SalesRetrnInfo.CashPay,  SalesRetrnInfo.CardPay,  SalesRetrnInfo.CUST_ID,  Customer.CustomerName,  Customer.Address, " +
                                                    " Customer.PhoneNo,  SalesReturn.ITEM_ID,  ItemInformation.ItemName,  SalesReturn.QTY,  ItemInformation.UnitOfMeasure,  SalesReturn.Price,  SalesReturn.TotalPrice, " +
                                                    " SalesReturn.Cost,  SalesReturn.TotalCost,  SalesReturn.Vat,  SalesReturn.TotalVat " +
                                                    " FROM  SalesRetrnInfo  LEFT JOIN SalesReturn ON SalesReturn.SALES_ID = SalesRetrnInfo.SALES_ID  LEFT JOIN Customer ON SalesRetrnInfo.CUST_ID = Customer.CUST_ID LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = SalesReturn.ITEM_ID " +
                                                    " WHERE (SalesReturn.ITEM_ID = '" + cmbItem.SelectedValue.ToString() + "') AND  SalesRetrnInfo.SalesReturnDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesRetrnInfo.SalesReturnDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                }
                // end 
            }
            else if (rbPurchaseReturnByItem.Checked)
            {
                // purchase return  by item
                if (cmbItem.SelectedIndex == -1 | cmbItem.SelectedValue == null) { errorProvider.SetError(cmbItem, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__PurchaseReturn(" SELECT  PurchaseReturnInfo.PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  PurchaseReturnInfo.EntreBy,  PurchaseReturnInfo.Total, " +
                                                       " PurchaseReturnInfo.CardPay, PurchaseReturnInfo.CashPay,  PurchaseReturnInfo.SUPP_ID, Supplier.SupplierName, Supplier.Address, " +
                                                       " Supplier.PhoneNo,  PurchaseReturn.ITEM_ID,  ItemInformation.ItemName, PurchaseReturn.WarehouseID,  Warehouse.WarehouseAddress, " +
                                                       " PurchaseReturn.QTY, ItemInformation.UnitOfMeasure,  PurchaseReturn.TotalPrice,  Warehouse.WarehouseName " +
                                                       " FROM  PurchaseReturnInfo LEFT JOIN PurchaseReturn ON PurchaseReturn.PUCHSE_ID = PurchaseReturnInfo.PUCHSE_ID " +
                                                       " LEFT JOIN Supplier ON PurchaseReturnInfo.SUPP_ID = Supplier.SUPP_ID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = PurchaseReturn.ITEM_ID " +
                                                       " LEFT JOIN Warehouse ON Warehouse.WarehouseID = PurchaseReturn.WarehouseID " +
                                                       " WHERE PurchaseReturn.ITEM_ID = '" + cmbItem.SelectedValue.ToString() + "' AND  PurchaseReturnInfo.PurchaseReturnDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  PurchaseReturnInfo.PurchaseReturnDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                }
                // end 
            }
            else { }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }


        }
    }
}
