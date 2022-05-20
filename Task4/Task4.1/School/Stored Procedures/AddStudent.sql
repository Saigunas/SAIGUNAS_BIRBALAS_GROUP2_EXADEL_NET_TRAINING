﻿CREATE PROCEDURE [dbo].[AddStudent]
	@ClassId int,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber INT,
	@Address NVARCHAR(50)
AS
BEGIN
	BEGIN TRY
		DECLARE @StudentId nvarchar(50)
		INSERT INTO Student (FirstName, LastName, PhoneNumber, Address)
		VALUES (@FirstName, @LastName, @PhoneNumber, @Address)

		SELECT @StudentId = Student.Id FROM Student WHERE id = SCOPE_IDENTITY()

		INSERT INTO StudentClassRelation (StudentID, ClassID)
		VALUES (@StudentId, @ClassId)
	END TRY
	BEGIN CATCH
		PRINT 'Error: Failed to add a student.'
	END CATCH;
END
