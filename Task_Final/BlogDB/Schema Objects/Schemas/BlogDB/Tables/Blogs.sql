CREATE TABLE [BlogDB].[Blogs]
(
	[BlogID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [Document] NTEXT NOT NULL, 
    [Tag] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Blogs_Users] FOREIGN KEY ([UserID]) REFERENCES [BlogDB].[Users]([UserID]) 
)
