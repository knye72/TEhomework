INSERT INTO park(park_name, date_established, area, has_camping) 
OUTPUT INSERTED.park_id
VALUES('My New Park 2', '10/19/2022', 6, 1);

select * from park_state;

--to insert into the park state table:

INSERT INTO park_state(park_id, state_abbreviation)
VALUES(67, OH);

INSERT INTO project(name, from_date, to_date)
VALUES(

SELECT * FROM park_state WHERE park_id = 68; --changing this to delete instead of select should get rid of that connection.

SELECT first_name, last_name FROM employee JOIN project_employee ON project_employee.employee_id = employee.employee_id; 

SELECT * FROM project_employee 

SELECT * FROM employee
JOIN project_employee ON employee.employee_id = project_employee.employee_id
WHERE project_id IS NULL