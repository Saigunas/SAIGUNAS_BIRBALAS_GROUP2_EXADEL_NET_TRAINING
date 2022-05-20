CREATE PROCEDURE [dbo].[DeleteStudent]
	@StudentId INT
AS
BEGIN
	DELETE FROM Student
	WHERE  Student.Id = @StudentId
END
