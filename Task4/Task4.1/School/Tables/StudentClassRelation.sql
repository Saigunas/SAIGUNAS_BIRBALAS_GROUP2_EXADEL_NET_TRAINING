CREATE TABLE [dbo].[StudentClassRelation] (
    [StudentID] INT NOT NULL,
    [ClassID]   INT NOT NULL,
    UNIQUE NONCLUSTERED ([StudentID] ASC),
    CONSTRAINT [FK_StudentClassRelation_Student] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Student] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentClassRelation_Class] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class] ([Id]) ON DELETE CASCADE
);
