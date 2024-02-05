-- --------------------------------------------------------
-- 호스트:                          aas-database.cjhnbi27czq0.ap-northeast-2.rds.amazonaws.com
-- 서버 버전:                        8.0.33 - Source distribution
-- 서버 OS:                        Linux
-- HeidiSQL 버전:                  12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- aas_db_test 데이터베이스 구조 내보내기
CREATE DATABASE IF NOT EXISTS `aas_db_test` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `aas_db_test`;

-- 테이블 aas_db_test.asset_administration_shell 구조 내보내기
CREATE TABLE IF NOT EXISTS `asset_administration_shell` (
  `category` varchar(5000) DEFAULT NULL,
  `id_short` varchar(5000) DEFAULT NULL,
  `aas_id` varchar(200) NOT NULL,
  `time_stamp_create` datetime DEFAULT NULL,
  `time_stamp` datetime DEFAULT NULL,
  `time_stamp_tree` datetime DEFAULT NULL,
  PRIMARY KEY (`aas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.asset_information 구조 내보내기
CREATE TABLE IF NOT EXISTS `asset_information` (
  `asset_kind` varchar(5000) DEFAULT NULL,
  `global_asset_id` varchar(5000) DEFAULT NULL,
  `asset_type` varchar(5000) DEFAULT NULL,
  `aas_id` varchar(200) NOT NULL,
  PRIMARY KEY (`aas_id`),
  KEY `fk_assetinformation_assetadministrationshell1_idx` (`aas_id`),
  CONSTRAINT `fk_assetinformation_assetadministrationshell1` FOREIGN KEY (`aas_id`) REFERENCES `asset_administration_shell` (`aas_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.property 구조 내보내기
CREATE TABLE IF NOT EXISTS `property` (
  `id` int NOT NULL AUTO_INCREMENT,
  `submodel_id` varchar(255) DEFAULT NULL,
  `id_short_path` varchar(255) DEFAULT NULL,
  `category` varchar(500) DEFAULT NULL,
  `id_short` varchar(255) DEFAULT NULL,
  `value_type` varchar(255) DEFAULT NULL,
  `value` varchar(255) DEFAULT NULL,
  `model_type` varchar(255) DEFAULT NULL,
  `timestamp` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.property_log 구조 내보내기
CREATE TABLE IF NOT EXISTS `property_log` (
  `id` int NOT NULL AUTO_INCREMENT,
  `submodel_id` varchar(255) DEFAULT NULL,
  `id_short_path` varchar(255) DEFAULT NULL,
  `category` varchar(500) DEFAULT NULL,
  `id_short` varchar(255) DEFAULT NULL,
  `value_type` varchar(255) DEFAULT NULL,
  `value` varchar(255) DEFAULT NULL,
  `model_type` varchar(255) DEFAULT NULL,
  `timestamp` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.reference 구조 내보내기
CREATE TABLE IF NOT EXISTS `reference` (
  `type` varchar(5000) DEFAULT NULL,
  `id` int NOT NULL,
  `aas_id` varchar(200) NOT NULL,
  PRIMARY KEY (`aas_id`,`id`),
  KEY `fk_reference_aas_idx` (`aas_id`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk_reference_aas` FOREIGN KEY (`aas_id`) REFERENCES `asset_administration_shell` (`aas_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.reference_key 구조 내보내기
CREATE TABLE IF NOT EXISTS `reference_key` (
  `type` varchar(5000) DEFAULT NULL,
  `value` varchar(5000) DEFAULT NULL,
  `id` int NOT NULL,
  `reference_aas_id` varchar(200) NOT NULL,
  `reference_id` int NOT NULL,
  PRIMARY KEY (`id`,`reference_aas_id`,`reference_id`),
  KEY `fk_reference_key_reference1_idx` (`reference_aas_id`,`reference_id`),
  CONSTRAINT `fk_reference_key_reference1` FOREIGN KEY (`reference_aas_id`, `reference_id`) REFERENCES `reference` (`aas_id`, `id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.resource 구조 내보내기
CREATE TABLE IF NOT EXISTS `resource` (
  `path` varchar(5000) DEFAULT NULL,
  `contentType` varchar(5000) DEFAULT NULL,
  `aas_id` varchar(200) NOT NULL,
  PRIMARY KEY (`aas_id`),
  CONSTRAINT `fk_resource_assetinformation1` FOREIGN KEY (`aas_id`) REFERENCES `asset_information` (`aas_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.semantic_id 구조 내보내기
CREATE TABLE IF NOT EXISTS `semantic_id` (
  `property_id` int NOT NULL,
  `type` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`property_id`),
  CONSTRAINT `fk_semantic_id_property1` FOREIGN KEY (`property_id`) REFERENCES `property` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.sementic_id_key 구조 내보내기
CREATE TABLE IF NOT EXISTS `sementic_id_key` (
  `semantic_id_property_id` int NOT NULL,
  `type` varchar(255) DEFAULT NULL,
  `value` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`semantic_id_property_id`),
  CONSTRAINT `fk_sementic_id_key_semantic_id1` FOREIGN KEY (`semantic_id_property_id`) REFERENCES `semantic_id` (`property_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.submodel 구조 내보내기
CREATE TABLE IF NOT EXISTS `submodel` (
  `submodel_id_short` varchar(5000) DEFAULT NULL,
  `submodel_id` varchar(200) NOT NULL,
  `time_stamp_create` datetime DEFAULT NULL,
  `time_stamp` datetime DEFAULT NULL,
  `time_stamp_tree` datetime DEFAULT NULL,
  PRIMARY KEY (`submodel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 aas_db_test.submodel_element 구조 내보내기
CREATE TABLE IF NOT EXISTS `submodel_element` (
  `category` varchar(5000) DEFAULT NULL,
  `id_short` varchar(500) DEFAULT NULL,
  `value_type` varchar(100) DEFAULT NULL,
  `value` float DEFAULT NULL,
  `model_type` varchar(5000) DEFAULT NULL,
  `id` int NOT NULL,
  `submodel_submodel_id` varchar(200) NOT NULL,
  PRIMARY KEY (`id`,`submodel_submodel_id`),
  KEY `fk_submodel_element_submodel1_idx` (`submodel_submodel_id`),
  CONSTRAINT `fk_submodel_element_submodel1` FOREIGN KEY (`submodel_submodel_id`) REFERENCES `submodel` (`submodel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 내보낼 데이터가 선택되어 있지 않습니다.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
