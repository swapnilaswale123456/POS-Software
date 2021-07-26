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
    public partial class frmSaleReturnReport : Form
    {
        string SALES_ID;
        public frmSaleReturnReport(string SAL_ID)
        {
            InitializeComponent();
            SALES_ID = SAL_ID;
        }

        private void frmSaleReturnReport_Load(object sender, EventArgs e)
        {
            clsUtility.crpString.Value = "-";
            clsUtility.Preview__SalesReturn(" SELECT  SalesRetrnInfo.SALES_ID,  SalesRetrnInfo.SalesReturnDate,  SalesRetrnInfo.SalesReturnTime,  SalesRetrnInfo.Total, " +
                                            " SalesRetrnInfo.EntreBy,  SalesRetrnInfo.CashPay,  SalesRetrnInfo.CardPay,  SalesRetrnInfo.CUST_ID,  Customer.CustomerName,  Customer.Address, " +
                                            " Customer.PhoneNo,  SalesReturn.ITEM_ID,  ItemInformation.ItemName,  SalesReturn.QTY,  ItemInformation.UnitOfMeasure,  SalesReturn.Price,  SalesReturn.TotalPrice, " +
                                            " SalesReturn.Cost,  SalesReturn.TotalCost,  SalesReturn.Vat,  SalesReturn.TotalVat " +
                                            " FROM  SalesRetrnInfo  LEFT JOIN SalesReturn ON SalesReturn.SALES_ID = SalesRetrnInfo.SALES_ID  LEFT JOIN Customer ON SalesRetrnInfo.CUST_ID = Customer.CUST_ID LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = SalesReturn.ITEM_ID " +
                                            " WHERE (SalesRetrnInfo.SALES_ID = '" + SALES_ID + "') ", crystalReportViewer1);
        }
    }
}
