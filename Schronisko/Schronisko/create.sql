
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/12/2019 13:20:54
-- --------------------------------------------------

--SET QUOTED_IDENTIFIER OFF;
--GO
--USE [Pieskowa];
--GO
--IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
--GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dogs'
CREATE TABLE [dbo].[Dogs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [year_of_birth] int  NULL,
    [photo_path] nvarchar(350)  NULL,
    [description] nvarchar(max)  NULL,
    [id_race] int  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NOT NULL,
    [time_end] time  NULL,
    [time] time  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [approved] int  NOT NULL,
    [id_user] int  NOT NULL,
    [id_dog] int  NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [id] int IDENTITY(1,1) NOT NULL,
    [news1] nvarchar(500)  NULL,
    [add_date] datetime  NULL,
    [user_id] int  NOT NULL
);
GO

-- Creating table 'Races'
CREATE TABLE [dbo].[Races] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [description] nvarchar(max)  NULL,
    [origin] nvarchar(50)  NULL,
    [size] nvarchar(50)  NULL,
    [for_child] nvarchar(50)  NULL,
    [for_animal] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(60)  NULL,
    [surname] nvarchar(100)  NULL,
    [pesel] nvarchar(11)  NULL,
    [city] nvarchar(60)  NULL,
    [street] nvarchar(60)  NULL,
    [house] nvarchar(15)  NULL,
    [login] nvarchar(50)  NULL,
    [email] nvarchar(50)  NULL,
    [password] nvarchar(200)  NULL,
    [role] nvarchar(30)  NULL,
    [reset_hash] nvarchar(100)  NULL,
    [phone] nvarchar(25)  NULL
);
GO

-- Creating table 'UsersEvents'
CREATE TABLE [dbo].[UsersEvents] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [id_event] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [PK_Dogs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Races'
ALTER TABLE [dbo].[Races]
ADD CONSTRAINT [PK_Races]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UsersEvents'
ALTER TABLE [dbo].[UsersEvents]
ADD CONSTRAINT [PK_UsersEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_race] in table 'Dogs'
ALTER TABLE [dbo].[Dogs]
ADD CONSTRAINT [FK__Dogs__id_race__78D3EB5B]
    FOREIGN KEY ([id_race])
    REFERENCES [dbo].[Races]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Dogs__id_race__78D3EB5B'
CREATE INDEX [IX_FK__Dogs__id_race__78D3EB5B]
ON [dbo].[Dogs]
    ([id_race]);
GO

-- Creating foreign key on [id_dog] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK__Events__id_dog__147C05D0]
    FOREIGN KEY ([id_dog])
    REFERENCES [dbo].[Dogs]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Events__id_dog__147C05D0'
CREATE INDEX [IX_FK__Events__id_dog__147C05D0]
ON [dbo].[Events]
    ([id_dog]);
GO

-- Creating foreign key on [id_user] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK__Events__id_user__1387E197]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Events__id_user__1387E197'
CREATE INDEX [IX_FK__Events__id_user__1387E197]
ON [dbo].[Events]
    ([id_user]);
GO

-- Creating foreign key on [id_event] in table 'UsersEvents'
ALTER TABLE [dbo].[UsersEvents]
ADD CONSTRAINT [FK__UsersEven__id_ev__15702A09]
    FOREIGN KEY ([id_event])
    REFERENCES [dbo].[Events]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UsersEven__id_ev__15702A09'
CREATE INDEX [IX_FK__UsersEven__id_ev__15702A09]
ON [dbo].[UsersEvents]
    ([id_event]);
GO

-- Creating foreign key on [user_id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [FK__News__user_id__740F363E]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__News__user_id__740F363E'
CREATE INDEX [IX_FK__News__user_id__740F363E]
ON [dbo].[News]
    ([user_id]);
GO

-- Creating foreign key on [id_user] in table 'UsersEvents'
ALTER TABLE [dbo].[UsersEvents]
ADD CONSTRAINT [FK__UsersEven__id_us__6B79F03D]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UsersEven__id_us__6B79F03D'
CREATE INDEX [IX_FK__UsersEven__id_us__6B79F03D]
ON [dbo].[UsersEvents]
    ([id_user]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------