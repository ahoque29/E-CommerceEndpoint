USE [master]
GO

CREATE DATABASE [ECommerce]
GO

USE [ECommerce]
GO

CREATE SCHEMA [Main]
    GO

CREATE TABLE [Main].[Customer]
(
    [CustomerId] [int] IDENTITY(1, 1) NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [RowGuid] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO

CREATE TABLE [Main].[Order]
(
    [OrderId] [int] IDENTITY(1, 1) NOT NULL,
    [OrderDate] [datetime2](7) NOT NULL,
    [CreatedUser] [nvarchar](max) NOT NULL,
    [CreatedDateTimeUTC] [datetime2](7) NOT NULL,
    [RowGuid] [nvarchar](max) NOT NULL,
    [CustomerId] [int] NOT NULL,
    CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO

CREATE TABLE [Main].[OrderDetail]
(
    [OrderDetailsId] [int] IDENTITY(1, 1) NOT NULL,
    [OrderId] [int] NOT NULL,
    [ProductId] [int] NOT NULL,
    [Quantity] [int] NOT NULL,
    CONSTRAINT [PK_OrderDetail]
    PRIMARY KEY CLUSTERED ([OrderDetailsId] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

CREATE TABLE [Main].[Product]
(
    [ProductId] [int] IDENTITY(1, 1) NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
    CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO

ALTER TABLE [Main].[Order] WITH CHECK
    ADD CONSTRAINT [FK_Order_Customer_CustomerId]
    FOREIGN KEY ([CustomerId])
    REFERENCES [Main].[Customer] ([CustomerId])
    GO
ALTER TABLE [Main].[Order] CHECK CONSTRAINT [FK_Order_Customer_CustomerId]
    GO
ALTER TABLE [Main].[OrderDetail] WITH CHECK
    ADD CONSTRAINT [FK_OrderDetail_Order_OrderId]
    FOREIGN KEY ([OrderId])
    REFERENCES [Main].[Order] ([OrderId])
    GO
ALTER TABLE [Main].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_OrderId]
    GO
ALTER TABLE [Main].[OrderDetail] WITH CHECK
    ADD CONSTRAINT [FK_OrderDetail_Product_ProductId]
    FOREIGN KEY ([ProductId])
    REFERENCES [Main].[Product] ([ProductId])
    GO
ALTER TABLE [Main].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product_ProductId]
    GO
    USE [master]
    GO
ALTER DATABASE [ECommerce] SET READ_WRITE
GO
