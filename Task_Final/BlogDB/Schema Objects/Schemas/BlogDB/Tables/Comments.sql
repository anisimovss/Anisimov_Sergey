CREATE TABLE [BlogDB].[Comments]
(
	[CommentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [Comment] NTEXT NOT NULL, 
    [BlogID] INT NOT NULL, 
    CONSTRAINT [FK_Comments_Users] FOREIGN KEY ([UserID]) REFERENCES [BlogDB].[Users]([UserID]),
    CONSTRAINT [FK_Comments_Blogs] FOREIGN KEY ([BlogID]) REFERENCES [BlogDB].[Blogs]([BlogID]) on delete cascade
)

GO
