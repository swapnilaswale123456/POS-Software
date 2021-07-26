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
    public partial class frmReportEmployee : Form
    {
        public frmReportEmployee()
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
                        XmlNode l1151 = languageNode["l1151"];
                        lbl1151.Text = l1151.InnerText;

                        XmlNode l1152 = languageNode["l1152"];
                        rbEmpList.Text = l1152.InnerText;

                        XmlNode l1153 = languageNode["l1153"];
                        rbAttnByDate.Text = l1153.InnerText;

                        XmlNode l1154 = languageNode["l1154"];
                        rbPaymentByDate.Text = l1154.InnerText;

                        XmlNode l1155 = languageNode["l1155"];
                        rbPaymentByEmp.Text = l1155.InnerText;

                        XmlNode l1129 = languageNode["l1129"];
                        lbl1129.Text = l1129.InnerText;

                        XmlNode l1080 = languageNode["l1080"];
                        lbl1080.Text = l1080.InnerText;

                        XmlNode l1081 = languageNode["l1081"];
                        lbl1080.Text = l1081.InnerText;

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

        private void frmReportEmployee_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  EMP_ID, EmployeeName  FROM  Employee  ORDER BY EmployeeName", "EMP_ID", "EmployeeName", cmbEmployee);
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
            if (rbEmpList.Checked)
            {
                ///Employee list
                clsUtility.Preview__EmployeeList("SELECT * FROM Employee", crystalReportViewer1);
                /// End
            }
            else if (rbAttnByDate.Checked)
            {
                ///Attendance List
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__EmployeeAttandance(" SELECT Attendance.EMP_ID, EmployeeName, Designation, AttendanceDate, Present, Absent, Remarks " +
                                                       " FROM  Attendance  LEFT JOIN Employee ON Employee.EMP_ID = Attendance.EMP_ID " +
                                                       " WHERE  Attendance.AttendanceDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND  Attendance.AttendanceDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ORDER BY  Attendance.AttendanceDate ", crystalReportViewer1);
                /// End
            }
            else if (rbPaymentByDate.Checked)
            {
                ///Payment List
                clsUtility.crpString.Value = " FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                clsUtility.Preview__EmployeePayment(" SELECT EMP_PAY_ID,   EmployeePayment.EMP_ID, Employee.EmployeeName, Designation, PaidDate, Description, PaidAmount " +
                                                    " FROM  EmployeePayment LEFT JOIN Employee ON Employee.EMP_ID = EmployeePayment.EMP_ID " +
                                                    " WHERE  EmployeePayment.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND   EmployeePayment.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                /// End
            }
            else if (rbPaymentByEmp.Checked)
            {
                ///Employee Payment
                if (cmbEmployee.SelectedIndex == -1 | cmbEmployee.SelectedValue == null) { errorProvider.SetError(cmbEmployee, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.crpString.Value = cmbEmployee.Text + ", FROM  " + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "  TO  " + dateTo.Value.Date.ToString("yyyy-MM-dd");
                    clsUtility.Preview__EmployeePayment(" SELECT EMP_PAY_ID,   EmployeePayment.EMP_ID, Employee.EmployeeName, Designation, PaidDate, Description, PaidAmount " +
                                                        " FROM  EmployeePayment LEFT JOIN Employee ON Employee.EMP_ID = EmployeePayment.EMP_ID " +
                                                        " WHERE (EmployeePayment.EMP_ID = '" + cmbEmployee.SelectedValue.ToString() + "') AND  EmployeePayment.PaidDate >= '" + dateFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND   EmployeePayment.PaidDate <= '" + dateTo.Value.Date.ToString("yyyy-MM-dd") + "' ", crystalReportViewer1);
                }
                /// End
            }
            else { }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }

        }
    }
}
