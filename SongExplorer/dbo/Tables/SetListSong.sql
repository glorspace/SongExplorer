CREATE TABLE [dbo].[SetListSong]
(
	[SetListId] INT NOT NULL, 
    [Position] INT NOT NULL, 
    [SongId] INT NOT NULL,  
    CONSTRAINT [PK_SetListSong] PRIMARY KEY ([SetListId], [Position]),
    CONSTRAINT [FK_SetListSong_ToSetList] FOREIGN KEY ([SetListId]) REFERENCES [SetList]([Id]), 
    CONSTRAINT [FK_SetListSong_ToSong] FOREIGN KEY ([SongId]) REFERENCES [Song]([Id])
)
