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
    public partial class frmReportPurchase : Form
    {
        public frmReportPurchase()
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
                        XmlNode l1135 = languageNode["l1135"];
                        lbl1135.Text = l1135.InnerText;

                        XmlNode l1128 = languageNode["l1128"];
                        rbToday.Text = l1128.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode l1136 = languageNode["l1136"];
                        rbSearchByDate.Text = l1136.InnerText;

                        XmlNode l1137 = languageNode["l1137"];
                        rbSearchBySupplier.Text = l1137.InnerText;

                        XmlNode l1134 = languageNode["l1134"];
                        rbSearchByItem.Text = l1134.InnerText;

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

        private void frmReportPurchase_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);
            clsUtility.FillComboBox(" SELECT  SUPP_ID, SupplierName  FROM  Supplier  ORDER BY SupplierName", "SUPP_ID", "SupplierName", cmbSupplier);
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
                //Today
                clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                clsUtility.Preview__PurchaseDetails(" SELECT  PurchaseInfo.PUCHSE_ID,  PurchaseInfo.PurchaseDate,  PurchaseInfo.ItemPrice,  PurchaseInfo.Discount,  PurchaseInfo.GrandTotal,  PurchaseInfo.Due, " +
                                                    " PurchaseInfo.CardPay,  PurchaseInfo.CashPay,  PurchaseInfo.SUPP_ID,  Supplier.SupplierName,  Supplier.Address,  Purchase.ITEM_ID,  ItemInformation.ItemName, " +
                                                    " Purchase.QTY,  ItemInformation.UnitOfMeasure,  Purchase.WarehouseID,  Warehouse.WarehouseName,  Purchase.TotalPrice,  Purchase.ExpDate FROM  PurchaseInfo " +
                                                    " LEFT JOIN Purchase ON PurchaseInfo.PUCHSE_ID = Purchase.PUCHSE_ID  LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID " +
                                                    " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Purchase.WarehouseID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Purchase.ITEM_ID " +
                                                    " WHERE  PurchaseInfo.PurchaseDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbSearchByDate.Checked)
            {
                //Search by date
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__PurchaseDetails(" SELECT  PurchaseInfo.PUCHSE_ID,  PurchaseInfo.PurchaseDate,  PurchaseInfo.ItemPrice,  PurchaseInfo.Discount,  PurchaseInfo.GrandTotal,  PurchaseInfo.Due, " +
                                                    " PurchaseInfo.CardPay,  PurchaseInfo.CashPay,  PurchaseInfo.SUPP_ID,  Supplier.SupplierName,  Supplier.Address,  Purchase.ITEM_ID,  ItemInformation.ItemName, " +
                                                    " Purchase.QTY,  ItemInformation.UnitOfMeasure,  Purchase.WarehouseID,  Warehouse.WarehouseName,  Purchase.TotalPrice,  Purchase.ExpDate FROM  PurchaseInfo " +
                                                    " LEFT JOIN Purchase ON PurchaseInfo.PUCHSE_ID = Purchase.PUCHSE_ID  LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID " +
                                                    " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Purchase.WarehouseID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Purchase.ITEM_ID " +
                                                    " WHERE  PurchaseInfo.PurchaseDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  PurchaseInfo.PurchaseDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbSearchBySupplier.Checked)
            {
                //Search by supplier
                if (cmbSupplier.SelectedIndex == -1 | cmbSupplier.SelectedValue == null) { errorProvider.SetError(cmbSupplier, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__PurchaseDetails(" SELECT  PurchaseInfo.PUCHSE_ID,  PurchaseInfo.PurchaseDate,  PurchaseInfo.ItemPrice,  PurchaseInfo.Discount,  PurchaseInfo.GrandTotal,  PurchaseInfo.Due, " +
                                                        " PurchaseInfo.CardPay,  PurchaseInfo.CashPay,  PurchaseInfo.SUPP_ID,  Supplier.SupplierName,  Supplier.Address,  Purchase.ITEM_ID,  ItemInformation.ItemName, " +
                                                        " Purchase.QTY,  ItemInformation.UnitOfMeasure,  Purchase.WarehouseID,  Warehouse.WarehouseName,  Purchase.TotalPrice,  Purchase.ExpDate FROM  PurchaseInfo " +
                                                        " LEFT JOIN Purchase ON PurchaseInfo.PUCHSE_ID = Purchase.PUCHSE_ID  LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID " +
                                                        " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Purchase.WarehouseID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Purchase.ITEM_ID " +
                                                        " WHERE  PurchaseInfo.PurchaseDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  PurchaseInfo.PurchaseDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "'  AND PurchaseInfo.SUPP_ID = '" + cmbSupplier.SelectedValue.ToString() + "' ", crystalReportViewer1);
                }
                //
            }
            else if (rbSearchByItem.Checked)
            {
                //Search by Item
                if (cmbItemName.SelectedIndex == -1 | cmbItemName.SelectedValue == null) { errorProvider.SetError(cmbItemName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__PurchaseDetails(" SELECT  PurchaseInfo.PUCHSE_ID,  PurchaseInfo.PurchaseDate,  PurchaseInfo.ItemPrice,  PurchaseInfo.Discount,  PurchaseInfo.GrandTotal,  PurchaseInfo.Due, " +
                                                        " PurchaseInfo.CardPay,  PurchaseInfo.CashPay,  PurchaseInfo.SUPP_ID,  Supplier.SupplierName,  Supplier.Address,  Purchase.ITEM_ID,  ItemInformation.ItemName, " +
                                                        " Purchase.QTY,  ItemInformation.UnitOfMeasure,  Purchase.WarehouseID,  Warehouse.WarehouseName,  Purchase.TotalPrice,  Purchase.ExpDate FROM  PurchaseInfo " +
                                                        " LEFT JOIN Purchase ON PurchaseInfo.PUCHSE_ID = Purchase.PUCHSE_ID  LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID " +
                                                        " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Purchase.WarehouseID  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Purchase.ITEM_ID " +
                                                        " WHERE  PurchaseInfo.PurchaseDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  PurchaseInfo.PurchaseDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "'  AND Purchase.ITEM_ID= '" + cmbItemName.SelectedValue.ToString() + "' ", crystalReportViewer1);
                }
                //
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
