--drop and create database
DROP DATABASE [BITDatabaseMP]
CREATE DATABASE [BITDatabaseMP]
GO

--drop tables
Use BITDatabaseMP
DROP TABLE Availability
DROP TABLE Timeslot
DROP TABLE RejectedJobs
DROP TABLE StaffSkills
DROP TABLE JobRequest
DROP TABLE Staff
DROP TABLE Client
DROP TABLE Dayofweek
DROP TABLE Skills
GO

--table creation
USE BITDatabaseMP
CREATE TABLE Skills (
				skillid INT identity(1,1),
                skillname VARCHAR(50),
                skillabbreviation VARCHAR(4),
				isactive BIT,
                CONSTRAINT Skills_pk PRIMARY KEY (skillid)
)

CREATE TABLE Dayofweek(
				dayid INT identity(1,1),
				dayname VARCHAR(9),
				CONSTRAINT Dayofweek_pk PRIMARY KEY (dayid)
)

CREATE TABLE Timeslot(
				timeid INT IDENTITY(1,1),
				timeslot TIME,
				CONSTRAINT Timeslot_pk PRIMARY KEY (timeid)
				)


CREATE TABLE Client (
                clientid INT identity(1,1),
				firstname VARCHAR(20),
                lastname VARCHAR(20),
                email VARCHAR(50),
                password VARCHAR(30) COLLATE SQL_Latin1_General_Cp1_CS_AS,
                phone VARCHAR(10),
				address VARCHAR(100),
                suburb VARCHAR(30),
				postcode VARCHAR(4),
				state VARCHAR(20),
				isactive BIT,
                CONSTRAINT Client_pk PRIMARY KEY (clientid)
)

CREATE TABLE Staff (
                staffid INT identity(1,1),
                firstname VARCHAR(20),
                lastname VARCHAR(20),
				email VARCHAR(40),
                password VARCHAR(20) COLLATE SQL_Latin1_General_Cp1_CS_AS,
                phone VARCHAR(10),
                address VARCHAR(60),
                suburb VARCHAR(30),
				state VARCHAR(3),
				postcode VARCHAR (4),
				payrate INT NULL,
				stafftype varchar(1),
				isactive BIT,
                CONSTRAINT Staff_pk PRIMARY KEY (staffid)
)

Create TABLE JobRequest (
				jobid INT identity(1,1),
                dateofjob DATE,
                jobaddress VARCHAR(50),
				suburb VARCHAR(20),
				postcode VARCHAR(4),
                clientid INT,
                skillid INT,
                jobdescription VARCHAR(200),
                staffid INT,
				kilometers INT,
				status VARCHAR(9), 
                CONSTRAINT JobRequest_pk PRIMARY KEY (jobid), 

				CONSTRAINT JobRequest_Staff_fk FOREIGN KEY (staffid) 
					REFERENCES Staff(staffid), 


				CONSTRAINT JobRequest_Client_fk FOREIGN KEY (clientid) 
					REFERENCES Client(clientid)
)

CREATE TABLE StaffSkills (
                skillid INT,
                staffid INT,
                CONSTRAINT StaffSkills_pk PRIMARY KEY (skillid, staffid),

				CONSTRAINT StaffSkills_Staff_fk FOREIGN KEY (staffid)
					REFERENCES Staff(staffid),

				CONSTRAINT StaffSkillsSkills_fk FOREIGN KEY (skillid)
					REFERENCES Skills(skillid)
)

CREATE TABLE Availability (
                dayid INT,
                staffid INT,
                starttime DATETIME,
                endtime VARCHAR,
				isAvailable BIT,
                CONSTRAINT Availability_pk PRIMARY KEY (dayid, staffid),

				CONSTRAINT Availability_Staff_fk FOREIGN KEY (staffid)
					REFERENCES Staff(staffid),

				CONSTRAINT Availability_DayofWeek_fk FOREIGN KEY (dayid)
					REFERENCES Dayofweek(dayid)
)

CREATE TABLE RejectedJobs(
				staffid INT,
				jobid INT,
				CONSTRAINT RejectedJobs_pk PRIMARY KEY (staffid, jobid),

				CONSTRAINT RejectedJobs_Staff_fk FOREIGN  KEY (staffid)
					REFERENCES Staff(staffid),

				CONSTRAINT RejectedJobs_JobRequest_fk FOREIGN KEY (jobid)
					REFERENCES JobRequest(jobid)
)
GO

