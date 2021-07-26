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
    public partial class frmBarcode : Form
    {
        public frmBarcode()
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
                        XmlNode l1051 = languageNode["l1051"];
                        lbl1051.Text = l1051.InnerText;

                        XmlNode l1052 = languageNode["l1052"];
                        lbl1052.Text = l1052.InnerText;

                        XmlNode l1053 = languageNode["l1053"];
                        lbl1053.Text = l1053.InnerText;

                        XmlNode l1054 = languageNode["l1054"];
                        chkCompanyName.Text = l1054.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        lbl1030.Text = l1030.InnerText;

                        XmlNode l1038 = languageNode["l1038"];
                        lbl1038.Text = l1038.InnerText;

                        XmlNode l1034 = languageNode["l1034"];
                        lbl1034.Text = l1034.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

                        XmlNode ctrlClose = languageNode["ctrlClose"];
                        btnClose.Text = ctrlClose.InnerText;

                        XmlNode ctrlPreview = languageNode["ctrlPreview"];
                        button2.Text = ctrlPreview.InnerText;

                        XmlNode ctrlRemoveAll = languageNode["ctrlRemoveAll"];
                        button1.Text = ctrlRemoveAll.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmBarcode_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            clsUtility.FillComboBox(" SELECT  ITEM_ID, ItemName  FROM  ItemInformation  ORDER BY ItemName", "ITEM_ID", "ItemName", cmbItem);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                string CompanyName = null;
                if (chkCompanyName.Checked)
                {
                    clsUtility.ExecuteSQLQuery("SELECT * FROM BusinessInformation");
                    if (clsUtility.sqlDT.Rows.Count > 0) { CompanyName = clsUtility.sqlDT.Rows[0]["CompanyName"].ToString(); }
                    else { CompanyName = ""; }
                }

                if (cmbItem.SelectedValue == null | cmbItem.SelectedIndex == -1)
                { errorProvider.SetError(cmbItem, "Required"); }
                else if (string.IsNullOrEmpty(txtQuantity.Text))
                { errorProvider.SetError(txtQuantity, "Required"); }
                else
                {
                    errorProvider.Clear();

                    int i, cnt, xHold, holdi;
                    holdi = 0;
                    cnt = 1;
                    xHold = 0;

                    for (i = 0; i < clsUtility.num_repl(txtQuantity.Text); i++)
                    {
                        /////////////////////
                        if (cnt == 1)
                        {
                            clsUtility.ExecuteSQLQuery("INSERT INTO PrintBarcode (COMPANY_NAME,BARCODE_1,PRODUCT_NAME_1 ,PRICE_1) VALUES ('" + CompanyName + "','" + txtBarcode.Text + "', '" + cmbItem.Text + "','" + txtPrice.Text + "') ");
                            clsUtility.ExecuteSQLQuery("SELECT * FROM PrintBarcode ORDER BY id DESC");
                            xHold = Convert.ToInt32(clsUtility.sqlDT.Rows[0]["id"]);
                        }
                        else if (cnt == 2)
                        {
                            clsUtility.ExecuteSQLQuery("UPDATE  PrintBarcode SET COMPANY_NAME='" + CompanyName + "',BARCODE_2='" + txtBarcode.Text + "',PRODUCT_NAME_2='" + cmbItem.Text + "' , PRICE_2= '" + txtPrice.Text + "' WHERE id= '" + xHold + "' ");
                            holdi = holdi + 1;
                        }
                        else
                        {
                            if (((cnt - 1) / (2)) == 1)
                            {
                                clsUtility.ExecuteSQLQuery("INSERT INTO PrintBarcode (COMPANY_NAME,BARCODE_1,PRODUCT_NAME_1 ,PRICE_1) VALUES ('" + CompanyName + "','" + txtBarcode.Text + "', '" + cmbItem.Text + "','" + txtPrice.Text + "') ");
                                clsUtility.ExecuteSQLQuery("SELECT * FROM PrintBarcode ORDER BY id DESC");
                                xHold = Convert.ToInt32(clsUtility.sqlDT.Rows[0]["id"]);
                                cnt = 1;
                            }
                        }
                        ///////////////////
                        cnt = cnt + 1;
                    }
                    txtBarcode.Text = "";
                    txtPrice.Text = "";
                    txtQuantity.Text = "";
                    clsUtility.MesgBoxShow("msgSaved", "info");
                }

                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cmbItem.SelectedValue == null) | !(cmbItem.SelectedIndex == -1))
            {
                clsUtility.ExecuteSQLQuery("SELECT * FROM ItemInformation WHERE  ITEM_ID = '" + clsUtility.num_repl(cmbItem.SelectedValue.ToString()) + "' ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtBarcode.Text = clsUtility.sqlDT.Rows[0]["Barcode"].ToString();
                    txtPrice.Text = clsUtility.sqlDT.Rows[0]["Price"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                clsUtility.ExecuteSQLQuery("DELETE FROM PrintBarcode");
                clsUtility.MesgBoxShow("msgDelete", "info");
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Print = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                frmPrintPreviewBarcode frmPrintPreviewBarcode = new frmPrintPreviewBarcode();
                frmPrintPreviewBarcode.ShowDialog();
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }
    }
}
