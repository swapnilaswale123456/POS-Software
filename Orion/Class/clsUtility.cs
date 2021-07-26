using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
//using System.Data.SQLite;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;


//=======================================================
//Developed by: LinkBird Technologies [https://codecanyon.net/user/linkbirdtech]
//              We explores your dream by providing best solutions. 
//Twitter     : @linkbirdtech
//Facebook    : facebook.com/linkbirdtech
//Email       : linkbirdtech@gmail.com
//Database    : Microsoft SQL Server
//Database URL: https://www.microsoft.com/en-us/sql-server/sql-server-2017
//=======================================================

namespace Orion
{
    class clsUtility
    {
        public static string CnString =  Properties.Settings.Default.App_Conn_string;
        public static DataTable sqlDT = new DataTable();
        public static DataTable sqlDT2 = new DataTable();
        public static string UserID;
        public static string UserName;
        public static string UsersPrivilege;
        // Initializing Database Connection
        public static bool DBConnectionInitializing()
        {
            bool functionReturnValue = false;
            try
            {
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = CnString;
                sqlCon.Open();
                functionReturnValue = true;
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                functionReturnValue = false;
                Properties.Settings.Default.App_Default_Conn = false;
                Properties.Settings.Default.Save();
                MessageBox.Show("Error : " + ex.Message, "Error establishing the database connection..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            return functionReturnValue;
        }

        public static void GetCompanyDetails_ReportsParameters()
        {
            ExecuteSQLQuery(" SELECT * FROM BusinessInformation ");
            if (sqlDT.Rows.Count > 0)
            {
                crpCompanyName.Value = sqlDT.Rows[0]["CompanyName"].ToString();
                crpAddress.Value = sqlDT.Rows[0]["Address"].ToString();
                crpTelephone.Value = sqlDT.Rows[0]["PhoneNo"].ToString();
                crpEmail.Value = sqlDT.Rows[0]["Email"].ToString();
                crpWEB.Value = sqlDT.Rows[0]["WebSite"].ToString();
                crpSlogan.Value = sqlDT.Rows[0]["WebSite"].ToString();
            }
            else
            {
                crpCompanyName.Value = "Your Company Name";
                crpAddress.Value = "Address";
                crpTelephone.Value = "Telephone";
                crpEmail.Value = "Email";
                crpWEB.Value = "Web";
                crpSlogan.Value = "Slogan Here...";
            }
        }

        public static DataTable ExecuteSQLQuery(string SQLQuery)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(CnString);
                SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
                SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);
                sqlDT.Reset();
                sqlDA.Fill(sqlDT);
            }
            catch (Exception ex)
            {
				Properties.Settings.Default.App_Default_Conn = false;
				Properties.Settings.Default.Save();
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sqlDT;
        }


        public static DataTable ExecuteSQLQuery2(string SQLQuery)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(CnString);
                SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
                SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);
                sqlDT2.Reset();
                sqlDA.Fill(sqlDT2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sqlDT2;
        }

