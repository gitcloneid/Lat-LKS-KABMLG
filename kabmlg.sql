DECLARE @DatabaseName NVARCHAR(128) = 'MyDatabase' -- Ganti nama db seleramu

USE [master]
GO
CREATE DATABASE [@DatabaseName]
 CONTAINMENT = NONE
 ON PRIMARY
( NAME = N'@DatabaseName', SIZE = 8192KB , MAXSIZE = UNLIMITED )
 LOG ON 
( NAME = N'@DatabaseName_log', SIZE = 8192KB , MAXSIZE = 2048GB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [@DatabaseName] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [@DatabaseName].[dbo].[sp_fulltext_database] @action = 'enable'
END
GO

USE [@DatabaseName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[borrowing_record] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [borrower_id] [int] NOT NULL,
    [device_id] [int] NOT NULL,
    [description] [varchar](100) NOT NULL,
    [start_date] [datetime] NOT NULL,
    [end_date] [datetime] NOT NULL,
    [status] [varchar](50) NULL,
    [created_at] [timestamp] NOT NULL,
    CONSTRAINT [PK_borrowing_record] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[borrowing_record_status] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [borrowing_record_id] [int] NOT NULL,
    [from_status] [varchar](50) NULL,
      NULL,
      NULL,
    [user_id] [int] NOT NULL,
    [created_at] [timestamp] NOT NULL,
    CONSTRAINT [PK_borrowing_record_status] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[devices] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [varchar](50) NOT NULL,
      NULL,
    [photo] [image] NULL,
    [status] [varchar](10) NULL,
      NULL,
    [created_at] [timestamp] NOT NULL,
    CONSTRAINT [PK_devices] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[users] (
    [id] [int] IDENTITY(1,1) NOT NULL,
    [full_name] [varchar](50) NULL,
      NOT NULL,
      NOT NULL,
      NULL,
      NULL,
    [created_at] [timestamp] NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

ALTER TABLE [dbo].[borrowing_record] ADD CONSTRAINT [FK_borrowing_record_devices] FOREIGN KEY ([device_id]) REFERENCES [dbo].[devices] ([id])
GO
ALTER TABLE [dbo].[borrowing_record] ADD CONSTRAINT [FK_borrowing_record_users] FOREIGN KEY ([borrower_id]) REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[borrowing_record_status] ADD CONSTRAINT [FK_borrowing_record_status_borrowing_record] FOREIGN KEY ([borrowing_record_id]) REFERENCES [dbo].[borrowing_record] ([id])
GO
ALTER TABLE [dbo].[borrowing_record_status] ADD CONSTRAINT [FK_borrowing_record_status_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
GO

USE [master]
GO
ALTER DATABASE [@DatabaseName] SET READ_WRITE
GO
