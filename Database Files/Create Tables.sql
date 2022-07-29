use GitDatabase
go

CREATE TABLE Students
(
    [StudentID] INT NOT NULL IDENTITY (1,1),
    [Firstname] NVARCHAR(500) NOT NULL,
    [Middlename] NVARCHAR(500) NULL,
    [Lastname] NVARCHAR(500) NOT NULL,
    [Birthdate] DATE NOT NULL,
    CONSTRAINT PK_Students PRIMARY KEY Clustered(StudentID)
)
go

 
CREATE TABLE Guardians
(
    [GuardianID] INT NOT NULL IDENTITY (1,1),
    [StudentID] INT NOT NULL,
    [Firstname] NVARCHAR(500) NOT NULL,
    [Middlename] NVARCHAR(500) NULL,
    [Lastname] NVARCHAR(500) NOT NULL,
    [Birthdate] DATE NOT NULL,
	[Relationship] NVARCHAR(500) NOT NULL,
    CONSTRAINT PK_Guardians PRIMARY KEY Clustered(GuardianID),
    CONSTRAINT FK_Guardians_StudentID FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)

INSERT INTO Students (FirstName, MiddleName, LastName, Birthdate)
VALUES
('Mike', 'Horseman', 'Wheeler', '12-23-2002' ),
('Lucas',null, 'Sinclair', '10-13-2001'),
('Will',null, 'Byers',  '10-03-2004'),
('Max', 'Sanchez', 'Mayfield', '04-16-2002'),
('Chrissy',null, 'Cunningham', '10-15-1996'),
('Eddie', null, 'Munson', '05-15-1993')


INSERT INTO Guardians (StudentID, FirstName, MiddleName, LastName, Birthdate, Relationship)
VALUES
(1, 'Bojack', 'Guntham', 'Horseman', '08-20-1986', 'Uncle'),
(2, 'Diane', 'Nguyen', 'Sinclair', '07-23-1983', 'Mother'),
(2, 'Todd', 'Chavez', 'Sinclair', '03-05-1968', 'Father'),
(3, 'Sarah', 'Lynn', 'Byers', '04-15-1974', 'Mother'),
(4, 'Carolyn', 'Parse', 'Sanchez', '11-25-1983', 'Aunt'),
(5, 'Kelsey', 'Littman', 'Cunningham', '06-18-1992', 'Mother'),
(6, 'Margo', 'Martindale' , 'Munson', '02-19-1989', 'Aunt');
go

SELECT Students.StudentID, Students.Firstname, Students.MiddleName, Students.Lastname, Students.Birthdate, 
COUNT(Guardians.GuardianID) AS 'Number of Guardians' FROM Students 
LEFT JOIN Guardians ON Students.StudentID = Guardians.StudentID 
GROUP BY Students.StudentID, Students.Firstname, Students.MiddleName, Students.Lastname, Students.Birthdate;



