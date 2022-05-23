CREATE VIEW [dbo].[FullStudents]
	AS 
	SELECT Student.FirstName, Student.LastName, Student.PhoneNumber, Student.Address, CONCAT(Class.Number, Class.Letter) AS 'Class'
	FROM Student 
		JOIN Class ON Class.Id = Student.ClassID
	;