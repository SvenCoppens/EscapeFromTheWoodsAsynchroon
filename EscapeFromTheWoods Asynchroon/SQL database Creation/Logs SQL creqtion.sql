﻿CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[woodId] INT NOT NULL,
	[monkeyId] INT NOT NULL,
	[message] VARCHAR(100) NOT NULL
)