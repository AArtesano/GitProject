USE GitDatabase
go


INSERT INTO Students (FirstName, MiddleName, LastName, Birthdate)
VALUES
('Francine', 'Saenz', 'Diaz', '01-27-2004'),
('Kyle', 'Paradillo', 'Echarri', '06-20-2003'),
('Blythe', 'Daguio', 'Gorostiza', '03-12-2003'),
('Seth', 'Fronda', 'Fedelin', '07-09-2002'),
('Belinda', 'Angelito', 'Mariano', '06-10-2002'),
('Kurt', 'Miole', 'Dela Cruz', '04-12-2003'),
('Jameson', 'Andrew', 'Blake', '09-07-1997'),
('Sue', 'Garina', 'Dodd', '07-20-1996'),
('Alonzo', 'Tupaz', 'Muhlach', '02-19-2010'),
('Ruelleen', 'Orquia', 'Olano', '05-03-2006'),
('James', 'Aquino', 'Yap', '04-19-2007'),
('Enzo', 'Fahrenheit', 'Dela Cruz', '09-27-2008'),
('Heart', 'Ramos', 'Dela Pena', '02-19-2010'),
('Christopher', 'Abkilan', 'Manguilimutan', '01-25-2009'),
('Rafaela', 'Domagoso', 'Castro', '01-27-2008'),
('Carl', 'Patricio', 'Dela Victoria', '11-27-2012'),
('Brian', 'Javellana', 'Demerin', '03-30-2014'),
('Kyla', 'Solas', 'Barba', '08-21-2015'),
('Andrea', 'Pareno', 'Franco', '12-24-2015'),
('Cassandra', 'Cuneta', 'Concepcion', '04-07-2016'),
('Morgan', 'Go', 'Reyes', '02-11-2003'),
('River', 'Lim', 'Martinez', '01-16-2002'),
('Gary', 'Cruz', 'Elizalde', '02-18-2000'),
('Jian', 'Tiu', 'Ramirez', '12-24-2000'),
('Paige', 'Fajardo', 'Valdez', '10-28-2001'),
('Reverence', 'Velez', 'Reyes', '03-24-1995'),
('Madison', 'Go', 'Reyes', '08-29-1994'),
('Ivy', 'Lim', 'Martinez', '06-20-1999'),
('Celeste', 'Lim', 'Martinez', '12-30-1998'),
('Mariz', 'Cruz', 'Elizalde', '05-17-1992')



SELECT count(CASE WHEN (DATEDIFF(YEAR, Birthdate, GETDATE()) >= 10 
			AND DATEDIFF(YEAR, Birthdate, GETDATE()) <= 18) 
			THEN StudentID ELSE null END) AS 'Age 10 to 18',
       count(CASE WHEN (DATEDIFF(YEAR, Birthdate, GETDATE()) < 10) 
			THEN StudentID ELSE null END) AS 'Age less than 10',
       count(CASE WHEN (DATEDIFF(YEAR, Birthdate, GETDATE()) > 18) 
			THEN StudentID ELSE null END) AS 'Age greater than 18'
FROM Students

SELECT * FROM Students
WHERE LastName LIKE 'Dela%';