USE [dbOrion]
GO
/****** Object:  Table [dbo].[warehouse]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[warehouse](
	[WarehouseID] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseName] [nvarchar](200) NULL,
	[WarehouseAddress] [nvarchar](200) NULL,
 CONSTRAINT [PK_warehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vat]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vat](
	[Vat] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[USER_ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Privilege] [nvarchar](100) NULL,
	[RegDate] [datetime] NULL,
	[Password] [nvarchar](max) NULL,
	[Can_Add] [nvarchar](10) NULL,
	[Can_Edit] [nvarchar](10) NULL,
	[Can_Delete] [nvarchar](10) NULL,
	[Can_Print] [nvarchar](10) NULL,
 CONSTRAINT [users_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier](
	[SUPP_ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](200) NULL,
	[Address] [ntext] NULL,
	[PhoneNo] [nvarchar](200) NULL,
	[OpeningDate] [date] NULL,
	[Balance] [float] NULL,
	[PhotoFileName] [nvarchar](200) NULL,
 CONSTRAINT [supplier_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[SUPP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stocktransfer]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocktransfer](
	[TRNS_ID] [int] IDENTITY(1,1) NOT NULL,
	[TransferDate] [date] NULL,
	[ITEM_ID] [int] NULL,
	[FromWarehouseID] [int] NULL,
	[ToWarehouseID] [int] NULL,
	[Quantity] [float] NULL,
	[Reason] [nvarchar](max) NULL,
 CONSTRAINT [PK_stocktransfer] PRIMARY KEY CLUSTERED 
(
	[TRNS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[STOCK_ID] [int] IDENTITY(1,1) NOT NULL,
	[ITEM_ID] [int] NULL,
	[Quantity] [float] NULL,
	[ExpiryDate] [nvarchar](100) NULL,
	[WarehouseID] [int] NULL,
	[SHELF_ID] [int] NULL,
	[Expiry] [nvarchar](100) NULL,
 CONSTRAINT [stock_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[STOCK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shelf]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shelf](
	[SHELF_ID] [int] IDENTITY(1,1) NOT NULL,
	[SHELF_NAME] [nvarchar](200) NULL,
 CONSTRAINT [shelf_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[SHELF_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salesreturn]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesreturn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SALES_ID] [int] NULL,
	[SalesReturn_Date] [datetime] NULL,
	[ITEM_ID] [int] NULL,
	[QTY] [float] NULL,
	[Price] [float] NULL,
	[TotalPrice] [float] NULL,
	[Cost] [float] NULL,
	[TotalCost] [float] NULL,
	[Vat] [float] NULL,
	[TotalVat] [float] NULL,
	[ExprDate] [nvarchar](100) NULL,
 CONSTRAINT [salesreturn_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salesretrninfo]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[salesretrninfo](
	[SALES_ID] [int] NULL,
	[SalesReturnDate] [date] NULL,
	[SalesReturnTime] [varchar](100) NULL,
	[Total] [float] NULL,
	[EntreBy] [nvarchar](100) NULL,
	[CashPay] [float] NULL,
	[CardPay] [float] NULL,
	[CUST_ID] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesinfo]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesinfo](
	[SALES_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [int] NULL,
	[CUST_ID] [int] NULL,
	[SalesDate] [date] NULL,
	[SalesTime] [nvarchar](200) NULL,
	[ItemPrice] [float] NULL,
	[VAT] [float] NULL,
	[Discount] [float] NULL,
	[GrandTotal] [float] NULL,
	[EntreBy] [nvarchar](250) NULL,
	[CashPay] [float] NULL,
	[CardPay] [float] NULL,
	[Due] [float] NULL,
	[Comment] [nvarchar](max) NULL,
	[Terminal] [nvarchar](200) NULL,
	[TrnsNo] [nvarchar](200) NULL,
	[ShippingName] [nvarchar](250) NULL,
	[ShippingAddress] [nvarchar](max) NULL,
	[ShippingContact] [nvarchar](250) NULL,
 CONSTRAINT [PK_salesinfo] PRIMARY KEY CLUSTERED 
(
	[SALES_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SALES_ID] [int] NULL,
	[Sales_Date] [date] NULL,
	[ITEM_ID] [int] NULL,
	[QTY] [float] NULL,
	[Price] [float] NULL,
	[TotalPrice] [float] NULL,
	[Cost] [float] NULL,
	[TotalCost] [float] NULL,
	[Vat] [float] NULL,
	[TotalVat] [float] NULL,
	[ExprDate] [nvarchar](100) NULL,
	[Terminal] [nvarchar](100) NULL,
 CONSTRAINT [sales_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchasereturninfo]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[purchasereturninfo](
	[PUCHSE_ID] [int] NULL,
	[PurchaseReturnDate] [date] NULL,
	[PurchaseReturnTime] [varchar](100) NULL,
	[EntreBy] [nvarchar](100) NULL,
	[Total] [float] NULL,
	[CardPay] [float] NULL,
	[CashPay] [float] NULL,
	[SUPP_ID] [int] NULL,
	[USER_ID] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[purchasereturn]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchasereturn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PUCHSE_ID] [int] NULL,
	[ITEM_ID] [int] NULL,
	[WarehouseID] [int] NULL,
	[QTY] [float] NULL,
	[TotalPrice] [float] NULL,
 CONSTRAINT [purchasereturn_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchaseinfo]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchaseinfo](
	[PUCHSE_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [date] NULL,
	[ItemPrice] [float] NULL,
	[Discount] [float] NULL,
	[GrandTotal] [float] NULL,
	[Due] [float] NULL,
	[SUPP_ID] [int] NULL,
	[CardPay] [float] NULL,
	[CashPay] [float] NULL,
	[USER_ID] [int] NULL,
 CONSTRAINT [purchaseinfo_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[PUCHSE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PUCHSE_ID] [int] NULL,
	[ITEM_ID] [int] NULL,
	[WarehouseID] [int] NULL,
	[QTY] [float] NULL,
	[TotalPrice] [float] NULL,
	[ExpDate] [nvarchar](100) NULL,
	[Stock] [nvarchar](10) NULL,
	[SoldDate] [date] NULL,
 CONSTRAINT [purchase_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[printbarcode]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[printbarcode](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[COMPANY_NAME] [nvarchar](200) NULL,
	[BARCODE_1] [nvarchar](200) NULL,
	[PRODUCT_NAME_1] [nvarchar](200) NULL,
	[PRICE_1] [nvarchar](200) NULL,
	[BARCODE_2] [nvarchar](200) NULL,
	[PRODUCT_NAME_2] [nvarchar](200) NULL,
	[PRICE_2] [nvarchar](200) NULL,
 CONSTRAINT [printbarcode_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[PAYM_ID] [int] IDENTITY(1,1) NOT NULL,
	[PUCHSE_ID] [int] NULL,
	[SUPP_ID] [int] NULL,
	[EntryDate] [date] NULL,
	[EnteredBy] [nvarchar](100) NULL,
	[Cash] [float] NULL,
	[Card] [float] NULL,
 CONSTRAINT [payment_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[PAYM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[iteminformation]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[iteminformation](
	[ITEM_ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](200) NULL,
	[UnitOfMeasure] [nvarchar](200) NULL,
	[Batch] [nvarchar](200) NULL,
	[GROUP_ID] [int] NULL,
	[Barcode] [nvarchar](200) NULL,
	[Cost] [float] NULL,
	[Price] [float] NULL,
	[ReorderPoint] [float] NULL,
	[VAT_Applicable] [nvarchar](10) NULL,
	[WarehouseID] [int] NULL,
	[PhotoFileName] [nvarchar](200) NULL,
 CONSTRAINT [iteminformation_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[ITEM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemgroup]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemgroup](
	[GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_NAME] [nvarchar](200) NULL,
 CONSTRAINT [itemgroup_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[GROUP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expense]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expense](
	[Expense_ID] [int] IDENTITY(1,1) NOT NULL,
	[EXP_AC_ID] [int] NULL,
	[PaidDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_expense] PRIMARY KEY CLUSTERED 
(
	[Expense_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expenditureaccount]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expenditureaccount](
	[EXP_AC_ID] [int] IDENTITY(1,1) NOT NULL,
	[ExpenditureAccount] [nvarchar](200) NULL,
 CONSTRAINT [expenditureaccount_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[EXP_AC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeepayment]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeepayment](
	[EMP_PAY_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMP_ID] [int] NULL,
	[PaidDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[PaidAmount] [float] NULL,
 CONSTRAINT [PK_employeepayment] PRIMARY KEY CLUSTERED 
(
	[EMP_PAY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](200) NULL,
	[Designation] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](200) NULL,
	[OpeningDate] [date] NULL,
	[Balance] [float] NULL,
	[PhotoFileName] [nvarchar](200) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[CUST_ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](200) NULL,
	[OpeningDate] [date] NULL,
	[Balance] [float] NULL,
	[PhotoFileName] [nvarchar](max) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[CUST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collection]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[collection](
	[COLL_ID] [int] IDENTITY(1,1) NOT NULL,
	[SALES_ID] [int] NULL,
	[CUST_ID] [int] NULL,
	[EntryDate] [date] NULL,
	[EnteredBy] [nvarchar](100) NULL,
	[Cash] [float] NULL,
	[Card] [float] NULL,
 CONSTRAINT [collection_PRIMARY] PRIMARY KEY NONCLUSTERED 
(
	[COLL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[businessinformation]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[businessinformation](
	[CompanyName] [nvarchar](200) NULL,
	[LegalName] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[WebSite] [nvarchar](200) NULL,
	[Slogan] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[barcode]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[barcode](
	[Barcode] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[badstock]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[badstock](
	[BDS_ID] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseID] [int] NULL,
	[ITEM_ID] [int] NULL,
	[Quantity] [float] NULL,
	[SoldDate] [date] NULL,
	[Reason] [nvarchar](max) NULL,
 CONSTRAINT [PK_badstock] PRIMARY KEY CLUSTERED 
(
	[BDS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attendance]    Script Date: 10/06/2018 01:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attendance](
	[EMP_ID] [int] NULL,
	[AttendanceDate] [date] NULL,
	[Present] [nvarchar](50) NULL,
	[Absent] [nvarchar](50) NULL,
	[Remarks] [nvarchar](max) NULL
) ON [PRIMARY]
GO
