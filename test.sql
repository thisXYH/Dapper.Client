-- Mssql 单元测试使用的数据库脚本

-- Create a new database called 'DapperClient_Db'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'DapperClient_Db'
)
CREATE DATABASE DapperClient_Db
GO


use DapperClient_Db
GO

-- Create a new table called 'Person' in schema
-- Drop the table if it already exists
IF OBJECT_ID('Person', 'U') IS NOT NULL
DROP TABLE Person
GO
-- Create the table in the specified schema
CREATE TABLE Person
(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), -- primary key column
    [Name] [NVARCHAR](8) NOT NULL,
    Age INT NOT NULL,
    -- specify more columns here
    Birthday DATETIME NULL,
    height FLOAT NULL,
    [weight] FLOAT NULL,
    InsertTime DATETIME NOT NULL DEFAULT getdate()
);
GO