using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion
{
    public partial class frmItemInformation : Form
    {
        string fileExtension = ".jpg";
        string ITEM_ID, WarehouseID;
        public frmItemInformation(String VAR_ITEM_ID, String VAR_WarehouseID)
        {
            InitializeComponent();
            ITEM_ID = VAR_ITEM_ID.ToString();
            WarehouseID = VAR_WarehouseID.ToString();
            txtItemID.Text = VAR_ITEM_ID.ToString();
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
                        XmlNode l1028 = languageNode["l1028"];
                        lbl1028.Text = l1028.InnerText;

                        XmlNode l1029 = languageNode["l1029"];
                        lbl1029.Text = l1029.InnerText;

                        XmlNode l1030 = languageNode["l1030"];
                        lbl1030.Text = l1030.InnerText;

                        XmlNode l1031 = languageNode["l1031"];
                        lbl1031.Text = l1031.InnerText;

                        XmlNode l1032 = languageNode["l1032"];
                        lbl1032.Text = l1032.InnerText;

                        XmlNode l1033 = languageNode["l1033"];
                        lbl1033.Text = l1033.InnerText;

                        XmlNode l1034 = languageNode["l1034"];
                        lbl1034.Text = l1034.InnerText;

                        XmlNode l1035 = languageNode["l1035"];
                        chkAutoBarcode.Text = l1035.InnerText;

                        XmlNode l1036 = languageNode["l1036"];
                        cbVATapplicable.Text = l1036.InnerText;

                        XmlNode l1037 = languageNode["l1037"];
                        lbl1037.Text = l1037.InnerText;

                        XmlNode l1038 = languageNode["l1038"];
                        lbl1038.Text = l1038.InnerText;

                        XmlNode l1039 = languageNode["l1039"];
                        lbl1039.Text = l1039.InnerText;

                        XmlNode l1040 = languageNode["l1040"];
                        lbl1040.Text = l1040.InnerText;

                        XmlNode l1041 = languageNode["l1041"];
                        lbl1041.Text = l1041.InnerText;

                        XmlNode l1042 = languageNode["l1042"];
                        lbl1042.Text = l1042.InnerText;

                        XmlNode l1043 = languageNode["l1043"];
                        lbl1043.Text = l1043.InnerText;

                        XmlNode l1044 = languageNode["l1044"];
                        lbl1044.Text = l1044.InnerText;

                        XmlNode l1045 = languageNode["l1045"];
                        chkExp.Text = l1045.InnerText;

                        XmlNode l1046 = languageNode["l1046"];
                        lbl1046.Text = l1046.InnerText;

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

                        XmlNode ctrlBrowsePhoto = languageNode["ctrlBrowsePhoto"];
                        btnBrowosePhoto.Text = ctrlBrowsePhoto.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ItemDescription() {
            try
            {
                clsUtility.ExecuteSQLQuery("SELECT *  FROM  ItemInformation  WHERE ITEM_ID ='" + ITEM_ID + "'  ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    txtItemName.Text = clsUtility.sqlDT.Rows[0]["ItemName"].ToString();
                    txtUnit.Text = clsUtility.sqlDT.Rows[0]["UnitOfMeasure"].ToString();
                    txtBatch.Text = clsUtility.sqlDT.Rows[0]["Batch"].ToString();
                    cmbGroup.SelectedValue = clsUtility.sqlDT.Rows[0]["GROUP_ID"].ToString();
                    cmbDefaultWarehouse.SelectedValue = clsUtility.sqlDT.Rows[0]["WarehouseID"].ToString();
                    txtBarcode.Text = clsUtility.sqlDT.Rows[0]["Barcode"].ToString();
                    txtPurchaseCost.Text = clsUtility.sqlDT.Rows[0]["Cost"].ToString();
                    txtSalesPrice.Text = clsUtility.sqlDT.Rows[0]["Price"].ToString();
                    txtReorderPoint.Text = clsUtility.sqlDT.Rows[0]["ReorderPoint"].ToString();

                    if (clsUtility.sqlDT.Rows[0]["VAT_Applicable"].ToString() == "Y") { cbVATapplicable.Checked = true; }
                    else { cbVATapplicable.Checked = false; }

                    try
                    {
                        pictureBox1.ImageLocation = Application.StartupPath + @"\Upload\ItemImage\" + clsUtility.sqlDT.Rows[0]["PhotoFileName"].ToString();
                        pictureBox1.InitialImage.Dispose();
                        fileExtension = Path.GetExtension(clsUtility.sqlDT.Rows[0]["PhotoFileName"].ToString());
                    }
                    catch (Exception) { pictureBox1.Image = Orion.Properties.Resources.No_image_found; }
                }

                clsUtility.ExecuteSQLQuery("SELECT *  FROM  Stock  WHERE ITEM_ID ='" + ITEM_ID + "' AND WarehouseID ='" + WarehouseID + "'  ");
                if (clsUtility.sqlDT.Rows.Count > 0)
                {
                    cmbWarehouse.SelectedValue = clsUtility.sqlDT.Rows[0]["WarehouseID"].ToString();
                    cmbShelf.SelectedValue = clsUtility.sqlDT.Rows[0]["SHELF_ID"].ToString();
                    txtOpeningStock.Text = clsUtility.sqlDT.Rows[0]["Quantity"].ToString();
                    try { dtpExpDate.Text = clsUtility.sqlDT.Rows[0]["ExpiryDate"].ToString(); }
                    catch (Exception) { }

                    if (clsUtility.sqlDT.Rows[0]["Expiry"].ToString() == "Y") { chkExp.Checked = true; }
                    else { chkExp.Checked = false; }
                }

                btnSubmit.Enabled = false;
                btnDelete.Enabled = true;
                btnAlter.Enabled = true;

            }
            catch (Exception) { }
        }

        private void frmItemInformation_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            btnReset.PerformClick();
            LoadLanguegePack();
            if (ITEM_ID == "0") { }
            else { ItemDescription(); }
            
        }

        private void LoadData()
        {
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbWarehouse);
            clsUtility.FillComboBox(" SELECT  WarehouseID, WarehouseName  FROM  Warehouse  ORDER BY WarehouseName", "WarehouseID", "WarehouseName", cmbDefaultWarehouse);
            clsUtility.FillComboBox(" SELECT  GROUP_ID, GROUP_NAME  FROM  ItemGroup  ORDER BY GROUP_NAME", "GROUP_ID", "GROUP_NAME", cmbGroup);
            clsUtility.FillComboBox(" SELECT  SHELF_ID, SHELF_NAME  FROM  Shelf  ORDER BY SHELF_NAME", "SHELF_ID", "SHELF_NAME", cmbShelf);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            frmGroup frmGroup = Application.OpenForms["frmGroup"] as frmGroup;
            if (frmGroup != null)
            {
                frmGroup.WindowState = FormWindowState.Normal;
                frmGroup.BringToFront();
                frmGroup.Activate();
            }
            else
            {
                frmGroup = new frmGroup();
                frmGroup.MdiParent = this.ParentForm;
                frmGroup.Dock = DockStyle.Fill;
                frmGroup.Show();
            }
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            //Warehouse
            frmWarehouse frmWarehouse = Application.OpenForms["frmWarehouse"] as frmWarehouse;
            if (frmWarehouse != null)
            {
                frmWarehouse.WindowState = FormWindowState.Normal;
                frmWarehouse.BringToFront();
                frmWarehouse.Activate();
            }
            else
            {
                frmWarehouse = new frmWarehouse();
                frmWarehouse.MdiParent = this.ParentForm;
                frmWarehouse.Dock = DockStyle.Fill;
                frmWarehouse.Show();
            }
        }

        private void btnBrowosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Browse image";
            OpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Orion.Properties.Resources.No_image_found;
                pictureBox1.ImageLocation = OpenFileDialog.FileName;
                fileExtension = Path.GetExtension(OpenFileDialog.FileName);
            }
        }

        private void chkExp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExp.Checked)
            { dtpExpDate.Enabled = true; }
            else { dtpExpDate.Enabled = false; }
        }

        private void UploadImage(string ITEM_ID)
        {
            string DestPath = Application.StartupPath + @"\Upload\ItemImage\";
            if (!Directory.Exists(DestPath)) { Directory.CreateDirectory(DestPath); }
            System.IO.File.Delete(DestPath + @"\" + ITEM_ID + fileExtension);
            string ImageFileName = DestPath + @"\" + openFileDialog.SafeFileName;
            pictureBox1.Image.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Png);
            System.IO.File.Move(DestPath + @"\" + openFileDialog.SafeFileName, DestPath + @"\" + ITEM_ID + fileExtension);
            clsUtility.ExecuteSQLQuery("UPDATE ItemInformation SET PhotoFileName= '" + ITEM_ID + fileExtension + "' WHERE ITEM_ID ='" + ITEM_ID + "' ");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Add = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtItemName.Text) | string.IsNullOrWhiteSpace(this.txtUnit.Text) | cmbGroup.SelectedValue == null | cmbGroup.SelectedIndex == -1 | cmbDefaultWarehouse.SelectedValue == null | cmbDefaultWarehouse.SelectedIndex == -1)
                {
                    errorProvider.SetError(txtItemName, "Required");
                    errorProvider.SetError(txtUnit, "Required");
                    errorProvider.SetError(cmbGroup, "Required");
                    errorProvider.SetError(cmbDefaultWarehouse, "Required");
                }
                else
                {
                    string Expiry, ExpiryDate;
                    if (chkExp.Checked) { ExpiryDate = dtpExpDate.Value.Date.ToString("yyyy-MM-dd"); Expiry = "Y"; } else { ExpiryDate = ""; Expiry = "N"; }

                    if (chkAutoBarcode.Checked)
                    {
                        errorProvider.Clear();
                        string barcode = null;
                        string VATapplicable = null;
                        string ITEM_ID = null;
                        if (cbVATapplicable.Checked) { VATapplicable = "Y"; } else { VATapplicable = "N"; }
                        try
                        {
                            ///////////////////////////

                            clsUtility.ExecuteSQLQuery(" INSERT INTO ItemInformation(ItemName,UnitOfMeasure,Batch,GROUP_ID,Barcode,Cost,Price,ReorderPoint,VAT_Applicable, WarehouseID) VALUES " +
                                                           "  ('" + txtItemName.Text + "','" + txtUnit.Text + "','" + txtBatch.Text + "','" + cmbGroup.SelectedValue.ToString() + "','" + clsUtility.GenarateAutoBarcode(barcode) + "','" + clsUtility.num_repl(txtPurchaseCost.Text) + "','" + clsUtility.num_repl(txtSalesPrice.Text) + "','" + clsUtility.num_repl(txtReorderPoint.Text) + "','" + VATapplicable + "','" + cmbDefaultWarehouse.SelectedValue.ToString() + "') ");
                            clsUtility.ExecuteSQLQuery("SELECT  ITEM_ID   FROM   ItemInformation  ORDER BY ITEM_ID DESC");
                            ITEM_ID = clsUtility.sqlDT.Rows[0]["ITEM_ID"].ToString();
                            clsUtility.ExecuteSQLQuery(" INSERT INTO Stock(ITEM_ID,Quantity,ExpiryDate,WarehouseID, SHELF_ID, Expiry) VALUES ('" + ITEM_ID + "','" + clsUtility.num_repl(txtOpeningStock.Text) + "','" + ExpiryDate.ToString() + "','" + cmbWarehouse.SelectedValue.ToString() + "', '" + clsUtility.fltr_combo(cmbShelf) + "', '" + Expiry + "') ");
                            UploadImage(ITEM_ID);
                            btnReset.PerformClick();
                            clsUtility.MesgBoxShow("msgSaved", "info");
                            ///////////////////
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(this.txtBarcode.Text))
                        { errorProvider.SetError(txtBarcode, "Required"); }
                        else
                        {
                            errorProvider.Clear();
                            string VATapplicable = null;
                            if (cbVATapplicable.Checked) { VATapplicable = "Y"; } else { VATapplicable = "N"; }
                            try
                            {
                                string ITEM_ID = null;
                                clsUtility.ExecuteSQLQuery(" INSERT INTO ItemInformation(ItemName,UnitOfMeasure,Batch,GROUP_ID,Barcode,Cost,Price,ReorderPoint,VAT_Applicable, WarehouseID) VALUES " +
                                           "  ('" + txtItemName.Text + "','" + txtUnit.Text + "','" + txtBatch.Text + "','" + cmbGroup.SelectedValue.ToString() + "','" + txtBarcode.Text + "','" + clsUtility.num_repl(txtPurchaseCost.Text) + "','" + clsUtility.num_repl(txtSalesPrice.Text) + "','" + clsUtility.num_repl(txtReorderPoint.Text) + "','" + VATapplicable + "','" + cmbDefaultWarehouse.SelectedValue.ToString() + "') ");
                                clsUtility.ExecuteSQLQuery("SELECT  ITEM_ID   FROM   ItemInformation  ORDER BY ITEM_ID DESC");
                                ITEM_ID = clsUtility.sqlDT.Rows[0]["ITEM_ID"].ToString();
                                clsUtility.ExecuteSQLQuery(" INSERT INTO Stock(ITEM_ID,Quantity,ExpiryDate,WarehouseID, SHELF_ID, Expiry) VALUES ('" + ITEM_ID + "','" + clsUtility.num_repl(txtOpeningStock.Text) + "','" + ExpiryDate.ToString() + "','" + cmbWarehouse.SelectedValue.ToString() + "', '" + clsUtility.fltr_combo(cmbShelf) + "', '" + Expiry + "') ");
                                UploadImage(ITEM_ID);
                                btnReset.PerformClick();
                                clsUtility.MesgBoxShow("msgSaved", "info");
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            btnSubmit.Enabled = true;
            btnAlter.Enabled = false;
            btnDelete.Enabled = false;
            fileExtension = ".png";
            pictureBox1.Image = Orion.Properties.Resources.No_image_found;
            txtOpeningStock.Text = "";
            chkExp.Checked = false ;
            dtpExpDate.Value = DateTime.Today;
            cbVATapplicable.Checked = false;
            txtReorderPoint.Text = "";
            txtSalesPrice.Text = "";
            txtPurchaseCost.Text = "";
            chkAutoBarcode.Checked = true;
            txtBarcode.Text = "";
            txtBatch.Text = "";
            txtUnit.Text = "";
            txtItemName.Text = "";
        }

        private void btnShelf_Click(object sender, EventArgs e)
        {
            //Shelf
            frmShelf frmShelf = Application.OpenForms["frmShelf"] as frmShelf;
            if (frmShelf != null)
            {
                frmShelf.WindowState = FormWindowState.Normal;
                frmShelf.BringToFront();
                frmShelf.Activate();
            }
            else
            {
                frmShelf = new frmShelf();
                frmShelf.MdiParent = this.ParentForm;
                frmShelf.Dock = DockStyle.Fill;
                frmShelf.Show();
            }
        }

        private void btnDefaultWarehouse_Click(object sender, EventArgs e)
        {
            //Warehouse
            frmWarehouse frmWarehouse = Application.OpenForms["frmWarehouse"] as frmWarehouse;
            if (frmWarehouse != null)
            {
                frmWarehouse.WindowState = FormWindowState.Normal;
                frmWarehouse.BringToFront();
                frmWarehouse.Activate();
            }
            else
            {
                frmWarehouse = new frmWarehouse();
                frmWarehouse.MdiParent = this.ParentForm;
                frmWarehouse.Dock = DockStyle.Fill;
                frmWarehouse.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Delete = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtItemID.Text))
                { errorProvider.SetError(txtItemID, "Required"); }
                else
                {
                    errorProvider.Clear();
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  ItemInformation  WHERE ITEM_ID ='" + txtItemID.Text + "'  ");
                    clsUtility.ExecuteSQLQuery(" DELETE FROM  Stock  WHERE ITEM_ID ='" + txtItemID.Text + "'  ");
                    btnReset.PerformClick();
                    txtItemID.Text = "";
                    clsUtility.MesgBoxShow("msgDelete", "info");
                }
                ///////////////////////////////////////////
            }
            else
            {
                clsUtility.MesgBoxShow("msgPermission", "err");
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            clsUtility.ExecuteSQLQuery(" SELECT  * FROM   Users  WHERE   USER_ID = '" + clsUtility.UserID + "' AND   Can_Edit = 'Y' ");
            if (clsUtility.sqlDT.Rows.Count > 0)
            {
                ///////////////////////////////////////////
                if (string.IsNullOrWhiteSpace(this.txtItemID.Text) | string.IsNullOrWhiteSpace(this.txtItemName.Text) | string.IsNullOrWhiteSpace(this.txtUnit.Text) | cmbGroup.SelectedValue == null | cmbGroup.SelectedIndex == -1 | cmbDefaultWarehouse.SelectedValue == null | cmbDefaultWarehouse.SelectedIndex == -1)
                {
                    errorProvider.SetError(txtItemName, "Required");
                    errorProvider.SetError(txtUnit, "Required");
                    errorProvider.SetError(cmbGroup, "Required");
                    errorProvider.SetError(cmbDefaultWarehouse, "Required");
                }
                else
                {
                    ///////////////////////////////
                    errorProvider.Clear();
                    string VATapplicable = null;
                    string Expiry, ExpiryDate;
                    if (chkExp.Checked) { ExpiryDate = dtpExpDate.Value.Date.ToString("yyyy-MM-dd"); Expiry = "Y"; } else { ExpiryDate = ""; Expiry = "N"; }
                    if (cbVATapplicable.Checked) { VATapplicable = "Y"; } else { VATapplicable = "N"; }
                    try
                    {
                        clsUtility.ExecuteSQLQuery(" UPDATE  ItemInformation SET  ItemName='" + txtItemName.Text + "',UnitOfMeasure='" + txtUnit.Text + "',Batch='" + txtBatch.Text + "',GROUP_ID='" + cmbGroup.SelectedValue.ToString() + "',Barcode='" + txtBarcode.Text + "',Cost='" + clsUtility.num_repl(txtPurchaseCost.Text) + "',Price='" + clsUtility.num_repl(txtSalesPrice.Text) + "',ReorderPoint='" + clsUtility.num_repl(txtReorderPoint.Text) + "',VAT_Applicable='" + VATapplicable + "', WarehouseID = '" + cmbDefaultWarehouse.SelectedValue.ToString() + "' " +
                                   " WHERE ITEM_ID ='" + ITEM_ID + "'  ");

                        clsUtility.ExecuteSQLQuery("UPDATE  Stock  SET  Quantity='" + clsUtility.num_repl(txtOpeningStock.Text) + "',  ExpiryDate='" + ExpiryDate.ToString() + "', WarehouseID='" + cmbWarehouse.SelectedValue.ToString() + "',  SHELF_ID='" + clsUtility.fltr_combo(cmbShelf).ToString() + "', Expiry='" + Expiry.ToString() + "'  WHERE  ITEM_ID ='" + ITEM_ID + "'  AND  WarehouseID='" + WarehouseID + "'  ");

                        UploadImage(txtItemID.Text);
                        btnReset.PerformClick();

                        txtItemID.Text = "";
                        clsUtility.MesgBoxShow("msgUpdate", "info");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    //////////////////////////////
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
