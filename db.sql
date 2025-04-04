-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: mysql
-- Thời gian đã tạo: Th4 04, 2025 lúc 03:41 PM
-- Phiên bản máy phục vụ: 8.1.0
-- Phiên bản PHP: 8.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `PersonalFinanceApp`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Budgets`
--

CREATE TABLE `Budgets` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `BudgetName` varchar(100) NOT NULL,
  `Amount` decimal(18,2) NOT NULL,
  `Currency` varchar(3) NOT NULL DEFAULT 'VND',
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastUpdatedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Đang đổ dữ liệu cho bảng `Budgets`
--

INSERT INTO `Budgets` (`Id`, `UserId`, `BudgetName`, `Amount`, `Currency`, `StartDate`, `EndDate`, `CreatedDate`, `LastUpdatedDate`) VALUES
(1, 4, 'Ngân sách mặc định', 0.00, 'VND', '2025-04-03 23:26:24', '2025-09-03 23:26:24', '2025-04-03 23:26:24', NULL),
(2, 5, 'Ngân sách mặc định', 0.00, 'VND', '2025-04-03 23:52:15', '2025-09-03 23:52:15', '2025-04-03 23:52:15', NULL);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `TransactionCategories`
--

CREATE TABLE `TransactionCategories` (
  `Id` int NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Description` text,
  `Type` varchar(20) NOT NULL,
  `IsDefault` tinyint(1) NOT NULL DEFAULT '0',
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Đang đổ dữ liệu cho bảng `TransactionCategories`
--

INSERT INTO `TransactionCategories` (`Id`, `Name`, `Description`, `Type`, `IsDefault`, `CreatedDate`) VALUES
(5, 'test', 'test', 'INCOME', 0, '2025-04-04 22:31:15'),
(6, 'gagaga', '123', 'EXPENSE', 0, '2025-04-04 22:31:24');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Transactions`
--

CREATE TABLE `Transactions` (
  `Id` int NOT NULL,
  `Amount` decimal(18,2) NOT NULL,
  `CategoryId` int NOT NULL,
  `BudgetId` int NOT NULL,
  `TransactionDate` datetime NOT NULL,
  `Description` text,
  `UserId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Đang đổ dữ liệu cho bảng `Transactions`
--

INSERT INTO `Transactions` (`Id`, `Amount`, `CategoryId`, `BudgetId`, `TransactionDate`, `Description`, `UserId`) VALUES
(1, 9999000.00, 5, 1, '2025-04-04 22:40:56', '123', 4);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `UserRole` varchar(20) NOT NULL DEFAULT 'USER',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Đang đổ dữ liệu cho bảng `Users`
--

INSERT INTO `Users` (`Id`, `UserName`, `PasswordHash`, `FullName`, `Email`, `UserRole`, `CreatedAt`) VALUES
(4, '1', '$2a$11$D31IMLclHkpg..pCtOoJ2.3dKMQ9ameUR8GDI6InOCY9QvrHolXwO', 'tuan', 'deptraivc@gmail.com', 'USER', '2025-04-03 16:26:10'),
(5, '2', '$2a$11$nC98UcB3PFsYlGcoKzRr.uCkO0A1dISs70tNYQAoYM.yX.idvGAAW', '2', '2@22', 'ADMIN', '2025-04-03 16:52:15');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `Budgets`
--
ALTER TABLE `Budgets`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- Chỉ mục cho bảng `TransactionCategories`
--
ALTER TABLE `TransactionCategories`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `Transactions`
--
ALTER TABLE `Transactions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CategoryId` (`CategoryId`),
  ADD KEY `BudgetId` (`BudgetId`),
  ADD KEY `UserId` (`UserId`);

--
-- Chỉ mục cho bảng `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserName` (`UserName`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `Budgets`
--
ALTER TABLE `Budgets`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `TransactionCategories`
--
ALTER TABLE `TransactionCategories`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `Transactions`
--
ALTER TABLE `Transactions`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `Budgets`
--
ALTER TABLE `Budgets`
  ADD CONSTRAINT `Budgets_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `Transactions`
--
ALTER TABLE `Transactions`
  ADD CONSTRAINT `Transactions_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `TransactionCategories` (`Id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `Transactions_ibfk_2` FOREIGN KEY (`BudgetId`) REFERENCES `Budgets` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `Transactions_ibfk_3` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
