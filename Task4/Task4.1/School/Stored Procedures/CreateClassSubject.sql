CREATE PROCEDURE [dbo].[CreateClassSubject]
AS
BEGIN
	INSERT INTO ClassSubject(ClassId, SubjectId)
		VALUES (1, 4),
			   (3, 2),
			   (3, 4),
			   (1, 2);
END