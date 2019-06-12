
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
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Dogs__id_race__78D3EB5B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogs] DROP CONSTRAINT [FK__Dogs__id_race__78D3EB5B];
GO
IF OBJECT_ID(N'[dbo].[FK__Events__id_dog__147C05D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK__Events__id_dog__147C05D0];
GO
IF OBJECT_ID(N'[dbo].[FK__Events__id_user__1387E197]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK__Events__id_user__1387E197];
GO
IF OBJECT_ID(N'[dbo].[FK__News__user_id__740F363E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[News] DROP CONSTRAINT [FK__News__user_id__740F363E];
GO
IF OBJECT_ID(N'[dbo].[FK__UsersEven__id_ev__15702A09]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersEvents] DROP CONSTRAINT [FK__UsersEven__id_ev__15702A09];
GO
IF OBJECT_ID(N'[dbo].[FK__UsersEven__id_us__6B79F03D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersEvents] DROP CONSTRAINT [FK__UsersEven__id_us__6B79F03D];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dogs];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Races]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Races];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersEvents];
GO



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------