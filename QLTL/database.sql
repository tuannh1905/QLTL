CREATE DATABASE  IF NOT EXISTS `quanlythuyloi` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `quanlythuyloi`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: quanlythuyloi
-- ------------------------------------------------------
-- Server version	8.0.44

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
-- Table structure for table `bandoquyhoach`
--

DROP TABLE IF EXISTS `bandoquyhoach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bandoquyhoach` (
  `BanDoID` int NOT NULL AUTO_INCREMENT,
  `TenBanDo` varchar(255) NOT NULL,
  `KyID` int DEFAULT NULL,
  PRIMARY KEY (`BanDoID`),
  KEY `KyID` (`KyID`),
  CONSTRAINT `bandoquyhoach_ibfk_1` FOREIGN KEY (`KyID`) REFERENCES `kyquyhoach` (`KyID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bandoquyhoach`
--

LOCK TABLES `bandoquyhoach` WRITE;
/*!40000 ALTER TABLE `bandoquyhoach` DISABLE KEYS */;
INSERT INTO `bandoquyhoach` VALUES (1,'Bản đồ số hóa mạng lưới trạm bơm tỉnh Hải Dương 2025',1),(2,'Sơ đồ phân vùng rủi ro thiên tai lưu vực sông Thái Bình',1),(3,'Bản đồ quy hoạch hồ chứa nước Chí Linh đến năm 2030',1);
/*!40000 ALTER TABLE `bandoquyhoach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `bao_cao_cong_trinh`
--

DROP TABLE IF EXISTS `bao_cao_cong_trinh`;
/*!50001 DROP VIEW IF EXISTS `bao_cao_cong_trinh`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `bao_cao_cong_trinh` AS SELECT 
 1 AS `BaoCaoID`,
 1 AS `LoaiCongTrinh`,
 1 AS `TieuDe`,
 1 AS `NgayTao`,
 1 AS `TepDinhKem`,
 1 AS `MoTaTep`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `baocaocongtrinh`
--

DROP TABLE IF EXISTS `baocaocongtrinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `baocaocongtrinh` (
  `BaoCaoID` int NOT NULL AUTO_INCREMENT,
  `CongTrinhID` int DEFAULT NULL,
  `LoaiCongTrinh` varchar(100) DEFAULT NULL,
  `TieuDe` varchar(255) DEFAULT NULL,
  `NgayTao` date DEFAULT NULL,
  PRIMARY KEY (`BaoCaoID`),
  KEY `CongTrinhID` (`CongTrinhID`),
  CONSTRAINT `baocaocongtrinh_ibfk_1` FOREIGN KEY (`CongTrinhID`) REFERENCES `congtrinhthuyloi` (`CongTrinhID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baocaocongtrinh`
--

LOCK TABLES `baocaocongtrinh` WRITE;
/*!40000 ALTER TABLE `baocaocongtrinh` DISABLE KEYS */;
INSERT INTO `baocaocongtrinh` VALUES (1,1,'Trạm bơm','Kiểm tra kỹ thuật định kỳ Trạm bơm Sông Rạng','2024-01-10'),(2,2,'Hệ thống đê','Báo cáo tu bổ đê hữu Thái Bình đoạn qua TP Hải Dương','2024-02-15'),(3,4,'Hồ chứa','Đánh giá trữ lượng nước Hồ Côn Sơn phục vụ du lịch và tưới tiêu','2024-03-01');
/*!40000 ALTER TABLE `baocaocongtrinh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `baocaoquyhoach`
--

DROP TABLE IF EXISTS `baocaoquyhoach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `baocaoquyhoach` (
  `BaoCaoID` int NOT NULL AUTO_INCREMENT,
  `TieuDe` varchar(255) NOT NULL,
  `TepDinhKem` varchar(255) DEFAULT NULL,
  `KyID` int DEFAULT NULL,
  PRIMARY KEY (`BaoCaoID`),
  KEY `KyID` (`KyID`),
  CONSTRAINT `baocaoquyhoach_ibfk_1` FOREIGN KEY (`KyID`) REFERENCES `kyquyhoach` (`KyID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baocaoquyhoach`
--

LOCK TABLES `baocaoquyhoach` WRITE;
/*!40000 ALTER TABLE `baocaoquyhoach` DISABLE KEYS */;
INSERT INTO `baocaoquyhoach` VALUES (1,'Thuyết minh quy hoạch hệ thống tưới vùng vải thiều Thanh Hà','quyhoach_vaitheo_thanhha.pdf',1),(2,'Đề án cải tạo hệ thống kênh mương nội đồng Nam Sách','caitao_kenh_namsach.pdf',1),(3,'Báo cáo đánh giá tác động xâm nhập mặn vùng Kinh Môn','xat_nhap_man_kinhmon.pdf',2);
/*!40000 ALTER TABLE `baocaoquyhoach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capcongtrinh`
--

DROP TABLE IF EXISTS `capcongtrinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `capcongtrinh` (
  `CapID` int NOT NULL AUTO_INCREMENT,
  `TenCap` varchar(100) DEFAULT NULL,
  `HuyenID` int DEFAULT NULL,
  `XaID` int DEFAULT NULL,
  PRIMARY KEY (`CapID`),
  KEY `HuyenID` (`HuyenID`),
  KEY `XaID` (`XaID`),
  CONSTRAINT `capcongtrinh_ibfk_1` FOREIGN KEY (`HuyenID`) REFERENCES `huyen` (`HuyenID`),
  CONSTRAINT `capcongtrinh_ibfk_2` FOREIGN KEY (`XaID`) REFERENCES `xa` (`XaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capcongtrinh`
--

LOCK TABLES `capcongtrinh` WRITE;
/*!40000 ALTER TABLE `capcongtrinh` DISABLE KEYS */;
/*!40000 ALTER TABLE `capcongtrinh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caphanhchinh`
--

DROP TABLE IF EXISTS `caphanhchinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `caphanhchinh` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Ten` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caphanhchinh`
--

LOCK TABLES `caphanhchinh` WRITE;
/*!40000 ALTER TABLE `caphanhchinh` DISABLE KEYS */;
INSERT INTO `caphanhchinh` VALUES (1,'Trung ương'),(2,'Tỉnh/Thành phố'),(3,'Quận/Huyện');
/*!40000 ALTER TABLE `caphanhchinh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `congtrinh`
--

DROP TABLE IF EXISTS `congtrinh`;
/*!50001 DROP VIEW IF EXISTS `congtrinh`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `congtrinh` AS SELECT 
 1 AS `CongTrinhID`,
 1 AS `LoaiCongTrinh`,
 1 AS `MoTa`,
 1 AS `TenCap`,
 1 AS `TenHuyen`,
 1 AS `TenXa`,
 1 AS `DiaDiem`,
 1 AS `MucNuoc`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `congtrinhthuyloi`
--

DROP TABLE IF EXISTS `congtrinhthuyloi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `congtrinhthuyloi` (
  `CongTrinhID` int NOT NULL AUTO_INCREMENT,
  `LoaiCongTrinh` varchar(100) DEFAULT NULL,
  `CapID` int DEFAULT NULL,
  `DiaDiem` text,
  `MoTa` text,
  `TrangThaiID` int DEFAULT NULL,
  PRIMARY KEY (`CongTrinhID`),
  KEY `CapID` (`CapID`),
  KEY `TrangThaiID` (`TrangThaiID`),
  CONSTRAINT `congtrinhthuyloi_ibfk_1` FOREIGN KEY (`CapID`) REFERENCES `capcongtrinh` (`CapID`),
  CONSTRAINT `congtrinhthuyloi_ibfk_2` FOREIGN KEY (`TrangThaiID`) REFERENCES `trangthai` (`TrangThaiID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `congtrinhthuyloi`
--

LOCK TABLES `congtrinhthuyloi` WRITE;
/*!40000 ALTER TABLE `congtrinhthuyloi` DISABLE KEYS */;
INSERT INTO `congtrinhthuyloi` VALUES (1,'Trạm bơm',1,'Cống Sông Rạng','Trạm bơm phục vụ tưới tiêu vùng vải Thanh Hà',2),(2,'Hê thống đê',1,'Đê hữu Thái Bình','Tuyến đê cấp quốc gia đi qua TP Hải Dương',3),(3,'Kênh dẫn',2,'Kênh Bắc Hưng Hải','Hệ thống thủy lợi liên tỉnh phục vụ miền Bắc',2),(4,'Hồ chứa',2,'Hồ Côn Sơn','Hồ điều tiết nước và du lịch Chí Linh',2);
/*!40000 ALTER TABLE `congtrinhthuyloi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danhmucdientichtuoi`
--

DROP TABLE IF EXISTS `danhmucdientichtuoi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danhmucdientichtuoi` (
  `DanhMucID` int NOT NULL AUTO_INCREMENT,
  `TenDanhMuc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`DanhMucID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `danhmucdientichtuoi`
--

LOCK TABLES `danhmucdientichtuoi` WRITE;
/*!40000 ALTER TABLE `danhmucdientichtuoi` DISABLE KEYS */;
INSERT INTO `danhmucdientichtuoi` VALUES (1,'Lúa Chiêm'),(2,'Lúa Mùa'),(3,'Cây vụ Đông');
/*!40000 ALTER TABLE `danhmucdientichtuoi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dientichtuoitheohuyen`
--

DROP TABLE IF EXISTS `dientichtuoitheohuyen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dientichtuoitheohuyen` (
  `TuoiTheoHuyenID` int NOT NULL AUTO_INCREMENT,
  `Vu` varchar(50) DEFAULT NULL,
  `DienTich` double DEFAULT NULL,
  `HuyenID` int DEFAULT NULL,
  `DanhMucID` int DEFAULT NULL,
  PRIMARY KEY (`TuoiTheoHuyenID`),
  KEY `HuyenID` (`HuyenID`),
  KEY `DanhMucID` (`DanhMucID`),
  CONSTRAINT `dientichtuoitheohuyen_ibfk_1` FOREIGN KEY (`HuyenID`) REFERENCES `huyen` (`HuyenID`),
  CONSTRAINT `dientichtuoitheohuyen_ibfk_2` FOREIGN KEY (`DanhMucID`) REFERENCES `danhmucdientichtuoi` (`DanhMucID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dientichtuoitheohuyen`
--

LOCK TABLES `dientichtuoitheohuyen` WRITE;
/*!40000 ALTER TABLE `dientichtuoitheohuyen` DISABLE KEYS */;
/*!40000 ALTER TABLE `dientichtuoitheohuyen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dientichtuoitheoxa`
--

DROP TABLE IF EXISTS `dientichtuoitheoxa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dientichtuoitheoxa` (
  `TuoiTheoXaID` int NOT NULL AUTO_INCREMENT,
  `Vu` varchar(50) DEFAULT NULL,
  `DienTich` double DEFAULT NULL,
  `XaID` int DEFAULT NULL,
  `DanhMucID` int DEFAULT NULL,
  PRIMARY KEY (`TuoiTheoXaID`),
  KEY `XaID` (`XaID`),
  KEY `DanhMucID` (`DanhMucID`),
  CONSTRAINT `dientichtuoitheoxa_ibfk_1` FOREIGN KEY (`XaID`) REFERENCES `xa` (`XaID`),
  CONSTRAINT `dientichtuoitheoxa_ibfk_2` FOREIGN KEY (`DanhMucID`) REFERENCES `danhmucdientichtuoi` (`DanhMucID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dientichtuoitheoxa`
--

LOCK TABLES `dientichtuoitheoxa` WRITE;
/*!40000 ALTER TABLE `dientichtuoitheoxa` DISABLE KEYS */;
INSERT INTO `dientichtuoitheoxa` VALUES (1,'Vụ Chiêm 2023',850.5,1,1),(2,'Vụ Mùa 2023',720,1,2),(3,'Vụ Đông 2023',540.2,4,3);
/*!40000 ALTER TABLE `dientichtuoitheoxa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donvi`
--

DROP TABLE IF EXISTS `donvi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donvi` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Ten` varchar(255) NOT NULL,
  `HanhChinhID` int DEFAULT NULL,
  `TruocThuocID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `HanhChinhID` (`HanhChinhID`),
  KEY `TruocThuocID` (`TruocThuocID`),
  CONSTRAINT `donvi_ibfk_1` FOREIGN KEY (`HanhChinhID`) REFERENCES `caphanhchinh` (`ID`),
  CONSTRAINT `donvi_ibfk_2` FOREIGN KEY (`TruocThuocID`) REFERENCES `donvi` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donvi`
--

LOCK TABLES `donvi` WRITE;
/*!40000 ALTER TABLE `donvi` DISABLE KEYS */;
INSERT INTO `donvi` VALUES (1,'Sở Nông nghiệp & PTNT',2,NULL),(2,'Phòng Thủy lợi Huyện',3,1);
/*!40000 ALTER TABLE `donvi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hoso`
--

DROP TABLE IF EXISTS `hoso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hoso` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `HoTen` varchar(255) NOT NULL,
  `NgaySinh` date DEFAULT NULL,
  `DonViID` int DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `ChucNang` text,
  `Exit_Status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DonViID` (`DonViID`),
  CONSTRAINT `hoso_ibfk_1` FOREIGN KEY (`DonViID`) REFERENCES `donvi` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hoso`
--

LOCK TABLES `hoso` WRITE;
/*!40000 ALTER TABLE `hoso` DISABLE KEYS */;
INSERT INTO `hoso` VALUES (1,'Trần Khánh Huyền','1990-05-20',1,'HuyenTK.sis.hust@gmail.com','Quản lý chung',0),(2,'Nguyễn Văn Khánh','2000-10-15',2,'KhanhNV.tt.sis.hust@gmail.com','Vận hành trạm bơm',0),(3,'Vũ Thành Long',NULL,NULL,'LongVT@sis.hust.edu.vn','Kỹ thuật viên',NULL),(4,'Karina',NULL,NULL,'Ka@','Nhân viên',NULL),(5,'Trần Văn Linh',NULL,NULL,'LinhVT@sis.hust.edu.vn','Kỹ thuật viên',NULL);
/*!40000 ALTER TABLE `hoso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `huyen`
--

DROP TABLE IF EXISTS `huyen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `huyen` (
  `HuyenID` int NOT NULL AUTO_INCREMENT,
  `Ten` varchar(100) NOT NULL,
  PRIMARY KEY (`HuyenID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `huyen`
--

LOCK TABLES `huyen` WRITE;
/*!40000 ALTER TABLE `huyen` DISABLE KEYS */;
INSERT INTO `huyen` VALUES (1,'Thanh Hà'),(2,'Chí Linh'),(3,'Nam Sách'),(4,'Kinh Môn');
/*!40000 ALTER TABLE `huyen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kyquyhoach`
--

DROP TABLE IF EXISTS `kyquyhoach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kyquyhoach` (
  `KyID` int NOT NULL AUTO_INCREMENT,
  `TenKy` varchar(255) NOT NULL,
  `NamBatDau` int DEFAULT NULL,
  `NamKetThuc` int DEFAULT NULL,
  PRIMARY KEY (`KyID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kyquyhoach`
--

LOCK TABLES `kyquyhoach` WRITE;
/*!40000 ALTER TABLE `kyquyhoach` DISABLE KEYS */;
INSERT INTO `kyquyhoach` VALUES (1,'Quy hoạch thủy lợi Hải Dương giai đoạn 2021-2030',2021,2030),(2,'Kế hoạch thích ứng biến đổi khí hậu tầm nhìn 2050',2031,2050);
/*!40000 ALTER TABLE `kyquyhoach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `lich_su_thao_tac`
--

DROP TABLE IF EXISTS `lich_su_thao_tac`;
/*!50001 DROP VIEW IF EXISTS `lich_su_thao_tac`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `lich_su_thao_tac` AS SELECT 
 1 AS `ID`,
 1 AS `TaiKhoanID`,
 1 AS `HoTen`,
 1 AS `GiaTriCu`,
 1 AS `GiaTriMoi`,
 1 AS `ThoiGianThucHien`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `lichsudangnhap`
--

DROP TABLE IF EXISTS `lichsudangnhap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lichsudangnhap` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ThoiDiemDN` datetime DEFAULT NULL,
  `ThoiDiemDX` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lichsudangnhap`
--

LOCK TABLES `lichsudangnhap` WRITE;
/*!40000 ALTER TABLE `lichsudangnhap` DISABLE KEYS */;
INSERT INTO `lichsudangnhap` VALUES (1,'2023-10-27 08:00:00','2023-10-27 08:30:00'),(2,'2026-01-14 07:47:45',NULL),(3,'2026-01-14 07:53:36',NULL),(4,'2026-01-14 08:04:08',NULL),(5,'2026-01-14 08:08:34',NULL),(6,'2026-01-14 16:28:47',NULL),(7,'2026-01-14 16:32:10',NULL),(8,'2026-01-14 16:32:40',NULL),(9,'2026-01-14 16:41:50',NULL),(10,'2026-01-14 16:55:32',NULL),(11,'2026-01-14 17:06:53',NULL),(12,'2026-01-14 17:10:38',NULL),(13,'2026-01-14 17:11:38',NULL),(14,'2026-01-14 17:14:36',NULL),(15,'2026-01-14 20:06:57','2026-01-14 20:07:22'),(16,'2026-01-14 20:07:34','2026-01-14 20:08:32'),(17,'2026-01-14 20:08:59','2026-01-14 20:09:47'),(18,'2026-01-14 20:11:23',NULL),(19,'2026-01-14 20:16:20','2026-01-14 20:18:24'),(20,'2026-01-14 20:18:34','2026-01-14 20:18:54'),(21,'2026-01-15 21:39:25',NULL),(22,'2026-01-15 21:52:27',NULL),(23,'2026-01-15 21:59:38',NULL),(24,'2026-01-15 22:06:55','2026-01-15 22:08:27'),(25,'2026-01-15 22:52:20','2026-01-15 22:52:24'),(26,'2026-01-15 22:52:52','2026-01-15 22:54:13'),(27,'2026-01-15 22:54:24','2026-01-15 22:55:41');
/*!40000 ALTER TABLE `lichsudangnhap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lichsuthaotac`
--

DROP TABLE IF EXISTS `lichsuthaotac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lichsuthaotac` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `TaiKhoanID` varchar(50) DEFAULT NULL,
  `ThaoTac` text,
  `GiaTriCu` text,
  `GiaTriMoi` text,
  `LichSuID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `TaiKhoanID` (`TaiKhoanID`),
  KEY `LichSuID` (`LichSuID`),
  CONSTRAINT `lichsuthaotac_ibfk_1` FOREIGN KEY (`TaiKhoanID`) REFERENCES `taikhoan` (`TenDangNhap`),
  CONSTRAINT `lichsuthaotac_ibfk_2` FOREIGN KEY (`LichSuID`) REFERENCES `lichsudangnhap` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lichsuthaotac`
--

LOCK TABLES `lichsuthaotac` WRITE;
/*!40000 ALTER TABLE `lichsuthaotac` DISABLE KEYS */;
INSERT INTO `lichsuthaotac` VALUES (1,'HuyenTK','Cập nhật mực nước','1.2m','1.5m',1),(2,'KhanhNV','Đăng nhập hệ thống',NULL,NULL,2),(3,'KhanhNV','Đăng nhập hệ thống',NULL,NULL,3),(4,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,4),(5,'KhanhNV','Đăng nhập hệ thống',NULL,NULL,5),(6,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,6),(7,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,7),(8,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,8),(9,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,9),(10,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,10),(11,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,11),(12,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,12),(13,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,13),(14,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,14),(15,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,15),(16,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,16),(17,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,17),(18,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,18),(19,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,19),(20,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,20),(21,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,21),(22,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,22),(23,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,23),(24,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,24),(25,'HuyenTK','Đã xóa user: Katarinablu',NULL,NULL,24),(26,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,25),(27,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,26),(28,'HuyenTK','Đăng nhập hệ thống',NULL,NULL,27),(29,'HuyenTK','Đã xóa user: LinhVT',NULL,NULL,27);
/*!40000 ALTER TABLE `lichsuthaotac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `nguoidung`
--

DROP TABLE IF EXISTS `nguoidung`;
/*!50001 DROP VIEW IF EXISTS `nguoidung`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nguoidung` AS SELECT 
 1 AS `TenDangNhap`,
 1 AS `HoTen`,
 1 AS `Email`,
 1 AS `NgaySinh`,
 1 AS `TenDonVi`,
 1 AS `CapHanhChinh`,
 1 AS `TrangThai`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `quyen`
--

DROP TABLE IF EXISTS `quyen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quyen` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `TenQuyen` varchar(100) DEFAULT NULL,
  `XemLichSu` tinyint(1) DEFAULT NULL,
  `Exit_Status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quyen`
--

LOCK TABLES `quyen` WRITE;
/*!40000 ALTER TABLE `quyen` DISABLE KEYS */;
INSERT INTO `quyen` VALUES (1,'Quản trị hệ thống',1,0),(2,'Cập nhật dữ liệu',0,0),(3,'Xem báo cáo',0,0);
/*!40000 ALTER TABLE `quyen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quyen_taikhoan`
--

DROP TABLE IF EXISTS `quyen_taikhoan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quyen_taikhoan` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `TaiKhoanID` varchar(50) DEFAULT NULL,
  `QuyenID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `TaiKhoanID` (`TaiKhoanID`),
  KEY `QuyenID` (`QuyenID`),
  CONSTRAINT `quyen_taikhoan_ibfk_1` FOREIGN KEY (`TaiKhoanID`) REFERENCES `taikhoan` (`TenDangNhap`),
  CONSTRAINT `quyen_taikhoan_ibfk_2` FOREIGN KEY (`QuyenID`) REFERENCES `quyen` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quyen_taikhoan`
--

LOCK TABLES `quyen_taikhoan` WRITE;
/*!40000 ALTER TABLE `quyen_taikhoan` DISABLE KEYS */;
INSERT INTO `quyen_taikhoan` VALUES (1,'HuyenTK',1),(2,'HuyenTK',2),(3,'KhanhNV',2),(4,'KhanhNV',3);
/*!40000 ALTER TABLE `quyen_taikhoan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taikhoan`
--

DROP TABLE IF EXISTS `taikhoan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `taikhoan` (
  `TenDangNhap` varchar(50) NOT NULL,
  `MatKhau` varchar(255) NOT NULL,
  `TrangThai` varchar(50) DEFAULT NULL,
  `HoSoID` int DEFAULT NULL,
  PRIMARY KEY (`TenDangNhap`),
  KEY `HoSoID` (`HoSoID`),
  CONSTRAINT `taikhoan_ibfk_1` FOREIGN KEY (`HoSoID`) REFERENCES `hoso` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taikhoan`
--

LOCK TABLES `taikhoan` WRITE;
/*!40000 ALTER TABLE `taikhoan` DISABLE KEYS */;
INSERT INTO `taikhoan` VALUES ('HuyenTK','123456','Active',1),('KhanhNV','123456','Active',2),('LongVT','123456','Active',3);
/*!40000 ALTER TABLE `taikhoan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tepdinhkembaocao`
--

DROP TABLE IF EXISTS `tepdinhkembaocao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tepdinhkembaocao` (
  `TepID` int NOT NULL AUTO_INCREMENT,
  `TepDinhKem` varchar(255) DEFAULT NULL,
  `MoTa` text,
  `BaoCaoID` int DEFAULT NULL,
  PRIMARY KEY (`TepID`),
  KEY `BaoCaoID` (`BaoCaoID`),
  CONSTRAINT `tepdinhkembaocao_ibfk_1` FOREIGN KEY (`BaoCaoID`) REFERENCES `baocaocongtrinh` (`BaoCaoID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tepdinhkembaocao`
--

LOCK TABLES `tepdinhkembaocao` WRITE;
/*!40000 ALTER TABLE `tepdinhkembaocao` DISABLE KEYS */;
INSERT INTO `tepdinhkembaocao` VALUES (1,'anh_may_bom_song_rang.jpg','Ảnh hiện trạng máy bơm số 1',1),(2,'quy_trinh_van_hanh_tram.pdf','Quy trình vận hành trạm bơm an toàn',1),(3,'so_do_mat_cat_de.dwg','Bản vẽ mặt cắt ngang thân đê',2),(4,'bien_ban_nghiem_thu_ho.docx','Biên bản nghiệm thu sửa chữa lòng hồ',3);
/*!40000 ALTER TABLE `tepdinhkembaocao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `thongkedientich`
--

DROP TABLE IF EXISTS `thongkedientich`;
/*!50001 DROP VIEW IF EXISTS `thongkedientich`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `thongkedientich` AS SELECT 
 1 AS `TenDanhMuc`,
 1 AS `Vu`,
 1 AS `DienTichXa`,
 1 AS `TenXa`,
 1 AS `TenHuyen`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `tracuuquyhoach`
--

DROP TABLE IF EXISTS `tracuuquyhoach`;
/*!50001 DROP VIEW IF EXISTS `tracuuquyhoach`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `tracuuquyhoach` AS SELECT 
 1 AS `TenKy`,
 1 AS `NamBatDau`,
 1 AS `NamKetThuc`,
 1 AS `TenBanDo`,
 1 AS `TieuDe`,
 1 AS `TepDinhKem`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `trangthai`
--

DROP TABLE IF EXISTS `trangthai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trangthai` (
  `TrangThaiID` int NOT NULL AUTO_INCREMENT,
  `MucNuoc` double DEFAULT NULL,
  PRIMARY KEY (`TrangThaiID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trangthai`
--

LOCK TABLES `trangthai` WRITE;
/*!40000 ALTER TABLE `trangthai` DISABLE KEYS */;
INSERT INTO `trangthai` VALUES (1,0.8),(2,1.5),(3,2.5),(4,3.5);
/*!40000 ALTER TABLE `trangthai` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `xa`
--

DROP TABLE IF EXISTS `xa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `xa` (
  `XaID` int NOT NULL AUTO_INCREMENT,
  `Ten` varchar(100) NOT NULL,
  `HuyenID` int DEFAULT NULL,
  PRIMARY KEY (`XaID`),
  KEY `HuyenID` (`HuyenID`),
  CONSTRAINT `xa_ibfk_1` FOREIGN KEY (`HuyenID`) REFERENCES `huyen` (`HuyenID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `xa`
--

LOCK TABLES `xa` WRITE;
/*!40000 ALTER TABLE `xa` DISABLE KEYS */;
INSERT INTO `xa` VALUES (1,'Thanh Thủy',1),(2,'Phường Sao Đỏ',2),(3,'Cộng Hòa',2),(4,'Nam Chính',3);
/*!40000 ALTER TABLE `xa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'quanlythuyloi'
--

--
-- Final view structure for view `bao_cao_cong_trinh`
--

/*!50001 DROP VIEW IF EXISTS `bao_cao_cong_trinh`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `bao_cao_cong_trinh` AS select `bc`.`BaoCaoID` AS `BaoCaoID`,`ct`.`LoaiCongTrinh` AS `LoaiCongTrinh`,`bc`.`TieuDe` AS `TieuDe`,`bc`.`NgayTao` AS `NgayTao`,`tep`.`TepDinhKem` AS `TepDinhKem`,`tep`.`MoTa` AS `MoTaTep` from ((`baocaocongtrinh` `bc` join `congtrinhthuyloi` `ct` on((`bc`.`CongTrinhID` = `ct`.`CongTrinhID`))) left join `tepdinhkembaocao` `tep` on((`bc`.`BaoCaoID` = `tep`.`BaoCaoID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `congtrinh`
--

/*!50001 DROP VIEW IF EXISTS `congtrinh`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `congtrinh` AS select `ct`.`CongTrinhID` AS `CongTrinhID`,`ct`.`LoaiCongTrinh` AS `LoaiCongTrinh`,`ct`.`MoTa` AS `MoTa`,`cct`.`TenCap` AS `TenCap`,`h`.`Ten` AS `TenHuyen`,`x`.`Ten` AS `TenXa`,`ct`.`DiaDiem` AS `DiaDiem`,`tt`.`MucNuoc` AS `MucNuoc` from ((((`congtrinhthuyloi` `ct` left join `capcongtrinh` `cct` on((`ct`.`CapID` = `cct`.`CapID`))) left join `huyen` `h` on((`cct`.`HuyenID` = `h`.`HuyenID`))) left join `xa` `x` on((`cct`.`XaID` = `x`.`XaID`))) left join `trangthai` `tt` on((`ct`.`TrangThaiID` = `tt`.`TrangThaiID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `lich_su_thao_tac`
--

/*!50001 DROP VIEW IF EXISTS `lich_su_thao_tac`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `lich_su_thao_tac` AS select `lstt`.`ID` AS `ID`,`lstt`.`TaiKhoanID` AS `TaiKhoanID`,`hs`.`HoTen` AS `HoTen`,`lstt`.`GiaTriCu` AS `GiaTriCu`,`lstt`.`GiaTriMoi` AS `GiaTriMoi`,`lsdn`.`ThoiDiemDN` AS `ThoiGianThucHien` from (((`lichsuthaotac` `lstt` join `taikhoan` `tk` on((`lstt`.`TaiKhoanID` = `tk`.`TenDangNhap`))) join `hoso` `hs` on((`tk`.`HoSoID` = `hs`.`ID`))) join `lichsudangnhap` `lsdn` on((`lstt`.`LichSuID` = `lsdn`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `nguoidung`
--

/*!50001 DROP VIEW IF EXISTS `nguoidung`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nguoidung` AS select `tk`.`TenDangNhap` AS `TenDangNhap`,`hs`.`HoTen` AS `HoTen`,`hs`.`Email` AS `Email`,`hs`.`NgaySinh` AS `NgaySinh`,`dv`.`Ten` AS `TenDonVi`,`cpc`.`Ten` AS `CapHanhChinh`,`tk`.`TrangThai` AS `TrangThai` from (((`taikhoan` `tk` join `hoso` `hs` on((`tk`.`HoSoID` = `hs`.`ID`))) left join `donvi` `dv` on((`hs`.`DonViID` = `dv`.`ID`))) left join `caphanhchinh` `cpc` on((`dv`.`HanhChinhID` = `cpc`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `thongkedientich`
--

/*!50001 DROP VIEW IF EXISTS `thongkedientich`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `thongkedientich` AS select `dm`.`TenDanhMuc` AS `TenDanhMuc`,`tx`.`Vu` AS `Vu`,`tx`.`DienTich` AS `DienTichXa`,`x`.`Ten` AS `TenXa`,`h`.`Ten` AS `TenHuyen` from (((`dientichtuoitheoxa` `tx` join `danhmucdientichtuoi` `dm` on((`tx`.`DanhMucID` = `dm`.`DanhMucID`))) join `xa` `x` on((`tx`.`XaID` = `x`.`XaID`))) join `huyen` `h` on((`x`.`HuyenID` = `h`.`HuyenID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `tracuuquyhoach`
--

/*!50001 DROP VIEW IF EXISTS `tracuuquyhoach`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `tracuuquyhoach` AS select `ky`.`TenKy` AS `TenKy`,`ky`.`NamBatDau` AS `NamBatDau`,`ky`.`NamKetThuc` AS `NamKetThuc`,`bd`.`TenBanDo` AS `TenBanDo`,`bc`.`TieuDe` AS `TieuDe`,`bc`.`TepDinhKem` AS `TepDinhKem` from ((`kyquyhoach` `ky` left join `bandoquyhoach` `bd` on((`ky`.`KyID` = `bd`.`KyID`))) left join `baocaoquyhoach` `bc` on((`ky`.`KyID` = `bc`.`KyID`))) */;
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

-- Dump completed on 2026-01-19 19:57:23
