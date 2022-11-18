
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2022 22:06:33
-- Generated from EDMX file: C:\Users\bacco\source\repos\BBQCookbook\ImpBBQLibary\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ImprovedBBQDB];
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
    [Kochname] nvarchar(max)  NOT NULL,
    [Kochbewertung] nvarchar(max)  NOT NULL,
    [BilderId] int  NOT NULL
);
GO

-- Creating table 'RezeptSet'
CREATE TABLE [dbo].[RezeptSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rezeptnamen] nvarchar(max)  NOT NULL,
    [Vorgehen] nvarchar(max)  NOT NULL,
    [Rezeptbewertung] nvarchar(max)  NOT NULL,
    [Koch_Id] int  NOT NULL
);
GO

-- Creating table 'KochvorgangSet'
CREATE TABLE [dbo].[KochvorgangSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Protokoll] nvarchar(max)  NOT NULL,
    [RezeptId] int  NOT NULL,
    [KochId] int  NOT NULL
);
GO

-- Creating table 'ZutatenSet'
CREATE TABLE [dbo].[ZutatenSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Zutatennamen] nvarchar(max)  NOT NULL,
    [Kategorie] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EquipmentSet'
CREATE TABLE [dbo].[EquipmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Equipmentnamen] nvarchar(max)  NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [BilderId] int  NOT NULL
);
GO

-- Creating table 'BilderSet'
CREATE TABLE [dbo].[BilderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bildernamen] nvarchar(max)  NOT NULL,
    [Bilderart] nvarchar(max)  NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KochBesitztEquipment'
CREATE TABLE [dbo].[KochBesitztEquipment] (
    [Equipment_Id] int  NOT NULL,
    [Koch_Id] int  NOT NULL
);
GO

-- Creating table 'KochZutaten'
CREATE TABLE [dbo].[KochZutaten] (
    [Koch_Id] int  NOT NULL,
    [Zutaten_Id] int  NOT NULL
);
GO

-- Creating table 'RezeptBestehtausZutaten'
CREATE TABLE [dbo].[RezeptBestehtausZutaten] (
    [Zutaten_Id] int  NOT NULL,
    [Rezept_Id] int  NOT NULL
);
GO

-- Creating table 'RezeptHatMusterbilder'
CREATE TABLE [dbo].[RezeptHatMusterbilder] (
    [Bilder_Id] int  NOT NULL,
    [Rezept_Id] int  NOT NULL
);
GO

