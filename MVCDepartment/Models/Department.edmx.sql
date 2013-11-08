
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2013 18:05:35
-- Generated from EDMX file: C:\Dropbox\Workspace(vs11)\MVCDepartment\MVCDepartment\Models\Department.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-MVCDepartment-20131005162119];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlanSpecialty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanSet] DROP CONSTRAINT [FK_PlanSpecialty];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleScheduleWeek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleWeekSet] DROP CONSTRAINT [FK_ScheduleScheduleWeek];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialtyGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_SpecialtyGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_ScheduleGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleDiscipline]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleSet] DROP CONSTRAINT [FK_ScheduleDiscipline];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAccountSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleSet] DROP CONSTRAINT [FK_UserAccountSchedule];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserAccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAccountSet];
GO
IF OBJECT_ID(N'[dbo].[DisciplineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisciplineSet];
GO
IF OBJECT_ID(N'[dbo].[SpecialtySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialtySet];
GO
IF OBJECT_ID(N'[dbo].[PlanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanSet];
GO
IF OBJECT_ID(N'[dbo].[GroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupSet];
GO
IF OBJECT_ID(N'[dbo].[ScheduleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleSet];
GO
IF OBJECT_ID(N'[dbo].[ScheduleWeekSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleWeekSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserAccountSet'
CREATE TABLE [dbo].[UserAccountSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Login] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DisciplineSet'
CREATE TABLE [dbo].[DisciplineSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpecialtySet'
CREATE TABLE [dbo].[SpecialtySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GlobalId] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlanSet'
CREATE TABLE [dbo].[PlanSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [File] nvarchar(max)  NOT NULL,
    [Specialty_Id] int  NOT NULL
);
GO

-- Creating table 'GroupSet'
CREATE TABLE [dbo].[GroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Course] int  NOT NULL,
    [Specialty_Id] int  NOT NULL,
    [Schedule_Id] int  NULL
);
GO

-- Creating table 'ScheduleSet'
CREATE TABLE [dbo].[ScheduleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Term] int  NOT NULL,
    [LecturesSum] int  NOT NULL,
    [LabsSum] int  NOT NULL,
    [PracticesSum] int  NOT NULL,
    [ExamWorksSum] int  NOT NULL,
    [Classroom] nvarchar(max)  NOT NULL,
    [Discipline_Id] int  NOT NULL,
    [UserAccount_Id] int  NOT NULL
);
GO

-- Creating table 'ScheduleWeekSet'
CREATE TABLE [dbo].[ScheduleWeekSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Lectures] int  NOT NULL,
    [Labs] int  NOT NULL,
    [Practices] int  NOT NULL,
    [ExamWorks] int  NOT NULL,
    [WeekNumber] int  NOT NULL,
    [Schedule_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserAccountSet'
ALTER TABLE [dbo].[UserAccountSet]
ADD CONSTRAINT [PK_UserAccountSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DisciplineSet'
ALTER TABLE [dbo].[DisciplineSet]
ADD CONSTRAINT [PK_DisciplineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecialtySet'
ALTER TABLE [dbo].[SpecialtySet]
ADD CONSTRAINT [PK_SpecialtySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanSet'
ALTER TABLE [dbo].[PlanSet]
ADD CONSTRAINT [PK_PlanSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [PK_GroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [PK_ScheduleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduleWeekSet'
ALTER TABLE [dbo].[ScheduleWeekSet]
ADD CONSTRAINT [PK_ScheduleWeekSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Specialty_Id] in table 'PlanSet'
ALTER TABLE [dbo].[PlanSet]
ADD CONSTRAINT [FK_PlanSpecialty]
    FOREIGN KEY ([Specialty_Id])
    REFERENCES [dbo].[SpecialtySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanSpecialty'
CREATE INDEX [IX_FK_PlanSpecialty]
ON [dbo].[PlanSet]
    ([Specialty_Id]);
GO

-- Creating foreign key on [Schedule_Id] in table 'ScheduleWeekSet'
ALTER TABLE [dbo].[ScheduleWeekSet]
ADD CONSTRAINT [FK_ScheduleScheduleWeek]
    FOREIGN KEY ([Schedule_Id])
    REFERENCES [dbo].[ScheduleSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleScheduleWeek'
CREATE INDEX [IX_FK_ScheduleScheduleWeek]
ON [dbo].[ScheduleWeekSet]
    ([Schedule_Id]);
GO

-- Creating foreign key on [Specialty_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_SpecialtyGroup]
    FOREIGN KEY ([Specialty_Id])
    REFERENCES [dbo].[SpecialtySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecialtyGroup'
CREATE INDEX [IX_FK_SpecialtyGroup]
ON [dbo].[GroupSet]
    ([Specialty_Id]);
GO

-- Creating foreign key on [Schedule_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_ScheduleGroup]
    FOREIGN KEY ([Schedule_Id])
    REFERENCES [dbo].[ScheduleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleGroup'
CREATE INDEX [IX_FK_ScheduleGroup]
ON [dbo].[GroupSet]
    ([Schedule_Id]);
GO

-- Creating foreign key on [Discipline_Id] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_ScheduleDiscipline]
    FOREIGN KEY ([Discipline_Id])
    REFERENCES [dbo].[DisciplineSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleDiscipline'
CREATE INDEX [IX_FK_ScheduleDiscipline]
ON [dbo].[ScheduleSet]
    ([Discipline_Id]);
GO

-- Creating foreign key on [UserAccount_Id] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_UserAccountSchedule]
    FOREIGN KEY ([UserAccount_Id])
    REFERENCES [dbo].[UserAccountSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAccountSchedule'
CREATE INDEX [IX_FK_UserAccountSchedule]
ON [dbo].[ScheduleSet]
    ([UserAccount_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------