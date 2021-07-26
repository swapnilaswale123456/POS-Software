using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Orion
{
    public partial class frmLanguage : Form
    {
        public frmLanguage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            try {
                string[] files = Directory.GetFiles(@"Language\", "*.xml*", SearchOption.AllDirectories);
                var namesOnly = files.Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();
                cmbLanguage.Items.AddRange(namesOnly);
            }
            catch( Exception ex){
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Properties.Settings.Default.App_Default_Language){
                cmbLanguage.Text = Properties.Settings.Default.App_Language;
                cbDefault.Checked = Properties.Settings.Default.App_Default_Language;
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"Language\" + cmbLanguage.Text + ".xml");
                XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                foreach (XmlNode languageNode in languageNodes)
                {
                    XmlAttribute isbnAttribute = languageNode.Attributes["translator"];
                    XmlNode authorNode = languageNode["comments"];
                    txtTranslator.Text = isbnAttribute.Value;
                    txtComments.Text = authorNode.InnerText;
                }
            }
           catch (Exception ex){
               MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.cmbLanguage.Text))
                { errorProvider.SetError(cmbLanguage, "Required"); }
                else
                {
                    errorProvider.Clear();
                    Properties.Settings.Default.App_Language = cmbLanguage.Text;
                    Properties.Settings.Default.App_Default_Language = cbDefault.Checked;
                    Properties.Settings.Default.Save();
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