--data insert
USE BITDatabaseMP
INSERT INTO Skills (skillname, skillabbreviation, isactive)
VALUES	('Computer Repair', 'CR', '1'),
		('Email Servcies', 'ES', '1'),
		('iPads & Tablets', 'IT', '1'),
		('Smartphones', 'SP','1'),	
		('Networking & Security', 'NS','1'),
		('Printers', 'PT','1'),
		('Virus & Spyware Removal','VS','1')

use BITDatabaseMP
INSERT INTO Client (email, password, firstname, lastname, address, suburb,
phone, postcode, state, isactive)
VALUES ('bob@bob.com', 'bob', 'bob', 'bobby', '23 street road',' bob town', '0465489126',
'3245', 'NSW' ,'1'), ('bobby@bob.com', 'bobs', 'bobby', 'bobson', '324 bob stree', 'bobville',
'0489315489', '1265','NSW','1')


use BITDatabaseMP
INSERT INTO Staff(email, password, firstname, lastname, stafftype, isactive, payrate)
VALUES 
('steve@steve.com', 'Steve123', 'Steve', 'Steven', 0, 1, 20),
('jack@jack.com', 'Jack123', ' Jack', 'Straton', 0, 1, 30),
('stephen@stephen.com', 'Stephen123', 'Stephen','Steph' , 1, 1, 20),
('karen@karen.com', 'Karen123', 'Karen', 'k', 2, 1, 40),
('Brennan@gmail.com' , 'Brennan123', 'Brennan', 'Crowther', 0, 1, 30),
('Joe@gmail.com', 'Joe123', 'Joe', 'Farrell', 0, 1, 25)

use BITDatabaseMP
INSERT INTO JobRequest(dateofjob, jobaddress, suburb, postcode, clientid, jobdescription, 
skillid, staffid, status)
VALUES 
('2020/03/22', '32 bob street', 'bob town', '3245', '1', 'please help me',
'1' , '1', 'Rejected'), 
('2020/03/19', '25 bob street', 'bob town', '3245', '1', 'please help',
'2' , '1', 'Rejected'),
('2020/03/25', '23 pope street', 'john town', '1422', '1', 'Need Help',
'2' , '1', 'Pending'),
('2020/06/14', '78 Ridge Avenue', 'Ryde', '1422', '2', 'Hacked',
'4' , '2', 'Accepted'),
('2020/12/31', '4 Eddy Road', 'Hornsby', '1657', '2', 'Yes, Help needed',
'5' , '2', 'Completed')


use BITDatabaseMP
INSERT INTO StaffSkills(skillid, staffid)
VALUES
(1, 2),(2,2),(5,1),(3,6),(4,2),(7,2),(2,5),(7,1),(4,5),(4,6),
(1,1),(5,5),(3,2),(5,2),(7,6),(6,2),(3,5),(6,5)


USE BITDatabaseMP
INSERT  INTO Dayofweek(dayname)
VALUES
('Monday'),
('Tuesday'),
('Wednesday'),
('Thursday'),
('Friday'),
('Saturday'),
('Sunday')

USE BITDatabaseMP
INSERT INTO Availability(dayid, staffid, isAvailable)
VALUES
('1', '2', '1'),('2', '2', '0'),
('3', '2', '1'),('4', '2', '1'),
('5', '2', '1'),('6', '2', '1'),
('7', '2', '1'),('1', '5', '1'),
('2', '5', '1'),('3', '5', '1'),
('4', '5', '1'),('5', '5', '1'),
('6', '5', '0'),('7', '5', '1'),
('1', '6', '1'),('2', '6', '1'),
('3', '6', '1'),('4', '6', '1'),
('5', '6', '1'),('6', '6', '1'),
('7', '6', '1')

USE BITDatabaseMP
INSERT INTO Timeslot(timeslot)
VALUES
('8:30:00'),
('9:00:00'),
('9:30:00'),
('10:00:00'),
('10:30:00'),
('11:00:00'),
('11:30:00'),
('12:00:00'),
('12:30:00'),
('13:00:00'),
('13:30:00'),
('14:30:00'),
('15:30:00'),
('16:00:00')
GO

