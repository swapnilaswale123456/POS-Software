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
    public partial class frmPrintPreviewBarcode : Form
    {
        public frmPrintPreviewBarcode()
        {
            InitializeComponent();
        }

        private void frmPrintPreviewBarcode_Load(object sender, EventArgs e)
        {
            clsUtility.Preview__Barcode(" SELECT  COMPANY_NAME,  BARCODE_1,  PRODUCT_NAME_1,  PRICE_1,  BARCODE_2, PRODUCT_NAME_2,  PRICE_2 FROM   PrintBarcode ", crystalReportViewer1);
        }
    }
}
