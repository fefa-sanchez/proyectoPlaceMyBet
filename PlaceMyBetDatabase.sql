-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: placemybet
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `placemybet`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `placemybet` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `placemybet`;

--
-- Table structure for table `apuestas`
--

DROP TABLE IF EXISTS `apuestas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apuestas` (
  `idApuesta` int NOT NULL AUTO_INCREMENT,
  `idUsuario` varchar(50) NOT NULL,
  `idMercado` varchar(10) NOT NULL,
  `tipoApuesta` char(5) NOT NULL,
  `dineroApostado` decimal(10,2) NOT NULL,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`idApuesta`),
  KEY `mercados_idMercado_idx` (`idMercado`),
  KEY `fk_usuarios_idUsuario_idx` (`idUsuario`),
  CONSTRAINT `fk_mercados_idMercado` FOREIGN KEY (`idMercado`) REFERENCES `mercados` (`idMercado`),
  CONSTRAINT `fk_usuarios_idUsuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuarios` (`idEmail`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apuestas`
--

LOCK TABLES `apuestas` WRITE;
/*!40000 ALTER TABLE `apuestas` DISABLE KEYS */;
INSERT INTO `apuestas` VALUES (1,'fefa.marino@hotmail.com','VM_1.5','Under',40.00,'2021-05-27'),(2,'fefa.marino@hotmail.com','VM_2.5','Over',92.00,'2021-05-20'),(3,'fefa.marino@hotmail.com','VM_3.5','Under',27.00,'2021-05-27'),(4,'fernandezleonardo@yahoo.com','BB_2.5','Under',40.00,'2021-06-03'),(5,'fernandezleonardo@yahoo.com','VM_1.5','Over',15.00,'2021-06-07'),(6,'fernandezleonardo@yahoo.com','VM_3.5','Over',50.00,'2021-06-04'),(7,'fernandezleonardo@yahoo.com','ZAM_1.5','Under',100.00,'2021-04-15'),(8,'player1951@gmail.com','VM_3.5','Under',60.00,'2021-05-19'),(9,'player1951@gmail.com','ZAM_1.5','Over',80.00,'2021-04-27');
/*!40000 ALTER TABLE `apuestas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventos`
--

DROP TABLE IF EXISTS `eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventos` (
  `idEventos` char(5) NOT NULL,
  `equipoLocal` varchar(20) NOT NULL,
  `equipoVisitante` varchar(20) NOT NULL,
  `fecha` date NOT NULL,
  PRIMARY KEY (`idEventos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventos`
--

LOCK TABLES `eventos` WRITE;
/*!40000 ALTER TABLE `eventos` DISABLE KEYS */;
INSERT INTO `eventos` VALUES ('BB','Barcelona','Betis','2021-06-07'),('SV','Sevilla','Villareal','2021-07-25'),('SV2','Sevilla','Villareal','2021-07-25'),('SVI','Sevilla','Villareal','2021-07-25'),('VM','Valencia','Real Madrid','2021-05-27'),('ZAM','Zaragoza','Atlético de Madrid','2021-06-24');
/*!40000 ALTER TABLE `eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mercados`
--

DROP TABLE IF EXISTS `mercados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mercados` (
  `idMercado` varchar(10) NOT NULL,
  `idEvento` char(5) NOT NULL,
  `tipoMercado` double DEFAULT NULL,
  `cuotaUnder` decimal(10,2) NOT NULL,
  `cuotaOver` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idMercado`),
  KEY `evento` (`idEvento`),
  CONSTRAINT `mercados_ibfk_1` FOREIGN KEY (`idEvento`) REFERENCES `eventos` (`idEventos`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mercados`
--

LOCK TABLES `mercados` WRITE;
/*!40000 ALTER TABLE `mercados` DISABLE KEYS */;
INSERT INTO `mercados` VALUES ('BB_1.5','BB',1.5,1.27,2.54),('BB_2.5','BB',2.5,1.59,2.35),('BB_3.5','BB',3.5,2.13,1.84),('SV_3.5','SV',3.5,2.25,1.75),('VM_1.5','VM',1.5,1.31,3.48),('VM_2.5','VM',2.5,1.90,1.30),('VM_3.5','VM',3.5,1.50,2.60),('ZAM_1.5','ZAM',1.5,2.65,1.32),('ZAM_2.5','ZAM',2.5,1.98,1.65),('ZAM_3.5','ZAM',3.5,1.05,1.87);
/*!40000 ALTER TABLE `mercados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idEmail` varchar(50) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `edad` int DEFAULT NULL,
  `banco` varchar(45) DEFAULT NULL,
  `numTarjetaCredito` bigint DEFAULT NULL,
  `saldoActual` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('alexlo@gmail.com','Alejandro','López',21,'Bankia',9726463481280467,25.40),('deb_lok@hotmail.com','Débora','Pacheco Almeida',63,'Sabadell',851045054571207,170.86),('fefa.marino@hotmail.com','Fernanda','Cunha Marino',35,'Sabadell',4516998055685460,350.00),('fernandezleonardo@yahoo.com','Leonardo','Fernandez Rodriguez',27,'Santander',9564859634151870,30.00),('franciscomendezr@gmail.com','Francisco','Mendéz Rivera',54,'KutxabanK',1563545132008499,978.27),('player1951@gmail.com','Ricardo','Martínez Días',69,'Bankia',6482379153694820,127.32),('rickyrocky@gmail.com','Ricardo','Casans Smith',23,'LaCaixa',9951843013052468,53.00),('virginiacerezuela@gmail.com','Virginia','Cerezuela Martínez',34,'LaCaixa',4301809760649008,27.54);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-10-26 11:27:26
