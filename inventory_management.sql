drop database if exists inventory_management
create database inventory_management
use inventory_management
ALTER DATABASE [inventory_management] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [inventory_management];

create table Product(
productId int identity(1,1) primary key,
productName varchar(20),
price decimal,
quantity int
)

create table Transactions(
transactionId int identity(1,1) primary key,
type int, -- 0 = import, 1 = export
quantity int,
date datetime,
productId int,
foreign key (productId) references Product(productId)
)

-- Thêm dữ liệu cho bảng Product
INSERT INTO Product (productName, price, quantity)
VALUES
('Laptop', 1500.00, 50),
('Smartphone', 800.00, 100),
('Tablet', 600.00, 40),
('Monitor', 300.00, 30),
('Keyboard', 50.00, 200),
('Mouse', 25.00, 300),
('Printer', 200.00, 20),
('Headphones', 120.00, 80),
('Camera', 1000.00, 15),
('Speaker', 180.00, 60);

-- Thêm dữ liệu cho bảng Transactions
INSERT INTO Transactions (type, quantity, date, productId)
VALUES
(0, 10, '2026-03-01', 1), -- import Laptop
(1, 5,  '2026-03-02', 1), -- export Laptop
(0, 20, '2026-03-01', 2), -- import Smartphone
(1, 8,  '2026-03-03', 2), -- export Smartphone
(0, 15, '2026-03-01', 3), -- import Tablet
(1, 5,  '2026-03-04', 3), -- export Tablet
(0, 12, '2026-03-01', 4), -- import Monitor
(1, 3,  '2026-03-05', 4), -- export Monitor
(0, 50, '2026-03-01', 5), -- import Keyboard
(1, 20, '2026-03-06', 5); -- export Keyboard
