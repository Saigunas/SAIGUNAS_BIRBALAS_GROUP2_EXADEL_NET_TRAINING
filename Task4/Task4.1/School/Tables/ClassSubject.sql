CREATE TABLE [dbo].[ClassSubject]
(
	[ClassID] INT NOT NULL , 
    [SubjectID] INT NOT NULL, 
    CONSTRAINT [FK_ClassSubject_Class] FOREIGN KEY ([ClassID]) REFERENCES [Class]([id]), 
    CONSTRAINT [FK_ClassSubject_Subject] FOREIGN KEY ([SubjectID]) REFERENCES [Subject]([id])
)
