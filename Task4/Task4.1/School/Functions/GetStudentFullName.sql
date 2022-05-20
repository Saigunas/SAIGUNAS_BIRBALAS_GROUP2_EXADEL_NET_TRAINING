CREATE FUNCTION [dbo].[GetStudentFullName]
(
	@StudentId int
)
RETURNS nvarchar(50)
	
AS
BEGIN
	DECLARE @FullName nvarchar(50)
	SELECT @FullName = CONCAT(Student.FirstName, ' ',Student.LastName)
	FROM Student
	WHERE Student.Id = @StudentId
	RETURN @FullName;
END
