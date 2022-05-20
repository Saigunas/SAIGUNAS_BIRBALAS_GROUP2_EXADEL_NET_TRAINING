CREATE PROCEDURE [dbo].[CreateSubjects]
AS
BEGIN
	INSERT INTO Subject (Name)
	VALUES ('German'),
		   ('Philosophy'),
		   ('P.E'),
		   ('History');
END