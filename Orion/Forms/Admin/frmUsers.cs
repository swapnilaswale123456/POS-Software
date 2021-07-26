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
    public partial class frmUsers : Form
    {
        string CAN_ADD, CAN_MODIFY, CAN_DELETE, CAN_PRINT;
        public frmUsers()
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
                        XmlNode l1158 = languageNode["l1158"];
                        lbl1158.Text = l1158.InnerText;

                        XmlNode l1159 = languageNode["l1159"];
                        lbl1159.Text = l1159.InnerText;

                        XmlNode l1160 = languageNode["l1160"];
                        lbl1160.Text = l1160.InnerText;

                        XmlNode l1161 = languageNode["l1161"];
                        lbl1161.Text = l1161.InnerText;

                        XmlNode l1162 = languageNode["l1162"];
                        lbl1162.Text = l1162.InnerText;

                        XmlNode l1163 = languageNode["l1163"];
                        lbl1163.Text = l1163.InnerText;

                        XmlNode l1164 = languageNode["l1164"];
                        lbl1164.Text = l1164.InnerText;

                        XmlNode l1165 = languageNode["l1165"];
                        lbl1165.Text = l1165.InnerText;

                        XmlNode l1166 = languageNode["l1166"];
                        chkAdd.Text = l1166.InnerText;

                        XmlNode l1167 = languageNode["l1167"];
                        chkModify.Text = l1167.InnerText;

                        XmlNode l1168 = languageNode["l1168"];
                        chkDelete.Text = l1168.InnerText;

                        XmlNode l1169 = languageNode["l1169"];
                        chkPrint.Text = l1169.InnerText;

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

                        XmlNode l1186 = languageNode["l1186"];

                        dataGridView1.Columns["Column2"].HeaderText = l1161.InnerText;
                        dataGridView1.Columns["Column3"].HeaderText = l1160.InnerText;
                        dataGridView1.Columns["Column4"].HeaderText = l1164.InnerText;
                        dataGridView1.Columns["Column5"].HeaderText = l1186.InnerText;
                        dataGridView1.Columns["Column6"].HeaderText = l1166.InnerText;
                        dataGridView1.Columns["Column7"].HeaderText = l1167.InnerText;
                        dataGridView1.Columns["Column8"].HeaderText = l1168.InnerText;
                        dataGridView1.Columns["Column9"].HeaderText = l1169.InnerText;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnDelete.Enabled = false;
            btnAlter.Enabled = false;
            btnReset.PerformClick();
        }

        private void LoadCheckVal() {
            if (chkAdd.Checked) { CAN_ADD = "Y"; } else { CAN_ADD = "N"; }
            if (chkModify.Checked) { CAN_MODIFY = "Y"; } else { CAN_MODIFY = "N"; }
            if (chkDelete.Checked) { CAN_DELETE = "Y"; } else { CAN_DELETE = "N"; }
            if (chkPrint.Checked) { CAN_PRINT = "Y"; } else { CAN_PRINT = "N"; }
        }

        private void LoadData()
        {
            clsUtility.FillDataGrid(" SELECT USER_ID, FullName, UserName, Privilege,  RegDate,  Can_Add, Can_Edit,  Can_Delete,  Can_Print " +
                                    " FROM  Users  ORDER BY  USER_ID DESC ", dataGridView1);

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
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            cmbUserType.Text = "";
            chkAdd.Checked = false;
            chkDelete.Checked = false;
            chkModify.Checked = false;
            chkPrint.Checked = false;
            txtUserName.Enabled = true;
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadCheckVal();
            if ( string.IsNullOrEmpty(txtUserName.Text) |  string.IsNullOrEmpty(txtPassword.Text) |  string.IsNullOrEmpty(txtRePassword.Text))
            { errorProvider.SetError(txtUserName, "Required"); errorProvider.SetError(txtPassword, "Required"); errorProvider.SetError(txtRePassword, "Required"); }
            else if (!(txtPassword.Text == txtRePassword.Text))
            { errorProvider.SetError(txtPassword, "Required"); errorProvider.SetError(txtRePassword, "Required"); }
            else if (!(cmbUserType.Text == "Administrator" | cmbUserType.Text == "Manager" | cmbUserType.Text == "Sales"))
            { errorProvider.SetError(cmbUserType, "Required"); }
            else {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" INSERT INTO Users (FullName, UserName,  Privilege,  RegDate,  Password,  Can_Add,  Can_Edit,  Can_Delete,  Can_Print) VALUES  " +
                                           " ('" + txtFullName.Text + "', '" + txtUserName.Text + "',  '" + cmbUserType.Text + "',  '" + DateTime.Now.ToString("yyyy-MM-dd") + "',  '"+ clsUtility.CreateMD5(txtPassword.Text) +"',  '"+ CAN_ADD +"',  '"+ CAN_MODIFY +"',  '"+ CAN_DELETE +"',  '"+ CAN_PRINT +"') ");
                LoadData();
                btnReset.PerformClick();
                clsUtility.MesgBoxShow("msgSaved", "info");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserID.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            clsUtility.ExecuteSQLQuery(" SELECT * FROM Users WHERE USER_ID='"+ txtUserID.Text +"' ");
            if (clsUtility.sqlDT.Rows.Count > 0) {
                txtFullName.Text = clsUtility.sqlDT.Rows[0]["FullName"].ToString();
                txtUserName.Text = clsUtility.sqlDT.Rows[0]["UserName"].ToString();
                cmbUserType.Text = clsUtility.sqlDT.Rows[0]["Privilege"].ToString();
                if ( clsUtility.sqlDT.Rows[0]["Can_Add"].ToString() == "Y" ){ chkAdd.Checked =true; } else { chkAdd.Checked = false; }
                if (clsUtility.sqlDT.Rows[0]["Can_Edit"].ToString() == "Y") { chkModify.Checked = true; } else { chkModify.Checked = false; }
                if (clsUtility.sqlDT.Rows[0]["Can_Delete"].ToString() == "Y") { chkDelete.Checked = true; } else { chkDelete.Checked = false; }
                if (clsUtility.sqlDT.Rows[0]["Can_Print"].ToString() == "Y") { chkPrint.Checked = true; } else { chkPrint.Checked = false; }
            }
            btnSubmit.Enabled = false;
            btnDelete.Enabled = true;
            btnAlter.Enabled = true;
            txtUserName.Enabled = false;
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            LoadCheckVal();
            if (string.IsNullOrEmpty(txtUserName.Text) | string.IsNullOrEmpty(txtUserID.Text) | string.IsNullOrEmpty(txtFullName.Text))
            { errorProvider.SetError(txtUserName, "Required"); errorProvider.SetError(txtFullName, "Required"); }
            else if (!(cmbUserType.Text == "Administrator" | cmbUserType.Text == "Manager" | cmbUserType.Text == "Sales"))
            { errorProvider.SetError(cmbUserType, "Required"); }
            else
            {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" UPDATE Users SET  FullName='" + txtFullName.Text + "',   Privilege='" + cmbUserType.Text + "',   Can_Add='" + CAN_ADD + "',  Can_Edit='" + CAN_MODIFY + "',  Can_Delete='" + CAN_DELETE + "',  Can_Print = '" + CAN_PRINT + "' " +
                                           " WHERE USER_ID='" + txtUserID.Text + "'  ");
                LoadData();
                btnReset.PerformClick();
                clsUtility.MesgBoxShow("msgUpdate", "info");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            { errorProvider.SetError(txtUserName, "Required");  }
            {
                errorProvider.Clear();
                clsUtility.ExecuteSQLQuery(" DELETE FROM  Users WHERE USER_ID='" + txtUserID.Text + "'  ");
                LoadData();
                btnReset.PerformClick();
                clsUtility.MesgBoxShow("msgDelete", "info");
            }
        }
    }
}
