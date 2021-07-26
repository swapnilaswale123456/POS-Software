-- Table: Attendance
CREATE TABLE "Attendance" (
	`EMP_ID`	INTEGER,
	`AttendanceDate`	TEXT,
	`Present`	INTEGER,
	`Absent`	INTEGER,
	`Remarks`	TEXT
);

-- Table: BadStock
CREATE TABLE `BadStock` (
	`BDS_ID`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`WarehouseID`	INTEGER,
	`ITEM_ID`	INTEGER,
	`Quantity`	NUMERIC,
	`SoldDate`	TEXT,
	`Reason`	TEXT
);

-- Table: Barcode
CREATE TABLE [Barcode] ([Barcode] numeric(63, 0));

-- Table: BusinessInformation
CREATE TABLE [BusinessInformation] ([CompanyName] nvarchar(254), [LegalName] nvarchar(254), [Address] text, [PhoneNo] nvarchar(254), [Email] nvarchar(254), [WebSite] nvarchar(254), [Slogan] text);

-- Table: Collection
CREATE TABLE `Collection` (
	`COLL_ID`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`SALES_ID`	INTEGER,
	`CUST_ID`	INTEGER,
	`EntryDate`	TEXT,
	`EnteredBy`	TEXT,
	`Cash`	NUMERIC,
	`Card`	NUMERIC
);

-- Table: Customer
CREATE TABLE "Customer" (
	`CUST_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CustomerName`	TEXT,
	`Address`	TEXT,
	`PhoneNo`	TEXT,
	`OpeningDate`	TEXT,
	`Balance`	NUMERIC,
	`PhotoFileName`	TEXT
);

-- Table: Employee
CREATE TABLE "Employee" (
	`EMP_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`EmployeeName`	TEXT,
	`Designation`	TEXT,
	`Address`	TEXT,
	`PhoneNo`	TEXT,
	`OpeningDate`	TEXT,
	`Balance`	TEXT,
	`PhotoFileName`	TEXT
);

-- Table: EmployeePayment
CREATE TABLE `EmployeePayment` (
	`EMP_PAY_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`EMP_ID`	INTEGER,
	`PaidDate`	TEXT,
	`Description`	TEXT,
	`PaidAmount`	NUMERIC
);

-- Table: ExpenditureAccount
CREATE TABLE `ExpenditureAccount` (
	`EXP_AC_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`ExpenditureAccount`	TEXT
);

-- Table: Expense
CREATE TABLE `Expense` (
	`Expense_ID`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`EXP_AC_ID`	INTEGER,
	`PaidDate`	TEXT,
	`Description`	TEXT,
	`Amount`	NUMERIC
);

-- Table: ItemGroup
CREATE TABLE "ItemGroup" ([GROUP_ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [GROUP_NAME] text);

-- Table: ItemInformation
CREATE TABLE "ItemInformation" (
	`ITEM_ID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
	`ItemName`	text,
	`UnitOfMeasure`	text,
	`Batch`	text,
	`GROUP_ID`	integer,
	`Barcode`	text,
	`Cost`	numeric ( 53 , 0 ),
	`Price`	numeric ( 53 , 0 ),
	`ReorderPoint`	numeric ( 53 , 0 ),
	`VAT_Applicable`	text,
	`WarehouseID`	INTEGER,
	`PhotoFileName`	TEXT
);

-- Table: Payment
CREATE TABLE `Payment` (
	`PAYM_ID`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`PUCHSE_ID`	INTEGER,
	`SUPP_ID`	INTEGER,
	`EntryDate`	TEXT,
	`EnteredBy`	TEXT,
	`Cash`	NUMERIC,
	`Card`	NUMERIC
);

