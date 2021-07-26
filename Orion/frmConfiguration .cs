using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConnectionString.Text)) { errorProvider.SetError(txtConnectionString, "Required"); }
            else {
                errorProvider.Clear();
                Properties.Settings.Default.App_Conn_string = txtConnectionString.Text;
                Properties.Settings.Default.App_Default_Conn = true;
                Properties.Settings.Default.Save();
                clsUtility.MesgBoxShow("msgSaved", "info");
            }
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = Properties.Settings.Default.App_Conn_string;
        }
    }
}
