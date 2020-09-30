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
-- Table structure for table `apuestas`
--

DROP TABLE IF EXISTS `apuestas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apuestas` (
  `usuario` varchar(50) NOT NULL,
  `mercado` varchar(10) NOT NULL,
  `tipoApuesta` char(5) NOT NULL,
  `dineroApostadoOver` float(10,2) DEFAULT '0.00',
  `dineroApostadoUnder` float(10,2) DEFAULT '0.00',
  `fecha` date NOT NULL,
  PRIMARY KEY (`usuario`,`mercado`),
  KEY `mercado` (`mercado`),
  CONSTRAINT `apuestas_ibfk_1` FOREIGN KEY (`usuario`) REFERENCES `usuarios` (`email`) ON UPDATE CASCADE,
  CONSTRAINT `apuestas_ibfk_2` FOREIGN KEY (`mercado`) REFERENCES `mercados` (`idMercado`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apuestas`
--

LOCK TABLES `apuestas` WRITE;
/*!40000 ALTER TABLE `apuestas` DISABLE KEYS */;
INSERT INTO `apuestas` VALUES ('fefa.marino@hotmail.com','VM_2.5','Over',75.00,0.00,'2021-05-20'),('fernandezleonardo@yahoo.com','BB_2.5','Under',0.00,40.00,'2021-06-03'),('fernandezleonardo@yahoo.com','ZAM_1.5','Under',0.00,100.00,'2021-04-15'),('player1951@gmail.com','VM_3.5','Under',0.00,60.00,'2021-05-19'),('player1951@gmail.com','ZAM_1.5','Over',90.00,0.00,'2021-04-27');
/*!40000 ALTER TABLE `apuestas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-30  3:14:59
