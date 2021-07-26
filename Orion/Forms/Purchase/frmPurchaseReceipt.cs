using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmPurchaseReceipt : Form
    {
        string PUCHSE_ID;
        public frmPurchaseReceipt(string PID)
        {
            InitializeComponent();
            PUCHSE_ID = PID;
        }

        public frmPurchaseReceipt()
        {
            // TODO: Complete member initialization
        }

        private void frmPurchaseReceipt_Load(object sender, EventArgs e)
        {
            clsUtility.Preview__Purchase(" SELECT  PurchaseInfo.PUCHSE_ID,  PurchaseInfo.PurchaseDate,  PurchaseInfo.ItemPrice,  PurchaseInfo.Discount, PurchaseInfo.GrandTotal,  PurchaseInfo.Due, " +
                                         " PurchaseInfo.CardPay, PurchaseInfo.CashPay,  PurchaseInfo.SUPP_ID,  Supplier.SupplierName,  Supplier.Address, Purchase.ITEM_ID, " +
                                         " ItemInformation.ItemName, Purchase.QTY,  ItemInformation.UnitOfMeasure,  Purchase.WarehouseID,  Warehouse.WarehouseName,  Purchase.TotalPrice, " +
                                         " Purchase.ExpDate FROM PurchaseInfo  LEFT JOIN Purchase ON PurchaseInfo.PUCHSE_ID = Purchase.PUCHSE_ID " +
                                         " LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID  LEFT JOIN Warehouse ON Warehouse.WarehouseID = Purchase.WarehouseID " +
                                         " LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Purchase.ITEM_ID WHERE PurchaseInfo.PUCHSE_ID = '" + PUCHSE_ID + "' ", crystalReportViewer1);
        }
    }
}
