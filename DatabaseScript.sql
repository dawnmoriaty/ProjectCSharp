-- Script tạo cơ sở dữ liệu Quản lý Chi tiêu Cá nhân
USE master
GO

-- Tạo database mới
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ExpenseManager')
BEGIN
    CREATE DATABASE ExpenseManager
END
GO

USE ExpenseManager
GO

-- Tạo bảng Users
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserName NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255) NOT NULL,
        Email NVARCHAR(100) UNIQUE,
        FullName NVARCHAR(100),
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        UserRole NVARCHAR(20) NOT NULL DEFAULT 'USER',
        Status NVARCHAR(20) NOT NULL DEFAULT 'ACTIVE'
    )
END
GO

-- Tạo bảng TransactionCategories
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TransactionCategories')
BEGIN
    CREATE TABLE TransactionCategories (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(50) NOT NULL,
        Description NVARCHAR(255),
        Type NVARCHAR(20) NOT NULL,  -- INCOME hoặc EXPENSE
        IsDefault BIT NOT NULL DEFAULT 0,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
    )
END
GO

-- Tạo bảng Budgets
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Budgets')
BEGIN
    CREATE TABLE Budgets (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        BudgetName NVARCHAR(100) NOT NULL,
        Amount DECIMAL(18, 2) NOT NULL,
        Currency NVARCHAR(10) NOT NULL DEFAULT 'VND',
        StartDate DATETIME NOT NULL,
        EndDate DATETIME NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        LastUpdatedDate DATETIME,
        CONSTRAINT FK_Budgets_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
    )
END
GO

-- Tạo bảng Transactions
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Transactions')
BEGIN
    CREATE TABLE Transactions (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        BudgetId INT NOT NULL,
        UserId INT NOT NULL,
        CategoryId INT NOT NULL,
        Amount DECIMAL(18, 2) NOT NULL,
        Type NVARCHAR(20) NOT NULL,  -- INCOME hoặc EXPENSE
        Description NVARCHAR(255),
        TransactionDate DATETIME NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        Status NVARCHAR(20) NOT NULL DEFAULT 'COMPLETED',
        Location NVARCHAR(255),
        Attachment NVARCHAR(255),
        CONSTRAINT FK_Transactions_Budgets FOREIGN KEY (BudgetId) REFERENCES Budgets(Id),
        CONSTRAINT FK_Transactions_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
        CONSTRAINT FK_Transactions_Categories FOREIGN KEY (CategoryId) REFERENCES TransactionCategories(Id)
    )
END
GO

-- Tạo các danh mục mặc định
IF NOT EXISTS (SELECT * FROM TransactionCategories WHERE IsDefault = 1)
BEGIN
    -- Danh mục thu nhập
    INSERT INTO TransactionCategories (Name, Description, Type, IsDefault, CreatedDate)
    VALUES 
    ('Lương', N'Lương cơ bản và phụ cấp', 'INCOME', 1, GETDATE()),
    ('Thưởng', N'Thưởng dự án, thưởng thành tích', 'INCOME', 1, GETDATE()),
    ('Đầu tư', N'Thu nhập từ đầu tư, cổ phiếu, tiết kiệm', 'INCOME', 1, GETDATE()),
    ('Quà tặng', N'Tiền hoặc quà được tặng', 'INCOME', 1, GETDATE()),
    ('Thu nhập khác', N'Các khoản thu nhập khác', 'INCOME', 1, GETDATE());

    -- Danh mục chi tiêu
    INSERT INTO TransactionCategories (Name, Description, Type, IsDefault, CreatedDate)
    VALUES
    ('Ăn uống', N'Chi phí ăn uống hàng ngày', 'EXPENSE', 1, GETDATE()),
    ('Di chuyển', N'Chi phí xăng xe, taxi, xe buýt', 'EXPENSE', 1, GETDATE()),
    ('Nhà ở', N'Tiền thuê nhà, điện, nước, internet', 'EXPENSE', 1, GETDATE()),
    ('Mua sắm', N'Quần áo, đồ dùng cá nhân', 'EXPENSE', 1, GETDATE()),
    ('Giải trí', N'Xem phim, du lịch, thể thao', 'EXPENSE', 1, GETDATE()),
    ('Y tế', N'Khám bệnh, thuốc men', 'EXPENSE', 1, GETDATE()),
    ('Giáo dục', N'Học phí, sách vở, khóa học', 'EXPENSE', 1, GETDATE()),
    ('Chi tiêu khác', N'Các khoản chi tiêu khác', 'EXPENSE', 1, GETDATE());
