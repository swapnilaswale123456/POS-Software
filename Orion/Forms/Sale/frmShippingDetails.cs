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
    public partial class frmShippingDetails : Form
    {
        public frmShippingDetails(string SALES_ID)
        {
            InitializeComponent();
            txtInvoiceNo.Text = SALES_ID;
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
                        XmlNode l1067 = languageNode["l1067"];
                        lbl1067.Text = l1067.InnerText;

                        XmlNode l1082 = languageNode["l1082"];
                        lbl1082.Text = l1082.InnerText;

                        XmlNode l1083 = languageNode["l1083"];
                        lbl1083.Text = l1083.InnerText;

                        XmlNode l1084 = languageNode["l1084"];
                        lbl1084.Text = l1084.InnerText;

                        XmlNode l1085 = languageNode["l1085"];
                        lbl1085.Text = l1085.InnerText;
                        lbl1085_2.Text = l1085.InnerText;

                        XmlNode l1004 = languageNode["l1004"];
                        lbl1004.Text = l1004.InnerText;
                        lbl1004_2.Text = l1004.InnerText;

                        XmlNode l1005 = languageNode["l1005"];
                        lbl1005.Text = l1005.InnerText;
                        lbl1005_2.Text = l1005.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSave.Text = ctrlSave.InnerText;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShippingDetails_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();

            clsUtility.FillComboBox(" SELECT  CUST_ID, CustomerName  FROM  Customer  ORDER BY CustomerName", "CUST_ID", "CustomerName", cmbCustomer);
            clsUtility.ExecuteSQLQuery("SELECT * FROM SalesInfo  WHERE  SALES_ID= '" + txtInvoiceNo.Text + "' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                txtShippingName.Text = clsUtility.sqlDT.Rows[0]["ShippingName"].ToString();
                txtShippingAddress.Text = clsUtility.sqlDT.Rows[0]["ShippingAddress"].ToString();
                txtShippingContact.Text = clsUtility.sqlDT.Rows[0]["ShippingContact"].ToString();
                txtComments.Text = clsUtility.sqlDT.Rows[0]["Comment"].ToString();
                cmbCustomer.SelectedValue = clsUtility.sqlDT.Rows[0]["CUST_ID"].ToString();
            }

            txtShippingName.Focus();
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
            if (!(cmbCustomer.SelectedValue == null) | !(cmbCustomer.SelectedIndex == -1))
            {
                clsUtility.ExecuteSQLQuery("SELECT * FROM Customer  WHERE  CUST_ID= '" + clsUtility.num_repl(cmbCustomer.SelectedValue.ToString()) + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtBillingAddress.Text = clsUtility.sqlDT.Rows[0]["Address"].ToString();
                    txtBillingContact.Text = clsUtility.sqlDT.Rows[0]["PhoneNo"].ToString();
                }
            }
            else { txtBillingAddress.Text = ""; txtBillingContact.Text = ""; txtShippingName.Text = ""; txtShippingAddress.Text = ""; txtShippingContact.Text = ""; }
            }
            catch (Exception)
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery(" UPDATE SalesInfo SET   ShippingName='" + txtShippingName.Text + "', ShippingAddress='" + txtShippingAddress.Text + "', ShippingContact='" + txtShippingContact.Text + "',  Comment='" + txtComments.Text + "',  CUST_ID= '" + clsUtility.fltr_combo(cmbCustomer) + "' " +
                                            " WHERE  SALES_ID= '" + txtInvoiceNo.Text + "' ");
                clsUtility.MesgBoxShow("msgSaved", "info");
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }
    }
}
