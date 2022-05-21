SET IDENTITY_INSERT [dbo].[Class] ON
GO

	INSERT INTO Class (Id, Letter, Number)
		VALUES (1, 'B', 3),
			   (2, 'C', 2),
			   (3, 'A', 3),
			   (4, 'C', 2);

GO
SET IDENTITY_INSERT [dbo].[Class] OFF

SET IDENTITY_INSERT [dbo].[Student] ON
GO

	INSERT INTO Student (Id, ClassId, FirstName, LastName, PhoneNumber, Address)
		VALUES (1, 2, 'Joker', 'Mask', 323432, 'Leblanc'),
			   (2, 2, 'Ann', 'Panther',993432, 'Station'),
			   (3, 3, 'Skull', 'Bat', 523534, 'Ramen shop'),
			   (4, 1, 'Morgana', 'Paw', 323432, 'Metaverse');

GO
SET IDENTITY_INSERT [dbo].[Student] OFF


SET IDENTITY_INSERT [dbo].[Subject] ON
GO

	INSERT INTO Subject (Id, Name)
		VALUES (1, 'German'),
			   (2, 'Philosophy'),
			   (3, 'P.E'),
			   (4, 'History');
GO

SET IDENTITY_INSERT [dbo].[Subject] OFF
GO

	INSERT INTO ClassSubject(ClassId, SubjectId)
		VALUES (1, 4),
			   (3, 2),
			   (3, 4),
			   (1, 2);
GO