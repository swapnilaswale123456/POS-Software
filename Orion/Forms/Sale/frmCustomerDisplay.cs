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
    public partial class frmCustomerDisplay : Form
    {
        public frmCustomerDisplay()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.cmbPortName.Text)) {
                MessageBox.Show("Please select a port to obtain customer display info.", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                Properties.Settings.Default.Port_Name = cmbPortName.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Settings saved on this computer for the customer display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCustomerDisplay_Load(object sender, EventArgs e)
        {
            cmbPortName.Text = Properties.Settings.Default.Port_Name;
        }
    }
}
