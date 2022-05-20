CREATE TABLE [dbo].[ClassSubjectRelation]
(
	[ClassID] INT NOT NULL , 
    [SubjectID] INT NOT NULL, 
    CONSTRAINT [FK_ClassSubjectRelation_Class] FOREIGN KEY ([ClassID]) REFERENCES [Class]([id]), 
    CONSTRAINT [FK_ClassSubjectRelation_Subject] FOREIGN KEY ([SubjectID]) REFERENCES [Subject]([id])
)
