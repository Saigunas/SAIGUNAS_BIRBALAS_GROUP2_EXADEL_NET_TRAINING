CREATE TRIGGER [AddStudent_Trigger]
	ON [dbo].[Student]
	FOR INSERT
	AS
	BEGIN
		SET NOCOUNT ON

		DECLARE @FirstNameUpper NVARCHAR(50)
		DECLARE @StudentId INT

		SELECT @FirstNameUpper = FirstName from inserted
		SELECT @FirstNameUpper = UPPER(@FirstNameUpper)
		SELECT @StudentId = Id from inserted

		UPDATE Student
		SET Student.FirstName = @FirstNameUpper
		WHERE Student.Id = @StudentId;
	END
