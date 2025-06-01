-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: dbproject
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account` (
  `AccountID` int NOT NULL AUTO_INCREMENT,
  `AccountNumber` varchar(9) NOT NULL,
  `AccountType` varchar(50) DEFAULT NULL,
  `Balance` decimal(15,2) DEFAULT '0.00',
  `Status` varchar(20) DEFAULT 'Active',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `InterestRate` decimal(5,2) DEFAULT NULL,
  `OverdraftLimit` decimal(10,2) DEFAULT NULL,
  `BranchID` int DEFAULT NULL,
  `CustomerID` int DEFAULT NULL,
  PRIMARY KEY (`AccountID`),
  UNIQUE KEY `AccountNumber` (`AccountNumber`),
  KEY `BranchID` (`BranchID`),
  KEY `CustomerID` (`CustomerID`),
  KEY `balanceindex` (`Balance`),
  CONSTRAINT `account_ibfk_1` FOREIGN KEY (`BranchID`) REFERENCES `branch` (`BranchID`),
  CONSTRAINT `account_ibfk_2` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`),
  CONSTRAINT `account_chk_1` CHECK ((`Balance` >= 0)),
  CONSTRAINT `account_chk_2` CHECK (regexp_like(`AccountNumber`,_utf8mb4'^[0-9]{9}$'))
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (1,'539986705','Current',0.00,'Active','2025-05-09 20:25:06',0.00,10.00,2,2),(2,'607987607','Current',95.00,'Active','2025-05-09 23:46:17',0.00,10.00,1,2),(3,'264750302','Current',50005.00,'Active','2025-05-11 18:09:02',0.00,10000.00,2,3);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_log_withdrawal` BEFORE UPDATE ON `account` FOR EACH ROW BEGIN
    -- Only log if balance is reduced (withdrawal)
    IF NEW.Balance < OLD.Balance THEN
        INSERT INTO AuditTransactionLog (AccountID, Amount)
        VALUES (OLD.AccountID, OLD.Balance - NEW.Balance);
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `assignmanageraudit`
--

DROP TABLE IF EXISTS `assignmanageraudit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assignmanageraudit` (
  `Audit_ID` int NOT NULL AUTO_INCREMENT,
  `BranchID` int DEFAULT NULL,
  `OldManager` int DEFAULT NULL,
  `NewManager` int DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Audit_ID`),
  KEY `BranchID` (`BranchID`),
  KEY `OldManager` (`OldManager`),
  KEY `NewManager` (`NewManager`),
  KEY `UpdatedBy` (`UpdatedBy`),
  CONSTRAINT `assignmanageraudit_ibfk_1` FOREIGN KEY (`BranchID`) REFERENCES `branch` (`BranchID`),
  CONSTRAINT `assignmanageraudit_ibfk_2` FOREIGN KEY (`OldManager`) REFERENCES `employee` (`EmployeeID`),
  CONSTRAINT `assignmanageraudit_ibfk_3` FOREIGN KEY (`NewManager`) REFERENCES `employee` (`EmployeeID`),
  CONSTRAINT `assignmanageraudit_ibfk_4` FOREIGN KEY (`UpdatedBy`) REFERENCES `bank` (`BankCode`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignmanageraudit`
--

LOCK TABLES `assignmanageraudit` WRITE;
/*!40000 ALTER TABLE `assignmanageraudit` DISABLE KEYS */;
INSERT INTO `assignmanageraudit` VALUES (1,1,2,1,NULL,'2025-05-11 19:34:59'),(2,1,2,1,NULL,'2025-05-11 19:34:59'),(4,1,1,2,NULL,'2025-05-11 19:39:12'),(5,1,1,2,NULL,'2025-05-11 19:39:12'),(6,1,2,1,NULL,'2025-05-11 19:59:40'),(7,1,2,1,NULL,'2025-05-11 19:59:40'),(8,1,1,2,NULL,'2025-05-11 20:40:46'),(9,1,1,2,NULL,'2025-05-11 20:40:46'),(10,1,2,1,NULL,'2025-05-11 20:52:43'),(11,1,2,1,NULL,'2025-05-11 20:52:43'),(12,1,1,2,NULL,'2025-05-11 20:55:23'),(13,1,1,2,NULL,'2025-05-11 20:55:23'),(14,1,2,1,NULL,'2025-05-12 14:38:04'),(15,1,2,1,NULL,'2025-05-12 14:38:04');
/*!40000 ALTER TABLE `assignmanageraudit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audittransactionlog`
--

DROP TABLE IF EXISTS `audittransactionlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `audittransactionlog` (
  `logID` int NOT NULL AUTO_INCREMENT,
  `AccountID` int DEFAULT NULL,
  `Amount` decimal(15,2) DEFAULT NULL,
  `timeoftransaction` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`logID`),
  KEY `AccountID` (`AccountID`),
  CONSTRAINT `audittransactionlog_ibfk_1` FOREIGN KEY (`AccountID`) REFERENCES `account` (`AccountID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audittransactionlog`
--

LOCK TABLES `audittransactionlog` WRITE;
/*!40000 ALTER TABLE `audittransactionlog` DISABLE KEYS */;
INSERT INTO `audittransactionlog` VALUES (2,2,105.00,'2025-05-12 00:36:42');
/*!40000 ALTER TABLE `audittransactionlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bank` (
  `BankCode` int NOT NULL AUTO_INCREMENT,
  `BankName` varchar(100) NOT NULL,
  `BankContact` varchar(50) NOT NULL,
  `BankAddress` varchar(255) NOT NULL,
  PRIMARY KEY (`BankCode`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank`
--

LOCK TABLES `bank` WRITE;
/*!40000 ALTER TABLE `bank` DISABLE KEYS */;
INSERT INTO `bank` VALUES (1,'MAT','03000000000','Uet Lahore');
/*!40000 ALTER TABLE `bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bankfund`
--

DROP TABLE IF EXISTS `bankfund`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankfund` (
  `FundID` int NOT NULL AUTO_INCREMENT,
  `TotalAmount` decimal(15,2) NOT NULL DEFAULT '0.00',
  `TransactionDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`FundID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankfund`
--

LOCK TABLES `bankfund` WRITE;
/*!40000 ALTER TABLE `bankfund` DISABLE KEYS */;
INSERT INTO `bankfund` VALUES (1,0.00,'2025-05-11 00:55:12'),(2,100.00,'2025-05-12 00:36:42');
/*!40000 ALTER TABLE `bankfund` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bankfundhistory`
--

DROP TABLE IF EXISTS `bankfundhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankfundhistory` (
  `HistoryID` int NOT NULL AUTO_INCREMENT,
  `DateTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `Amount` decimal(15,2) NOT NULL,
  `TransactionType` enum('Added','Deducted') NOT NULL,
  `Source` varchar(50) DEFAULT NULL,
  `PerformedBy` int DEFAULT NULL,
  `Note` text,
  PRIMARY KEY (`HistoryID`),
  KEY `PerformedBy` (`PerformedBy`),
  CONSTRAINT `bankfundhistory_ibfk_1` FOREIGN KEY (`PerformedBy`) REFERENCES `users` (`UserID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankfundhistory`
--

LOCK TABLES `bankfundhistory` WRITE;
/*!40000 ALTER TABLE `bankfundhistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `bankfundhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch`
--

DROP TABLE IF EXISTS `branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branch` (
  `BranchID` int NOT NULL AUTO_INCREMENT,
  `BranchName` varchar(100) NOT NULL,
  `Contact` varchar(15) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Status` varchar(20) DEFAULT 'Active',
  `BankCode` int DEFAULT NULL,
  PRIMARY KEY (`BranchID`),
  KEY `BankCode` (`BankCode`),
  CONSTRAINT `branch_ibfk_1` FOREIGN KEY (`BankCode`) REFERENCES `bank` (`BankCode`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch`
--

LOCK TABLES `branch` WRITE;
/*!40000 ALTER TABLE `branch` DISABLE KEYS */;
INSERT INTO `branch` VALUES (1,'Shalimar','033333','Salimar','Active',1),(2,'UET','032399132','Bulevar Road','Active',1),(3,'yedue','0987655','gsdfyuiu','5',1),(4,'gfyu','09876543','dfxctguh','5',1);
/*!40000 ALTER TABLE `branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chequebooks`
--

DROP TABLE IF EXISTS `chequebooks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chequebooks` (
  `ChequeBookID` int NOT NULL AUTO_INCREMENT,
  `RequestID` int DEFAULT NULL,
  `AccountID` int DEFAULT NULL,
  `IssueDate` date DEFAULT NULL,
  `TotalLeaves` int DEFAULT NULL,
  `UsedLeaves` int DEFAULT '0',
  `IsFullyUsed` tinyint(1) DEFAULT '0',
  `Status` varchar(20) DEFAULT 'Active',
  PRIMARY KEY (`ChequeBookID`),
  KEY `RequestID` (`RequestID`),
  KEY `AccountID` (`AccountID`),
  CONSTRAINT `chequebooks_ibfk_1` FOREIGN KEY (`RequestID`) REFERENCES `servicerequests` (`RequestID`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `chequebooks_ibfk_2` FOREIGN KEY (`AccountID`) REFERENCES `account` (`AccountID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chequebooks`
--

LOCK TABLES `chequebooks` WRITE;
/*!40000 ALTER TABLE `chequebooks` DISABLE KEYS */;
INSERT INTO `chequebooks` VALUES (1,1,1,'2025-05-12',100,0,0,'Active');
/*!40000 ALTER TABLE `chequebooks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chequeleaves`
--

DROP TABLE IF EXISTS `chequeleaves`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chequeleaves` (
  `LeafID` int NOT NULL AUTO_INCREMENT,
  `ChequeBookID` int DEFAULT NULL,
  `LeafNumber` int DEFAULT NULL,
  `IssueDate` date DEFAULT NULL,
  `Amount` decimal(10,2) DEFAULT NULL,
  `Status` varchar(20) DEFAULT 'Available',
  PRIMARY KEY (`LeafID`),
  KEY `ChequeBookID` (`ChequeBookID`),
  CONSTRAINT `chequeleaves_ibfk_1` FOREIGN KEY (`ChequeBookID`) REFERENCES `chequebooks` (`ChequeBookID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chequeleaves`
--

LOCK TABLES `chequeleaves` WRITE;
/*!40000 ALTER TABLE `chequeleaves` DISABLE KEYS */;
/*!40000 ALTER TABLE `chequeleaves` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `complains`
--

DROP TABLE IF EXISTS `complains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `complains` (
  `ComplainID` int NOT NULL AUTO_INCREMENT,
  `UserID` int DEFAULT NULL,
  `ComplainType` varchar(120) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `DateOfComplain` datetime DEFAULT CURRENT_TIMESTAMP,
  `ResolutionDate` datetime DEFAULT NULL,
  `Status_` enum('pending','verified','declined','under Process') DEFAULT 'pending',
  PRIMARY KEY (`ComplainID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `complains_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `complains`
--

LOCK TABLES `complains` WRITE;
/*!40000 ALTER TABLE `complains` DISABLE KEYS */;
INSERT INTO `complains` VALUES (1,10,'Unauthorized Transactions','my account has been hacked by Ayesha','2025-05-11 10:55:23','2025-05-18 10:55:23','under Process'),(2,10,'Incorrected Fee','i have seen by unathorized access','2025-05-11 10:57:57','2025-05-18 10:57:57','under Process'),(5,5,'Misinterpretation of Service','I didnt ask for any extra serivces','2025-05-11 19:04:36','2025-05-18 19:04:36','declined');
/*!40000 ALTER TABLE `complains` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `set_resolution_date` BEFORE INSERT ON `complains` FOR EACH ROW begin 
if new.ResolutionDate is null then
set new.ResolutionDate = Now()+interval 7 Day;
End if;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `creditcards`
--

DROP TABLE IF EXISTS `creditcards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `creditcards` (
  `CardID` int NOT NULL AUTO_INCREMENT,
  `RequestID` int DEFAULT NULL,
  `AccountID` int DEFAULT NULL,
  `IssueDate` date DEFAULT NULL,
  `CardNumber` varchar(16) DEFAULT NULL,
  `ExpiryDate` date DEFAULT NULL,
  `CreditLimit` decimal(10,2) DEFAULT NULL,
  `Status` varchar(20) DEFAULT 'Active',
  `pin` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`CardID`),
  UNIQUE KEY `AccountID` (`AccountID`),
  KEY `RequestID` (`RequestID`),
  CONSTRAINT `creditcards_ibfk_1` FOREIGN KEY (`RequestID`) REFERENCES `servicerequests` (`RequestID`),
  CONSTRAINT `creditcards_ibfk_2` FOREIGN KEY (`AccountID`) REFERENCES `account` (`AccountID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `creditcards`
--

LOCK TABLES `creditcards` WRITE;
/*!40000 ALTER TABLE `creditcards` DISABLE KEYS */;
INSERT INTO `creditcards` VALUES (1,1,1,'2025-05-12','7338204507544286','2028-05-12',10000.00,'Active','1122');
/*!40000 ALTER TABLE `creditcards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `CustomerID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `CNIC` char(13) NOT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `UserID` int DEFAULT NULL,
  PRIMARY KEY (`CustomerID`),
  UNIQUE KEY `CNIC` (`CNIC`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `customer_ibfk_2` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'Aleeza','aleeza@gmail.com','3110525164132','03008882435','House no 1 , lalauabid','2007-05-17',9),(2,'Aliya','aliya@gmail.com','311052516512','030012323211','house no 1 lala','2006-06-06',10),(3,'Asad','asad@gmail.com','3110212121','03000000','houseno1 ','2025-05-11',12);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customeraccount`
--

DROP TABLE IF EXISTS `customeraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customeraccount` (
  `CustomerID` int DEFAULT NULL,
  `BranchID` int DEFAULT NULL,
  KEY `CustomerID` (`CustomerID`),
  KEY `BranchID` (`BranchID`),
  CONSTRAINT `customeraccount_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`),
  CONSTRAINT `customeraccount_ibfk_2` FOREIGN KEY (`BranchID`) REFERENCES `branch` (`BranchID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customeraccount`
--

LOCK TABLES `customeraccount` WRITE;
/*!40000 ALTER TABLE `customeraccount` DISABLE KEYS */;
/*!40000 ALTER TABLE `customeraccount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `EmployeeID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `RoleID` int NOT NULL,
  `BranchID` int NOT NULL,
  `UserID` int DEFAULT NULL,
  `ManagerID` int DEFAULT NULL,
  `AddedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `Status` enum('Active','Inactive','Delete') DEFAULT 'Active',
  PRIMARY KEY (`EmployeeID`),
  KEY `ManagerID` (`ManagerID`),
  KEY `RoleID` (`RoleID`),
  KEY `BranchID` (`BranchID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`ManagerID`) REFERENCES `employee` (`EmployeeID`),
  CONSTRAINT `employee_ibfk_2` FOREIGN KEY (`RoleID`) REFERENCES `lookup` (`LookupID`),
  CONSTRAINT `employee_ibfk_3` FOREIGN KEY (`BranchID`) REFERENCES `branch` (`BranchID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `employee_ibfk_4` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Ali','ali@gmail.com','0300889989',2,1,5,1,'2025-05-09 19:14:50','Active'),(2,'Musfirah','m@gmail.com','030000000',3,1,6,1,'2025-05-09 19:15:24','Active'),(3,'Taleya','t@gmail.com','0311213131',3,2,7,NULL,'2025-05-09 19:17:35','Inactive'),(4,'Amna','amna@gmail.com','03129921',3,2,8,NULL,'2025-05-09 19:35:06','Active');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AssignManagerAudit` BEFORE UPDATE ON `employee` FOR EACH ROW begin
 if old.ManagerID <> new.ManagerID then 
  Insert into AssignManagerAudit (BranchID , OldManager , NewManager ) values (new.BranchID , old.ManagerID , new.ManagerID );
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_UpdateUserRole` AFTER UPDATE ON `employee` FOR EACH ROW BEGIN
    -- Check if the RoleID actually changed
    IF NEW.RoleID <> OLD.RoleID THEN
        UPDATE Users
        SET RoleID = NEW.RoleID
        WHERE UserID = NEW.UserID;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `employeeaudit`
--

DROP TABLE IF EXISTS `employeeaudit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employeeaudit` (
  `AuditID` int NOT NULL AUTO_INCREMENT,
  `EmployeeID` int DEFAULT NULL,
  `ColumnName` varchar(100) DEFAULT NULL,
  `OldValue` varchar(255) DEFAULT NULL,
  `NewValue` varchar(255) DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`AuditID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeeaudit`
--

LOCK TABLES `employeeaudit` WRITE;
/*!40000 ALTER TABLE `employeeaudit` DISABLE KEYS */;
/*!40000 ALTER TABLE `employeeaudit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lookup`
--

DROP TABLE IF EXISTS `lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lookup` (
  `LookupID` int NOT NULL AUTO_INCREMENT,
  `Category` varchar(50) DEFAULT NULL,
  `Value_` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`LookupID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lookup`
--

LOCK TABLES `lookup` WRITE;
/*!40000 ALTER TABLE `lookup` DISABLE KEYS */;
INSERT INTO `lookup` VALUES (1,'UserRole','Head'),(2,'UserRole','Manager'),(3,'UserRole','Employee'),(4,'UserRole','Customer'),(5,'BranchStatus','Active'),(6,'BranchStatus','Inactive'),(7,'AccountType','Current'),(8,'AccountType','Saving'),(9,'ServiceType','ChequeBook'),(10,'ServiceType','CreditCard'),(11,'ServiceType','L'),(12,'TransactionType','WithInbranch'),(13,'TransactionType','branch-to-branch');
/*!40000 ALTER TABLE `lookup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicerequests`
--

DROP TABLE IF EXISTS `servicerequests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicerequests` (
  `RequestID` int NOT NULL AUTO_INCREMENT,
  `CustomerID` int DEFAULT NULL,
  `BranchID` int DEFAULT NULL,
  `AccountID` int DEFAULT NULL,
  `ServiceType` int DEFAULT NULL,
  `Status` varchar(20) DEFAULT 'Active',
  `TotalLeaves` int DEFAULT NULL,
  `RequestDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`RequestID`),
  KEY `CustomerID` (`CustomerID`),
  KEY `BranchID` (`BranchID`),
  KEY `AccountID` (`AccountID`),
  CONSTRAINT `servicerequests_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE CASCADE ON UPDATE SET NULL,
  CONSTRAINT `servicerequests_ibfk_2` FOREIGN KEY (`BranchID`) REFERENCES `branch` (`BranchID`) ON DELETE CASCADE ON UPDATE SET NULL,
  CONSTRAINT `servicerequests_ibfk_3` FOREIGN KEY (`AccountID`) REFERENCES `account` (`AccountID`) ON DELETE CASCADE ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicerequests`
--

LOCK TABLES `servicerequests` WRITE;
/*!40000 ALTER TABLE `servicerequests` DISABLE KEYS */;
INSERT INTO `servicerequests` VALUES (1,2,2,1,10,'Active',NULL,'2025-05-12 01:00:18'),(2,2,1,2,9,'Active',NULL,'2025-05-12 01:00:37');
/*!40000 ALTER TABLE `servicerequests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `TransactionID` int NOT NULL AUTO_INCREMENT,
  `SenderAccountID` int NOT NULL,
  `ReceiverAccountID` int NOT NULL,
  `FromBranchID` int NOT NULL,
  `ToBranchID` int NOT NULL,
  `Amount` decimal(10,2) NOT NULL,
  `Fee` decimal(10,2) DEFAULT '0.00',
  `TransactionDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`TransactionID`),
  KEY `SenderAccountID` (`SenderAccountID`),
  KEY `ReceiverAccountID` (`ReceiverAccountID`),
  KEY `FromBranchID` (`FromBranchID`),
  KEY `ToBranchID` (`ToBranchID`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`SenderAccountID`) REFERENCES `account` (`AccountID`),
  CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`ReceiverAccountID`) REFERENCES `account` (`AccountID`),
  CONSTRAINT `transactions_ibfk_3` FOREIGN KEY (`FromBranchID`) REFERENCES `branch` (`BranchID`),
  CONSTRAINT `transactions_ibfk_4` FOREIGN KEY (`ToBranchID`) REFERENCES `branch` (`BranchID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,2,3,1,2,3.00,0.00,'2025-05-11 23:29:56','completed'),(2,2,3,1,2,3.00,0.00,'2025-05-11 23:30:15','completed'),(4,2,3,1,2,5.00,100.00,'2025-05-12 00:36:42','Completed');
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AfterTransactionInsert` AFTER INSERT ON `transactions` FOR EACH ROW BEGIN
    IF NEW.Fee > 0 THEN
        INSERT INTO BankFund (TotalAmount)
        VALUES (NEW.Fee);
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(200) DEFAULT 'Abc',
  `Email` varchar(259) DEFAULT NULL,
  `Password_Hash` varchar(255) NOT NULL,
  `RoleID` int DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `RoleID` (`RoleID`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `lookup` (`LookupID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Ayesha','a@gmail.com','123',1),(5,'Ali','ali@gmail.com','123',2),(6,'Musfirah','m@gmail.com','123',3),(7,'Taleya','t@gmail.com','123',3),(8,'Amna','amna@gmail.com','123',3),(9,'Aleeza','aleeza@gmail.com','123',4),(10,'Aliya','aliya@gmail.com','123',4),(11,'Asad','asad@gmail.com','123',4),(12,'Asad','asad@gmail.com','123',4);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_bankfundhistory`
--

DROP TABLE IF EXISTS `view_bankfundhistory`;
/*!50001 DROP VIEW IF EXISTS `view_bankfundhistory`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_bankfundhistory` AS SELECT 
 1 AS `HistoryID`,
 1 AS `DateTime`,
 1 AS `Amount`,
 1 AS `TransactionType`,
 1 AS `Source`,
 1 AS `PerformedByName`,
 1 AS `Note`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'dbproject'
--

--
-- Dumping routines for database 'dbproject'
--
/*!50003 DROP PROCEDURE IF EXISTS `AddBankFundTransaction` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddBankFundTransaction`(
    IN p_Amount DECIMAL(15,2),
    IN p_TransactionType ENUM('Added', 'Deducted'),
    IN p_Source VARCHAR(50),
    IN p_PerformedBy INT,
    IN p_Note TEXT
)
BEGIN
    -- Step 1: Fund Update
    IF p_TransactionType = 'Added' THEN
        UPDATE BankFund SET TotalAmount = TotalAmount + p_Amount;
    ELSE
        UPDATE BankFund SET TotalAmount = TotalAmount - p_Amount;
    END IF;

    -- Step 2: Fund History Save
    INSERT INTO BankFundHistory (Amount, TransactionType, Source, PerformedBy, Note)
    VALUES (p_Amount, p_TransactionType, p_Source, p_PerformedBy, p_Note);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ApproveLoanRequest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ApproveLoanRequest`(
    IN p_RequestID INT,
    IN p_AccountID INT,
    IN p_LoanAmount DECIMAL(15,2),
    IN p_PerformedBy INT
)
BEGIN
    DECLARE availableFunds DECIMAL(15,2);

   
        INSERT INTO Loan (RequestID, AccountID, LoanAmount, LoanTermMonths, LoanStatus, PerformedBy)
        VALUES (p_RequestID, p_AccountID, p_LoanAmount, 10, 'Approved', p_PerformedBy);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `view_bankfundhistory`
--

/*!50001 DROP VIEW IF EXISTS `view_bankfundhistory`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_bankfundhistory` AS select `h`.`HistoryID` AS `HistoryID`,date_format(`h`.`DateTime`,'%Y-%m-%d %H:%i:%s') AS `DateTime`,`h`.`Amount` AS `Amount`,`h`.`TransactionType` AS `TransactionType`,`h`.`Source` AS `Source`,`u`.`UserName` AS `PerformedByName`,`h`.`Note` AS `Note` from (`bankfundhistory` `h` left join `users` `u` on((`h`.`PerformedBy` = `u`.`UserID`))) order by `h`.`DateTime` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-01 18:12:04
