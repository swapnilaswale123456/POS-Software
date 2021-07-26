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
    public partial class frmVAT : Form
    {
        public frmVAT()
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
                        XmlNode l1019 = languageNode["l1019"];
                        lbl1019.Text = l1019.InnerText;

                        XmlNode l1020 = languageNode["l1020"];
                        lbl1020.Text = l1020.InnerText;

                        XmlNode l1021 = languageNode["l1021"];
                        lbl1021.Text = l1021.InnerText;

                        XmlNode ctrlSave = languageNode["ctrlSave"];
                        btnSubmit.Text = ctrlSave.InnerText;

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

        private void frmVAT_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();

            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            clsUtility.ExecuteSQLQuery("SELECT * FROM Vat");
            if (clsUtility.sqlDT.Rows.Count > 0)
            { txtVat.Text = clsUtility.sqlDT.Rows[0]["Vat"].ToString(); }
            else { txtVat.Text = "0"; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                int parsedValue;
                if (string.IsNullOrWhiteSpace(this.txtVat.Text))
                { errorProvider.SetError(txtVat, "Required"); }
                else if (!int.TryParse(txtVat.Text, out parsedValue))
                { errorProvider.SetError(txtVat, "Required"); return; }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery("SELECT * FROM Vat");
                    if (clsUtility.sqlDT.Rows.Count > 0)
                    {
                        try
                        {
                            clsUtility.ExecuteSQLQuery(" UPDATE Vat SET Vat='" + txtVat.Text + "'   ");
                            clsUtility.MesgBoxShow("msgUpdate", "info");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
                    }
                    else
                    {
                        try
                        {
                            clsUtility.ExecuteSQLQuery(" INSERT INTO Vat (Vat) VALUES  ('" + txtVat.Text + "') ");
                            clsUtility.MesgBoxShow("msgSaved", "info");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
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
