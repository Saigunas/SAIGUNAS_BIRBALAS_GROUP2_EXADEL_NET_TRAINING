CREATE VIEW [dbo].[FullStudents]
	AS 
	SELECT Student.FirstName, Student.LastName, Student.PhoneNumber, Student.Address, CONCAT(Class.Number, Class.Letter) AS 'Class'
	FROM Student 
		JOIN StudentClassRelation scs ON Student.Id = scs.StudentID
		JOIN Class ON Class.Id = scs.ClassID
	WHERE Student.Id IN 
	(
		SELECT StudentClassRelation.StudentID 
		FROM StudentClassRelation
	)
	
	;