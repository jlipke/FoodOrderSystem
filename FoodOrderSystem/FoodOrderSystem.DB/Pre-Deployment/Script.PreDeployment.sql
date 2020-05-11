/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS tblOrderItem
DROP TABLE IF EXISTS tblOrder
DROP TABLE IF EXISTS tblUserPayment
DROP TABLE IF EXISTS tblState
DROP TABLE IF EXISTS tblUserAddress
DROP TABLE IF EXISTS tblUser
DROP TABLE IF EXISTS tblMenuItem