CREATE DATABASE  IF NOT EXISTS `placemybet` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `placemybet`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: placemybet
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `apuesta`
--

DROP TABLE IF EXISTS `apuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apuesta` (
  `usuario` varchar(50) NOT NULL,
  `mercado` varchar(10) NOT NULL,
  `tipoApuesta` char(5) NOT NULL,
  `dineroApostadoOver` float(10,2) DEFAULT '0.00',
  `dineroApostadoUnder` float(10,2) DEFAULT '0.00',
  `fecha` date NOT NULL,
  PRIMARY KEY (`usuario`,`mercado`),
  KEY `mercado` (`mercado`),
  CONSTRAINT `apuesta_ibfk_1` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`email`) ON UPDATE CASCADE,
  CONSTRAINT `apuesta_ibfk_2` FOREIGN KEY (`mercado`) REFERENCES `mercado` (`idMercado`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apuesta`
--

LOCK TABLES `apuesta` WRITE;
/*!40000 ALTER TABLE `apuesta` DISABLE KEYS */;
INSERT INTO `apuesta` VALUES ('fefa.marino@hotmail.com','VM_2.5','Over',75.00,0.00,'2021-05-20'),('fernandezleonardo@yahoo.com','BB_2.5','Under',0.00,40.00,'2021-06-03'),('fernandezleonardo@yahoo.com','ZAM_1.5','Under',0.00,100.00,'2021-04-15'),('player1951@gmail.com','VM_3.5','Under',0.00,60.00,'2021-05-19'),('player1951@gmail.com','ZAM_1.5','Over',90.00,0.00,'2021-04-27');
/*!40000 ALTER TABLE `apuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento` (
  `idEventos` char(5) NOT NULL,
  `equipoLocal` varchar(20) NOT NULL,
  `equipoVisitante` varchar(20) NOT NULL,
  `fecha` date NOT NULL,
  PRIMARY KEY (`idEventos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
INSERT INTO `evento` VALUES ('BB','Barcelona','Betis','2021-06-07'),('VM','Valencia','Real Madrid','2021-05-27'),('ZAM','Zaragoza','Atlético de Madrid','2021-06-24');
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mercado`
--

DROP TABLE IF EXISTS `mercado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mercado` (
  `idMercado` varchar(10) NOT NULL,
  `evento` char(5) NOT NULL,
  `overUnder` float NOT NULL,
  `cuotaUnder` float NOT NULL,
  `cuotaOver` float NOT NULL,
  PRIMARY KEY (`idMercado`),
  KEY `evento` (`evento`),
  CONSTRAINT `mercado_ibfk_1` FOREIGN KEY (`evento`) REFERENCES `evento` (`idEventos`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mercado`
--

LOCK TABLES `mercado` WRITE;
/*!40000 ALTER TABLE `mercado` DISABLE KEYS */;
INSERT INTO `mercado` VALUES ('BB_1.5','BB',1.5,1.27,2.54),('BB_2.5','BB',2.5,1.59,2.35),('BB_3.5','BB',3.5,2.13,1.84),('VM_1.5','VM',1.5,1.43,2.85),('VM_2.5','VM',2.5,1.9,1.3),('VM_3.5','VM',3.5,2.85,1.43),('ZAM_1.5','ZAM',1.5,2.65,1.32),('ZAM_2.5','ZAM',2.5,1.98,1.65),('ZAM_3.5','ZAM',3.5,1.05,1.87);
/*!40000 ALTER TABLE `mercado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `email` varchar(50) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellidos` varchar(45) NOT NULL,
  `edad` int DEFAULT NULL,
  `banco` varchar(45) DEFAULT NULL,
  `numTarjetaCredito` bigint DEFAULT NULL,
  `saldoActual` float(10,2) DEFAULT '0.00',
  PRIMARY KEY (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('fefa.marino@hotmail.com','Fernanda','Cunha Marino',35,'Sabadell',4516998055685460,350.00),('fernandezleonardo@yahoo.com','Leonardo','Fernandez Rodriguez',27,'Santander',9564859634151870,30.00),('player1951@gmail.com','Ricardo','Martínez Días',69,'Bankia',6482379153694820,127.32);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-22 11:13:39
