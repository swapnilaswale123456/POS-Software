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
    public partial class frmResetDatabase : Form
    {
        public frmResetDatabase()
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
                        XmlNode l1170 = languageNode["l1170"];
                        lbl1170.Text = l1170.InnerText;

                        XmlNode l1171 = languageNode["l1171"];
                        lbl1171.Text = l1171.InnerText;

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

        private void frmResetDatabase_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LoadLanguegePack();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbSQLite.Checked) {
                //// ////// TRUNCATE  sqlite statement is very fast, and a better approach than dropping the table.
                clsUtility.ExecuteSQLQuery(" DELETE FROM Attendance; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Attendance'; DELETE FROM BadStock; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'BadStock'; " +
                                           " DELETE FROM Barcode;  DELETE FROM BusinessInformation;  DELETE FROM Collection; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Collection'; DELETE FROM Customer; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Customer'; " +
                                           " DELETE FROM Employee; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Employee'; DELETE FROM EmployeePayment; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'EmployeePayment'; " +
                                           " DELETE FROM ExpenditureAccount; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'ExpenditureAccount'; DELETE FROM Expense; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Expense'; " +
                                           " DELETE FROM ItemGroup; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'ItemGroup'; DELETE FROM ItemInformation; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'ItemInformation'; " +
                                           " DELETE FROM Payment; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Payment'; DELETE FROM PrintBarcode; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'PrintBarcode'; " +
                                           " DELETE FROM Purchase; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Purchase'; DELETE FROM PurchaseInfo; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'PurchaseInfo'; " +
                                           " DELETE FROM PurchaseReturn; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'PurchaseReturn'; DELETE FROM PurchaseReturnInfo; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'PurchaseReturnInfo'; " +
                                           " DELETE FROM Sales; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Sales'; DELETE FROM SalesInfo; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'SalesInfo'; " +
                                           " DELETE FROM SalesRetrnInfo; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'SalesRetrnInfo'; DELETE FROM SalesReturn; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'SalesReturn'; " +
                                           " DELETE FROM Shelf; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Shelf'; DELETE FROM Stock; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Stock'; " +
                                           " DELETE FROM StockTransfer; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'StockTransfer'; DELETE FROM Supplier; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Supplier'; " +
                                           " DELETE FROM Users; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Users'; DELETE FROM Vat;  DELETE FROM Warehouse; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'Warehouse'; ");
                clsUtility.MesgBoxShow("msgDelete", "info");
                Environment.Exit(0);
                ///////////
            }
            else if (rbMySQL.Checked) {
                //// ////// TRUNCATE  sqlite statement is very fast, and a better approach than dropping the table.
                clsUtility.ExecuteSQLQuery(" TRUNCATE TABLE Attendance; TRUNCATE TABLE BadStock;  TRUNCATE TABLE Barcode; TRUNCATE TABLE BusinessInformation;   " +
                                           " TRUNCATE TABLE Collection; TRUNCATE TABLE Customer; TRUNCATE TABLE Employee; TRUNCATE TABLE EmployeePayment; TRUNCATE TABLE ExpenditureAccount; TRUNCATE TABLE Expense;  " +
                                           " TRUNCATE TABLE ItemGroup; TRUNCATE TABLE ItemInformation; TRUNCATE TABLE Payment;TRUNCATE TABLE PrintBarcode;TRUNCATE TABLE Purchase; TRUNCATE TABLE PurchaseInfo;  " +
                                           " TRUNCATE TABLE PurchaseReturn;TRUNCATE TABLE PurchaseReturnInfo; TRUNCATE TABLE Sales; TRUNCATE TABLE SalesInfo; TRUNCATE TABLE SalesRetrnInfo;TRUNCATE TABLE SalesReturn;   " +
                                           " TRUNCATE TABLE Shelf;TRUNCATE TABLE Stock;TRUNCATE TABLE StockTransfer;TRUNCATE TABLE Supplier; TRUNCATE TABLE Users; TRUNCATE TABLE Vat; TRUNCATE TABLE Warehouse;   ");
                clsUtility.MesgBoxShow("msgDelete", "info");
                Environment.Exit(0);
                ///////////
            }
            else if (rbSQLServer.Checked) {
                //// ////// TRUNCATE  sqlite statement is very fast, and a better approach than dropping the table.
                clsUtility.ExecuteSQLQuery(" TRUNCATE TABLE Attendance; TRUNCATE TABLE BadStock;  TRUNCATE TABLE Barcode; TRUNCATE TABLE BusinessInformation;   " +
                                           " TRUNCATE TABLE Collection; TRUNCATE TABLE Customer; TRUNCATE TABLE Employee; TRUNCATE TABLE EmployeePayment; TRUNCATE TABLE ExpenditureAccount; TRUNCATE TABLE Expense;  " +
                                           " TRUNCATE TABLE ItemGroup; TRUNCATE TABLE ItemInformation; TRUNCATE TABLE Payment;TRUNCATE TABLE PrintBarcode;TRUNCATE TABLE Purchase; TRUNCATE TABLE PurchaseInfo;  " +
                                           " TRUNCATE TABLE PurchaseReturn;TRUNCATE TABLE PurchaseReturnInfo; TRUNCATE TABLE Sales; TRUNCATE TABLE SalesInfo; TRUNCATE TABLE SalesRetrnInfo;TRUNCATE TABLE SalesReturn;   " +
                                           " TRUNCATE TABLE Shelf;TRUNCATE TABLE Stock;TRUNCATE TABLE StockTransfer;TRUNCATE TABLE Supplier; TRUNCATE TABLE Users; TRUNCATE TABLE Vat; TRUNCATE TABLE Warehouse;   ");
                clsUtility.MesgBoxShow("msgDelete", "info");
                Environment.Exit(0);
                ///////////
            }
            else {
                MessageBox.Show("An illegal operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
