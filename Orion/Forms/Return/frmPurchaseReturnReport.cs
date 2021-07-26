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
    public partial class frmPurchaseReturnReport : Form
    {
        string PUCHSE_ID;
        public frmPurchaseReturnReport(string PID)
        {
            InitializeComponent();
            PUCHSE_ID = PID;
        }

        private void frmPurchaseReturnReport_Load(object sender, EventArgs e)
        {
            clsUtility.crpString.Value = " - ";
            clsUtility.Preview__PurchaseReturn(" SELECT  PurchaseReturnInfo.PUCHSE_ID,  PurchaseReturnDate, PurchaseReturnTime,  PurchaseReturnInfo.EntreBy,  PurchaseReturnInfo.Total, " +
                                               " PurchaseReturnInfo.CardPay, PurchaseReturnInfo.CashPay,  PurchaseReturnInfo.SUPP_ID, Supplier.SupplierName, Supplier.Address, " +
                                               " Supplier.PhoneNo,  PurchaseReturn.ITEM_ID,  ItemInformation.ItemName, PurchaseReturn.WarehouseID,  Warehouse.WarehouseAddress, " +
                                               " PurchaseReturn.QTY, ItemInformation.UnitOfMeasure,  PurchaseReturn.TotalPrice,  Warehouse.WarehouseName " +
                                               " FROM  PurchaseReturnInfo LEFT JOIN PurchaseReturn ON PurchaseReturn.PUCHSE_ID = PurchaseReturnInfo.PUCHSE_ID " +
                                               " LEFT JOIN Supplier ON PurchaseReturnInfo.SUPP_ID = Supplier.SUPP_ID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = PurchaseReturn.ITEM_ID " +
                                               " LEFT JOIN Warehouse ON Warehouse.WarehouseID = PurchaseReturn.WarehouseID " +
                                               " WHERE  (PurchaseReturnInfo.PUCHSE_ID = '" + PUCHSE_ID + "') ", crystalReportViewer1);
        }
    }
}
