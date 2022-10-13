-- INSERT

-- Add Disneyland to the park table. (It was established on 7/17/1955, has an area of 2.1 square kilometers and does not offer camping.)
INSERT INTO park (park_name, date_established, area, has_camping) 
VALUES ('Disneyland', '7-17-1955', 2.1, 0);

SELECT * FROM park WHERE park_name = 'Disneyland';

-- Add Hawkins, IN (with a population of 30,000 and an area of 38.1 square kilometers) and 
--Cicely, AK (with a popuation of 839 and an area of 11.4 square kilometers) to the city table.
INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Hawkins', 'IN', 30000, 38.1), ('Cicely', 'AK', 839, 11.4);

SELECT * FROM city WHERE city_name IN ('Hawkins', 'Cicely'); 

-- Since Disneyland is in California (CA), add a record representing that to the park_state table.
INSERT INTO park_state (park_id, state_abbreviation) 
SELECT park_id, 'CA' FROM park WHERE park_name = 'Disneyland'; --select in this case is acting as VALUES

--written the way it's in the book: 
INSERT INTO park_state (park_id, state_abbreviation)
VALUES ((SELECT park_id FROM park WHERE park_name = 'Disneyland'), (SELECT state_abbreviation FROM state WHERE state_name = 'California'));

--VALUES (64, 'CA') --using my human eyeballs to go look at the park_id is not good practice 

SELECT * FROM park_state WHERE park_id = '64';


-- UPDATE

-- Change the state nickname of California to "The Happiest Place on Earth."
UPDATE state SET state_nickname = 'The Happiest Place on Earth' WHERE state_name = 'California';


-- Increase the population of California by 1,000,000.
UPDATE state SET population += 1000000 WHERE state_name = 'California';

SELECT population FROM state WHERE state_abbreviation = 'CA';

-- Change the capital of California to Anaheim.
UPDATE state SET capital = (SELECT city_id FROM city WHERE city_name = 'Anaheim' AND state_abbreviation = 'CA') WHERE state_name = 'California';

SELECT * FROM state WHERE state_name = 'California';

-- Change California's nickname back to "The Golden State", reduce the population by 1,000,000, and change the capital back to Sacramento.
UPDATE state
SET state_nickname = 'The Golden State',
    population -= 2000000,
	capital = (SELECT city_id FROM city WHERE city_name = 'Sacramento' AND state_abbreviation = 'CA')
WHERE state_name = 'California';



-- DELETE

-- Delete Hawkins, IN from the city table.
DELETE FROM city WHERE city_name = 'Hawkins' AND state_abbreviation = 'IN';


-- Delete all cities with a population of less than 1,000 people from the city table.
DELETE FROM city WHERE population < 1000;




-- REFERENTIAL INTEGRITY

-- Try adding a city to the city table with "XX" as the state abbreviation.
INSERT INTO city (city_name, state_abbreviation, population, area) VALUES ('Kevanaheim', 'XX', 1, 0.1); --this doesn't work
SELECT * FROM state WHERE state_abbreviation = 'XX'; --state_abbreviation 'XX' does not exist, so I can't add a city with that foreign key

-- Try deleting California from the state table.
DELETE FROM state WHERE state_abbreviation = 'CA'; --doesn't work, violates reference constraight on foreign key 
--'CA' is a primary key on the state table, and is used as a foreign key in other tables, so deleting the record from the state table
--would destroy the relationships to the other tables 

-- Try deleting Disneyland from the park table. Try again after deleting its record from the park_state table.
DELETE FROM park WHERE park_name = 'Disneyland';

DELETE FROM park_state WHERE park_id = (SELECT park_id FROM park WHERE park_name = 'Disneyland'); --delete the relationship in park_state


-- CONSTRAINTS

-- NOT NULL constraint
-- Try adding Smallville, KS to the city table without specifying its population or area.
INSERT INTO city (city_name, state_abbreviation) VALUES ('Smallville', 'KS'); --fails NOT NULL constraints 


-- DEFAULT constraint
-- Try adding Smallville, KS again, specifying an area but not a population.
INSERT INTO city (city_name, state_abbreviation, area) VALUES ('Smallville', 'KS', 0.5);

-- Retrieve the new record to confirm it has been given a default, non-null value for population.
SELECT * FROM city WHERE city_name = 'Smallville'; 

-- UNIQUE constraint
-- Try changing California's nickname to "Vacationland" (which is already the nickname of Maine).
UPDATE state SET state_nickname = 'Vacationland' WHERE state_name = 'California';


-- CHECK constraint
-- Try changing the census region of Florida (FL) to "Southeast" (which is not a valid census region).
UPDATE state SET census_region = 'Southeast' WHERE state_abbreviation = 'FL';



-- TRANSACTIONS

-- Delete the record for Smallville, KS within a transaction.
BEGIN TRANSACTION; --begin the transaction + ; 
DELETE FROM city WHERE city_name = 'Smallville'; --this is a complete SQL clause;
COMMIT; --committing a transaction makes the changes permanently applied to the database 

-- Delete all of the records from the park_state table, but then "undo" the deletion by rolling back the transaction.
BEGIN TRANSACTION;
DELETE FROM park_state; --no WHERE, all of the danger
SELECT COUNT(*) FROM park_state; --count number of rows remaining in the table
ROLLBACK; --rollback the transaction (throw out the changes, do not apply them to the database)
SELECT COUNT(*) FROM park_state; --count number of rows in the table

-- Update all of the cities to be in the state of Texas (TX), but then roll back the transaction.
BEGIN TRANSACTION;
UPDATE city SET state_abbreviation = 'TX'; 
SELECT TOP 10 city_name, state_abbreviation FROM city;
ROLLBACK;
SELECT TOP 10 city_name, state_abbreviation FROM city;


-- Demonstrate two different SQL connections trying to access the same table where one is inside of a transaction but hasn't committed yet.

SELECT * FROM city WHERE city_name = 'Schrodinger''s City'; 

SELECT * FROM city WITH(NOLOCK) WHERE city_name = 'Schrodinger''s City'; 
