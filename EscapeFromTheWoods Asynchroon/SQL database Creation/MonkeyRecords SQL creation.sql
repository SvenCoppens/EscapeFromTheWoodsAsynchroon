CREATE TABLE [dbo].[MonkeyRecords]
(
	[recordID] INT PRIMARY KEY IDENTITY,
	[monkeyID] INT NOT NULL,
	[monkeyName] VARCHAR(50) NOT NULL,
	[woodID] INT NOT NULL,
	[seqnr] INT NOT NULL,
	[treeID] INT NOT NULL,
	[X] INT NOT NULL,
	[Y] INT NOT NULL
)
