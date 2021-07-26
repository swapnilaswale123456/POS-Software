using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmStockTransfer : Form
    {
        public frmStockTransfer()
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
                        XmlNode l1058 = languageNode["l1058"];
                        lbl1058.Text = l1058.InnerText;

                        XmlNode l1059 = languageNode["l1059"];
                        lbl1059.Text = l1059.InnerText;

                        XmlNode l1060 = languageNode["l1060"];
                        lbl1060.Text = l1060.InnerText;

                        XmlNode l1061 = languageNode["l1061"];
                        lbl1061.Text = l1061.InnerText;

                        XmlNode l1062 = languageNode["l1062"];
                        lbl1062.Text = l1062.InnerText;

                        XmlNode l1063 = languageNode["l1063"];
                        lbl1063.Text = l1063.InnerText;

                        XmlNode l1053 = languageNode["l1053"];
                        lbl1053.Text = l1053.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        lbl1030.Text = l1030.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        dataGridView1.Columns["Column9"].HeaderText = l1182.InnerText;

                        XmlNode l1034 = languageNode["l1034"];
                        XmlNode l1031 = languageNode["l1031"];

                        dataGridView1.Columns["Column1"].HeaderText = l1063.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1034.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1060.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1061.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1031.InnerText;
                        dataGridView1.Columns["Column8"].HeaderText = l1062.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData() { 
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbFromWarehouse);
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbToWarehouse);

            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  iteminformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);

            clsUtility.FillDataGrid(" SELECT        TRNS_ID, TransferDate, ItemName, Barcode, Warehouse.WarehouseName,  Warehouse1.WarehouseName, Quantity, UnitOfMeasure, Reason " +
                                    " FROM    ItemInformation INNER JOIN StockTransfer ON (ItemInformation.ITEM_ID = StockTransfer.ITEM_ID) INNER JOIN Warehouse ON (StockTransfer.FromWarehouseID = Warehouse.WarehouseID)" +
                                    " INNER JOIN Warehouse Warehouse1 ON (StockTransfer.ToWarehouseID = Warehouse1.WarehouseID) " +
                                    " WHERE        (StockTransfer.TransferDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND StockTransfer.TransferDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ORDER BY TRNS_ID DESC ", dataGridView1);
        }        

        private void frmStockTransfer_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LoadData();
            LoadLanguegePack();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (cmbFromWarehouse.SelectedValue == null | cmbFromWarehouse.SelectedIndex == -1 | cmbToWarehouse.SelectedValue == null | cmbToWarehouse.SelectedIndex == -1 | cmbItemName.SelectedValue == null | cmbItemName.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtQuantity.Text))
                { errorProvider.SetError(cmbFromWarehouse, "Required"); errorProvider.SetError(cmbToWarehouse, "Required"); errorProvider.SetError(cmbItemName, "Required"); errorProvider.SetError(txtQuantity, "Required"); }
                else if (!int.TryParse(txtQuantity.Text, out parsedValue))
                { errorProvider.SetError(txtQuantity, "Required"); return; }
                else if (cmbFromWarehouse.SelectedValue.ToString() == cmbToWarehouse.SelectedValue.ToString())
                { errorProvider.SetError(cmbFromWarehouse, "Required"); errorProvider.SetError(cmbToWarehouse, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery("SELECT * FROM Stock  WHERE  WarehouseID= '" + cmbFromWarehouse.SelectedValue.ToString() + "' AND ITEM_ID= '" + cmbItemName.SelectedValue.ToString() + "' AND  (Quantity >= '" + txtQuantity.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        errorProvider.Clear();
                        clsUtility.ExecuteSQLQuery(" INSERT INTO StockTransfer(TransferDate,ITEM_ID,FromWarehouseID,ToWarehouseID,Quantity,Reason) " +
                                                   "  VALUES ( '" + dtpTransferDate.Value.Date.ToString("yyyy-MM-dd") + "' , '" + cmbItemName.SelectedValue.ToString() + "' ,'" + cmbFromWarehouse.SelectedValue.ToString() + "','" + cmbToWarehouse.SelectedValue.ToString() + "','" + clsUtility.num_repl(txtQuantity.Text) + "','" + txtReason.Text + "') ");
                        clsUtility.ExecuteSQLQuery(" UPDATE Stock SET Quantity= Quantity - '" + clsUtility.num_repl(txtQuantity.Text) + "'  WHERE  (WarehouseID ='" + cmbFromWarehouse.SelectedValue.ToString() + "')  AND (ITEM_ID ='" + cmbItemName.SelectedValue.ToString() + "') ");
                        clsUtility.ExecuteSQLQuery(" SELECT * FROM Stock WHERE  (WarehouseID ='" + cmbToWarehouse.SelectedValue.ToString() + "')  AND (ITEM_ID ='" + cmbItemName.SelectedValue.ToString() + "')  ");
                        if (clsUtility.sqlDT.Rows.Count > 0)
                        { clsUtility.ExecuteSQLQuery(" UPDATE Stock SET Quantity= Quantity + '" + clsUtility.num_repl(txtQuantity.Text) + "'  WHERE  (WarehouseID ='" + cmbToWarehouse.SelectedValue.ToString() + "')  AND (ITEM_ID ='" + cmbItemName.SelectedValue.ToString() + "') "); }
                        else { clsUtility.ExecuteSQLQuery(" INSERT INTO Stock ( Quantity,WarehouseID,ITEM_ID,  SHELF_ID) VALUES  ('" + clsUtility.num_repl(txtQuantity.Text) + "', '" + cmbToWarehouse.SelectedValue.ToString() + "', '" + cmbItemName.SelectedValue.ToString() + "', 0) "); }
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgSaved", "info");
                    }
                    else { errorProvider.SetError(txtQuantity, "Required"); }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cmbFromWarehouse.SelectedValue == null) | !(cmbFromWarehouse.SelectedIndex == -1) | !(cmbItemName.SelectedValue == null) | !(cmbItemName.SelectedIndex == -1))
            {
                clsUtility.ExecuteSQLQuery("SELECT * FROM Stock  WHERE  WarehouseID= '" + cmbFromWarehouse.SelectedValue.ToString() + "' AND ITEM_ID= '" + cmbItemName.SelectedValue.ToString() + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtQuantity.Text = clsUtility.sqlDT.Rows[0]["Quantity"].ToString();
                }
                else { txtQuantity.Text = "0"; }
            }
            else { txtQuantity.Text = "0"; }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "";
            txtReason.Text = "";
            dtpTransferDate.Value = DateTime.Today;
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsUtility.FillDataGrid(" SELECT        TRNS_ID, TransferDate, ItemName, Barcode, Warehouse.WarehouseName,  Warehouse1.WarehouseName, Quantity, UnitOfMeasure, Reason " +
                       " FROM    ItemInformation INNER JOIN StockTransfer ON (ItemInformation.ITEM_ID = StockTransfer.ITEM_ID) INNER JOIN Warehouse ON (StockTransfer.FromWarehouseID = Warehouse.WarehouseID)" +
                       " INNER JOIN Warehouse Warehouse1 ON (StockTransfer.ToWarehouseID = Warehouse1.WarehouseID) " +
                       " WHERE        (StockTransfer.TransferDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND StockTransfer.TransferDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ORDER BY TRNS_ID DESC ", dataGridView1);
        }

    }
}
