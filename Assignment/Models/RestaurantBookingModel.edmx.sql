
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/17/2021 19:41:40
-- Generated from EDMX file: C:\Users\xiaohan2\Desktop\monash\5032\source\Assignment\Assignment\Models\RestaurantBookingModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Assignment-20210717065841];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RestaurantsSet'
CREATE TABLE [dbo].[RestaurantsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Signaturedish] nvarchar(max)  NOT NULL,
    [ReceptionCapacity] nvarchar(max)  NOT NULL,
    [PerCapitaConsumption] nvarchar(max)  NOT NULL,
    [OpeningHours] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [BookingId] int IDENTITY(1,1) NOT NULL,
    [BookingRestaurant] nvarchar(max)  NOT NULL,
    [SeatsNumber] nvarchar(max)  NOT NULL,
    [Requirements] nvarchar(max)  ,
    [BookingDate] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RestaurantsSet'
ALTER TABLE [dbo].[RestaurantsSet]
ADD CONSTRAINT [PK_RestaurantsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BookingId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([BookingId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------