﻿CREATE TABLE [dbo].[Address]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Street] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(20) NULL, 
    [State] NVARCHAR(50) NULL, 
    [Zipcode] NVARCHAR(50) NULL 
)
