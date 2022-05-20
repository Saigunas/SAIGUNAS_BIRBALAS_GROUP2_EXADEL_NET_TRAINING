CREATE PROCEDURE [dbo].[CreateStudents]
AS
BEGIN
	INSERT INTO Student (ClassId, FirstName, LastName, PhoneNumber, Address)
		VALUES (2, 'Joker', 'Mask', 323432, 'Leblanc'),
			   (2, 'Ann', 'Panther',993432, 'Station'),
			   (3, 'Skull', 'Bat', 523534, 'Ramen shop'),
			   (1, 'Morgana', 'Paw', 323432, 'Metaverse');
END