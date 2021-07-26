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
    public partial class frmPurchaseList : Form
    {
        public frmPurchaseList()
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
                        XmlNode l1088 = languageNode["l1088"];
                        lbl1088.Text = l1088.InnerText;

                        XmlNode l1056 = languageNode["l1056"];
                        lbl1056.Text = l1056.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        XmlNode l1099 = languageNode["l1099"];
                        XmlNode l1018 = languageNode["l1018"];

                        dataGridView1.Columns["Column1"].HeaderText = l1067.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1099.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1018.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseList_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsUtility.FillDataGrid(" SELECT PUCHSE_ID, PurchaseDate, SupplierName FROM  PurchaseInfo  LEFT JOIN Supplier ON Supplier.SUPP_ID = PurchaseInfo.SUPP_ID " +
                                    " WHERE        (PurchaseDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND PurchaseDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String PUCHSE_ID = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            frmPurchase frmPurchase = Application.OpenForms["frmPurchase"] as frmPurchase;
            if (frmPurchase != null)
            {
                frmPurchase.WindowState = FormWindowState.Normal;
                frmPurchase.BringToFront();
                frmPurchase.Activate();
            }
            else
            {
                frmPurchase = new frmPurchase(PUCHSE_ID);
                frmPurchase.MdiParent = this.ParentForm;
                frmPurchase.Dock = DockStyle.Fill;
                frmPurchase.Show();
            }
        }
    }
}
