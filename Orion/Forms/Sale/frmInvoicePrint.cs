using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmInvoicePrint : Form
    {
        string BILL_NO, BILL_TYPE;
        public frmInvoicePrint(string INV_NO, string INV_TYPE)
        {
            InitializeComponent();
            BILL_NO = INV_NO;
            BILL_TYPE = INV_TYPE;
        }

        private void frmInvoicePrint_Load(object sender, EventArgs e)
        {
            if (BILL_TYPE == "POS") {
                clsUtility.Preview__SalesReceipt(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName,  Customer.Address,  Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                 " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                 " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo,    SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  Sales.ITEM_ID,  " +
                                                 " ItemInformation.ItemName,  Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,    Sales.TotalCost,  Sales.Vat AS ItemUnitVat,  " +
                                                 " Sales.TotalVat, Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                 " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID  LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                 " WHERE (SalesInfo.SALES_ID = '" + BILL_NO + "') ", crystalReportViewer1);
                this.Close();
            }
            else {
                clsUtility.Preview__TaxInvoice(" SELECT  SalesInfo.SALES_ID,  SalesInfo.CUST_ID,  Customer.CustomerName,  Customer.Address,  Customer.PhoneNo,  SalesInfo.SalesDate,  SalesInfo.SalesTime,  " +
                                                 " SalesInfo.ItemPrice,  SalesInfo.VAT AS TOTAL_VAT,  SalesInfo.Discount,  SalesInfo.GrandTotal,  SalesInfo.EntreBy,  SalesInfo.CashPay,  SalesInfo.CardPay,  " +
                                                 " SalesInfo.Due,  SalesInfo.Comment,  SalesInfo.Terminal,  SalesInfo.TrnsNo, SalesInfo.ShippingName, SalesInfo.ShippingAddress,  SalesInfo.ShippingContact,  Sales.ITEM_ID,  " +
                                                 " ItemInformation.ItemName,  Sales.QTY,  ItemInformation.UnitOfMeasure,  Sales.Price,  Sales.TotalPrice,    Sales.TotalCost,  Sales.Vat AS ItemUnitVat,  " +
                                                 " Sales.TotalVat, Sales.ExprDate FROM SalesInfo  LEFT JOIN Sales ON Sales.SALES_ID = SalesInfo.SALES_ID  " +
                                                 " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Sales.ITEM_ID  LEFT JOIN Customer ON Customer.CUST_ID = SalesInfo.CUST_ID  " +
                                                 " WHERE (SalesInfo.SALES_ID = '" + BILL_NO + "') ", crystalReportViewer1);
            }
        }
    }
}
