CREATE TABLE [dbo].[Student] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [ClassId]     INT   NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [PhoneNumber] INT            NOT NULL,
    [Address]     NVARCHAR (50) NOT NULL,
	CONSTRAINT [FK_Student_Class] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Class] ([Id]) ON DELETE CASCADE
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student_LastName]
    ON [dbo].[Student]([LastName] ASC);

