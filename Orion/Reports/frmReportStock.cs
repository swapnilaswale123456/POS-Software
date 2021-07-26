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
    public partial class frmReportStock : Form
    {
        public frmReportStock()
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
                        XmlNode l1124 = languageNode["l1124"];
                        lbl1124.Text = l1124.InnerText;

                        XmlNode l1122 = languageNode["l1122"];
                        rbAll.Text = l1122.InnerText;

                        XmlNode l1123 = languageNode["l1123"];
                        rbGroup.Text = l1123.InnerText;

                        XmlNode l1125 = languageNode["l1125"];
                        rbWarehouse.Text = l1125.InnerText;

                        XmlNode l1126 = languageNode["l1126"];
                        rbShelf.Text = l1126.InnerText;

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

        private void frmReportStock_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbWarehouse);
            clsUtility.FillComboBox(" SELECT  GROUP_ID, GROUP_NAME  FROM  ItemGroup  ORDER BY GROUP_NAME", "GROUP_ID", "GROUP_NAME", cmbGroup);
            clsUtility.FillComboBox(" SELECT  SHELF_ID, SHELF_NAME  FROM  Shelf  ORDER BY SHELF_NAME", "SHELF_ID", "SHELF_NAME", cmbShelf);
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
                if (rbAll.Checked)
                {
                    ////All stock report
                    clsUtility.Preview__CurrentStock(" SELECT  Stock.ITEM_ID, ItemName, Quantity, UnitOfMeasure, Barcode, Cost, Price, ExpiryDate,   Stock.WarehouseID, Stock.SHELF_ID,SHELF_NAME,WarehouseName " +
                                                     " FROM  Stock  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Stock.ITEM_ID  LEFT JOIN Shelf ON Shelf.SHELF_ID = Stock.SHELF_ID " +
                                                     " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Stock.WarehouseID ", crystalReportViewer1);
                    //
                }
                else if (rbGroup.Checked)
                {
                    ////All stock report group wise
                    if (cmbGroup.SelectedIndex == -1 | cmbGroup.SelectedValue == null) { errorProvider.SetError(cmbGroup, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        clsUtility.Preview__CurrentStock(" SELECT  Stock.ITEM_ID, ItemName, Quantity, UnitOfMeasure, Barcode, Cost, Price, ExpiryDate,   Stock.WarehouseID, Stock.SHELF_ID,SHELF_NAME,WarehouseName " +
                                     " FROM  Stock  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Stock.ITEM_ID  LEFT JOIN Shelf ON Shelf.SHELF_ID = Stock.SHELF_ID " +
                                     " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Stock.WarehouseID " +
                                     " WHERE (ItemInformation.GROUP_ID = '" + cmbGroup.SelectedValue.ToString() + "') ", crystalReportViewer1);
                    }
                    //
                }
                else if (rbWarehouse.Checked)
                {
                    ////All stock report warehouse wise
                    if (cmbWarehouse.SelectedIndex == -1 | cmbWarehouse.SelectedValue == null) { errorProvider.SetError(cmbWarehouse, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        clsUtility.Preview__CurrentStock(" SELECT  Stock.ITEM_ID, ItemName, Quantity, UnitOfMeasure, Barcode, Cost, Price, ExpiryDate,   Stock.WarehouseID, Stock.SHELF_ID,SHELF_NAME,WarehouseName " +
                                     " FROM  Stock  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Stock.ITEM_ID  LEFT JOIN Shelf ON Shelf.SHELF_ID = Stock.SHELF_ID " +
                                     " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Stock.WarehouseID " +
                                     " WHERE (Stock.WarehouseID = '" + cmbWarehouse.SelectedValue.ToString() + "') ", crystalReportViewer1);
                    }
                    //
                }
                else if (rbShelf.Checked)
                {
                    ////All stock report shelf wise
                    if (cmbShelf.SelectedIndex == -1 | cmbShelf.SelectedValue == null) { errorProvider.SetError(cmbShelf, "Required"); }
                    else
                    {
                        errorProvider.Clear();
                        clsUtility.Preview__CurrentStock(" SELECT  Stock.ITEM_ID, ItemName, Quantity, UnitOfMeasure, Barcode, Cost, Price, ExpiryDate,   Stock.WarehouseID, Stock.SHELF_ID,SHELF_NAME,WarehouseName " +
                                     " FROM  Stock  LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = Stock.ITEM_ID  LEFT JOIN Shelf ON Shelf.SHELF_ID = Stock.SHELF_ID " +
                                     " LEFT JOIN Warehouse ON Warehouse.WarehouseID = Stock.WarehouseID " +
                                     " WHERE (Stock.SHELF_ID = '" + cmbShelf.SelectedValue.ToString() + "') ", crystalReportViewer1);
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
