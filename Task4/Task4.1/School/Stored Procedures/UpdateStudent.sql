CREATE PROCEDURE [dbo].[UpdateStudent]
	@StudentId INT,
	@ClassId INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber INT,
	@Address NVARCHAR(50)
AS
BEGIN
	UPDATE Student
	SET ClassID = @ClassId,
		FirstName = @FirstName,
		LastName = @LastName,
		PhoneNumber = @PhoneNumber,
		Address = @Address
	WHERE Id = @StudentId
END