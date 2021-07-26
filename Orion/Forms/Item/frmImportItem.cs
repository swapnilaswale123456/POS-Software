using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmImportItem : Form
    {
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public frmImportItem()
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
                        XmlNode l1049 = languageNode["l1049"];
                        lbl1049.Text = l1049.InnerText;

                        XmlNode l1050 = languageNode["l1050"];
                        lbl1050.Text = l1050.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

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

        private void frmImportItem_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LoadLanguegePack();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                OpenFileDialog.Title = "Microsoft Excel File...";
                OpenFileDialog.Filter = "Excel Files (xlsx)|*.xlsx;";
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = OpenFileDialog.FileName;
                    try
                    {
                        string conStr, sheetName;
                        conStr = string.Format(Excel07ConString, txtFilePath.Text, "YES");
                        using (OleDbConnection con = new OleDbConnection(conStr))
                        {
                            using (OleDbCommand cmd = new OleDbCommand())
                            {
                                cmd.Connection = con;
                                con.Open();
                                DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                con.Close();
                            }
                        }
                        using (OleDbConnection con = new OleDbConnection(conStr))
                        {
                            using (OleDbCommand cmd = new OleDbCommand())
                            {
                                using (OleDbDataAdapter oda = new OleDbDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmd.CommandText = "SELECT * From [" + sheetName + "]";
                                    cmd.Connection = con;
                                    con.Open();
                                    oda.SelectCommand = cmd;
                                    oda.Fill(dt);
                                    con.Close();
                                    dataGridView1.DataSource = dt;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                try
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        DialogResult msg = new DialogResult();
                        msg = MessageBox.Show("Total " + dataGridView1.RowCount.ToString() + " product(s) found. Click Yes to save this data.", "Import Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {
                            int i = 0;
                            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                string ItemName;
                                try { ItemName = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString(); }
                                catch { ItemName = ""; }

                                string UnitOfMeasure;
                                try { UnitOfMeasure = dataGridView1.Rows[i].Cells["UnitOfMeasure"].Value.ToString(); }
                                catch { UnitOfMeasure = ""; }

                                string Batch;
                                try { Batch = dataGridView1.Rows[i].Cells["Batch"].Value.ToString(); }
                                catch { Batch = ""; }

                                double GROUP_ID;
                                try { GROUP_ID = clsUtility.num_repl(dataGridView1.Rows[i].Cells["GROUP_ID"].Value.ToString()); }
                                catch { GROUP_ID = 0; }

                                string Barcode;
                                try { Barcode = dataGridView1.Rows[i].Cells["Barcode"].Value.ToString(); }
                                catch { Barcode = ""; }

                                double Cost;
                                try { Cost = clsUtility.num_repl(dataGridView1.Rows[i].Cells["Cost"].Value.ToString()); }
                                catch { Cost = 0; }

                                double Price;
                                try { Price = clsUtility.num_repl(dataGridView1.Rows[i].Cells["Price"].Value.ToString()); }
                                catch { Price = 0; }

                                double ReorderPoint;
                                try { ReorderPoint = clsUtility.num_repl(dataGridView1.Rows[i].Cells["ReorderPoint"].Value.ToString()); }
                                catch { ReorderPoint = 0; }

                                string VAT_Applicable;
                                try { VAT_Applicable = dataGridView1.Rows[i].Cells["VAT_Applicable"].Value.ToString(); }
                                catch { VAT_Applicable = ""; }

                                double WarehouseID;
                                try { WarehouseID = clsUtility.num_repl(dataGridView1.Rows[i].Cells["WarehouseID"].Value.ToString()); }
                                catch { WarehouseID = 0; }

                                double OpeningStock;
                                try { OpeningStock = clsUtility.num_repl(dataGridView1.Rows[i].Cells["OpeningStock"].Value.ToString()); }
                                catch { OpeningStock = 0; }

                                clsUtility.ExecuteSQLQuery(" INSERT INTO ItemInformation (ItemName,  UnitOfMeasure, Batch,  GROUP_ID,  Barcode,  Cost,  Price,  ReorderPoint, VAT_Applicable,  WarehouseID) VALUES " +
                                                           " ('" + ItemName + "',  '" + UnitOfMeasure + "', '" + Batch + "',  '" + GROUP_ID + "',  '" + Barcode + "',  '" + Cost + "',  '" + Price + "',  '" + ReorderPoint + "', '" + VAT_Applicable + "',  '" + WarehouseID + "') ");
                                clsUtility.ExecuteSQLQuery("SELECT  ITEM_ID  FROM   ItemInformation    ORDER BY ITEM_ID DESC");
                                string ITEM_ID = clsUtility.sqlDT.Rows[0]["ITEM_ID"].ToString();
                                clsUtility.ExecuteSQLQuery(" INSERT INTO Stock (ITEM_ID,  Quantity,  ExpiryDate, WarehouseID,  SHELF_ID) VALUES ('" + ITEM_ID + "',  '" + OpeningStock + "',  ' ', '" + WarehouseID + "',  0) ");
                            }
                            clsUtility.MesgBoxShow("msgSaved", "info");
                        }
                    }
                    else
                    {
                        clsUtility.MesgBoxShow("msgNotFound", "info");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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