-- Creating table 'KochvorgangHatVorgangsbilder'
CREATE TABLE [dbo].[KochvorgangHatVorgangsbilder] (
    [Bilder_Id] int  NOT NULL,
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

-- Creating primary key on [Id] in table 'RezeptSet'
ALTER TABLE [dbo].[RezeptSet]
ADD CONSTRAINT [PK_RezeptSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KochvorgangSet'
ALTER TABLE [dbo].[KochvorgangSet]
ADD CONSTRAINT [PK_KochvorgangSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ZutatenSet'
ALTER TABLE [dbo].[ZutatenSet]
ADD CONSTRAINT [PK_ZutatenSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [PK_EquipmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BilderSet'
ALTER TABLE [dbo].[BilderSet]
ADD CONSTRAINT [PK_BilderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Equipment_Id], [Koch_Id] in table 'KochBesitztEquipment'
ALTER TABLE [dbo].[KochBesitztEquipment]
ADD CONSTRAINT [PK_KochBesitztEquipment]
    PRIMARY KEY CLUSTERED ([Equipment_Id], [Koch_Id] ASC);
GO

-- Creating primary key on [Koch_Id], [Zutaten_Id] in table 'KochZutaten'
ALTER TABLE [dbo].[KochZutaten]
ADD CONSTRAINT [PK_KochZutaten]
    PRIMARY KEY CLUSTERED ([Koch_Id], [Zutaten_Id] ASC);
GO

-- Creating primary key on [Zutaten_Id], [Rezept_Id] in table 'RezeptBestehtausZutaten'
ALTER TABLE [dbo].[RezeptBestehtausZutaten]
ADD CONSTRAINT [PK_RezeptBestehtausZutaten]
    PRIMARY KEY CLUSTERED ([Zutaten_Id], [Rezept_Id] ASC);
GO

-- Creating primary key on [Bilder_Id], [Rezept_Id] in table 'RezeptHatMusterbilder'
ALTER TABLE [dbo].[RezeptHatMusterbilder]
ADD CONSTRAINT [PK_RezeptHatMusterbilder]
    PRIMARY KEY CLUSTERED ([Bilder_Id], [Rezept_Id] ASC);
GO

-- Creating primary key on [Bilder_Id], [Kochvorgang_Id] in table 'KochvorgangHatVorgangsbilder'
ALTER TABLE [dbo].[KochvorgangHatVorgangsbilder]
ADD CONSTRAINT [PK_KochvorgangHatVorgangsbilder]
    PRIMARY KEY CLUSTERED ([Bilder_Id], [Kochvorgang_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Equipment_Id] in table 'KochBesitztEquipment'
ALTER TABLE [dbo].[KochBesitztEquipment]
ADD CONSTRAINT [FK_KochBesitztEquipment_Equipment]
    FOREIGN KEY ([Equipment_Id])
    REFERENCES [dbo].[EquipmentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Koch_Id] in table 'KochBesitztEquipment'
ALTER TABLE [dbo].[KochBesitztEquipment]
ADD CONSTRAINT [FK_KochBesitztEquipment_Koch]
    FOREIGN KEY ([Koch_Id])
    REFERENCES [dbo].[KochSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochBesitztEquipment_Koch'
CREATE INDEX [IX_FK_KochBesitztEquipment_Koch]
ON [dbo].[KochBesitztEquipment]
    ([Koch_Id]);
GO

-- Creating foreign key on [Koch_Id] in table 'RezeptSet'
ALTER TABLE [dbo].[RezeptSet]
ADD CONSTRAINT [FK_KochErstelltRezepte]
    FOREIGN KEY ([Koch_Id])
    REFERENCES [dbo].[KochSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochErstelltRezepte'
CREATE INDEX [IX_FK_KochErstelltRezepte]
ON [dbo].[RezeptSet]
    ([Koch_Id]);
GO

-- Creating foreign key on [Koch_Id] in table 'KochZutaten'
ALTER TABLE [dbo].[KochZutaten]
ADD CONSTRAINT [FK_KochZutaten_Koch]
    FOREIGN KEY ([Koch_Id])
    REFERENCES [dbo].[KochSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Zutaten_Id] in table 'KochZutaten'
ALTER TABLE [dbo].[KochZutaten]
ADD CONSTRAINT [FK_KochZutaten_Zutaten]
    FOREIGN KEY ([Zutaten_Id])
    REFERENCES [dbo].[ZutatenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochZutaten_Zutaten'
CREATE INDEX [IX_FK_KochZutaten_Zutaten]
ON [dbo].[KochZutaten]
    ([Zutaten_Id]);
GO

-- Creating foreign key on [Zutaten_Id] in table 'RezeptBestehtausZutaten'
ALTER TABLE [dbo].[RezeptBestehtausZutaten]
ADD CONSTRAINT [FK_RezeptBestehtausZutaten_Zutaten]
    FOREIGN KEY ([Zutaten_Id])
    REFERENCES [dbo].[ZutatenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Rezept_Id] in table 'RezeptBestehtausZutaten'
ALTER TABLE [dbo].[RezeptBestehtausZutaten]
ADD CONSTRAINT [FK_RezeptBestehtausZutaten_Rezept]
    FOREIGN KEY ([Rezept_Id])
    REFERENCES [dbo].[RezeptSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezeptBestehtausZutaten_Rezept'
CREATE INDEX [IX_FK_RezeptBestehtausZutaten_Rezept]
ON [dbo].[RezeptBestehtausZutaten]
    ([Rezept_Id]);
GO

-- Creating foreign key on [RezeptId] in table 'KochvorgangSet'
ALTER TABLE [dbo].[KochvorgangSet]
ADD CONSTRAINT [FK_KochvorgangFolgtRezept]
    FOREIGN KEY ([RezeptId])
    REFERENCES [dbo].[RezeptSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochvorgangFolgtRezept'
CREATE INDEX [IX_FK_KochvorgangFolgtRezept]
ON [dbo].[KochvorgangSet]
    ([RezeptId]);
GO

-- Creating foreign key on [KochId] in table 'KochvorgangSet'
ALTER TABLE [dbo].[KochvorgangSet]
ADD CONSTRAINT [FK_KochFührtausKochvorgang]
    FOREIGN KEY ([KochId])
    REFERENCES [dbo].[KochSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochFührtausKochvorgang'
CREATE INDEX [IX_FK_KochFührtausKochvorgang]
ON [dbo].[KochvorgangSet]
    ([KochId]);
GO

-- Creating foreign key on [BilderId] in table 'KochSet'
ALTER TABLE [dbo].[KochSet]
ADD CONSTRAINT [FK_KochHatProfilbild]
    FOREIGN KEY ([BilderId])
    REFERENCES [dbo].[BilderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochHatProfilbild'
CREATE INDEX [IX_FK_KochHatProfilbild]
ON [dbo].[KochSet]
    ([BilderId]);
GO

-- Creating foreign key on [Bilder_Id] in table 'RezeptHatMusterbilder'
ALTER TABLE [dbo].[RezeptHatMusterbilder]
ADD CONSTRAINT [FK_RezeptHatMusterbilder_Bilder]
    FOREIGN KEY ([Bilder_Id])
    REFERENCES [dbo].[BilderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Rezept_Id] in table 'RezeptHatMusterbilder'
ALTER TABLE [dbo].[RezeptHatMusterbilder]
ADD CONSTRAINT [FK_RezeptHatMusterbilder_Rezept]
    FOREIGN KEY ([Rezept_Id])
    REFERENCES [dbo].[RezeptSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezeptHatMusterbilder_Rezept'
CREATE INDEX [IX_FK_RezeptHatMusterbilder_Rezept]
ON [dbo].[RezeptHatMusterbilder]
    ([Rezept_Id]);
GO

-- Creating foreign key on [BilderId] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [FK_EquipmentHatEquipmentbild]
    FOREIGN KEY ([BilderId])
    REFERENCES [dbo].[BilderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentHatEquipmentbild'
CREATE INDEX [IX_FK_EquipmentHatEquipmentbild]
ON [dbo].[EquipmentSet]
    ([BilderId]);
GO

-- Creating foreign key on [Bilder_Id] in table 'KochvorgangHatVorgangsbilder'
ALTER TABLE [dbo].[KochvorgangHatVorgangsbilder]
ADD CONSTRAINT [FK_KochvorgangHatVorgangsbilder_Bilder]
    FOREIGN KEY ([Bilder_Id])
    REFERENCES [dbo].[BilderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Kochvorgang_Id] in table 'KochvorgangHatVorgangsbilder'
ALTER TABLE [dbo].[KochvorgangHatVorgangsbilder]
ADD CONSTRAINT [FK_KochvorgangHatVorgangsbilder_Kochvorgang]
    FOREIGN KEY ([Kochvorgang_Id])
    REFERENCES [dbo].[KochvorgangSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KochvorgangHatVorgangsbilder_Kochvorgang'
CREATE INDEX [IX_FK_KochvorgangHatVorgangsbilder_Kochvorgang]
ON [dbo].[KochvorgangHatVorgangsbilder]
    ([Kochvorgang_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------