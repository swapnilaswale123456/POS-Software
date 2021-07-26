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
    public partial class frmBadStock : Form
    {
        public frmBadStock()
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
                        XmlNode l1064 = languageNode["l1064"];
                        lbl1064.Text = l1064.InnerText;

                        XmlNode l1059 = languageNode["l1059"];
                        lbl1059.Text = l1059.InnerText;

                        XmlNode l1053 = languageNode["l1053"];
                        lbl1053.Text = l1053.InnerText;


                        XmlNode l1030 = languageNode["l1030"];
                        lbl1030.Text = l1030.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode l1065 = languageNode["l1065"];
                        lbl1065.Text = l1065.InnerText;

                        XmlNode l1062 = languageNode["l1062"];
                        lbl1062.Text = l1062.InnerText;

                        XmlNode l1042 = languageNode["l1042"];
                        lbl1042.Text = l1042.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlDelete = languageNode["ctrlDelete"];
                        btnDelete.Text = ctrlDelete.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        XmlNode l1031 = languageNode["l1031"];
                        dataGridView1.Columns["Column1"].HeaderText = l1182.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1031.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1065.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1042.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1062.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbWarehouse);
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItemName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBadStock_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            txtQuantity.Text = "";
            txtID.Text = "";
            txtReason.Text = "";
            dtpTransferDate.Value = DateTime.Today;
            btnSearch.PerformClick();
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
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
                if (cmbWarehouse.SelectedValue == null | cmbWarehouse.SelectedIndex == -1 | cmbItemName.SelectedValue == null | cmbItemName.SelectedIndex == -1 | string.IsNullOrWhiteSpace(this.txtQuantity.Text))
                { errorProvider.SetError(cmbWarehouse, "Required"); errorProvider.SetError(cmbItemName, "Required"); errorProvider.SetError(txtQuantity, "Required"); }
                else if (!int.TryParse(txtQuantity.Text, out parsedValue))
                { errorProvider.SetError(txtQuantity, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery("SELECT * FROM Stock  WHERE  WarehouseID= '" + cmbWarehouse.SelectedValue.ToString() + "' AND ITEM_ID= '" + cmbItemName.SelectedValue.ToString() + "' AND  (Quantity >= '" + txtQuantity.Text + "') ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO BadStock (WarehouseID, ITEM_ID, Quantity, SoldDate, Reason) VALUES ('" + cmbWarehouse.SelectedValue.ToString() + "', '" + cmbItemName.SelectedValue.ToString() + "', '" + clsUtility.num_repl(txtQuantity.Text) + "', '" + dtpTransferDate.Value.Date.ToString("yyyy-MM-dd") + "',  '" + txtReason.Text + "') ");
                        clsUtility.ExecuteSQLQuery(" UPDATE Stock SET Quantity= Quantity - '" + clsUtility.num_repl(txtQuantity.Text) + "'  WHERE  (WarehouseID ='" + cmbWarehouse.SelectedValue.ToString() + "')  AND (ITEM_ID ='" + cmbItemName.SelectedValue.ToString() + "') ");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsUtility.FillDataGrid(" SELECT BDS_ID, ItemName, Quantity, UnitOfMeasure, SoldDate, WarehouseName, Reason " +
                                    " FROM  BadStock  LEFT JOIN Warehouse ON Warehouse.WarehouseID = BadStock.WarehouseID " +
                                    "   LEFT JOIN ItemInformation ON ItemInformation.ITEM_ID = BadStock.ITEM_ID " +
                                    " WHERE  BadStock.SoldDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  BadStock.SoldDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            clsUtility.ExecuteSQLQuery(" SELECT * FROM BadStock WHERE BDS_ID='" + txtID.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                txtReason.Text = clsUtility.sqlDT.Rows[0]["Reason"].ToString();
                txtQuantity.Text = clsUtility.sqlDT.Rows[0]["Quantity"].ToString();
                dtpTransferDate.Text = clsUtility.sqlDT.Rows[0]["SoldDate"].ToString();
                cmbItemName.SelectedValue = clsUtility.sqlDT.Rows[0]["ITEM_ID"].ToString();
                cmbWarehouse.SelectedValue = clsUtility.sqlDT.Rows[0]["WarehouseID"].ToString();
                btnSubmit.Enabled = false;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtID.Text)) { errorProvider.SetError(cmbItemName, "Required"); }
                else
                {
                    clsUtility.ExecuteSQLQuery(" SELECT * FROM BadStock WHERE BDS_ID='" + txtID.Text + "' ");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        txtReason.Text = clsUtility.sqlDT.Rows[0]["Reason"].ToString();
                        txtQuantity.Text = clsUtility.sqlDT.Rows[0]["Quantity"].ToString();
                        cmbItemName.SelectedValue = clsUtility.sqlDT.Rows[0]["ITEM_ID"].ToString();
                        cmbWarehouse.SelectedValue = clsUtility.sqlDT.Rows[0]["WarehouseID"].ToString();
                        clsUtility.ExecuteSQLQuery(" UPDATE Stock SET Quantity= Quantity + '" + clsUtility.num_repl(txtQuantity.Text) + "'  WHERE  (WarehouseID ='" + cmbWarehouse.SelectedValue.ToString() + "')  AND (ITEM_ID ='" + cmbItemName.SelectedValue.ToString() + "') ");
                        clsUtility.ExecuteSQLQuery(" DELETE FROM BadStock  WHERE BDS_ID='" + txtID.Text + "'   ");
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgDelete", "info");
                    }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }
    }
}
