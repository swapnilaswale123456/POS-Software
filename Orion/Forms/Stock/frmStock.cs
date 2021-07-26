using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orion
{
    public partial class frmStock : Form
    {
        public frmStock()
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
                        XmlNode l1055 = languageNode["l1055"];
                        lbl1055.Text = l1055.InnerText;

                        XmlNode l1048 = languageNode["l1048"];
                        lbl1048.Text = l1048.InnerText;

                        XmlNode l1033 = languageNode["l1033"];
                        lbl1033.Text = l1033.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1042 = languageNode["l1042"];
                        lbl1042.Text = l1042.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        dataGridView1.Columns["Column12"].HeaderText = l1182.InnerText;

                        XmlNode l1031 = languageNode["l1031"];
                        XmlNode l1032 = languageNode["l1032"];
                        XmlNode l1037 = languageNode["l1037"];
                        XmlNode l1038 = languageNode["l1038"];
                        XmlNode l1039 = languageNode["l1039"];
                        XmlNode l1036 = languageNode["l1036"];

                        XmlNode l1053 = languageNode["l1053"];
                        XmlNode l1043 = languageNode["l1043"];

                        XmlNode l1030 = languageNode["l1030"];
                        XmlNode l1034 = languageNode["l1034"];

                        dataGridView1.Columns["Column2"].HeaderText = l1030.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1034.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1053.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1031.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1037.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1038.InnerText;
                        dataGridView1.Columns["Column8"].HeaderText = l1042.InnerText;
                        dataGridView1.Columns["Column9"].HeaderText = l1043.InnerText;
                        dataGridView1.Columns["Column10"].HeaderText = l1039.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LoadData();
            LoadLanguegePack();
        }

        private void LoadData() {
            clsUtility.FillComboBox(" SELECT  GROUP_ID, GROUP_NAME  FROM  ItemGroup  ORDER BY GROUP_NAME", "GROUP_ID", "GROUP_NAME", cmbGroup);
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbWarehouse);
            clsUtility.FillDataGrid(" SELECT        STOCK_ID, ItemName, Barcode, Quantity, UnitOfMeasure, Cost, Price, WarehouseName, SHELF_NAME, ReorderPoint, Stock.WarehouseID, Stock.ITEM_ID " +
                                    " FROM            Stock LEFT OUTER JOIN  Shelf ON Stock.SHELF_ID = Shelf.SHELF_ID LEFT OUTER JOIN  Warehouse ON Stock.WarehouseID = Warehouse.WarehouseID LEFT OUTER JOIN   ItemInformation ON Stock.ITEM_ID = ItemInformation.ITEM_ID ", dataGridView1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearchByGroup_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue == null | cmbGroup.SelectedIndex == -1)
            {
                LoadData();
            }
            else
            {
                try
                {
                    clsUtility.FillDataGrid(" SELECT   STOCK_ID, ItemName, Barcode, Quantity, UnitOfMeasure, Cost, Price, WarehouseName, SHELF_NAME, ReorderPoint , Stock.WarehouseID, Stock.ITEM_ID " +
                                            " FROM   Stock LEFT OUTER JOIN  Shelf ON Stock.SHELF_ID = Shelf.SHELF_ID LEFT OUTER JOIN  Warehouse ON Stock.WarehouseID = Warehouse.WarehouseID LEFT OUTER JOIN   ItemInformation ON Stock.ITEM_ID = ItemInformation.ITEM_ID " +
                                            " WHERE   (ItemInformation.GROUP_ID='" + cmbGroup.SelectedValue.ToString() + "') ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void btnSearchByWarehouse_Click(object sender, EventArgs e)
        {
            if (cmbWarehouse.SelectedValue == null | cmbWarehouse.SelectedIndex == -1)
            {
                LoadData();
            }
            else
            {
                try
                {
                    clsUtility.FillDataGrid(" SELECT   STOCK_ID, ItemName, Barcode, Quantity, UnitOfMeasure, Cost, Price, WarehouseName, SHELF_NAME, ReorderPoint, Stock.WarehouseID, Stock.ITEM_ID " +
                                            " FROM   Stock LEFT OUTER JOIN  Shelf ON Stock.SHELF_ID = Shelf.SHELF_ID LEFT OUTER JOIN  Warehouse ON Stock.WarehouseID = Warehouse.WarehouseID LEFT OUTER JOIN   ItemInformation ON Stock.ITEM_ID = ItemInformation.ITEM_ID " +
                                            " WHERE   (Stock.WarehouseID='" + cmbWarehouse.SelectedValue.ToString() + "') ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ITEM_ID = dataGridView1.Rows[e.RowIndex].Cells["Column12"].Value.ToString();
            string WarehouseID = dataGridView1.Rows[e.RowIndex].Cells["Column11"].Value.ToString();
            frmItemInformation frmItemInformation = Application.OpenForms["frmItemInformation"] as frmItemInformation;
            if (frmItemInformation != null)
            {
                frmItemInformation.WindowState = FormWindowState.Normal;
                frmItemInformation.BringToFront();
                frmItemInformation.Activate();
            }
            else
            {
                frmItemInformation = new frmItemInformation(ITEM_ID, WarehouseID);
                frmItemInformation.MdiParent = this.ParentForm;
                frmItemInformation.Dock = DockStyle.Fill;
                frmItemInformation.Show();
            }
        }

        private void SaveExportedData(DataGridView DatGrdV, string filename)
        {
            string dataExport = "";
            string fColumnHeader = "";
            for (int j = 0; j < DatGrdV.Columns.Count; j++)
                fColumnHeader = fColumnHeader.ToString() + Convert.ToString(DatGrdV.Columns[j].HeaderText) + "\t";
            dataExport += fColumnHeader + "\r\n";
            for (int i = 0; i < DatGrdV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < DatGrdV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(DatGrdV.Rows[i].Cells[j].Value) + "\t";
                dataExport += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(dataExport);
            FileStream FleSys = new FileStream(filename, FileMode.Create);
            BinaryWriter BinryWrtr = new BinaryWriter(FleSys);
            BinryWrtr.Write(output, 0, output.Length);
            BinryWrtr.Flush();
            BinryWrtr.Close();
            FleSys.Close();
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "StockListOfItem.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {  
                try
                {
                    SaveExportedData(dataGridView1, sfd.FileName);
                    clsUtility.MesgBoxShow("msgSaved", "info");
                }
                catch (Exception )
                { clsUtility.MesgBoxShow("msgPermission", "err"); }
            }
        }

        private void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.cmbParameter.Text))
            {
                errorProvider.SetError(cmbParameter, "Required");
                LoadData();
            }
            else if (string.IsNullOrWhiteSpace(this.txtCriteria.Text))
            {
                errorProvider.SetError(txtCriteria, "Required");
                LoadData();
            }
            else
            {
                try
                {
                    errorProvider.Clear();
                    clsUtility.FillDataGrid(" SELECT  STOCK_ID, ItemName, Barcode, Quantity, UnitOfMeasure, Cost, Price, WarehouseName, SHELF_NAME, ReorderPoint, Stock.WarehouseID, Stock.ITEM_ID " +
                                            " FROM   Stock LEFT OUTER JOIN  Shelf ON Stock.SHELF_ID = Shelf.SHELF_ID LEFT OUTER JOIN  Warehouse ON Stock.WarehouseID = Warehouse.WarehouseID LEFT OUTER JOIN   ItemInformation ON Stock.ITEM_ID = ItemInformation.ITEM_ID " +
                                            " WHERE   (ItemInformation." + cmbParameter.Text + " LIKE '%" + txtCriteria.Text + "%') ", dataGridView1);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        } 

    }
}
