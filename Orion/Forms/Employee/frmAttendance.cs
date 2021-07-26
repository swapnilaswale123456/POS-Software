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
    public partial class frmAttendance : Form
    {
        public frmAttendance()
        {
            InitializeComponent();
        }

        int dgvVAL;
        private void CheckGrid()
        {
            dgvVAL = 0;
            if (dataGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Column4"].Value);
                    if (isSelected)
                    {
                        dgvVAL = dgvVAL + 1;
                    }
                }
            }
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
                        XmlNode l1106 = languageNode["l1106"];
                        lbl1106.Text = l1106.InnerText;

                        XmlNode l1107 = languageNode["l1107"];
                        lbl1107.Text = l1107.InnerText;

                        XmlNode l1108 = languageNode["l1108"];
                        lbl1108.Text = l1108.InnerText;

                        XmlNode l1109 = languageNode["l1109"];
                        lbl1109.Text = l1109.InnerText;

                        XmlNode l1110 = languageNode["l1110"];
                        rbPresent.Text = l1110.InnerText;

                        XmlNode l1111 = languageNode["l1111"];
                        rbAbsent.Text = l1111.InnerText;

                        XmlNode l1112 = languageNode["l1112"];
                        lbl1112.Text = l1112.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlReset = languageNode["ctrlReset"];
                        btnReset.Text = ctrlReset.InnerText;

                        XmlNode ctrlRefresh = languageNode["ctrlRefresh"];
                        btnRefresh.Text = ctrlRefresh.InnerText;

                        XmlNode l1104 = languageNode["l1104"];
                        XmlNode l1105 = languageNode["l1105"];
                        XmlNode l1005 = languageNode["l1005"];

                        dataGridView1.Columns["Column2"].HeaderText = l1104.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1105.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1005.InnerText;
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
            clsUtility.FillDataGrid(" SELECT  EMP_ID,EmployeeName,Designation,PhoneNo FROM Employee ", dataGridView1);
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
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
            LoadData();
            txtRemarks.Text = "";
            rbPresent.Checked = true;
            dtpAttnDate.Value = DateTime.Today;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                CheckGrid();
                if (dgvVAL <= 0) { errorProvider.SetError(dataGridView1, "Required"); }
                else
                {
                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {
                        if (Row.Cells[0].Value != null)
                        {
                            if ((bool)(Row.Cells[0].Value) == true)
                            {
                                string EMP_ID = dataGridView1.Rows[Row.Index].Cells["Column1"].Value.ToString();
                                if (rbPresent.Checked)
                                {
                                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Attendance  WHERE AttendanceDate='" + dtpAttnDate.Value.Date.ToString("yyyy-MM-dd") + "' AND EMP_ID='" + EMP_ID + "' ");
                                    if (clsUtility.sqlDT.Rows.Count > 0) { }
                                    else { clsUtility.ExecuteSQLQuery("INSERT INTO Attendance(EMP_ID,AttendanceDate,Present,Absent,Remarks) VALUES ('" + EMP_ID + "','" + dtpAttnDate.Value.Date.ToString("yyyy-MM-dd") + "', 1, 0, '" + txtRemarks.Text + "')"); }
                                }
                                else
                                {
                                    clsUtility.ExecuteSQLQuery(" SELECT * FROM Attendance  WHERE AttendanceDate='" + dtpAttnDate.Value.Date.ToString("yyyy-MM-dd") + "' AND EMP_ID='" + EMP_ID + "' ");
                                    if (clsUtility.sqlDT.Rows.Count > 0) { }
                                    else { clsUtility.ExecuteSQLQuery("INSERT INTO Attendance(EMP_ID,AttendanceDate,Present,Absent,Remarks) VALUES ('" + EMP_ID + "','" + dtpAttnDate.Value.Date.ToString("yyyy-MM-dd") + "', 0, 1, '" + txtRemarks.Text + "')"); }
                                }
                            }
                        }
                    }
                    btnReset.PerformClick();
                    clsUtility.MesgBoxShow("msgSaved", "info");
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
