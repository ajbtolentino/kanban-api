CREATE TABLE [dbo].[Status]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [IsActive] BIT NOT NULL
)
