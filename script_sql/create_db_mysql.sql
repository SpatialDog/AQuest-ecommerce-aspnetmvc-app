CREATE TABLE `coupons` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `MinPrice` decimal(18,2) NOT NULL DEFAULT '0.00',
  `MaxPrice` decimal(18,2) DEFAULT NULL,
  `AssociatedProductIds` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_UniqueCode` (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `products` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Name` text COLLATE utf8mb4_unicode_ci,
  `Price` decimal(18,2) NOT NULL,
  `StockQty` int NOT NULL DEFAULT '0',
  `Active` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;