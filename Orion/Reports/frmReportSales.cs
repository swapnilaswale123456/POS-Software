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
    public partial class frmReportSales : Form
    {
        public frmReportSales()
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
                        XmlNode l1127 = languageNode["l1127"];
                        lbl1127.Text = l1127.InnerText;

                        XmlNode l1128 = languageNode["l1128"];
                        rbToday.Text = l1128.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode l1130 = languageNode["l1130"];
                        rbPOS.Text = l1130.InnerText;

                        XmlNode l1131 = languageNode["l1131"];
                        rbQuickSale.Text = l1131.InnerText;

                        XmlNode l1132 = languageNode["l1132"];
                        rbBestProductSale.Text = l1132.InnerText;

                        XmlNode l1133 = languageNode["l1133"];
                        rbCustomer.Text = l1133.InnerText;

                        XmlNode l1134 = languageNode["l1134"];
                        rbItem.Text = l1134.InnerText;

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

        private void frmReportSales_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  CUST_ID, CustomerName  FROM  Customer  ORDER BY CustomerName", "CUST_ID", "CustomerName", cmbCustomer);
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);
            clsUtility.FillComboBox(" SELECT  EMP_ID, EmployeeName  FROM  Employee  ORDER BY EmployeeName", "EMP_ID", "EmployeeName", cmbEmpSale);

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
                if (rbToday.Checked)
                {
                    // Today sale
                    clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                    clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                    " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                    " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                    " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                    " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                    " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                    " WHERE  (SalesInfo.SalesDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "') ", crystalReportViewer1);
                    // End
                }
                else if (rbPOS.Checked)
                {
                    // POS

                    clsUtility.crpString.Value = "POS,  FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                    " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                    " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                    " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                    " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                    " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                    " WHERE  SalesInfo.SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND SalesInfo.SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' AND SalesInfo.Terminal = 'POS' ", crystalReportViewer1);

                    // End
                }
                else if (rbQuickSale.Checked)
                {
                    // Quick Sale

                    clsUtility.crpString.Value = "POS,  FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                    " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                    " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                    " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                    " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                    " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                    " WHERE  SalesInfo.SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND SalesInfo.SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' AND SalesInfo.Terminal = 'QuickSale' ", crystalReportViewer1);

                    // End
                }
                else if (rbBestProductSale.Checked)
                {
                    // Best product sale
                    clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__BestProductSale(" SELECT ItemInformation.ITEM_ID,  ItemInformation.ItemName, ItemInformation.Barcode,  Sum(Sales.QTY) AS QTY,  ItemInformation.UnitOfMeasure " +
                                                        " FROM  Sales  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID WHERE  Sales.Sales_Date >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  Sales.Sales_Date <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' " +
                                                        " GROUP BY  ItemInformation.ITEM_ID, ItemInformation.ItemName,  ItemInformation.Barcode,  ItemInformation.UnitOfMeasure  order by  QTY DESC ", crystalReportViewer1);
                    // End
                }
                else if (rbCustomer.Checked)
                {
                    // Customer
                    if (cmbCustomer.SelectedIndex == -1 | cmbCustomer.SelectedValue == null) { errorProvider.SetError(cmbCustomer, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                        clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                        " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                        " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                        " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                        " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                        " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                        " WHERE  SalesInfo.SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesInfo.SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesInfo.CUST_ID = '" + cmbCustomer.SelectedValue.ToString() + "' ", crystalReportViewer1);
                    }
                    // End
                }
                else if (rbItem.Checked)
                {
                    // Item wise sales
                    if (cmbItemName.SelectedIndex == -1 | cmbItemName.SelectedValue == null) { errorProvider.SetError(cmbItemName, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                        clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                        " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                        " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                        " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                        " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                        " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                        " WHERE  SalesInfo.SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesInfo.SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' AND  Sales.ITEM_ID  = '" + cmbItemName.SelectedValue.ToString() + "' ", crystalReportViewer1);
                    }
                    // End
                }
                else if (rbEmpSale.Checked)
                {
                    // Item wise sales
                    if (cmbEmpSale.SelectedIndex == -1 | cmbEmpSale.SelectedValue == null) { errorProvider.SetError(cmbEmpSale, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        errorProvider.Clear();
                        clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                        clsUtility.Preview__SaleDetails(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName, Customer.Address, Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                        " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                        " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,  SalesInfo.ShippingName,  SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  " +
                                                        " Sales.ITEM_ID,  ItemInformation.ItemName, Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,  Sales.Cost,  Sales.TotalCost,  " +
                                                        " Sales.Vat AS ItemUnitVat,  Sales.TotalVat,  Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                        " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID "+
                                                        " LEFT JOIN Employee ON Employee.EMP_ID = SalesInfo.EntreBy " +
                                                        
                                                        " WHERE  SalesInfo.SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesInfo.SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' AND  SalesInfo.EntreBy = '" + cmbEmpSale.SelectedValue.ToString() + "' ", crystalReportViewer1);
                    }
                    // End
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
