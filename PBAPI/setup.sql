USE [master]
GO

IF DB_ID('PBIAPI') IS NOT NULL
BEGIN
	CREATE DATABASE PBIAPI;
END
GO