END
GO

-- Tạo các chỉ mục để tối ưu hiệu suất truy vấn
-- Chỉ mục cho Transactions
CREATE INDEX IX_Transactions_BudgetId ON Transactions(BudgetId);
CREATE INDEX IX_Transactions_UserId ON Transactions(UserId);
CREATE INDEX IX_Transactions_CategoryId ON Transactions(CategoryId);
CREATE INDEX IX_Transactions_TransactionDate ON Transactions(TransactionDate);

-- Chỉ mục cho Budgets
CREATE INDEX IX_Budgets_UserId ON Budgets(UserId);
CREATE INDEX IX_Budgets_DateRange ON Budgets(StartDate, EndDate);

-- Tạo PROCEDURE để tính toán tổng thu chi theo tháng
CREATE OR ALTER PROCEDURE GetMonthlySummary
    @UserId INT,
    @Year INT,
    @Month INT
AS
BEGIN
    SELECT
        c.Type,
        c.Name AS CategoryName,
        SUM(t.Amount) AS TotalAmount
    FROM
        Transactions t
    INNER JOIN
        TransactionCategories c ON t.CategoryId = c.Id
    WHERE
        t.UserId = @UserId
        AND YEAR(t.TransactionDate) = @Year
        AND MONTH(t.TransactionDate) = @Month
    GROUP BY
        c.Type, c.Name
    ORDER BY
        c.Type, SUM(t.Amount) DESC
END
GO

-- Tạo PROCEDURE để tính toán chi tiêu theo danh mục và khoảng thời gian
CREATE OR ALTER PROCEDURE GetCategorySummary
    @UserId INT,
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    SELECT
        c.Id AS CategoryId,
        c.Name AS CategoryName,
        c.Type,
        SUM(t.Amount) AS TotalAmount,
        COUNT(t.Id) AS TransactionCount
    FROM
        Transactions t
    INNER JOIN
        TransactionCategories c ON t.CategoryId = c.Id
    WHERE
        t.UserId = @UserId
        AND t.TransactionDate BETWEEN @StartDate AND @EndDate
    GROUP BY
        c.Id, c.Name, c.Type
    ORDER BY
        c.Type, SUM(t.Amount) DESC
END
GO

-- Tạo PROCEDURE để tính toán số dư ngân sách
CREATE OR ALTER PROCEDURE GetBudgetBalance
    @BudgetId INT
AS
BEGIN
    DECLARE @TotalIncome DECIMAL(18, 2)
    DECLARE @TotalExpense DECIMAL(18, 2)
    DECLARE @InitialAmount DECIMAL(18, 2)
    
    -- Lấy số tiền ban đầu của ngân sách
    SELECT @InitialAmount = Amount FROM Budgets WHERE Id = @BudgetId
    
    -- Tính tổng thu nhập
    SELECT @TotalIncome = ISNULL(SUM(Amount), 0)
    FROM Transactions
    WHERE BudgetId = @BudgetId AND Type = 'INCOME'
    
    -- Tính tổng chi tiêu
    SELECT @TotalExpense = ISNULL(SUM(Amount), 0)
    FROM Transactions
    WHERE BudgetId = @BudgetId AND Type = 'EXPENSE'
    
    -- Trả về kết quả
    SELECT
        @InitialAmount AS InitialAmount,
        @TotalIncome AS TotalIncome,
        @TotalExpense AS TotalExpense,
        (@InitialAmount + @TotalIncome - @TotalExpense) AS CurrentBalance
END
GO

-- Tạo view để xem lịch sử giao dịch chi tiết
CREATE OR ALTER VIEW TransactionHistory AS
SELECT
    t.Id,
    t.TransactionDate,
    t.Amount,
    t.Type,
    t.Description,
    t.Status,
    t.Location,
    u.UserName,
    u.FullName AS UserFullName,
    c.Name AS CategoryName,
    c.Type AS CategoryType,
    b.BudgetName
FROM
    Transactions t
INNER JOIN
    Users u ON t.UserId = u.Id
INNER JOIN
    TransactionCategories c ON t.CategoryId = c.Id
INNER JOIN
    Budgets b ON t.BudgetId = b.Id
GO

PRINT N'Đã tạo xong cơ sở dữ liệu Quản lý Chi tiêu Cá nhân!' 