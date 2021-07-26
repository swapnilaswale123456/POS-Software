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
    public partial class frmShelf : Form
    {
        public frmShelf()
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
                        XmlNode l1025 = languageNode["l1025"];
                        lbl1025.Text = l1025.InnerText;

                        XmlNode l1026 = languageNode["l1026"];
                        lbl1026.Text = l1026.InnerText;

                        XmlNode l1027 = languageNode["l1027"];
                        lbl1027.Text = l1027.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1027.InnerText;

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

        private void frmShelf_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnReset.PerformClick();
            LoadLanguegePack();
        }

        private void LoadData()
        {
            clsUtility.FillDataGrid("SELECT SHELF_ID ,SHELF_NAME  FROM Shelf  ORDER BY SHELF_NAME ASC", dataGridView1);
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtShelfID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtShelfName.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
            txtShelfName.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnSubmit.Enabled = true;
            txtShelfID.Text = "";
            txtShelfName.Text = "";
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtShelfName.Text))
                { errorProvider.SetError(txtShelfName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" INSERT INTO Shelf (SHELF_NAME) VALUES ('" + txtShelfName.Text + "') ");
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
                if (string.IsNullOrWhiteSpace(this.txtShelfID.Text) | string.IsNullOrWhiteSpace(this.txtShelfName.Text))
                { errorProvider.SetError(txtShelfName, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery("UPDATE  Shelf SET SHELF_NAME='" + txtShelfName.Text + "' WHERE  SHELF_ID='" + txtShelfID.Text + "'  ");
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
                if (string.IsNullOrWhiteSpace(this.txtShelfID.Text))
                { errorProvider.SetError(txtShelfID, "Required"); }
                else
                {
                    errorProvider.Clear();
                    try
                    {
                        clsUtility.ExecuteSQLQuery("DELETE FROM  Shelf WHERE  SHELF_ID='" + txtShelfID.Text + "'  ");
                        LoadData();
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
