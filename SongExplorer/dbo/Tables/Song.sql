CREATE TABLE [dbo].[Song] (
    [Id]   INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR (100) NOT NULL,
    [KeyId] INT NULL, 
    [SlotId] INT NULL, 
    [VocalistId] INT NULL, 
    [StatusId] INT NULL, 
    [DateAdded] DATETIME NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_Song_ToKey] FOREIGN KEY ([KeyId]) REFERENCES [Key]([Id]), 
    CONSTRAINT [FK_Song_ToSlot] FOREIGN KEY ([SlotId]) REFERENCES [Slot]([Id]), 
    CONSTRAINT [FK_Song_ToVocalist] FOREIGN KEY ([VocalistId]) REFERENCES [Vocalist]([Id]), 
    CONSTRAINT [FK_Song_ToStatus] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id])
);

