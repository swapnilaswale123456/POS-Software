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
    public partial class frmReportExpenses : Form
    {
        public frmReportExpenses()
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
                        XmlNode l1156 = languageNode["l1156"];
                        lbl1156.Text = l1156.InnerText;

                        XmlNode l1128 = languageNode["l1128"];
                        rbToday.Text = l1128.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1136 = languageNode["l1136"];
                        rbByDate.Text = l1136.InnerText;

                        XmlNode l1157 = languageNode["l1157"];
                        rbByExpense.Text = l1157.InnerText;

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

        private void frmReportExpenses_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  EXP_AC_ID, ExpenditureAccount  FROM  ExpenditureAccount  ORDER BY ExpenditureAccount", "EXP_AC_ID", "ExpenditureAccount", cmbExpense);
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
            if (rbToday.Checked)
            {
                clsUtility.Preview__ExpenseList(" SELECT Expense_ID,  Expense.EXP_AC_ID, ExpenditureAccount, PaidDate, Description, Amount " +
                                                " FROM  Expense   LEFT JOIN ExpenditureAccount ON ExpenditureAccount.EXP_AC_ID = Expense.EXP_AC_ID " +
                                                " WHERE  (Expense.PaidDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "') ", crystalReportViewer1);
            }
            else if (rbByDate.Checked)
            {
                clsUtility.Preview__ExpenseList(" SELECT Expense_ID,  Expense.EXP_AC_ID, ExpenditureAccount, PaidDate, Description, Amount " +
                                                " FROM  Expense   LEFT JOIN ExpenditureAccount ON ExpenditureAccount.EXP_AC_ID = Expense.EXP_AC_ID " +
                                                " WHERE (Expense.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "') AND (Expense.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", crystalReportViewer1);
            }
            else
            {
                if (cmbExpense.SelectedIndex == -1 | cmbExpense.SelectedValue == null) { errorProvider.SetError(cmbExpense, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.Preview__ExpenseList(" SELECT Expense_ID,  Expense.EXP_AC_ID, ExpenditureAccount, PaidDate, Description, Amount " +
                                                    " FROM  Expense   LEFT JOIN ExpenditureAccount ON ExpenditureAccount.EXP_AC_ID = Expense.EXP_AC_ID " +
                                                    " WHERE (Expense.EXP_AC_ID = '" + cmbExpense.SelectedValue.ToString() + "') AND  (Expense.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "') AND (Expense.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "') ", crystalReportViewer1);
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
