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
    public partial class frmWarehouse : Form
    {
        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnReset.PerformClick();
            LoadLanguegePack();
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
                        XmlNode l1022 = languageNode["l1022"];
                        lbl1022.Text = l1022.InnerText;

                        XmlNode l1023 = languageNode["l1023"];
                        lbl1023.Text = l1023.InnerText;

                        XmlNode l1024 = languageNode["l1024"];
                        lbl1024.Text = l1024.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1024.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1004.InnerText;

                        XmlNode l1182 = languageNode["l1182"];
                        dataGridView1.Columns["Column1"].HeaderText = l1182.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlAlter = languageNode["ctrlAlter"];
                        btnAlter.Text = ctrlAlter.InnerText;

                        XmlNode ctrlDelete = languageNode["ctrlDelete"];
                        btnDelete.Text = ctrlDelete.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;
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
            clsUtility.FillDataGrid("SELECT WarehouseID ,WarehouseName, WarehouseAddress FROM Warehouse  ORDER BY WarehouseName ASC", dataGridView1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWarehouseID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtWarehouseName.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            txtWarehouseAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
            txtWarehouseName.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtWarehouseID.Text = "";
            txtWarehouseName.Text = "";
            txtWarehouseAddress.Text = "";
            LoadData();
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
                if (string.IsNullOrWhiteSpace(this.txtWarehouseName.Text) | string.IsNullOrWhiteSpace(this.txtWarehouseAddress.Text))
                { errorProvider.SetError(txtWarehouseName, "Required"); errorProvider.SetError(txtWarehouseAddress, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO Warehouse (WarehouseName, WarehouseAddress) VALUES ('" + txtWarehouseName.Text + "', '" + txtWarehouseAddress.Text + "') ");
                        LoadData();
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgSaved", "info");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtWarehouseID.Text) | string.IsNullOrWhiteSpace(this.txtWarehouseName.Text) | string.IsNullOrWhiteSpace(this.txtWarehouseAddress.Text))
                { errorProvider.SetError(txtWarehouseName, "Required"); errorProvider.SetError(txtWarehouseAddress, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery("UPDATE  Warehouse SET WarehouseName='" + txtWarehouseName.Text + "', WarehouseAddress='" + txtWarehouseAddress.Text + "' WHERE  WarehouseID='" + txtWarehouseID.Text + "'  ");
                        LoadData();
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgUpdate", "info");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtWarehouseID.Text))
                { errorProvider.SetError(txtWarehouseID, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        errorProvider.Clear();
                        clsUtility.ExecuteSQLQuery(" DELETE FROM  Warehouse  WHERE WarehouseID ='" + txtWarehouseID.Text + "'  ");
                        btnReset.PerformClick();
                        clsUtility.MesgBoxShow("msgDelete", "info");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
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
