CREATE PROCEDURE [dbo].[CreateClasses]
AS
BEGIN
	INSERT INTO Class (Letter, Number)
	VALUES ('B', 3),
		   ('C', 2),
		   ('A', 3),
		   ('C', 2);
END