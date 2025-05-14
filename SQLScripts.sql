-- ============================================
-- Database Setup Script: AgriEnergyConnect
-- Entities: UserRole, User, MarketplaceItem
-- ============================================

-- ================================
-- DROP TABLES IF THEY EXIST (Safe Reset)
-- ================================
IF OBJECT_ID('dbo.MarketplaceItem', 'U') IS NOT NULL DROP TABLE dbo.MarketplaceItem;
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL DROP TABLE dbo.[User];
IF OBJECT_ID('dbo.UserRole', 'U') IS NOT NULL DROP TABLE dbo.UserRole;

-- ================================
-- 1. Create UserRole Table
-- ================================
CREATE TABLE UserRole (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL,
    CanAddProducts BIT NULL,
    CanAddFarmerProfiles BIT NULL,
    CanViewAndFilterProducts BIT NULL
);

-- ================================
-- 2. Create User Table
-- ================================
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    RoleId INT NULL,
    FOREIGN KEY (RoleId) REFERENCES UserRole(RoleId)
);

-- ================================
-- 3. Create MarketplaceItem Table
-- ================================
CREATE TABLE MarketplaceItem (
    ItemId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Type NVARCHAR(50) NULL,
    ProviderId INT NULL,
    Price DECIMAL(18,2) NULL,
    FOREIGN KEY (ProviderId) REFERENCES [User](UserId)
);

-- ================================
-- 4. Insert Sample User Roles
-- ================================
INSERT INTO UserRole (RoleName, CanAddProducts, CanAddFarmerProfiles, CanViewAndFilterProducts)
VALUES 
('Admin', 1, 1, 1),
('Vendor', 1, 0, 1),
('Farmer', 0, 1, 1),
('Viewer', 0, 0, 1);

-- ================================
-- 5. Insert Sample Users
-- ================================
INSERT INTO [User] (Name, Email, Password, RoleId)
VALUES 
('Alice Farmer', 'alice@example.com', 'hashedpassword1', 3), -- Farmer role
('Bob Vendor', 'bob@example.com', 'hashedpassword2', 2);      -- Vendor role

-- ================================
-- 6. Insert Sample Marketplace Items
-- ================================
INSERT INTO MarketplaceItem (Name, Description, Type, ProviderId, Price)
VALUES 
('Solar Water Pump', 'Efficient water pump for irrigation', 'Equipment', 2, 499.99),
('Organic Compost', 'High quality natural compost', 'Supply', 2, 89.50);

-- ================================
-- 7. Verify Data
-- ================================
SELECT * FROM UserRole;
SELECT * FROM [User];
SELECT * FROM MarketplaceItem;
