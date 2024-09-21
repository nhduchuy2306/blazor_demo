-- Drop database if it exists
DROP DATABASE IF EXISTS managementdb;

-- Drop existing tables if they exist
DROP TABLE IF EXISTS InvoiceDetails;
DROP TABLE IF EXISTS SalesInvoices;
DROP TABLE IF EXISTS WarehouseProducts;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS Warehouses;
DROP TABLE IF EXISTS Products;

-- Create database
CREATE DATABASE managementdb;

-- Create table for Roles
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

-- Create table for Customers with Password field
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerCode NVARCHAR(50) NOT NULL unique,
    CustomerName NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(255),
    Address NVARCHAR(255),
    Password NVARCHAR(255) NOT NULL,  -- Assuming hashed passwords
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

-- Create table for Products
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductCode NVARCHAR(50) NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL
);

-- Create table for Warehouses
CREATE TABLE Warehouses (
    WarehouseId INT PRIMARY KEY IDENTITY(1,1),
    WarehouseCode NVARCHAR(50) NOT NULL,
    WarehouseName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255)
);

-- Create junction table for Warehouses and Products to represent N-N relationship
CREATE TABLE WarehouseProducts (
    WarehouseId INT NOT NULL,
    ProductId INT NOT NULL,
    StockQuantity INT NOT NULL,  -- Quantity of the product in this warehouse
    PRIMARY KEY (WarehouseId, ProductId),
    FOREIGN KEY (WarehouseId) REFERENCES Warehouses(WarehouseId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Create table for SalesInvoices
CREATE TABLE SalesInvoices (
    InvoiceId INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNumber NVARCHAR(50) NOT NULL,
    InvoiceDate DATE NOT NULL,
    CustomerId INT NOT NULL,
    TotalAmount DECIMAL(18,2),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- Create table for InvoiceDetails
CREATE TABLE InvoiceDetails (
    InvoiceDetailId INT PRIMARY KEY IDENTITY(1,1),
    InvoiceId INT NOT NULL,
    WarehouseId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (InvoiceId) REFERENCES SalesInvoices(InvoiceId),
    FOREIGN KEY (WarehouseId, ProductId) REFERENCES WarehouseProducts(WarehouseId, ProductId)
);

-- Insert data into Roles
INSERT INTO Roles (RoleName)
VALUES 
('Customer'),
('ShopEmployee'),
('Admin');

-- Insert data into Customers with RoleId and Password
INSERT INTO Customers (CustomerCode, CustomerName, ContactInfo, Address, Password, RoleId)
VALUES 
('C001', 'John Doe', 'john.doe@example.com', '123 Main St, New York', 'hashed_password_1', 1),  -- Customer Role
('C002', 'Jane Smith', 'jane.smith@example.com', '456 Elm St, Los Angeles', 'hashed_password_2', 1),  -- Customer Role
('C003', 'Bob Johnson', 'bob.johnson@example.com', '789 Oak St, Chicago', 'hashed_password_3', 1),  -- Customer Role
('C004', 'Alice Brown', 'alice.brown@example.com', '321 Pine St, Miami', 'hashed_password_4', 1),  -- Customer Role
('C005', 'Charlie Green', 'charlie.green@example.com', '654 Cedar St, Chicago', 'hashed_password_5', 1),  -- Customer Role
('C006', 'David White', 'david.white@example.com', '987 Maple St, Los Angeles', 'hashed_password_6', 1),  -- Customer Role
('SHOP01', 'Shop 1', 'shop@example.com', 'shop address', 'AQAAAAEAACcQAAAAEKi8ocaDPoq47q7XUvUw6i5S+0Zpga7WBuaIsuRvI5HnXDYTgH1sc9hDAliaZhhs2Q==', 2), -- Shop Employee Role
('SHOP02', 'Shop 2', 'shop2@example.com', 'shop2 address', 'AQAAAAEAACcQAAAAEKi8ocaDPoq47q7XUvUw6i5S+0Zpga7WBuaIsuRvI5HnXDYTgH1sc9hDAliaZhhs2Q==', 2), -- Shop Employee Role
('ADMIN01', 'Admin 1', 'admin@example.com', 'admin address', 'AQAAAAEAACcQAAAAEKi8ocaDPoq47q7XUvUw6i5S+0Zpga7WBuaIsuRvI5HnXDYTgH1sc9hDAliaZhhs2Q==', 3); -- Admin Role

-- Insert data into Products
INSERT INTO Products (ProductCode, ProductName, UnitPrice)
VALUES 
('P001', 'Laptop', 1200.00),
('P002', 'Smartphone', 800.00),
('P003', 'Tablet', 500.00),
('P004', 'Monitor', 300.00),
('P005', 'Keyboard', 50.00),
('P006', 'Mouse', 25.00),
('P007', 'Headphones', 100.00),
('P008', 'Webcam', 150.00),
('P009', 'External Hard Drive', 200.00),
('P010', 'USB Cable', 10.00);

-- Insert data into Warehouses
INSERT INTO Warehouses (WarehouseCode, WarehouseName, Location)
VALUES 
('W001', 'Main Warehouse', 'New York'),
('W002', 'Secondary Warehouse', 'Los Angeles'),
('W003', 'North Warehouse', 'Chicago'),
('W004', 'East Warehouse', 'Miami');

-- Insert data into WarehouseProducts (Product availability in each warehouse)
INSERT INTO WarehouseProducts (WarehouseId, ProductId, StockQuantity)
VALUES 
-- Main Warehouse
(1, 1, 50),   -- Laptop
(1, 2, 100),  -- Smartphone
(1, 3, 70),   -- Tablet
(1, 6, 200),  -- Mouse
(1, 7, 50),   -- Headphones

-- Secondary Warehouse
(2, 1, 30),   -- Laptop
(2, 4, 150),  -- Monitor
(2, 5, 200),  -- Keyboard
(2, 3, 40),   -- Tablet
(2, 6, 120),  -- Mouse
(2, 9, 80),   -- External Hard Drive

-- North Warehouse
(3, 2, 70),   -- Smartphone
(3, 4, 60),   -- Monitor
(3, 8, 90),   -- Webcam
(3, 10, 500), -- USB Cable

-- East Warehouse
(4, 5, 150),  -- Keyboard
(4, 7, 100),  -- Headphones
(4, 9, 50);   -- External Hard Drive

-- Insert data into SalesInvoices
INSERT INTO SalesInvoices (InvoiceNumber, InvoiceDate, CustomerId, TotalAmount)
VALUES 
('INV001', '2024-09-01', 1, 2600.00),    -- John Doe's invoice
('INV002', '2024-09-02', 2, 1100.00),    -- Jane Smith's invoice
('INV003', '2024-09-03', 3, 950.00),     -- Bob Johnson's invoice
('INV004', '2024-09-04', 4, 1225.00),    -- Alice Brown's invoice
('INV005', '2024-09-05', 5, 450.00),     -- Charlie Green's invoice
('INV006', '2024-09-06', 6, 1780.00);    -- David White's invoice

-- InvoiceDetails with Total column
INSERT INTO InvoiceDetails (InvoiceId, WarehouseId, ProductId, Quantity, UnitPrice, Total)
VALUES 
-- Invoice 1: John Doe buys 2 laptops and 1 smartphone from Main Warehouse
(1, 1, 1, 2, 1200.00, 2400.00),   -- 2 Laptops from Main Warehouse
(1, 1, 2, 1, 800.00, 800.00),     -- 1 Smartphone from Main Warehouse

-- Invoice 2: Jane Smith buys 1 monitor and 2 keyboards from Secondary Warehouse
(2, 2, 4, 1, 300.00, 300.00),     -- 1 Monitor from Secondary Warehouse
(2, 2, 5, 2, 50.00, 100.00),      -- 2 Keyboards from Secondary Warehouse

-- Invoice 3: Bob Johnson buys 1 Laptop from Main Warehouse and 1 External Hard Drive from Secondary Warehouse
(3, 1, 1, 1, 1200.00, 1200.00),   -- 1 Laptop from Main Warehouse
(3, 2, 9, 1, 200.00, 200.00),     -- 1 External Hard Drive from Secondary Warehouse

-- Invoice 4: Alice Brown buys 2 Headphones and 1 Monitor from East Warehouse
(4, 4, 7, 2, 100.00, 200.00),     -- 2 Headphones from East Warehouse
(4, 4, 5, 1, 300.00, 300.00),     -- 1 Monitor from East Warehouse

-- Invoice 5: Charlie Green buys 3 USB Cables from North Warehouse
(5, 3, 10, 3, 10.00, 30.00),      -- 3 USB Cables from North Warehouse

-- Invoice 6: David White buys 2 Tablets and 1 Webcam from North Warehouse
(6, 3, 2, 2, 500.00, 1000.00),    -- 2 Tablets from North Warehouse
(6, 3, 8, 1, 150.00, 150.00);     -- 1 Webcam from North Warehouse