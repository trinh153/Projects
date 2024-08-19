CREATE DATABASE QuanLyChoThueXe06
GO

USE DATABASE QuanLyChoThueXe06
GO

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

-- Tạo bảng Cars để quản lý thông tin xe
CREATE TABLE Cars (
    CarId INT PRIMARY KEY IDENTITY,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Color NVARCHAR(20) NOT NULL,
    PricePerDay DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(20) NOT NULL
);

-- Tạo bảng Customers để quản lý thông tin khách hàng
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Address NVARCHAR(100) NOT NULL
);

-- Tạo bảng Rentals để quản lý việc thuê và trả xe
CREATE TABLE Rentals (
    RentalId INT PRIMARY KEY IDENTITY,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    RentalDate DATE NOT NULL,
    ReturnDate DATE,
    Issues NVARCHAR(500),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (CarId) REFERENCES Cars(CarId)
);

-- Tạo bảng Revenue để quản lý doanh thu
CREATE TABLE Revenue (
    RevenueId INT PRIMARY KEY IDENTITY,
    RentalId INT NOT NULL,
    RevenueDate DATE NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (RentalId) REFERENCES Rentals(RentalId)
);