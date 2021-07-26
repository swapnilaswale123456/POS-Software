-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 05, 2018 at 09:34 PM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dborion`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `EMP_ID` int(11) DEFAULT NULL,
  `AttendanceDate` date DEFAULT NULL,
  `Present` varchar(10) DEFAULT NULL,
  `Absent` varchar(10) DEFAULT NULL,
  `Remarks` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `badstock`
--

CREATE TABLE `badstock` (
  `BDS_ID` int(11) NOT NULL,
  `WarehouseID` int(11) DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `Quantity` float DEFAULT NULL,
  `SoldDate` date DEFAULT NULL,
  `Reason` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `badstock`
--
DELIMITER $$
CREATE TRIGGER `a_d_badstock` AFTER DELETE ON `badstock` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'badstock';						SET @pk_d = CONCAT('<BDS_ID>',OLD.`BDS_ID`,'</BDS_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_badstock` AFTER INSERT ON `badstock` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'badstock'; 						SET @pk_d = CONCAT('<BDS_ID>',NEW.`BDS_ID`,'</BDS_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_badstock` AFTER UPDATE ON `badstock` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'badstock';						SET @pk_d_old = CONCAT('<BDS_ID>',OLD.`BDS_ID`,'</BDS_ID>');						SET @pk_d = CONCAT('<BDS_ID>',NEW.`BDS_ID`,'</BDS_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `barcode`
--

CREATE TABLE `barcode` (
  `Barcode` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `businessinformation`
--

CREATE TABLE `businessinformation` (
  `CompanyName` varchar(250) DEFAULT NULL,
  `LegalName` varchar(250) DEFAULT NULL,
  `Address` text,
  `PhoneNo` varchar(250) DEFAULT NULL,
  `Email` varchar(250) DEFAULT NULL,
  `WebSite` varchar(250) DEFAULT NULL,
  `Slogan` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `collection`
--

CREATE TABLE `collection` (
  `COLL_ID` int(11) NOT NULL,
  `SALES_ID` int(11) DEFAULT NULL,
  `CUST_ID` int(11) DEFAULT NULL,
  `EntryDate` date DEFAULT NULL,
  `EnteredBy` varchar(100) DEFAULT NULL,
  `Cash` float DEFAULT NULL,
  `Card` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `collection`
--
DELIMITER $$
CREATE TRIGGER `a_d_collection` AFTER DELETE ON `collection` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'collection';						SET @pk_d = CONCAT('<COLL_ID>',OLD.`COLL_ID`,'</COLL_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_collection` AFTER INSERT ON `collection` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'collection'; 						SET @pk_d = CONCAT('<COLL_ID>',NEW.`COLL_ID`,'</COLL_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_collection` AFTER UPDATE ON `collection` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'collection';						SET @pk_d_old = CONCAT('<COLL_ID>',OLD.`COLL_ID`,'</COLL_ID>');						SET @pk_d = CONCAT('<COLL_ID>',NEW.`COLL_ID`,'</COLL_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `CUST_ID` int(11) NOT NULL,
  `CustomerName` varchar(200) DEFAULT NULL,
  `Address` text,
  `PhoneNo` varchar(200) DEFAULT NULL,
  `OpeningDate` date DEFAULT NULL,
  `Balance` float DEFAULT NULL,
  `PhotoFileName` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `customer`
--
DELIMITER $$
CREATE TRIGGER `a_d_customer` AFTER DELETE ON `customer` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'customer';						SET @pk_d = CONCAT('<CUST_ID>',OLD.`CUST_ID`,'</CUST_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_customer` AFTER INSERT ON `customer` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'customer'; 						SET @pk_d = CONCAT('<CUST_ID>',NEW.`CUST_ID`,'</CUST_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_customer` AFTER UPDATE ON `customer` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'customer';						SET @pk_d_old = CONCAT('<CUST_ID>',OLD.`CUST_ID`,'</CUST_ID>');						SET @pk_d = CONCAT('<CUST_ID>',NEW.`CUST_ID`,'</CUST_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EMP_ID` int(11) NOT NULL,
  `EmployeeName` varchar(200) DEFAULT NULL,
  `Designation` varchar(200) DEFAULT NULL,
  `Address` text,
  `PhoneNo` varchar(200) DEFAULT NULL,
  `OpeningDate` date DEFAULT NULL,
  `Balance` float DEFAULT NULL,
  `PhotoFileName` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `employee`
--
DELIMITER $$
CREATE TRIGGER `a_d_employee` AFTER DELETE ON `employee` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employee';						SET @pk_d = CONCAT('<EMP_ID>',OLD.`EMP_ID`,'</EMP_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_employee` AFTER INSERT ON `employee` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employee'; 						SET @pk_d = CONCAT('<EMP_ID>',NEW.`EMP_ID`,'</EMP_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_employee` AFTER UPDATE ON `employee` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employee';						SET @pk_d_old = CONCAT('<EMP_ID>',OLD.`EMP_ID`,'</EMP_ID>');						SET @pk_d = CONCAT('<EMP_ID>',NEW.`EMP_ID`,'</EMP_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `employeepayment`
--

CREATE TABLE `employeepayment` (
  `EMP_PAY_ID` int(11) NOT NULL,
  `EMP_ID` int(11) DEFAULT NULL,
  `PaidDate` date DEFAULT NULL,
  `Description` text,
  `PaidAmount` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `employeepayment`
--
DELIMITER $$
CREATE TRIGGER `a_d_employeepayment` AFTER DELETE ON `employeepayment` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employeepayment';						SET @pk_d = CONCAT('<EMP_PAY_ID>',OLD.`EMP_PAY_ID`,'</EMP_PAY_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_employeepayment` AFTER INSERT ON `employeepayment` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employeepayment'; 						SET @pk_d = CONCAT('<EMP_PAY_ID>',NEW.`EMP_PAY_ID`,'</EMP_PAY_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_employeepayment` AFTER UPDATE ON `employeepayment` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'employeepayment';						SET @pk_d_old = CONCAT('<EMP_PAY_ID>',OLD.`EMP_PAY_ID`,'</EMP_PAY_ID>');						SET @pk_d = CONCAT('<EMP_PAY_ID>',NEW.`EMP_PAY_ID`,'</EMP_PAY_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `expenditureaccount`
--

CREATE TABLE `expenditureaccount` (
  `EXP_AC_ID` int(11) NOT NULL,
  `ExpenditureAccount` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `expenditureaccount`
--
DELIMITER $$
CREATE TRIGGER `a_d_expenditureaccount` AFTER DELETE ON `expenditureaccount` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expenditureaccount';						SET @pk_d = CONCAT('<EXP_AC_ID>',OLD.`EXP_AC_ID`,'</EXP_AC_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_expenditureaccount` AFTER INSERT ON `expenditureaccount` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expenditureaccount'; 						SET @pk_d = CONCAT('<EXP_AC_ID>',NEW.`EXP_AC_ID`,'</EXP_AC_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_expenditureaccount` AFTER UPDATE ON `expenditureaccount` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expenditureaccount';						SET @pk_d_old = CONCAT('<EXP_AC_ID>',OLD.`EXP_AC_ID`,'</EXP_AC_ID>');						SET @pk_d = CONCAT('<EXP_AC_ID>',NEW.`EXP_AC_ID`,'</EXP_AC_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `expense`
--

CREATE TABLE `expense` (
  `Expense_ID` int(11) NOT NULL,
  `EXP_AC_ID` int(11) DEFAULT NULL,
  `PaidDate` date DEFAULT NULL,
  `Description` text,
  `Amount` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `expense`
--
DELIMITER $$
CREATE TRIGGER `a_d_expense` AFTER DELETE ON `expense` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expense';						SET @pk_d = CONCAT('<Expense_ID>',OLD.`Expense_ID`,'</Expense_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_expense` AFTER INSERT ON `expense` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expense'; 						SET @pk_d = CONCAT('<Expense_ID>',NEW.`Expense_ID`,'</Expense_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_expense` AFTER UPDATE ON `expense` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'expense';						SET @pk_d_old = CONCAT('<Expense_ID>',OLD.`Expense_ID`,'</Expense_ID>');						SET @pk_d = CONCAT('<Expense_ID>',NEW.`Expense_ID`,'</Expense_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `history_store`
--

CREATE TABLE `history_store` (
  `timemark` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `table_name` tinytext NOT NULL,
  `pk_date_src` text NOT NULL,
  `pk_date_dest` text NOT NULL,
  `record_state` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `history_store`
--

INSERT INTO `history_store` (`timemark`, `table_name`, `pk_date_src`, `pk_date_dest`, `record_state`) VALUES
('2018-10-05 19:29:50', 'users', '<USER_ID>1</USER_ID>', '<USER_ID>1</USER_ID>', 1);

-- --------------------------------------------------------

--
-- Table structure for table `itemgroup`
--

CREATE TABLE `itemgroup` (
  `GROUP_ID` int(11) NOT NULL,
  `GROUP_NAME` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `itemgroup`
--
DELIMITER $$
CREATE TRIGGER `a_d_itemgroup` AFTER DELETE ON `itemgroup` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'itemgroup';						SET @pk_d = CONCAT('<GROUP_ID>',OLD.`GROUP_ID`,'</GROUP_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_itemgroup` AFTER INSERT ON `itemgroup` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'itemgroup'; 						SET @pk_d = CONCAT('<GROUP_ID>',NEW.`GROUP_ID`,'</GROUP_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_itemgroup` AFTER UPDATE ON `itemgroup` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'itemgroup';						SET @pk_d_old = CONCAT('<GROUP_ID>',OLD.`GROUP_ID`,'</GROUP_ID>');						SET @pk_d = CONCAT('<GROUP_ID>',NEW.`GROUP_ID`,'</GROUP_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `iteminformation`
--

CREATE TABLE `iteminformation` (
  `ITEM_ID` int(11) NOT NULL,
  `ItemName` varchar(200) DEFAULT NULL,
  `UnitOfMeasure` varchar(200) DEFAULT NULL,
  `Batch` varchar(200) DEFAULT NULL,
  `GROUP_ID` int(11) DEFAULT NULL,
  `Barcode` varchar(200) DEFAULT NULL,
  `Cost` float DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `ReorderPoint` float DEFAULT NULL,
  `VAT_Applicable` varchar(10) DEFAULT NULL,
  `WarehouseID` int(11) DEFAULT NULL,
  `PhotoFileName` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `iteminformation`
--
DELIMITER $$
CREATE TRIGGER `a_d_iteminformation` AFTER DELETE ON `iteminformation` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'iteminformation';						SET @pk_d = CONCAT('<ITEM_ID>',OLD.`ITEM_ID`,'</ITEM_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_iteminformation` AFTER INSERT ON `iteminformation` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'iteminformation'; 						SET @pk_d = CONCAT('<ITEM_ID>',NEW.`ITEM_ID`,'</ITEM_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_iteminformation` AFTER UPDATE ON `iteminformation` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'iteminformation';						SET @pk_d_old = CONCAT('<ITEM_ID>',OLD.`ITEM_ID`,'</ITEM_ID>');						SET @pk_d = CONCAT('<ITEM_ID>',NEW.`ITEM_ID`,'</ITEM_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `PAYM_ID` int(11) NOT NULL,
  `PUCHSE_ID` int(11) DEFAULT NULL,
  `SUPP_ID` int(11) DEFAULT NULL,
  `EntryDate` date DEFAULT NULL,
  `EnteredBy` varchar(100) DEFAULT NULL,
  `Cash` float DEFAULT NULL,
  `Card` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `payment`
--
DELIMITER $$
CREATE TRIGGER `a_d_payment` AFTER DELETE ON `payment` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'payment';						SET @pk_d = CONCAT('<PAYM_ID>',OLD.`PAYM_ID`,'</PAYM_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_payment` AFTER INSERT ON `payment` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'payment'; 						SET @pk_d = CONCAT('<PAYM_ID>',NEW.`PAYM_ID`,'</PAYM_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_payment` AFTER UPDATE ON `payment` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'payment';						SET @pk_d_old = CONCAT('<PAYM_ID>',OLD.`PAYM_ID`,'</PAYM_ID>');						SET @pk_d = CONCAT('<PAYM_ID>',NEW.`PAYM_ID`,'</PAYM_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `printbarcode`
--

CREATE TABLE `printbarcode` (
  `id` int(11) NOT NULL,
  `COMPANY_NAME` varchar(200) DEFAULT NULL,
  `BARCODE_1` varchar(200) DEFAULT NULL,
  `PRODUCT_NAME_1` varchar(200) DEFAULT NULL,
  `PRICE_1` varchar(200) DEFAULT NULL,
  `BARCODE_2` varchar(200) DEFAULT NULL,
  `PRODUCT_NAME_2` varchar(200) DEFAULT NULL,
  `PRICE_2` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `printbarcode`
--
DELIMITER $$
CREATE TRIGGER `a_d_printbarcode` AFTER DELETE ON `printbarcode` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'printbarcode';						SET @pk_d = CONCAT('<id>',OLD.`id`,'</id>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_printbarcode` AFTER INSERT ON `printbarcode` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'printbarcode'; 						SET @pk_d = CONCAT('<id>',NEW.`id`,'</id>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_printbarcode` AFTER UPDATE ON `printbarcode` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'printbarcode';						SET @pk_d_old = CONCAT('<id>',OLD.`id`,'</id>');						SET @pk_d = CONCAT('<id>',NEW.`id`,'</id>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase` (
  `ID` int(11) NOT NULL,
  `PUCHSE_ID` int(11) DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `WarehouseID` int(11) DEFAULT NULL,
  `QTY` float DEFAULT NULL,
  `TotalPrice` float DEFAULT NULL,
  `ExpDate` varchar(100) DEFAULT NULL,
  `Stock` varchar(10) DEFAULT NULL,
  `SoldDate` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `purchase`
--
DELIMITER $$
CREATE TRIGGER `a_d_purchase` AFTER DELETE ON `purchase` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchase';						SET @pk_d = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_purchase` AFTER INSERT ON `purchase` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchase'; 						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_purchase` AFTER UPDATE ON `purchase` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchase';						SET @pk_d_old = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `purchaseinfo`
--

CREATE TABLE `purchaseinfo` (
  `PUCHSE_ID` int(11) NOT NULL,
  `PurchaseDate` date DEFAULT NULL,
  `ItemPrice` float DEFAULT NULL,
  `Discount` float DEFAULT NULL,
  `GrandTotal` float DEFAULT NULL,
  `Due` float DEFAULT NULL,
  `SUPP_ID` int(11) DEFAULT NULL,
  `CardPay` float DEFAULT NULL,
  `CashPay` float DEFAULT NULL,
  `USER_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `purchaseinfo`
--
DELIMITER $$
CREATE TRIGGER `a_d_purchaseinfo` AFTER DELETE ON `purchaseinfo` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchaseinfo';						SET @pk_d = CONCAT('<PUCHSE_ID>',OLD.`PUCHSE_ID`,'</PUCHSE_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_purchaseinfo` AFTER INSERT ON `purchaseinfo` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchaseinfo'; 						SET @pk_d = CONCAT('<PUCHSE_ID>',NEW.`PUCHSE_ID`,'</PUCHSE_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_purchaseinfo` AFTER UPDATE ON `purchaseinfo` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchaseinfo';						SET @pk_d_old = CONCAT('<PUCHSE_ID>',OLD.`PUCHSE_ID`,'</PUCHSE_ID>');						SET @pk_d = CONCAT('<PUCHSE_ID>',NEW.`PUCHSE_ID`,'</PUCHSE_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `purchasereturn`
--

CREATE TABLE `purchasereturn` (
  `ID` int(11) NOT NULL,
  `PUCHSE_ID` int(11) DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `WarehouseID` int(11) DEFAULT NULL,
  `QTY` float DEFAULT NULL,
  `TotalPrice` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `purchasereturn`
--
DELIMITER $$
CREATE TRIGGER `a_d_purchasereturn` AFTER DELETE ON `purchasereturn` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchasereturn';						SET @pk_d = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_purchasereturn` AFTER INSERT ON `purchasereturn` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchasereturn'; 						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_purchasereturn` AFTER UPDATE ON `purchasereturn` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'purchasereturn';						SET @pk_d_old = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `purchasereturninfo`
--

CREATE TABLE `purchasereturninfo` (
  `PUCHSE_ID` int(11) DEFAULT NULL,
  `PurchaseReturnDate` date DEFAULT NULL,
  `PurchaseReturnTime` varchar(100) DEFAULT NULL,
  `EntreBy` varchar(100) DEFAULT NULL,
  `Total` float DEFAULT NULL,
  `CardPay` float DEFAULT NULL,
  `CashPay` float DEFAULT NULL,
  `SUPP_ID` int(11) DEFAULT NULL,
  `USER_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `ID` int(11) NOT NULL,
  `SALES_ID` int(11) DEFAULT NULL,
  `Sales_Date` date DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `QTY` float DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `TotalPrice` float DEFAULT NULL,
  `Cost` float DEFAULT NULL,
  `TotalCost` float DEFAULT NULL,
  `Vat` float DEFAULT NULL,
  `TotalVat` float DEFAULT NULL,
  `ExprDate` varchar(100) DEFAULT NULL,
  `Terminal` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `sales`
--
DELIMITER $$
CREATE TRIGGER `a_d_sales` AFTER DELETE ON `sales` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'sales';						SET @pk_d = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_sales` AFTER INSERT ON `sales` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'sales'; 						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_sales` AFTER UPDATE ON `sales` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'sales';						SET @pk_d_old = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `salesinfo`
--

CREATE TABLE `salesinfo` (
  `SALES_ID` int(11) NOT NULL,
  `USER_ID` int(11) DEFAULT NULL,
  `CUST_ID` int(11) DEFAULT NULL,
  `SalesDate` date DEFAULT NULL,
  `SalesTime` varchar(100) DEFAULT NULL,
  `ItemPrice` float DEFAULT NULL,
  `VAT` float DEFAULT NULL,
  `Discount` float DEFAULT NULL,
  `GrandTotal` float DEFAULT NULL,
  `EntreBy` varchar(100) DEFAULT NULL,
  `CashPay` float DEFAULT NULL,
  `CardPay` float DEFAULT NULL,
  `Due` float DEFAULT NULL,
  `Comment` text,
  `Terminal` varchar(200) DEFAULT NULL,
  `TrnsNo` varchar(200) DEFAULT NULL,
  `ShippingName` text,
  `ShippingAddress` text,
  `ShippingContact` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `salesinfo`
--
DELIMITER $$
CREATE TRIGGER `a_d_salesinfo` AFTER DELETE ON `salesinfo` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesinfo';						SET @pk_d = CONCAT('<SALES_ID>',OLD.`SALES_ID`,'</SALES_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_salesinfo` AFTER INSERT ON `salesinfo` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesinfo'; 						SET @pk_d = CONCAT('<SALES_ID>',NEW.`SALES_ID`,'</SALES_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_salesinfo` AFTER UPDATE ON `salesinfo` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesinfo';						SET @pk_d_old = CONCAT('<SALES_ID>',OLD.`SALES_ID`,'</SALES_ID>');						SET @pk_d = CONCAT('<SALES_ID>',NEW.`SALES_ID`,'</SALES_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `salesretrninfo`
--

CREATE TABLE `salesretrninfo` (
  `SALES_ID` int(11) DEFAULT NULL,
  `SalesReturnDate` date DEFAULT NULL,
  `SalesReturnTime` varchar(100) DEFAULT NULL,
  `Total` float DEFAULT NULL,
  `EntreBy` varchar(100) DEFAULT NULL,
  `CashPay` float DEFAULT NULL,
  `CardPay` float DEFAULT NULL,
  `CUST_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `salesreturn`
--

CREATE TABLE `salesreturn` (
  `ID` int(11) NOT NULL,
  `SALES_ID` int(11) DEFAULT NULL,
  `SalesReturn_Date` date DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `QTY` float DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `TotalPrice` float DEFAULT NULL,
  `Cost` float DEFAULT NULL,
  `TotalCost` float DEFAULT NULL,
  `Vat` float DEFAULT NULL,
  `TotalVat` float DEFAULT NULL,
  `ExprDate` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `salesreturn`
--
DELIMITER $$
CREATE TRIGGER `a_d_salesreturn` AFTER DELETE ON `salesreturn` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesreturn';						SET @pk_d = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_salesreturn` AFTER INSERT ON `salesreturn` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesreturn'; 						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_salesreturn` AFTER UPDATE ON `salesreturn` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'salesreturn';						SET @pk_d_old = CONCAT('<ID>',OLD.`ID`,'</ID>');						SET @pk_d = CONCAT('<ID>',NEW.`ID`,'</ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `shelf`
--

CREATE TABLE `shelf` (
  `SHELF_ID` int(11) NOT NULL,
  `SHELF_NAME` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `shelf`
--
DELIMITER $$
CREATE TRIGGER `a_d_shelf` AFTER DELETE ON `shelf` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'shelf';						SET @pk_d = CONCAT('<SHELF_ID>',OLD.`SHELF_ID`,'</SHELF_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_shelf` AFTER INSERT ON `shelf` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'shelf'; 						SET @pk_d = CONCAT('<SHELF_ID>',NEW.`SHELF_ID`,'</SHELF_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_shelf` AFTER UPDATE ON `shelf` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'shelf';						SET @pk_d_old = CONCAT('<SHELF_ID>',OLD.`SHELF_ID`,'</SHELF_ID>');						SET @pk_d = CONCAT('<SHELF_ID>',NEW.`SHELF_ID`,'</SHELF_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `STOCK_ID` int(11) NOT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `Quantity` float DEFAULT NULL,
  `ExpiryDate` varchar(100) DEFAULT NULL,
  `WarehouseID` int(11) DEFAULT NULL,
  `SHELF_ID` int(11) DEFAULT NULL,
  `Expiry` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `stock`
--
DELIMITER $$
CREATE TRIGGER `a_d_stock` AFTER DELETE ON `stock` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stock';						SET @pk_d = CONCAT('<STOCK_ID>',OLD.`STOCK_ID`,'</STOCK_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_stock` AFTER INSERT ON `stock` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stock'; 						SET @pk_d = CONCAT('<STOCK_ID>',NEW.`STOCK_ID`,'</STOCK_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_stock` AFTER UPDATE ON `stock` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stock';						SET @pk_d_old = CONCAT('<STOCK_ID>',OLD.`STOCK_ID`,'</STOCK_ID>');						SET @pk_d = CONCAT('<STOCK_ID>',NEW.`STOCK_ID`,'</STOCK_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `stocktransfer`
--

CREATE TABLE `stocktransfer` (
  `TRNS_ID` int(11) NOT NULL,
  `TransferDate` date DEFAULT NULL,
  `ITEM_ID` int(11) DEFAULT NULL,
  `FromWarehouseID` int(11) DEFAULT NULL,
  `ToWarehouseID` int(11) DEFAULT NULL,
  `Quantity` float DEFAULT NULL,
  `Reason` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `stocktransfer`
--
DELIMITER $$
CREATE TRIGGER `a_d_stocktransfer` AFTER DELETE ON `stocktransfer` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stocktransfer';						SET @pk_d = CONCAT('<TRNS_ID>',OLD.`TRNS_ID`,'</TRNS_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_stocktransfer` AFTER INSERT ON `stocktransfer` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stocktransfer'; 						SET @pk_d = CONCAT('<TRNS_ID>',NEW.`TRNS_ID`,'</TRNS_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_stocktransfer` AFTER UPDATE ON `stocktransfer` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'stocktransfer';						SET @pk_d_old = CONCAT('<TRNS_ID>',OLD.`TRNS_ID`,'</TRNS_ID>');						SET @pk_d = CONCAT('<TRNS_ID>',NEW.`TRNS_ID`,'</TRNS_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `SUPP_ID` int(11) NOT NULL,
  `SupplierName` varchar(200) DEFAULT NULL,
  `Address` text,
  `PhoneNo` varchar(200) DEFAULT NULL,
  `OpeningDate` date DEFAULT NULL,
  `Balance` float DEFAULT NULL,
  `PhotoFileName` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `supplier`
--
DELIMITER $$
CREATE TRIGGER `a_d_supplier` AFTER DELETE ON `supplier` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'supplier';						SET @pk_d = CONCAT('<SUPP_ID>',OLD.`SUPP_ID`,'</SUPP_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_supplier` AFTER INSERT ON `supplier` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'supplier'; 						SET @pk_d = CONCAT('<SUPP_ID>',NEW.`SUPP_ID`,'</SUPP_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_supplier` AFTER UPDATE ON `supplier` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'supplier';						SET @pk_d_old = CONCAT('<SUPP_ID>',OLD.`SUPP_ID`,'</SUPP_ID>');						SET @pk_d = CONCAT('<SUPP_ID>',NEW.`SUPP_ID`,'</SUPP_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `USER_ID` int(11) NOT NULL,
  `FullName` varchar(200) DEFAULT NULL,
  `UserName` varchar(200) DEFAULT NULL,
  `Privilege` varchar(200) DEFAULT NULL,
  `RegDate` date DEFAULT NULL,
  `Password` text,
  `Can_Add` varchar(10) DEFAULT NULL,
  `Can_Edit` varchar(10) DEFAULT NULL,
  `Can_Delete` varchar(10) DEFAULT NULL,
  `Can_Print` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`USER_ID`, `FullName`, `UserName`, `Privilege`, `RegDate`, `Password`, `Can_Add`, `Can_Edit`, `Can_Delete`, `Can_Print`) VALUES
(1, 'Administrator', 'admin', 'Administrator', '2018-10-06', '827CCB0EEA8A706C4C34A16891F84E7B', 'Y', 'Y', 'Y', 'Y');

--
-- Triggers `users`
--
DELIMITER $$
CREATE TRIGGER `a_d_users` AFTER DELETE ON `users` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'users';						SET @pk_d = CONCAT('<USER_ID>',OLD.`USER_ID`,'</USER_ID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_users` AFTER INSERT ON `users` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'users'; 						SET @pk_d = CONCAT('<USER_ID>',NEW.`USER_ID`,'</USER_ID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_users` AFTER UPDATE ON `users` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'users';						SET @pk_d_old = CONCAT('<USER_ID>',OLD.`USER_ID`,'</USER_ID>');						SET @pk_d = CONCAT('<USER_ID>',NEW.`USER_ID`,'</USER_ID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `vat`
--

CREATE TABLE `vat` (
  `Vat` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `warehouse`
--

CREATE TABLE `warehouse` (
  `WarehouseID` int(11) NOT NULL,
  `WarehouseName` varchar(200) DEFAULT NULL,
  `WarehouseAddress` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `warehouse`
--
DELIMITER $$
CREATE TRIGGER `a_d_warehouse` AFTER DELETE ON `warehouse` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'warehouse';						SET @pk_d = CONCAT('<WarehouseID>',OLD.`WarehouseID`,'</WarehouseID>');						SET @rec_state = 3;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE  `table_name` = @tbl_name AND `pk_date_src` = @pk_d;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						IF @rs <> 1 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d, @rec_state ); 						END IF; END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_i_warehouse` AFTER INSERT ON `warehouse` FOR EACH ROW BEGIN 						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'warehouse'; 						SET @pk_d = CONCAT('<WarehouseID>',NEW.`WarehouseID`,'</WarehouseID>'); 						SET @rec_state = 1;						DELETE FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d; 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`,`record_state` ) 						VALUES (@time_mark, @tbl_name, @pk_d, @pk_d, @rec_state); 						END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `a_u_warehouse` AFTER UPDATE ON `warehouse` FOR EACH ROW BEGIN						SET @time_mark = DATE_ADD(NOW(), INTERVAL 0 SECOND); 						SET @tbl_name = 'warehouse';						SET @pk_d_old = CONCAT('<WarehouseID>',OLD.`WarehouseID`,'</WarehouseID>');						SET @pk_d = CONCAT('<WarehouseID>',NEW.`WarehouseID`,'</WarehouseID>');						SET @rec_state = 2;						SET @rs = 0;						SELECT `record_state` INTO @rs FROM `history_store` WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						IF @rs = 0 THEN 						INSERT INTO `history_store`( `timemark`, `table_name`, `pk_date_src`,`pk_date_dest`, `record_state` ) VALUES (@time_mark, @tbl_name, @pk_d,@pk_d_old, @rec_state );						ELSE 						UPDATE `history_store` SET `timemark` = @time_mark, `pk_date_src` = @pk_d WHERE `table_name` = @tbl_name AND `pk_date_src` = @pk_d_old;						END IF; END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `badstock`
--
ALTER TABLE `badstock`
  ADD PRIMARY KEY (`BDS_ID`);

--
-- Indexes for table `collection`
--
ALTER TABLE `collection`
  ADD PRIMARY KEY (`COLL_ID`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CUST_ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EMP_ID`);

--
-- Indexes for table `employeepayment`
--
ALTER TABLE `employeepayment`
  ADD PRIMARY KEY (`EMP_PAY_ID`);

--
-- Indexes for table `expenditureaccount`
--
ALTER TABLE `expenditureaccount`
  ADD PRIMARY KEY (`EXP_AC_ID`);

--
-- Indexes for table `expense`
--
ALTER TABLE `expense`
  ADD PRIMARY KEY (`Expense_ID`);

--
-- Indexes for table `history_store`
--
ALTER TABLE `history_store`
  ADD PRIMARY KEY (`table_name`(85),`pk_date_dest`(85));

--
-- Indexes for table `itemgroup`
--
ALTER TABLE `itemgroup`
  ADD PRIMARY KEY (`GROUP_ID`);

--
-- Indexes for table `iteminformation`
--
ALTER TABLE `iteminformation`
  ADD PRIMARY KEY (`ITEM_ID`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PAYM_ID`);

--
-- Indexes for table `printbarcode`
--
ALTER TABLE `printbarcode`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `purchaseinfo`
--
ALTER TABLE `purchaseinfo`
  ADD PRIMARY KEY (`PUCHSE_ID`);

--
-- Indexes for table `purchasereturn`
--
ALTER TABLE `purchasereturn`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `salesinfo`
--
ALTER TABLE `salesinfo`
  ADD PRIMARY KEY (`SALES_ID`);

--
-- Indexes for table `salesreturn`
--
ALTER TABLE `salesreturn`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `shelf`
--
ALTER TABLE `shelf`
  ADD PRIMARY KEY (`SHELF_ID`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`STOCK_ID`);

--
-- Indexes for table `stocktransfer`
--
ALTER TABLE `stocktransfer`
  ADD PRIMARY KEY (`TRNS_ID`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SUPP_ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`USER_ID`);

--
-- Indexes for table `warehouse`
--
ALTER TABLE `warehouse`
  ADD PRIMARY KEY (`WarehouseID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `badstock`
--
ALTER TABLE `badstock`
  MODIFY `BDS_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `collection`
--
ALTER TABLE `collection`
  MODIFY `COLL_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `CUST_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `EMP_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeepayment`
--
ALTER TABLE `employeepayment`
  MODIFY `EMP_PAY_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `expenditureaccount`
--
ALTER TABLE `expenditureaccount`
  MODIFY `EXP_AC_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `expense`
--
ALTER TABLE `expense`
  MODIFY `Expense_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itemgroup`
--
ALTER TABLE `itemgroup`
  MODIFY `GROUP_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `iteminformation`
--
ALTER TABLE `iteminformation`
  MODIFY `ITEM_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `PAYM_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `printbarcode`
--
ALTER TABLE `printbarcode`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchase`
--
ALTER TABLE `purchase`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchaseinfo`
--
ALTER TABLE `purchaseinfo`
  MODIFY `PUCHSE_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchasereturn`
--
ALTER TABLE `purchasereturn`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `salesinfo`
--
ALTER TABLE `salesinfo`
  MODIFY `SALES_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `salesreturn`
--
ALTER TABLE `salesreturn`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shelf`
--
ALTER TABLE `shelf`
  MODIFY `SHELF_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `STOCK_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stocktransfer`
--
ALTER TABLE `stocktransfer`
  MODIFY `TRNS_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `SUPP_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `USER_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `warehouse`
--
ALTER TABLE `warehouse`
  MODIFY `WarehouseID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
