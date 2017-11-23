CREATE TABLE [dbo].[Task]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [StatusId] INT NOT NULL,
	[IsActive] BIT NOT NULL, 
    CONSTRAINT [FK_Task_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
	CONSTRAINT [FK_Task_Status] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id])
)
