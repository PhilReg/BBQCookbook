
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2022 21:16:03
-- Generated from EDMX file: C:\Users\bacco\source\repos\BBQCookbook\BBQLibary\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BBQKochbuchDB];
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

-- Creating table 'KochSet'
CREATE TABLE [dbo].[KochSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nutzerkennung] nvarchar(max)  NOT NULL,
    [Equipment] nvarchar(max)  NOT NULL,
    [Zutaten] nvarchar(max)  NOT NULL,
    [Holz] nvarchar(max)  NOT NULL,
    [Bewertung] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KochvorgangSet'
CREATE TABLE [dbo].[KochvorgangSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Protokoll] nvarchar(max)  NOT NULL,
    [RezeptId] int  NOT NULL
);
GO

-- Creating table 'RezeptSet'
CREATE TABLE [dbo].[RezeptSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Zutatenliste] nvarchar(max)  NOT NULL,
    [Vorgehen] nvarchar(max)  NOT NULL,
    [Holzart] nvarchar(max)  NOT NULL,
    [Equipmentliste] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KochKochvorgang'
CREATE TABLE [dbo].[KochKochvorgang] (
    [Koch_Id] int  NOT NULL,
    [Kochvorgang_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'KochSet'
ALTER TABLE [dbo].[KochSet]
ADD CONSTRAINT [PK_KochSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KochvorgangSet'
ALTER TABLE [dbo].[KochvorgangSet]
ADD CONSTRAINT [PK_KochvorgangSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RezeptSet'
ALTER TABLE [dbo].[RezeptSet]
ADD CONSTRAINT [PK_RezeptSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Koch_Id], [Kochvorgang_Id] in table 'KochKochvorgang'
ALTER TABLE [dbo].[KochKochvorgang]
ADD CONSTRAINT [PK_KochKochvorgang]
    PRIMARY KEY CLUSTERED ([Koch_Id], [Kochvorgang_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Koch_Id] in table 'KochKochvorgang'
ALTER TABLE [dbo].[KochKochvorgang]
ADD CONSTRAINT [FK_KochKochvorgang_Koch]
    FOREIGN KEY ([Koch_Id])
    REFERENCES [dbo].[KochSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Kochvorgang_Id] in table 'KochKochvorgang'
ALTER TABLE [dbo].[KochKochvorgang]
ADD CONSTRAINT [FK_KochKochvorgang_Kochvorgang]
    FOREIGN KEY ([Kochvorgang_Id])
    REFERENCES [dbo].[KochvorgangSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochKochvorgang_Kochvorgang'
CREATE INDEX [IX_FK_KochKochvorgang_Kochvorgang]
ON [dbo].[KochKochvorgang]
    ([Kochvorgang_Id]);
GO

-- Creating foreign key on [RezeptId] in table 'KochvorgangSet'
ALTER TABLE [dbo].[KochvorgangSet]
ADD CONSTRAINT [FK_RezeptKochvorgang]
    FOREIGN KEY ([RezeptId])
    REFERENCES [dbo].[RezeptSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezeptKochvorgang'
CREATE INDEX [IX_FK_RezeptKochvorgang]
ON [dbo].[KochvorgangSet]
    ([RezeptId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------