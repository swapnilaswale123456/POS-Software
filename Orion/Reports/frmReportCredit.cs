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
    public partial class frmReportCredit : Form
    {
       
        public frmReportCredit()
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
                        XmlNode l1145 = languageNode["l1145"];
                        lbl1145.Text = l1145.InnerText;

                        XmlNode l1146 = languageNode["l1146"];
                        rbTodayCollection.Text = l1146.InnerText;

                        XmlNode l1147 = languageNode["l1147"];
                        rbTodayPayment.Text = l1147.InnerText;

                        XmlNode l1148 = languageNode["l1148"];
                        rbCollecByDate.Text = l1148.InnerText;

                        XmlNode l1149 = languageNode["l1149"];
                        rbPayByDate.Text = l1149.InnerText;

                        XmlNode l1150 = languageNode["l1150"];
                        rbBySupplier.Text = l1150.InnerText;

                        XmlNode l1133 = languageNode["l1133"];
                        rbByCustomer.Text = l1133.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1081.Text = l1081.InnerText;

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

        private void frmReportCredit_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  SUPP_ID, SupplierName  FROM  Supplier  ORDER BY SupplierName", "SUPP_ID", "SupplierName", cmbSupplier);
            clsUtility.FillComboBox(" SELECT  CUST_ID, CustomerName  FROM  Customer  ORDER BY CustomerName", "CUST_ID", "CustomerName", cmbCustomer);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '"+ clsUtility.UserID +"' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
            ///////////////////////////////////////////
            if (rbTodayCollection.Checked)
            {
                //Today collection
                clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                clsUtility.Preview__Collection(" SELECT COLL_ID, SALES_ID,  Collection.CUST_ID,CustomerName, Address, PhoneNo, EntryDate, EnteredBy, Cash,Card " +
                                               " FROM  Collection LEFT JOIN Customer ON Customer.CUST_ID = Collection.CUST_ID WHERE  Collection.EntryDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbTodayPayment.Checked)
            {
                //Today payment
                clsUtility.crpString.Value = " AS OF " + DateTime.Now.ToString("yyyy-MM-dd");
                clsUtility.Preview__SupplierPayment(" SELECT PAYM_ID, PUCHSE_ID,  Payment.SUPP_ID, Supplier.SupplierName,Address, PhoneNo,EntryDate,EnteredBy,Cash,Card " +
                                                    " FROM  Payment  LEFT JOIN Supplier ON Supplier.SUPP_ID = Payment.SUPP_ID WHERE  Payment.EntryDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbCollecByDate.Checked)
            {
                //Collection by date
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__Collection(" SELECT COLL_ID, SALES_ID,  Collection.CUST_ID,CustomerName, Address, PhoneNo, EntryDate, EnteredBy, Cash,Card " +
                                               " FROM  Collection LEFT JOIN Customer ON Customer.CUST_ID = Collection.CUST_ID  " +
                                               " WHERE  Collection.EntryDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND   Collection.EntryDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbPayByDate.Checked)
            {
                //Payment by date
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__SupplierPayment(" SELECT PAYM_ID, PUCHSE_ID,  Payment.SUPP_ID, Supplier.SupplierName,Address, PhoneNo,EntryDate,EnteredBy,Cash,Card " +
                                                    " FROM  Payment  LEFT JOIN Supplier ON Supplier.SUPP_ID = Payment.SUPP_ID  " +
                                                    " WHERE  Payment.EntryDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  Payment.EntryDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                //
            }
            else if (rbByCustomer.Checked)
            {
                //Collectio from customer
                if (cmbCustomer.SelectedIndex == -1 | cmbCustomer.SelectedValue == null) { errorProvider.SetError(cmbCustomer, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = cmbCustomer.Text + ", FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__Collection(" SELECT COLL_ID, SALES_ID,  Collection.CUST_ID,CustomerName, Address, PhoneNo, EntryDate, EnteredBy, Cash,Card " +
                                                   " FROM  Collection LEFT JOIN Customer ON Customer.CUST_ID = Collection.CUST_ID  " +
                                                   " WHERE Collection.CUST_ID = '" + cmbCustomer.SelectedValue.ToString() + "' AND   Collection.EntryDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND   Collection.EntryDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                }
                //
            }
            else if (rbBySupplier.Checked)
            {
                //Supplier payment
                if (cmbSupplier.SelectedIndex == -1 | cmbSupplier.SelectedValue == null) { errorProvider.SetError(cmbSupplier, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = cmbSupplier.Text + ", FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__SupplierPayment(" SELECT PAYM_ID, PUCHSE_ID,  Payment.SUPP_ID, Supplier.SupplierName,Address, PhoneNo,EntryDate,EnteredBy,Cash,Card " +
                                                        " FROM  Payment  LEFT JOIN Supplier ON Supplier.SUPP_ID = Payment.SUPP_ID  " +
                                                        " WHERE  Payment.SUPP_ID = '" + cmbSupplier.SelectedValue.ToString() + "' AND Payment.EntryDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  Payment.EntryDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                }
                //
            }
            else { }
            ///////////////////////////////////////////
            }
            else {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }

        }
    }
}