-- Table: PrintBarcode
CREATE TABLE `PrintBarcode` (
	`id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`COMPANY_NAME`	TEXT,
	`BARCODE_1`	TEXT,
	`PRODUCT_NAME_1`	TEXT,
	`PRICE_1`	TEXT,
	`BARCODE_2`	TEXT,
	`PRODUCT_NAME_2`	TEXT,
	`PRICE_2`	TEXT
);

-- Table: Purchase
CREATE TABLE "Purchase" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`PUCHSE_ID`	INTEGER,
	`ITEM_ID`	INTEGER,
	`WarehouseID`	INTEGER,
	`QTY`	NUMERIC,
	`TotalPrice`	NUMERIC,
	`ExpDate`	TEXT,
	`Stock`	TEXT,
	`SoldDate`	TEXT
);

-- Table: PurchaseInfo
CREATE TABLE "PurchaseInfo" (
	`PUCHSE_ID`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	`PurchaseDate`	TEXT,
	`ItemPrice`	NUMERIC,
	`Discount`	NUMERIC,
	`GrandTotal`	NUMERIC,
	`Due`	NUMERIC,
	`SUPP_ID`	INTEGER,
	`CardPay`	NUMERIC,
	`CashPay`	NUMERIC,
	`USER_ID`	INTEGER
);

-- Table: PurchaseReturn
CREATE TABLE "PurchaseReturn" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`PUCHSE_ID`	INTEGER,
	`ITEM_ID`	INTEGER,
	`WarehouseID`	INTEGER,
	`QTY`	NUMERIC,
	`TotalPrice`	NUMERIC
);

-- Table: PurchaseReturnInfo
CREATE TABLE "PurchaseReturnInfo" (
	`PUCHSE_ID`	INTEGER,
	`PurchaseReturnDate`	TEXT,
	`PurchaseReturnTime`	TEXT,
	`EntreBy`	TEXT,
	`Total`	NUMERIC,
	`CardPay`	NUMERIC,
	`CashPay`	NUMERIC,
	`SUPP_ID`	INTEGER,
	`USER_ID`	INTEGER
);

-- Table: Sales
CREATE TABLE "Sales" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`SALES_ID`	INTEGER,
	`Sales_Date`	TEXT,
	`ITEM_ID`	INTEGER,
	`QTY`	NUMERIC,
	`Price`	NUMERIC,
	`TotalPrice`	NUMERIC,
	`Cost`	NUMERIC,
	`TotalCost`	NUMERIC,
	`Vat`	NUMERIC,
	`TotalVat`	NUMERIC,
	`ExprDate`	TEXT,
	`Terminal`	TEXT
);

-- Table: SalesInfo
CREATE TABLE "SalesInfo" (
	`SALES_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`USER_ID`	INTEGER,
	`CUST_ID`	INTEGER,
	`SalesDate`	TEXT,
	`SalesTime`	TEXT,
	`ItemPrice`	NUMERIC,
	`VAT`	NUMERIC,
	`Discount`	NUMERIC,
	`GrandTotal`	NUMERIC,
	`EntreBy`	TEXT,
	`CashPay`	NUMERIC,
	`CardPay`	NUMERIC,
	`Due`	NUMERIC,
	`Comment`	TEXT,
	`Terminal`	TEXT,
	`TrnsNo`	TEXT,
	`ShippingName`	TEXT,
	`ShippingAddress`	TEXT,
	`ShippingContact`	TEXT
);

-- Table: SalesRetrnInfo
CREATE TABLE "SalesRetrnInfo" (
	`SALES_ID`	INTEGER,
	`SalesReturnDate`	TEXT,
	`SalesReturnTime`	TEXT,
	`Total`	NUMERIC,
	`EntreBy`	TEXT,
	`CashPay`	NUMERIC,
	`CardPay`	NUMERIC,
	`CUST_ID`	INTEGER
);

-- Table: SalesReturn
CREATE TABLE "SalesReturn" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`SALES_ID`	INTEGER,
	`SalesReturn_Date`	TEXT,
	`ITEM_ID`	INTEGER,
	`QTY`	NUMERIC,
	`Price`	NUMERIC,
	`TotalPrice`	NUMERIC,
	`Cost`	NUMERIC,
	`TotalCost`	NUMERIC,
	`Vat`	NUMERIC,
	`TotalVat`	NUMERIC,
	`ExprDate`	TEXT
);

-- Table: Shelf
CREATE TABLE [Shelf] ([SHELF_ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [SHELF_NAME] nvarchar(254));

-- Table: Stock
CREATE TABLE "Stock" (
	`STOCK_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`ITEM_ID`	NUMERIC,
	`Quantity`	NUMERIC,
	`ExpiryDate`	TEXT,
	`WarehouseID`	NUMERIC,
	`SHELF_ID`	INTEGER,
	`Expiry`	TEXT
);

-- Table: StockTransfer
CREATE TABLE "StockTransfer" (
	`TRNS_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`TransferDate`	TEXT,
	`ITEM_ID`	INTEGER,
	`FromWarehouseID`	INTEGER,
	`ToWarehouseID`	INTEGER,
	`Quantity`	NUMERIC,
	`Reason`	TEXT
);

-- Table: Supplier
CREATE TABLE `Supplier` (
	`SUPP_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`SupplierName`	TEXT,
	`Address`	TEXT,
	`PhoneNo`	TEXT,
	`OpeningDate`	TEXT,
	`Balance`	NUMERIC,
	`PhotoFileName`	TEXT
);

-- Table: Users
CREATE TABLE "Users" (
	`USER_ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`FullName`	TEXT,
	`UserName`	TEXT,
	`Privilege`	TEXT,
	`RegDate`	TEXT,
	`Password`	TEXT,
	`Can_Add`	TEXT,
	`Can_Edit`	TEXT,
	`Can_Delete`	TEXT,
	`Can_Print`	TEXT
);

-- Table: Vat
CREATE TABLE [Vat] ([Vat] numeric(15, 0));

-- Table: Warehouse
CREATE TABLE [Warehouse] ([WarehouseID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, [WarehouseName] text, [WarehouseAddress] text);

