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
    public partial class frmReportItem : Form
    {
        public frmReportItem()
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
                        XmlNode l1121 = languageNode["l1121"];
                        lbl1121.Text = l1121.InnerText;

                        XmlNode l1122 = languageNode["l1122"];
                        rbAll.Text = l1122.InnerText;

                        XmlNode l1123 = languageNode["l1123"];
                        rbGroup.Text = l1123.InnerText;

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

        private void frmReportItem_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  GROUP_ID, GROUP_NAME  FROM  ItemGroup  ORDER BY GROUP_NAME", "GROUP_ID", "GROUP_NAME", cmbGroup);
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
            if (rbGroup.Checked)
            {
                if (cmbGroup.SelectedIndex == -1 | cmbGroup.SelectedValue == null) { errorProvider.SetError(cmbGroup, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.Preview__ListOfItem(" SELECT ITEM_ID, ItemName, UnitOfMeasure, Batch,  ItemInformation.GROUP_ID, GROUP_NAME, Barcode, Cost, Price, ReorderPoint, VAT_Applicable, WarehouseName, PhotoFileName " +
                                    " FROM   ItemInformation   LEFT JOIN Warehouse ON Warehouse.WarehouseID = ItemInformation.WarehouseID " +
                                    " LEFT JOIN ItemGroup ON ItemGroup.GROUP_ID = ItemInformation.GROUP_ID WHERE  (ItemInformation.GROUP_ID = '" + cmbGroup.SelectedValue.ToString() + "') ", crystalReportViewer1);
                }
            }
            else
            {
                clsUtility.Preview__ListOfItem(" SELECT ITEM_ID, ItemName, UnitOfMeasure, Batch,  ItemInformation.GROUP_ID, GROUP_NAME, Barcode, Cost, Price, ReorderPoint, VAT_Applicable, WarehouseName, PhotoFileName " +
                                " FROM   ItemInformation   LEFT JOIN Warehouse ON Warehouse.WarehouseID = ItemInformation.WarehouseID " +
                                " LEFT JOIN ItemGroup ON ItemGroup.GROUP_ID = ItemInformation.GROUP_ID ", crystalReportViewer1);
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