        public static void FillDataGrid(string sql, DataGridView dgv)
        {
            SqlConnection conn = new SqlConnection(CnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                dgv.DataSource = dt;
                adp.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // FillCombo Box dynamically
        public static void FillComboBox(string sql, string Value_Member, string Display_Member, ComboBox combo)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(CnString))
            {
                using (var cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        dt.Load(cmd.ExecuteReader());
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(" Error : " + e.ToString());
                    }
                }
            }
            combo.DataSource = dt;
            combo.ValueMember = Value_Member;
            combo.DisplayMember = Display_Member;
        }

        public static double num_repl(string a)
        {
            double n;
            bool isNumeric = double.TryParse(a, out n);
            return n;
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string GenarateAutoBarcode(string barcode)
        {
            double val = 0;
            ExecuteSQLQuery("SELECT * FROM Barcode");
            if (sqlDT.Rows.Count > 0)
            {
                barcode = sqlDT.Rows[0]["Barcode"].ToString();
                val = Int64.Parse(barcode) + 1;
                ExecuteSQLQuery("UPDATE  Barcode  SET  Barcode='" + val + "' ");
                barcode = val.ToString();
            }
            else
            {
                ExecuteSQLQuery("INSERT INTO Barcode (Barcode) VALUES ('1000000000') ");
                barcode = "1000000000";
            }
            return barcode;
        }

        public static void MesgBoxShow(string msg, string alertType)
        {
            frmMsgBox frmMsgBox = new frmMsgBox(msg, alertType);
            frmMsgBox.ShowDialog();
        }

        public static object fltr_combo(ComboBox cmbo)
        {
            if (cmbo.SelectedIndex == -1)
            {
                return 0;
            }
            return cmbo.SelectedValue;
        }

        public static void Preview__TaxInvoice(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\tax_invoice.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "SalesInvoice");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTime);
            rpt_Document.ParameterFields["TIME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDiscount);
            rpt_Document.ParameterFields["DISCOUNT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpExprDate);
            rpt_Document.ParameterFields["EXPR_DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTermCond);
            rpt_Document.ParameterFields["TERM_COND"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTerm1);
            rpt_Document.ParameterFields["TERM_1"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTerm2);
            rpt_Document.ParameterFields["TERM_2"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["ENTRY_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["SOLD_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpShipping);
            rpt_Document.ParameterFields["SHIP_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBilling);
            rpt_Document.ParameterFields["BILL_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpComment);
            rpt_Document.ParameterFields["COMMENT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAuthSigh);
            rpt_Document.ParameterFields["AUTH_SIGN"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpGrossAmount);
            rpt_Document.ParameterFields["GROSS_AMT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUnit);
            rpt_Document.ParameterFields["UNIT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotalPrice);
            rpt_Document.ParameterFields["TOTAL_PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUnitVat);
            rpt_Document.ParameterFields["UNIT_VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotalVat);
            rpt_Document.ParameterFields["TOTAL_VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTaxInv);
            rpt_Document.ParameterFields["TAX_INV"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__SalesReceipt(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\sales_receipt.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "SalesInvoice");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSlogan);
            rpt_Document.ParameterFields["Slogan"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTime);
            rpt_Document.ParameterFields["TIME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["SOLD_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpRcpVat);
            rpt_Document.ParameterFields["VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpGrossAmount);
            rpt_Document.ParameterFields["GROSS_AMT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDiscount);
            rpt_Document.ParameterFields["DISCOUNT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPayment);
            rpt_Document.ParameterFields["PAYMENT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpRcpNotice);
            rpt_Document.ParameterFields["Notice"].CurrentValues = ParamCollection;

			AppStartDirectory.Value = Application.StartupPath + @"\Upload\Company\BrandLogo.jpg";
            ParamCollection.Add(AppStartDirectory);
            rpt_Document.ParameterFields["AppStartDirectory"].CurrentValues = ParamCollection;
            //CrystalReportViewer.ReportSource = rpt_Document;
            rpt_Document.PrintToPrinter(1, false, 1, 1);
        }

        public static void Preview__PurchaseDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\purchase_report.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Purchase");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSuppName);
            rpt_Document.ParameterFields["SUPP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["CUST_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWarehouse);
            rpt_Document.ParameterFields["WAREHOUSE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDiscount);
            rpt_Document.ParameterFields["DISCOUNT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPurchase);
            rpt_Document.ParameterFields["PURCHASE"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }



        public static void Preview__BestProductSale(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\best_product_sale.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "BestProductSale");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBarcode);
            rpt_Document.ParameterFields["BARCODE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBestSale);
            rpt_Document.ParameterFields["BestSale"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview__Barcode(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\barcode.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Barcode");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["Price"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__SaleDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\sales_report.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "SalesInvoice");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCost);
            rpt_Document.ParameterFields["COST"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpVAT);
            rpt_Document.ParameterFields["VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpExprDate);
            rpt_Document.ParameterFields["EXP_DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustName);
            rpt_Document.ParameterFields["CUST_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["CUST_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["CUST_PHN"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDiscount);
            rpt_Document.ParameterFields["DISCOUNT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["SOLD_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTime);
            rpt_Document.ParameterFields["TIME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpProfit);
            rpt_Document.ParameterFields["PROFIT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSale);
            rpt_Document.ParameterFields["SALES"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__SalesReturn(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\sales_return.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "SalesReturn");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpVAT);
            rpt_Document.ParameterFields["VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustName);
            rpt_Document.ParameterFields["CUST_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["CUST_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["CUST_PHN"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["SOLD_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTime);
            rpt_Document.ParameterFields["TIME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSaleReturn);
            rpt_Document.ParameterFields["SALES_RETURN"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSale);
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__PurchaseReturn(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\purchase_retrun.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "PurchaseReturn");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSuppName);
            rpt_Document.ParameterFields["SUPP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["CUST_ADD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["CUST_PHN"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD_PAY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSoldBy);
            rpt_Document.ParameterFields["SOLD_BY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTime);
            rpt_Document.ParameterFields["TIME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPurchaseReturn);
            rpt_Document.ParameterFields["PurchaseReturn"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__Purchase(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\purchase.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Purchase");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTotal);
            rpt_Document.ParameterFields["TOTAL"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPayment);
            rpt_Document.ParameterFields["PAYMENT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDue);
            rpt_Document.ParameterFields["DUE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDiscount);
            rpt_Document.ParameterFields["DISCOUNT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpExprDate);
            rpt_Document.ParameterFields["EXP_DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSuppName);
            rpt_Document.ParameterFields["SUPP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["SUPP_ADDRESS"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWarehouse);
            rpt_Document.ParameterFields["TO_WAREHOUSE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPurchase);
            rpt_Document.ParameterFields["PUR_INV"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview__Collection(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\collection.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Collection");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustName);
            rpt_Document.ParameterFields["CUSTOMER_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["PHONE_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpColl);
            rpt_Document.ParameterFields["COLLECTION"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__SupplierPayment(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\payment.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Payment");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpInvNo);
            rpt_Document.ParameterFields["INV_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpSuppName);
            rpt_Document.ParameterFields["SUPP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["PHONE_NO"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCashPay);
            rpt_Document.ParameterFields["CASH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCardPay);
            rpt_Document.ParameterFields["CARD"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPayment);
            rpt_Document.ParameterFields["PAYMENT"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__EmployeePayment(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\employee_payment.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "EmployeePayment");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDescription);
            rpt_Document.ParameterFields["Description"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDesignation);
            rpt_Document.ParameterFields["DESIGNATION"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmpName);
            rpt_Document.ParameterFields["EMP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAmount);
            rpt_Document.ParameterFields["Amount"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmpPayment);
            rpt_Document.ParameterFields["EMP_PAYMENT"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__EmployeeAttandance(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\attendance.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Attendance");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpString);
            rpt_Document.ParameterFields["ShareDate"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDesignation);
            rpt_Document.ParameterFields["DESIGNATION"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmpName);
            rpt_Document.ParameterFields["EMP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAttandance);
            rpt_Document.ParameterFields["Attandance"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPresent);
            rpt_Document.ParameterFields["Present"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAbsent);
            rpt_Document.ParameterFields["Absent"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpRemarks);
            rpt_Document.ParameterFields["Remarks"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }

        public static void Preview__EmployeeList(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\employee_list.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Employee");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmpName);
            rpt_Document.ParameterFields["EMP_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDesignation);
            rpt_Document.ParameterFields["DESIGNATION"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustAddress);
            rpt_Document.ParameterFields["CustAddress"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCustPhone);
            rpt_Document.ParameterFields["CustPhone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmployeeList);
            rpt_Document.ParameterFields["EmployeeList"].CurrentValues = ParamCollection;
            AppStartDirectory.Value = Application.StartupPath + @"\Upload\Employee\";
            ParamCollection.Add(AppStartDirectory);
            rpt_Document.ParameterFields["AppStartDirectory"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview__CurrentStock(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\current_stock.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "StockDetails");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpQty);
            rpt_Document.ParameterFields["QTY"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBarcode);
            rpt_Document.ParameterFields["BARCODE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCost);
            rpt_Document.ParameterFields["COST"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpShelf);
            rpt_Document.ParameterFields["SHELF"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWarehouse);
            rpt_Document.ParameterFields["WAREHOUSE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpStock);
            rpt_Document.ParameterFields["STOCK"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPurchaseCost);
            rpt_Document.ParameterFields["PurchaseCost"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview__ExpenseList(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\expense_list.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "Expenses");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDate);
            rpt_Document.ParameterFields["DATE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpExpenditure);
            rpt_Document.ParameterFields["Expenditure"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpDescription);
            rpt_Document.ParameterFields["Description"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAmount);
            rpt_Document.ParameterFields["Amount"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview__ListOfItem(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportLanguegePack();
            GetCompanyDetails_ReportsParameters();
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\list_of_item.rpt");
            SqlConnection My_Connection = default(SqlConnection);
            SqlCommand my_Command = new SqlCommand();
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
            dsOrion my_DataSource = new dsOrion();
            My_Connection = new SqlConnection(CnString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            my_DataAdapter.Fill(my_DataSource, "ItemDetails");
            rpt_Document.SetDataSource(my_DataSource);
            ParamCollection.Add(crpCompanyName);
            rpt_Document.ParameterFields["CompanyName"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpAddress);
            rpt_Document.ParameterFields["Address"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpTelephone);
            rpt_Document.ParameterFields["Telephone"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpEmail);
            rpt_Document.ParameterFields["Email"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWEB);
            rpt_Document.ParameterFields["WEB"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpID);
            rpt_Document.ParameterFields["ID"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpItemName);
            rpt_Document.ParameterFields["ITEM_NAME"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpUom);
            rpt_Document.ParameterFields["UOM"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBatch);
            rpt_Document.ParameterFields["BATCH"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpBarcode);
            rpt_Document.ParameterFields["BARCODE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpCost);
            rpt_Document.ParameterFields["COST"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpPrice);
            rpt_Document.ParameterFields["PRICE"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpVAT);
            rpt_Document.ParameterFields["VAT"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpReorder);
            rpt_Document.ParameterFields["REORDER"].CurrentValues = ParamCollection;
            ParamCollection.Add(crpWarehouse);
            rpt_Document.ParameterFields["WAREHOUSE"].CurrentValues = ParamCollection;
            AppStartDirectory.Value = Application.StartupPath + @"\Upload\ItemImage\";
            ParamCollection.Add(AppStartDirectory);
            rpt_Document.ParameterFields["AppStartDirectory"].CurrentValues = ParamCollection;
            CrystalReportViewer.ReportSource = rpt_Document;
        }


        public static void ReportLanguegePack()
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
                        XmlNode l1182 = languageNode["l1182"];
                        crpID.Value = l1182.InnerText;
                        XmlNode l1030 = languageNode["l1030"];
                        crpItemName.Value = l1030.InnerText;
                        XmlNode l1031 = languageNode["l1031"];
                        crpUom.Value = l1031.InnerText;
                        XmlNode l1032 = languageNode["l1032"];
                        crpBatch.Value = l1032.InnerText;
                        XmlNode l1034 = languageNode["l1034"];
                        crpBarcode.Value = l1034.InnerText;
                        XmlNode l1037 = languageNode["l1037"];
                        crpCost.Value = l1037.InnerText;
                        crpPurchaseCost.Value = l1037.InnerText;
                        XmlNode l1038 = languageNode["l1038"];
                        crpPrice.Value = l1038.InnerText;
                        XmlNode l1039 = languageNode["l1039"];
                        crpReorder.Value = l1039.InnerText;
                        XmlNode l1036 = languageNode["l1036"];
                        crpVAT.Value = l1036.InnerText;
                        XmlNode l1042 = languageNode["l1042"];
                        crpWarehouse.Value = l1042.InnerText;
                        XmlNode l1043 = languageNode["l1043"];
                        crpShelf.Value = l1043.InnerText;
                        XmlNode l1053 = languageNode["l1053"];
                        crpQty.Value = l1053.InnerText;
                        XmlNode l1055 = languageNode["l1055"];
                        crpStock.Value = l1055.InnerText;
                        XmlNode l1132 = languageNode["l1132"];
                        crpBestSale.Value = l1132.InnerText;
                        XmlNode l1046 = languageNode["l1046"];
                        crpExprDate.Value = l1046.InnerText;
                        XmlNode l1011 = languageNode["l1011"];
                        crpCustName.Value = l1011.InnerText;
                        XmlNode l1004 = languageNode["l1004"];
                        crpCustAddress.Value = l1004.InnerText;
                        XmlNode l1005 = languageNode["l1005"];
                        crpCustPhone.Value = l1005.InnerText;
                        XmlNode l1070 = languageNode["l1070"];
                        crpDiscount.Value = l1070.InnerText;
                        XmlNode l1073 = languageNode["l1073"];
                        crpCashPay.Value = l1073.InnerText;
                        XmlNode l1074 = languageNode["l1074"];
                        crpCardPay.Value = l1074.InnerText;
                        XmlNode l1076 = languageNode["l1076"];
                        crpDue.Value = l1076.InnerText;
                        XmlNode l1071 = languageNode["l1071"];
                        crpTotal.Value = l1071.InnerText;
                        XmlNode l1195 = languageNode["l1195"];
                        crpTime.Value = l1195.InnerText;
                        XmlNode l1097 = languageNode["l1097"];
                        crpSoldBy.Value = l1097.InnerText;
                        XmlNode l1065 = languageNode["l1065"];
                        crpDate.Value = l1065.InnerText;
                        XmlNode l1067 = languageNode["l1067"];
                        crpInvNo.Value = l1067.InnerText;
                        XmlNode l1196 = languageNode["l1196"];
                        crpProfit.Value = l1196.InnerText;
                        XmlNode l1127 = languageNode["l1127"];
                        crpSale.Value = l1127.InnerText;
                        XmlNode l1018 = languageNode["l1018"];
                        crpSuppName.Value = l1018.InnerText;
                        XmlNode l1086 = languageNode["l1086"];
                        crpPurchase.Value = l1086.InnerText;
                        XmlNode l1089 = languageNode["l1089"];
                        crpSaleReturn.Value = l1089.InnerText;
                        XmlNode l1092 = languageNode["l1092"];
                        crpPurchaseReturn.Value = l1092.InnerText;
                        XmlNode l1175 = languageNode["l1175"];
                        crpExpenditure.Value = l1175.InnerText;
                        XmlNode l1115 = languageNode["l1115"];
                        crpDescription.Value = l1115.InnerText;
                        XmlNode l1116 = languageNode["l1116"];
                        crpAmount.Value = l1116.InnerText;
                        XmlNode l1105 = languageNode["l1105"];
                        crpDesignation.Value = l1105.InnerText;
                        XmlNode l1104 = languageNode["l1104"];
                        crpEmpName.Value = l1104.InnerText;
                        XmlNode l1113 = languageNode["l1113"];
                        crpEmpPayment.Value = l1113.InnerText;
                        XmlNode l1110 = languageNode["l1110"];
                        crpPresent.Value = l1110.InnerText;
                        XmlNode l1111 = languageNode["l1111"];
                        crpAbsent.Value = l1111.InnerText;
                        XmlNode l1112 = languageNode["l1112"];
                        crpRemarks.Value = l1112.InnerText;
                        XmlNode l1106 = languageNode["l1106"];
                        crpAttandance.Value = l1106.InnerText;
                        XmlNode l1102 = languageNode["l1102"];
                        crpEmployeeList.Value = l1102.InnerText;
                        XmlNode l1094 = languageNode["l1094"];
                        crpColl.Value = l1094.InnerText;
                        XmlNode l1098 = languageNode["l1098"];
                        crpPayment.Value = l1098.InnerText;
                        XmlNode l1197 = languageNode["l1197"];
                        crpTermCond.Value = l1197.InnerText;
                        XmlNode l1198 = languageNode["l1198"];
                        crpTerm1.Value = l1198.InnerText;
                        XmlNode l1199 = languageNode["l1199"];
                        crpTerm2.Value = l1199.InnerText;
                        XmlNode l1204 = languageNode["l1204"];
                        crpGrossAmount.Value = l1204.InnerText;
                        XmlNode l1205 = languageNode["l1205"];
                        crpUnit.Value = l1205.InnerText;
                        XmlNode l1206 = languageNode["l1206"];
                        crpTotalPrice.Value = l1206.InnerText;
                        XmlNode l1207 = languageNode["l1207"];
                        crpUnitVat.Value = l1207.InnerText;
                        XmlNode l1208 = languageNode["l1208"];
                        crpTotalVat.Value = l1208.InnerText;
                        XmlNode l1200 = languageNode["l1200"];
                        crpShipping.Value = l1200.InnerText;
                        XmlNode l1201 = languageNode["l1201"];
                        crpBilling.Value = l1201.InnerText;
                        XmlNode l1202 = languageNode["l1202"];
                        crpAuthSigh.Value = l1202.InnerText;
                        XmlNode l1203 = languageNode["l1203"];
                        crpComment.Value = l1203.InnerText;
                        XmlNode l1209 = languageNode["l1209"];
                        crpTaxInv.Value = l1209.InnerText;
                        XmlNode l1069 = languageNode["l1069"];
                        crpRcpVat.Value = l1069.InnerText;
                        XmlNode l1210 = languageNode["l1210"];
                        crpRcpNotice.Value = l1210.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                crpID.Value = "ID #";
                crpItemName.Value = "ITEM NAME";
                crpUom.Value = "UOM";
                crpBatch.Value = "BATCH";
                crpBarcode.Value = "BARCODE";
                crpCost.Value = "COST";
                crpPrice.Value = "PRICE";
                crpReorder.Value = "ROP";
                crpVAT.Value = "VAT";
                crpWarehouse.Value = "WAREHOUSE";
                crpQty.Value = "QTY.";
                crpShelf.Value = "SHELF";
                crpShelf.Value = "STOCK";
                crpPurchaseCost.Value = "PURCHASE COST";
                crpBestSale.Value = "BEST PRODUCT SALE";
                crpExprDate.Value = "EXPR. DATE";
                crpCustName.Value = "CUSTOMER NAME";
                crpCustAddress.Value = "ADDRESS";
                crpCustPhone.Value = "PHONE NO";
                crpDiscount.Value = "DISCOUNT";
                crpCashPay.Value = "CASH";
                crpCardPay.Value = "CARD";
                crpDue.Value = "DUE";
                crpTotal.Value = "TOTAL";
                crpTime.Value = "TIME";
                crpInvNo.Value = "INV. NO";
                crpDate.Value = "DATE";
                crpSoldBy.Value = "BY";
                crpProfit.Value = "PROFIT";
                crpSale.Value = "SALES";
                crpSuppName.Value = "SUPP. NAME";
                crpPurchase.Value = "PURCHASE";
                crpSaleReturn.Value = "SALE RETURN";
                crpPurchaseReturn.Value = "PURCHASE RETURN";
                crpExpenditure.Value = "Expenditure Account";
                crpDescription.Value = "Description";
                crpAmount.Value = "AMOUNT";
                crpDesignation.Value = "Designation";
                crpEmpName.Value = "Employee Name";
                crpEmpPayment.Value = "Employee Payment";
                crpPresent.Value = "Present";
                crpAbsent.Value = "Absent";
                crpRemarks.Value = "Remarks";
                crpAttandance.Value = "Attendance";
                crpEmployeeList.Value = "EMPLOYEE LIST";
                crpColl.Value = "COLLECTION";
                crpPayment.Value = "PAYMENT";
                crpTermCond.Value = "TERMS  AND CONDITION";
                crpTerm1.Value = "All goods returned for replacement must be in salable condition with original packing.";
                crpTerm2.Value = "We are not responsible for any transit damage loss or leakage.";

                crpShipping.Value = "Shipping Address";
                crpBilling.Value = "Billing Address";
                crpAuthSigh.Value = "Authorized Signature";
                crpComment.Value = "COMMENTS";

                crpGrossAmount.Value = "GROSS PRICE";
                crpUnit.Value = "UNIT";
                crpTotalPrice.Value = "TOTAL PRICE";
                crpUnitVat.Value = "UNIT VAT";
                crpTotalVat.Value = "TOTAL VAT";
                crpTaxInv.Value = "TAX INVOICE";
                crpRcpVat.Value = "VAT";
                crpRcpNotice.Value = "GOODS ONCE SOLD CAN’T BE RETURNED OR EXCHANGE.";
                crpStock.Value = "STOCK";
            }
        }


        //Crystal Reports Parameters
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCompanyName = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpAddress = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTelephone = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpEmail = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpWEB = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpSlogan = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpString = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue AppStartDirectory = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpID = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpItemName = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpUom = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpBatch = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpBarcode = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCost = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPrice = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpReorder = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpVAT = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpWarehouse = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpQty = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpShelf = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpStock = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPurchaseCost = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpBestSale = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpExprDate = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCustName = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCustAddress = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCustPhone = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpDiscount = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCashPay = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpCardPay = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpDue = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTotal = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpInvNo = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpDate = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTime = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpSoldBy = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpProfit = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpSale = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpSuppName = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPurchase = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpSaleReturn = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPurchaseReturn = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpExpenditure = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpDescription = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpAmount = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpDesignation = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpEmpName = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpEmpPayment = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPresent = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpAbsent = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpRemarks = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpAttandance = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpEmployeeList = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpColl = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpPayment = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTermCond = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTerm1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTerm2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpShipping = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpBilling = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpAuthSigh = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpComment = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpUnit = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTotalPrice = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpUnitVat = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTotalVat = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpGrossAmount = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpTaxInv = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpRcpVat = new CrystalDecisions.Shared.ParameterDiscreteValue();
        public static CrystalDecisions.Shared.ParameterDiscreteValue crpRcpNotice = new CrystalDecisions.Shared.ParameterDiscreteValue();
    }
}
