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
    public partial class frmSalesList : Form
    {
        public frmSalesList()
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
                        XmlNode l1079 = languageNode["l1079"];
                        lbl1079.Text = l1079.InnerText;

                        XmlNode l1056 = languageNode["l1056"];
                        lbl1056.Text = l1056.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081= languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

                        XmlNode ctrlSearch = languageNode["ctrlSearch"];
                        btnSearch.Text = ctrlSearch.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode l1067 = languageNode["l1067"];
                        XmlNode l1065 = languageNode["l1065"];
                        XmlNode l1184 = languageNode["l1184"];

                        dataGridView1.Columns["Column1"].HeaderText = l1067.InnerText;
                        dataGridView1.Columns["Column2"].HeaderText = l1065.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1184.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmSalesList_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnSearch.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsUtility.FillDataGrid(" SELECT  SALES_ID, SalesDate, Terminal   FROM            SalesInfo " +
                                    " WHERE        (SalesDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND SalesDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", dataGridView1);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String SALES_ID = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString() == "QuickSale")
            {
                ////// 
                frmSales frmSales = Application.OpenForms["frmSales"] as frmSales;
                if (frmSales != null)
                {
                    frmSales.WindowState = FormWindowState.Normal;
                    frmSales.BringToFront();
                    frmSales.Activate();
                }
                else
                {
                    frmSales = new frmSales(SALES_ID);
                    frmSales.MdiParent = this.ParentForm;
                    frmSales.Dock = DockStyle.Fill;
                    frmSales.Show();
                }
                ///////////
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString() == "POS")
            {
                ////// 
                frmPOS frmPOS = Application.OpenForms["frmPOS"] as frmPOS;
                if (frmPOS != null)
                {
                    frmPOS.WindowState = FormWindowState.Normal;
                    frmPOS.BringToFront();
                    frmPOS.Activate();
                }
                else
                {
                    frmPOS = new frmPOS(SALES_ID);
                    frmPOS.MdiParent = this.ParentForm;
                    frmPOS.Dock = DockStyle.Fill;
                    frmPOS.Show();
                }
                ///////////
            }
            else { }
        }
    }
}
