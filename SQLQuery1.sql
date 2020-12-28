Create database Subjects
GO

Use Subjects
GO

Create Table Type_User
(
Id_Type_User int not null,
Name_Type varchar(8) not null
Constraint Pk_Type_User Primary key (Id_Type_User)
)


Create Table Users
(
File_Number int Identity (1,1) not null,
Dni int unique not null,
Id_Type_User_U int not null,
Users_state bit default 1,
Constraint Pk_Users Primary key (File_Number),
Constraint Fk_Users_Type_User Foreign key (Id_Type_User_U) References Type_User(Id_Type_User)
)

Create Table Teachers
(
Id_Teacher int Identity(1,1) not null,
Dni int unique not null,
Teacher_Name varchar(40) not null,
Teacher_LastName varchar(40) not null,
Teacher_State bit default 1,
Constraint Pk_Teachers Primary key (Id_Teacher),
)

Create Table Subjects
(
Subject_Id int Identity (1,1) not null,
Subject_Name varchar(40) not null,
Subject_StartTime time not null,
Subject_EndingTime time not null,
Subject_Day varchar(15) not null,
Subject_Id_Teacher int not null,
Subject_Quota int not null,
Subject_State bit default 1,
Constraint Pk_Subjects Primary key (Subject_Id),
Constraint Fk_Subjects_Teachers Foreign key (Subject_Id_Teacher) References Teachers(Id_Teacher)
)

Create Table SubjectsxStudents
(
File_Number_SxS int not null References Users(File_Number),
Subject_Id_SxS int not null References Subjects(Subject_Id),
Constraint Pk_SubjectsxStudents Primary key(File_Number_SxS,Subject_Id_SxS)
)
Go

------------------------------------------------------------------------------------------------------------------------------

Insert Into Type_User (Id_Type_User, Name_Type)
Select 1, 'Admin' Union
Select 2, 'Student'
Go

Insert Into Users(Dni,Id_Type_User_U)
Select 123,1 Union
Select 456,2 Union
Select 789,2 Union
Select 147,2 Union
Select 321,2
Go

Insert Into Teachers(Dni,Teacher_Name,Teacher_LastName)
Select 10, 'Tamara', 'Herrera' Union
Select 11, 'Angel', 'Simon' Union
Select 12, 'Daniel', 'Kloster' 
Go

Insert Into Subjects(Subject_Name,Subject_StartTime,Subject_EndingTime,Subject_Day,Subject_Id_Teacher,Subject_Quota)
Select 'Programacion', '08:30','11:00', 'Lunes',2,4 Union
Select 'Matematicas', '08:30', '11:00', 'Martes',1,4 Union
Select 'Base de Datos', '09:30', '12:00', 'Lunes',3,3 
Go


-----------------------------------------------------Store Procedures-----------------------------------------
Create Procedure SP_Quota
@Id int
As
Begin
Update Subjects
Set
Subject_Quota = Subject_Quota -1
Where Subject_Id = @Id
End
Go

Create Procedure SP_StudentxSubject
@Id_Student int,
@Id_Subject int
As
Begin
Exec SP_Quota @Id_Subject
Insert Into SubjectsxStudents(File_Number_SxS,Subject_Id_SxS)
Select @Id_Student, @Id_Subject
End
Go


