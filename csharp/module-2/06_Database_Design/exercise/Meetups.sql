

USE master;
GO

DROP DATABASE IF EXISTS Meetups;

CREATE DATABASE Meetups;
GO

USE Meetups;
GO

BEGIN TRANSACTION;

CREATE TABLE member(
member_number INT IDENTITY(1,1),
last_name VARCHAR(25) NOT NULL,
first_name VARCHAR(25) NOT NULL,
email_address VARCHAR(35) NOT NULL,
phone VARCHAR(15) NULL,
date_of_birth DATE NOT NULL,
reminder_emails BIT NOT NULL,

CONSTRAINT pk_member PRIMARY KEY (member_number)
);

CREATE TABLE interest_group(
group_number INT IDENTITY (1,1),
group_name VARCHAR(50) NOT NULL,
group_members INT NOT NULL,

CONSTRAINT pk_interest_group PRIMARY KEY (group_number),
CONSTRAINT UQ_interest_group UNIQUE (group_name)
);

CREATE TABLE event(
event_number INT IDENTITY (1,1),
event_name VARCHAR(50) NOT NULL,
description VARCHAR(100) NULL,
start_date_time DATETIME,
duration INT,
event_group VARCHAR (50) NOT NULL,
event_members INT NOT NULL,

CONSTRAINT pk_event PRIMARY KEY (event_number),
CONSTRAINT chk_event CHECK (duration >= 30)

);
CREATE TABLE member_group(
member_number INT NOT NULL,
group_number INT NOT NULL,

CONSTRAINT pk_member_group PRIMARY KEY (member_number, group_number),
CONSTRAINT fk_member_group_member FOREIGN KEY (member_number) REFERENCES member(member_number),
CONSTRAINT fk_member_group_group FOREIGN KEY (group_number) REFERENCES interest_group(group_number)

);
CREATE TABLE member_event(
member_number INT NOT NULL,
event_number INT NOT NULL,

CONSTRAINT pk_member_event PRIMARY KEY (member_number, event_number),
CONSTRAINT fk_member_event_member FOREIGN KEY (member_number) REFERENCES member(member_number),
CONSTRAINT fk_member_event_event FOREIGN KEY (event_number) REFERENCES event(event_number)
);

COMMIT;

INSERT INTO member (last_name, first_name, email_address, phone, date_of_birth, reminder_emails)
VALUES('Nye', 'Kevin', 'kevin.nye@aol.com', '12167291422', '10/07/1986', 0),
	('Henderson', 'Rickey', 'rickeyhenderson@gmail.com', '19173339989', '01/08/1961', 1),
	('Berens', 'Jenna', 'jennaberens44@gmail.com', '13343035066', '04/04/1986', 0),
	('Waetjen', 'Nick', 'nicksemail@gmail.com', '14407085188', '09/13/1986', 1),
	('Veenstra', 'Graham', 'grahamveenstra@gmail.com', '14405335900', '11/09/1987', 0),
	('Friedmann', 'Sean', 'seanislame@lamesean.com', '19939399876', '01/08/1995', 1),
	('Lillard', 'Damian', 'dametime99@nba.com', '13149231234', '07/21/1992', 0),
	('LeBron', 'James', 'lebronjames@nbc.com', '13307981234', '12/30/1985', 1)


SELECT * FROM member;
INSERT INTO interest_group (group_name, group_members)
VALUES('Pro athletes', 3),
	('Idiots from Chesterland', 3),
	('People named Rickey Henderson', 1)

--SELECT * FROM interest_group;


INSERT INTO event(event_name, description, start_date_time, duration, event_group, event_members)
VALUES('Dinner date', 'Dinner at my house with all the tallest people', '10/18/2022 19:00', 180, 'Idiots from Chesterland', 6),
	('Lunch date', 'Lunch at a buffet where all they serve is rice dishes', '10/21/2022 12:30', 90, 'People named Rickey Henderson', 2),
	('Walking in Memphis', 'A walk around Memphis, Tennessee', '11/19/2022 12:30', 60, 'Pro athletes', 3),
	('Learning to Code', 'Learning all about c# and whatnot', '12/01/2022 09:00', 240, 'Pro athletes', 2)


--SELECT * FROM event;

INSERT INTO member_event(member_number, event_number)
VALUES
	(1, 4),
	(1, 2),
	(3, 3),
	(4, 1),
	(5, 1),
	(7, 1),
	(8, 1);

--SELECT * FROM member_event;

--INSERT INTO member_event(member_number, event_number)  this didn't work so i've commented it out.
--VALUES--((SELECT member_number FROM member WHERE last_name = 'Henderson'), 2),
--	((SELECT member_number FROM member WHERE last_name = 'Nye'), 4),
--	((SELECT member_number FROM member WHERE last_name = 'Nye'), 2),
--	((SELECT member_number FROM member WHERE last_name = 'Berens'), 3),
--	((SELECT member_number FROM member WHERE last_name = 'James'), 1),
--	((SELECT member_number FROM member WHERE last_name = 'Lillard'), 1),
--	((SELECT member_number FROM member WHERE last_name = 'Veenstra'), 1),
--	((SELECT member_number FROM member WHERE last_name = 'Waetjen'), 1);

--	SELECT * FROM member_event;





INSERT INTO member_group (member_number, group_number)
VALUES (1, 1),
	(1, 2),
	(2, 3),
	(3, 1),
	(4, 2),
	(5, 2),
	(7, 2),
	(8, 2);

SELECT * FROM member_group;