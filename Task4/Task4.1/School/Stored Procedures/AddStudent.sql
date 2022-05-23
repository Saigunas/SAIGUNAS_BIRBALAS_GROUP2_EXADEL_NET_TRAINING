CREATE PROCEDURE [dbo].[AddStudent]
	@ClassId int,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber INT,
	@Address NVARCHAR(50)
AS
BEGIN
	BEGIN TRY
		DECLARE @StudentId nvarchar(50)
		INSERT INTO Student (ClassId, FirstName, LastName, PhoneNumber, Address)
		VALUES (@ClassId, @FirstName, @LastName, @PhoneNumber, @Address)
	END TRY
	BEGIN CATCH
		PRINT 'Error: Failed to add a student.'
	END CATCH;
END
