using Orion.Forms.Setup;
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
    public partial class frmMDIParent : Form
    {
        Timer clockTime = new Timer();
        public frmMDIParent()
        {
            InitializeComponent();
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            cmsSetUp.Show(btnSetUp, new Point(5, 63)); 
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cmsStock.Show(btnStock, new Point(5, 63)); 
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            cmsSale.Show(btnSale, new Point(5, 63)); 
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            cmsPurchase.Show(btnPurchase, new Point(5, 63)); 
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            cmsReturn.Show(btnReturn, new Point(5, 63)); 
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            cmsItem.Show(btnItem, new Point(5, 63)); 
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            cmsCredit.Show(btnCredit, new Point(5, 63));
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            cmsEmployee.Show(btnEmployee, new Point(5, 63));
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            //Expenses
            frmExpenses frmExpenses = Application.OpenForms["frmExpenses"] as frmExpenses;
            if (frmExpenses != null)
            {
                frmExpenses.WindowState = FormWindowState.Normal;
                frmExpenses.BringToFront();
                frmExpenses.Activate();
            }
            else
            {
                frmExpenses = new frmExpenses();
                frmExpenses.MdiParent = this;
                frmExpenses.Dock = DockStyle.Fill;
                frmExpenses.Show();
            }
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            cmsTools.Show(btnTools, new Point(5, 63));
        }

        private void tsmlBusinessInformation_Click(object sender, EventArgs e)
        {
            //Business Information
            frmBusinessInformation frmBusinessInformation = Application.OpenForms["frmBusinessInformation"] as frmBusinessInformation;
            if (frmBusinessInformation != null)
            {
                frmBusinessInformation.WindowState = FormWindowState.Normal;
                frmBusinessInformation.BringToFront();
                frmBusinessInformation.Activate();
            }
            else
            {
                frmBusinessInformation = new frmBusinessInformation();
                frmBusinessInformation.MdiParent = this;
                frmBusinessInformation.Dock = DockStyle.Fill;
                frmBusinessInformation.Show();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //User Information
            frmUsers frmUsers = Application.OpenForms["frmUsers"] as frmUsers;
            if (frmUsers != null)
            {
                frmUsers.WindowState = FormWindowState.Normal;
                frmUsers.BringToFront();
                frmUsers.Activate();
            }
            else
            {
                frmUsers = new frmUsers();
                frmUsers.MdiParent = this;
                frmUsers.Dock = DockStyle.Fill;
                frmUsers.Show();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Customer Information
            frmCustomerInfo frmCustomerInfo = Application.OpenForms["frmCustomerInfo"] as frmCustomerInfo;
            if (frmCustomerInfo != null)
            {
                frmCustomerInfo.WindowState = FormWindowState.Normal;
                frmCustomerInfo.BringToFront();
                frmCustomerInfo.Activate();
            }
            else
            {
                frmCustomerInfo = new frmCustomerInfo();
                frmCustomerInfo.MdiParent = this;
                frmCustomerInfo.Dock = DockStyle.Fill;
                frmCustomerInfo.Show();
            }
        }

        private void LoadLanguegePack() {
            if (Properties.Settings.Default.App_Default_Language) {
                try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"Language\" + Properties.Settings.Default.App_Language + ".xml");
                XmlNodeList languageNodes = xmlDocument.GetElementsByTagName("language");
                foreach (XmlNode languageNode in languageNodes)
                {
                    XmlNode authorNode = languageNode["lnkChangePassword"];
                    lnkChangePassword.Text = authorNode.InnerText;

                    XmlNode SetUp = languageNode["btnSetUp"];
                    btnSetUp.Text = SetUp.InnerText;

                    XmlNode Item = languageNode["btnItem"];
                    btnItem.Text = Item.InnerText;

                    XmlNode Stock = languageNode["btnStock"];
                    btnStock.Text = Stock.InnerText;

                    XmlNode Sale = languageNode["btnSale"];
                    btnSale.Text = Sale.InnerText;

                    XmlNode Purchase = languageNode["btnPurchase"];
                    btnPurchase.Text = Purchase.InnerText;

                    XmlNode Return = languageNode["btnReturn"];
                    btnReturn.Text = Return.InnerText;

                    XmlNode Credit = languageNode["btnCredit"];
                    btnCredit.Text = Credit.InnerText;

                    XmlNode Employee = languageNode["btnEmployee"];
                    btnEmployee.Text = Employee.InnerText;

                    XmlNode Expense = languageNode["btnExpense"];
                    btnExpense.Text = Expense.InnerText;

                    XmlNode Report = languageNode["btnReport"];
                    btnReport.Text = Report.InnerText;

                    XmlNode Admin = languageNode["btnAdmin"];
                    btnAdmin.Text = Admin.InnerText;

                    XmlNode Tools = languageNode["btnTools"];
                    btnTools.Text = Tools.InnerText;

                    XmlNode LogOut = languageNode["linkLogOut"];
                    linkLogOut.Text = LogOut.InnerText;

                    XmlNode BusinessInformation = languageNode["tsmlBusinessInformation"];
                    tsmlBusinessInformation.Text = BusinessInformation.InnerText;

                    XmlNode Customer = languageNode["tsmlCustomer"];
                    tsmlCustomer.Text = Customer.InnerText;

                    XmlNode Supplier = languageNode["tsmlSupplier"];
                    tsmlSupplier.Text = Supplier.InnerText;

                    XmlNode VAT = languageNode["tsmlVAT"];
                    tsmlVAT.Text = VAT.InnerText;

                    XmlNode WareHouse = languageNode["tsmlWareHouse"];
                    tsmlWareHouse.Text = WareHouse.InnerText;

                    XmlNode Shelf = languageNode["tsmlShelf"];
                    tsmlShelf.Text = Shelf.InnerText;


                    XmlNode ItemInformation = languageNode["tsmlItemInformation"];
                    tsmlItemInformation.Text = ItemInformation.InnerText;

                    XmlNode ListOfItem = languageNode["tsmlListOfItem"];
                    tsmlListOfItem.Text = ListOfItem.InnerText;

                    XmlNode Import = languageNode["tsmlImport"];
                    tsmlImport.Text = Import.InnerText;

                    XmlNode Barcode = languageNode["tsmlBarcode"];
                    tsmlBarcode.Text = Barcode.InnerText;


                    XmlNode tStock = languageNode["tsmlStock"];
                    tsmlStock.Text = tStock.InnerText;

                    XmlNode ExpiredItem = languageNode["tsmlExpiredItem"];
                    tsmlExpiredItem.Text = ExpiredItem.InnerText;

                    XmlNode BadStock = languageNode["tsmlBadStock"];
                    tsmlBadStock.Text = BadStock.InnerText;

                    XmlNode StockTransfer = languageNode["tsmlStockTransfer"];
                    tsmlStockTransfer.Text = StockTransfer.InnerText;

                    XmlNode tSales = languageNode["tsmlSales"];
                    tsmlSales.Text = tSales.InnerText;

                    XmlNode tPOS = languageNode["tsmlPOS"];
                    tsmlPOS.Text = tPOS.InnerText;

                    XmlNode tInvoiceList = languageNode["tsmlInvoiceList"];
                    tsmlInvoiceList.Text = tInvoiceList.InnerText;

                    XmlNode tPurchase = languageNode["tsmlPurchase"];
                    tsmlPurchase.Text = tPurchase.InnerText;

                    XmlNode tPurchaseList = languageNode["tsmlPurchaseList"];
                    tsmlPurchaseList.Text = tPurchaseList.InnerText;

                    XmlNode tSalesReturn = languageNode["tsmlSalesReturn"];
                    tsmlSalesReturn.Text = tSalesReturn.InnerText;

                    XmlNode tPurchaseReturn = languageNode["tsmlPurchaseReturn"];
                    tsmlPurchaseReturn.Text = tPurchaseReturn.InnerText;


                    XmlNode tCreditSale = languageNode["tsmlCreditSale"];
                    tsmlCreditSale.Text = tCreditSale.InnerText;

                    XmlNode tCreditPurchase = languageNode["tsmlCreditPurchase"];
                    tsmlCreditPurchase.Text = tCreditPurchase.InnerText;

                    XmlNode tEmployee = languageNode["tsmlEmployee"];
                    tsmlEmployee.Text = tEmployee.InnerText;

                    XmlNode tAttendance = languageNode["tsmlAttendance"];
                    tsmlAttendance.Text = tAttendance.InnerText;

                    XmlNode tEmployeeSalary = languageNode["tsmlEmployeeSalary"];
                    tsmlEmployeeSalary.Text = tEmployeeSalary.InnerText;


                    XmlNode tItemReport = languageNode["tsmlItemReport"];
                    tsmlItemReport.Text = tItemReport.InnerText;

                    XmlNode tStockReport = languageNode["tsmlStockReport"];
                    tsmlStockReport.Text = tStockReport.InnerText;

                    XmlNode tSalesReport = languageNode["tsmlSalesReport"];
                    tsmlSalesReport.Text = tSalesReport.InnerText;


                    XmlNode tPurchaseReport = languageNode["tsmlPurchaseReport"];
                    tsmlPurchaseReport.Text = tPurchaseReport.InnerText;

                    XmlNode tReturnReport = languageNode["tsmlReturnReport"];
                    tsmlReturnReport.Text = tReturnReport.InnerText;

                    XmlNode tCreditReport = languageNode["tsmlCreditReport"];
                    tsmlCreditReport.Text = tCreditReport.InnerText;

                    XmlNode tEmployeeReport = languageNode["tsmlEmployeeReport"];
                    tsmlEmployeeReport.Text = tEmployeeReport.InnerText;

                    XmlNode tExpenseReport = languageNode["tsmlExpenseReport"];
                    tsmlExpenseReport.Text = tExpenseReport.InnerText;

                    XmlNode tLanguage = languageNode["tsmlLanguage"];
                    tsmlLanguage.Text = tLanguage.InnerText;

                    XmlNode tResetDB = languageNode["tsmlResetDB"];
                    tsmlResetDB.Text = tResetDB.InnerText;
                }
                }
                catch(Exception ex){
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            LoadLanguegePack();
            clockTime.Interval = 1000;
            clockTime.Tick += new EventHandler(this.clockTime_Tick);
            clockTime.Start();
            clsUtility.DBConnectionInitializing();
            linkLogOut.Text = linkLogOut.Text + " - " + clsUtility.UserName;

            if (clsUtility.UsersPrivilege == "Administrator")
            {
                btnSetUp.Enabled = true;
                btnItem.Enabled = true;
                btnStock.Enabled = true;
                btnSale.Enabled = true;
                btnPurchase.Enabled = true;
                btnReturn.Enabled = true;
                btnCredit.Enabled = true;
                btnEmployee.Enabled = true;
                btnExpense.Enabled = true;
                btnReport.Enabled = true;
                btnAdmin.Enabled = true;
                btnTools.Enabled = true;
            }
            else if (clsUtility.UsersPrivilege == "Manager")
            {
                btnSetUp.Enabled = false;
                btnItem.Enabled = false;
                btnStock.Enabled = false;
                btnSale.Enabled = false;
                btnPurchase.Enabled = false;
                btnReturn.Enabled = false;
                btnCredit.Enabled = true;
                btnEmployee.Enabled = true;
                btnExpense.Enabled = true;
                btnReport.Enabled = false;
                btnAdmin.Enabled = false;
                btnTools.Enabled = false;
            }
            else if (clsUtility.UsersPrivilege == "Sales") {
                btnSetUp.Enabled = false;
                btnItem.Enabled = false;
                btnStock.Enabled = true;
                btnSale.Enabled = true;
                btnPurchase.Enabled = false;
                btnReturn.Enabled = true;
                btnCredit.Enabled = true;
                btnEmployee.Enabled = false;
                btnExpense.Enabled = false;
                btnReport.Enabled = false;
                btnAdmin.Enabled = false;
                btnTools.Enabled = false;
            }
            else { clsUtility.MesgBoxShow("Permission error while saving changes.", "info"); }
        }

        private void clockTime_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Supplier Information
            frmSupplierInfo frmSupplierInfo = Application.OpenForms["frmSupplierInfo"] as frmSupplierInfo;
            if (frmSupplierInfo != null)
            {
                frmSupplierInfo.WindowState = FormWindowState.Normal;
                frmSupplierInfo.BringToFront();
                frmSupplierInfo.Activate();
            }
            else
            {
                frmSupplierInfo = new frmSupplierInfo();
                frmSupplierInfo.MdiParent = this;
                frmSupplierInfo.Dock = DockStyle.Fill;
                frmSupplierInfo.Show();
            }
        }

        private void vATSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //vat
            frmVAT frmVAT = Application.OpenForms["frmVAT"] as frmVAT;
            if (frmVAT != null)
            {
                frmVAT.WindowState = FormWindowState.Normal;
                frmVAT.BringToFront();
                frmVAT.Activate();
            }
            else
            {
                frmVAT = new frmVAT();
                frmVAT.MdiParent = this;
                frmVAT.Dock = DockStyle.Fill;
                frmVAT.Show();
            }
        }

        private void rackingToolStripMenuItem_Click(object sender, EventArgs e)
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
                frmShelf.MdiParent = this;
                frmShelf.Dock = DockStyle.Fill;
                frmShelf.Show();
            }
        }

        private void stockSetupToolStripMenuItem_Click(object sender, EventArgs e)
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
                frmWarehouse.MdiParent = this;
                frmWarehouse.Dock = DockStyle.Fill;
                frmWarehouse.Show();
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Item information
            frmItemInformation frmItemInformation = Application.OpenForms["frmItemInformation"] as frmItemInformation;
            if (frmItemInformation != null)
            {
                frmItemInformation.WindowState = FormWindowState.Normal;
                frmItemInformation.BringToFront();
                frmItemInformation.Activate();
            }
            else
            {
                frmItemInformation = new frmItemInformation("0", "0");
                frmItemInformation.MdiParent = this;
                frmItemInformation.Dock = DockStyle.Fill;
                frmItemInformation.Show();
            }
        }

        private void barcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Import Item
            frmImportItem frmImportItem = Application.OpenForms["frmImportItem"] as frmImportItem;
            if (frmImportItem != null)
            {
                frmImportItem.WindowState = FormWindowState.Normal;
                frmImportItem.BringToFront();
                frmImportItem.Activate();
            }
            else
            {
                frmImportItem = new frmImportItem();
                frmImportItem.MdiParent = this;
                frmImportItem.Dock = DockStyle.Fill;
                frmImportItem.Show();
            }
        }

        private void barcodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Barcode
            frmBarcode frmBarcode = Application.OpenForms["frmBarcode"] as frmBarcode;
            if (frmBarcode != null)
            {
                frmBarcode.WindowState = FormWindowState.Normal;
                frmBarcode.BringToFront();
                frmBarcode.Activate();
            }
            else
            {
                frmBarcode = new frmBarcode();
                frmBarcode.MdiParent = this;
                frmBarcode.Dock = DockStyle.Fill;
                frmBarcode.Show();
            }
        }

        private void listOfItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List of Item
            frmListOfItem frmListOfItem = Application.OpenForms["frmListOfItem"] as frmListOfItem;
            if (frmListOfItem != null)
            {
                frmListOfItem.WindowState = FormWindowState.Normal;
                frmListOfItem.BringToFront();
                frmListOfItem.Activate();
            }
            else
            {
                frmListOfItem = new frmListOfItem();
                frmListOfItem.MdiParent = this;
                frmListOfItem.Dock = DockStyle.Fill;
                frmListOfItem.Show();
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee
            frmEmployee frmEmployee = Application.OpenForms["frmEmployee"] as frmEmployee;
            if (frmEmployee != null)
            {
                frmEmployee.WindowState = FormWindowState.Normal;
                frmEmployee.BringToFront();
                frmEmployee.Activate();
            }
            else
            {
                frmEmployee = new frmEmployee();
                frmEmployee.MdiParent = this;
                frmEmployee.Dock = DockStyle.Fill;
                frmEmployee.Show();
            }
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee Attendance
            frmAttendance frmAttendance = Application.OpenForms["frmAttendance"] as frmAttendance;
            if (frmAttendance != null)
            {
                frmAttendance.WindowState = FormWindowState.Normal;
                frmAttendance.BringToFront();
                frmAttendance.Activate();
            }
            else
            {
                frmAttendance = new frmAttendance();
                frmAttendance.MdiParent = this;
                frmAttendance.Dock = DockStyle.Fill;
                frmAttendance.Show();
            }
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee Payment
            frmEmployeePayment frmEmployeePayment = Application.OpenForms["frmEmployeePayment"] as frmEmployeePayment;
            if (frmEmployeePayment != null)
            {
                frmEmployeePayment.WindowState = FormWindowState.Normal;
                frmEmployeePayment.BringToFront();
                frmEmployeePayment.Activate();
            }
            else
            {
                frmEmployeePayment = new frmEmployeePayment();
                frmEmployeePayment.MdiParent = this;
                frmEmployeePayment.Dock = DockStyle.Fill;
                frmEmployeePayment.Show();
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stock
            frmStock frmStock = Application.OpenForms["frmStock"] as frmStock;
            if (frmStock != null)
            {
                frmStock.WindowState = FormWindowState.Normal;
                frmStock.BringToFront();
                frmStock.Activate();
            }
            else
            {
                frmStock = new frmStock();
                frmStock.MdiParent = this;
                frmStock.Dock = DockStyle.Fill;
                frmStock.Show();
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Purchase
            frmPurchase frmPurchase = Application.OpenForms["frmPurchase"] as frmPurchase;
            if (frmPurchase != null)
            {
                frmPurchase.WindowState = FormWindowState.Normal;
                frmPurchase.BringToFront();
                frmPurchase.Activate();
            }
            else
            {
                frmPurchase = new frmPurchase("0");
                frmPurchase.MdiParent = this;
                frmPurchase.Dock = DockStyle.Fill;
                frmPurchase.Show();
            }
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           //Change Password
            frmChangePassword frmChangePassword = Application.OpenForms["frmChangePassword"] as frmChangePassword;
            if (frmChangePassword != null)
            {
                frmChangePassword.WindowState = FormWindowState.Normal;
                frmChangePassword.BringToFront();
                frmChangePassword.Activate();
            }
            else
            {
                frmChangePassword = new frmChangePassword();
                frmChangePassword.MdiParent = this;
                frmChangePassword.Dock = DockStyle.Fill;
                frmChangePassword.Show();
            }
        }

        private void purchaseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Purchase List
            frmPurchaseList frmPurchaseList = Application.OpenForms["frmPurchaseList"] as frmPurchaseList;
            if (frmPurchaseList != null)
            {
                frmPurchaseList.WindowState = FormWindowState.Normal;
                frmPurchaseList.BringToFront();
                frmPurchaseList.Activate();
            }
            else
            {
                frmPurchaseList = new frmPurchaseList();
                frmPurchaseList.MdiParent = this;
                frmPurchaseList.Dock = DockStyle.Fill;
                frmPurchaseList.Show();
            }
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Language
            frmLanguage frmLanguage = Application.OpenForms["frmLanguage"] as frmLanguage;
            if (frmLanguage != null)
            {
                frmLanguage.WindowState = FormWindowState.Normal;
                frmLanguage.BringToFront();
                frmLanguage.Activate();
            }
            else
            {
                frmLanguage = new frmLanguage();
                frmLanguage.MdiParent = this;
                frmLanguage.Dock = DockStyle.Fill;
                frmLanguage.Show();
            }
        }

        private void dataBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset Database
            frmResetDatabase frmResetDatabase = Application.OpenForms["frmResetDatabase"] as frmResetDatabase;
            if (frmResetDatabase != null)
            {
                frmResetDatabase.WindowState = FormWindowState.Normal;
                frmResetDatabase.BringToFront();
                frmResetDatabase.Activate();
            }
            else
            {
                frmResetDatabase = new frmResetDatabase();
                frmResetDatabase.MdiParent = this;
                frmResetDatabase.Dock = DockStyle.Fill;
                frmResetDatabase.Show();
            }
        }


        private void expiredItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Expired Item
            frmExpiredItem frmExpiredItem = Application.OpenForms["frmExpiredItem"] as frmExpiredItem;
            if (frmExpiredItem != null)
            {
                frmExpiredItem.WindowState = FormWindowState.Normal;
                frmExpiredItem.BringToFront();
                frmExpiredItem.Activate();
            }
            else
            {
                frmExpiredItem = new frmExpiredItem();
                frmExpiredItem.MdiParent = this;
                frmExpiredItem.Dock = DockStyle.Fill;
                frmExpiredItem.Show();
            }
        }

        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stock Transfer
            frmStockTransfer frmStockTransfer = Application.OpenForms["frmStockTransfer"] as frmStockTransfer;
            if (frmStockTransfer != null)
            {
                frmStockTransfer.WindowState = FormWindowState.Normal;
                frmStockTransfer.BringToFront();
                frmStockTransfer.Activate();
            }
            else
            {
                frmStockTransfer = new frmStockTransfer();
                frmStockTransfer.MdiParent = this;
                frmStockTransfer.Dock = DockStyle.Fill;
                frmStockTransfer.Show();
            }
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sales
            frmSales frmSales = Application.OpenForms["frmSales"] as frmSales;
            if (frmSales != null)
            {
                frmSales.WindowState = FormWindowState.Normal;
                frmSales.BringToFront();
                frmSales.Activate();
            }
            else
            {
                frmSales = new frmSales("0");
                frmSales.MdiParent = this;
                frmSales.Dock = DockStyle.Fill;
                frmSales.Show();
            }
        }

        private void invoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sales List
            frmSalesList frmSalesList = Application.OpenForms["frmSalesList"] as frmSalesList;
            if (frmSalesList != null)
            {
                frmSalesList.WindowState = FormWindowState.Normal;
                frmSalesList.BringToFront();
                frmSalesList.Activate();
            }
            else
            {
                frmSalesList = new frmSalesList();
                frmSalesList.MdiParent = this;
                frmSalesList.Dock = DockStyle.Fill;
                frmSalesList.Show();
            }
        }

        private void advancedPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Point of Sales
            frmPOS frmPOS = Application.OpenForms["frmPOS"] as frmPOS;
            if (frmPOS != null)
            {
                frmPOS.WindowState = FormWindowState.Normal;
                frmPOS.BringToFront();
                frmPOS.Activate();
            }
            else
            {
                frmPOS = new frmPOS("0");
                frmPOS.MdiParent = this;
                frmPOS.Dock = DockStyle.Fill;
                frmPOS.Show();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            cmsReports.Show(btnReport, new Point(5, 63));
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sales Return
            frmSalesReturn frmSalesReturn = Application.OpenForms["frmSalesReturn"] as frmSalesReturn;
            if (frmSalesReturn != null)
            {
                frmSalesReturn.WindowState = FormWindowState.Normal;
                frmSalesReturn.BringToFront();
                frmSalesReturn.Activate();
            }
            else
            {
                frmSalesReturn = new frmSalesReturn();
                frmSalesReturn.MdiParent = this;
                frmSalesReturn.Dock = DockStyle.Fill;
                frmSalesReturn.Show();
            }
        }

        private void adjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bad Stock
            frmBadStock frmBadStock = Application.OpenForms["frmBadStock"] as frmBadStock;
            if (frmBadStock != null)
            {
                frmBadStock.WindowState = FormWindowState.Normal;
                frmBadStock.BringToFront();
                frmBadStock.Activate();
            }
            else
            {
                frmBadStock = new frmBadStock();
                frmBadStock.MdiParent = this;
                frmBadStock.Dock = DockStyle.Fill;
                frmBadStock.Show();
            }
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Purchase Return
            frmPurchaseReturn frmPurchaseReturn = Application.OpenForms["frmPurchaseReturn"] as frmPurchaseReturn;
            if (frmPurchaseReturn != null)
            {
                frmPurchaseReturn.WindowState = FormWindowState.Normal;
                frmPurchaseReturn.BringToFront();
                frmPurchaseReturn.Activate();
            }
            else
            {
                frmPurchaseReturn = new frmPurchaseReturn();
                frmPurchaseReturn.MdiParent = this;
                frmPurchaseReturn.Dock = DockStyle.Fill;
                frmPurchaseReturn.Show();
            }
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            //Item Report
            frmReportItem frmReportItem = Application.OpenForms["frmReportItem"] as frmReportItem;
            if (frmReportItem != null)
            {
                frmReportItem.WindowState = FormWindowState.Normal;
                frmReportItem.BringToFront();
                frmReportItem.Activate();
            }
            else
            {
                frmReportItem = new frmReportItem();
                frmReportItem.MdiParent = this;
                frmReportItem.Dock = DockStyle.Fill;
                frmReportItem.Show();
            }
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            //Stock Report
            frmReportStock frmReportStock = Application.OpenForms["frmReportStock"] as frmReportStock;
            if (frmReportStock != null)
            {
                frmReportStock.WindowState = FormWindowState.Normal;
                frmReportStock.BringToFront();
                frmReportStock.Activate();
            }
            else
            {
                frmReportStock = new frmReportStock();
                frmReportStock.MdiParent = this;
                frmReportStock.Dock = DockStyle.Fill;
                frmReportStock.Show();
            }
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            //Sales Report
            frmReportSales frmReportSales = Application.OpenForms["frmReportSales"] as frmReportSales;
            if (frmReportSales != null)
            {
                frmReportSales.WindowState = FormWindowState.Normal;
                frmReportSales.BringToFront();
                frmReportSales.Activate();
            }
            else
            {
                frmReportSales = new frmReportSales();
                frmReportSales.MdiParent = this;
                frmReportSales.Dock = DockStyle.Fill;
                frmReportSales.Show();
            }
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            //Purchase Report
            frmReportPurchase frmReportPurchase = Application.OpenForms["frmReportPurchase"] as frmReportPurchase;
            if (frmReportPurchase != null)
            {
                frmReportPurchase.WindowState = FormWindowState.Normal;
                frmReportPurchase.BringToFront();
                frmReportPurchase.Activate();
            }
            else
            {
                frmReportPurchase = new frmReportPurchase();
                frmReportPurchase.MdiParent = this;
                frmReportPurchase.Dock = DockStyle.Fill;
                frmReportPurchase.Show();
            }
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            //Return Report
            frmReportReturn frmReportReturn = Application.OpenForms["frmReportReturn"] as frmReportReturn;
            if (frmReportReturn != null)
            {
                frmReportReturn.WindowState = FormWindowState.Normal;
                frmReportReturn.BringToFront();
                frmReportReturn.Activate();
            }
            else
            {
                frmReportReturn = new frmReportReturn();
                frmReportReturn.MdiParent = this;
                frmReportReturn.Dock = DockStyle.Fill;
                frmReportReturn.Show();
            }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            //Credit Report
            frmReportCredit frmReportCredit = Application.OpenForms["frmReportCredit"] as frmReportCredit;
            if (frmReportCredit != null)
            {
                frmReportCredit.WindowState = FormWindowState.Normal;
                frmReportCredit.BringToFront();
                frmReportCredit.Activate();
            }
            else
            {
                frmReportCredit = new frmReportCredit();
                frmReportCredit.MdiParent = this;
                frmReportCredit.Dock = DockStyle.Fill;
                frmReportCredit.Show();
            }
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            //Exployee Report
            frmReportEmployee frmReportEmployee = Application.OpenForms["frmReportEmployee"] as frmReportEmployee;
            if (frmReportEmployee != null)
            {
                frmReportEmployee.WindowState = FormWindowState.Normal;
                frmReportEmployee.BringToFront();
                frmReportEmployee.Activate();
            }
            else
            {
                frmReportEmployee = new frmReportEmployee();
                frmReportEmployee.MdiParent = this;
                frmReportEmployee.Dock = DockStyle.Fill;
                frmReportEmployee.Show();
            }
        }

        private void creditSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collection
            frmCollection frmCollection = Application.OpenForms["frmCollection"] as frmCollection;
            if (frmCollection != null)
            {
                frmCollection.WindowState = FormWindowState.Normal;
                frmCollection.BringToFront();
                frmCollection.Activate();
            }
            else
            {
                frmCollection = new frmCollection();
                frmCollection.MdiParent = this;
                frmCollection.Dock = DockStyle.Fill;
                frmCollection.Show();
            }
        }

        private void creditPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Payment
            frmPayment frmPayment = Application.OpenForms["frmPayment"] as frmPayment;
            if (frmPayment != null)
            {
                frmPayment.WindowState = FormWindowState.Normal;
                frmPayment.BringToFront();
                frmPayment.Activate();
            }
            else
            {
                frmPayment = new frmPayment();
                frmPayment.MdiParent = this;
                frmPayment.Dock = DockStyle.Fill;
                frmPayment.Show();
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Expense Report
            frmReportExpenses frmReportExpenses = Application.OpenForms["frmReportExpenses"] as frmReportExpenses;
            if (frmReportExpenses != null)
            {
                frmReportExpenses.WindowState = FormWindowState.Normal;
                frmReportExpenses.BringToFront();
                frmReportExpenses.Activate();
            }
            else
            {
                frmReportExpenses = new frmReportExpenses();
                frmReportExpenses.MdiParent = this;
                frmReportExpenses.Dock = DockStyle.Fill;
                frmReportExpenses.Show();
            }
        }

        private void frmMDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogIn frmLogIn = new frmLogIn();
            frmLogIn.Show();
            this.Hide();
        }



    }
}
