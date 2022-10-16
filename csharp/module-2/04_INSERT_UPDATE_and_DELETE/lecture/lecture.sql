-- INSERT

-- Add Disneyland to the park table. (It was established on 7/17/1955, has an area of 2.1 square kilometers and does not offer camping.)
INSERT INTO park (park_name, date_established, area, has_camping)
VALUES ('Disneyland', '7/17/1955', '2.1', '0');

SELECT * FROM park -- automatically generates a park_id

-- Add Hawkins, IN (with a population of 30,000 and an area of 38.1 square kilometers) and Cicely, AK (with a popuation of 839 and an area of 11.4 square kilometers) to the city table.
INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Cicely', 'AK', '839', '11.4')

SELECT * FROM city WHERE state_abbreviation = 'AK'

-- Don't use commas when using numbers over 999

-- Since Disneyland is in California (CA), add a record representing that to the park_state table.
INSERT INTO park_state(park_id, state_abbreviation)
-- we can get this info from the park table, but that's bad practice. we should figure out how to get it from the table automatically in case
-- some new thing gets added/removed from the table.
SELECT park_id, 'CA' FROM park WHERE park_name = 'Disneyland'

SELECT * FROM park_state WHERE park_id = '64' -- so now it's into park_state

-- UPDATE

-- Change the state nickname of California to "The Happiest Place on Earth."
UPDATE state SET state_nickname = 'The Happiest Place on Earth.'
WHERE state_name = 'California'

select * FROM state WHERE state_name = 'California'

-- Increase the population of California by 1,000,000.
UPDATE state SET population = population + 1000000 WHERE state_name = 'California'

-- Change the capital of California to Anaheim.
UPDATE state SET capital = (SELECT city_id FROM city WHERE city_name = 'Anaheim' AND state_abbreviation = 'CA') 
WHERE state_name = 'California';


-- Change California's nickname back to "The Golden State", reduce the population by 1,000,000, and change the capital back to Sacramento.
UPDATE state
SET state_nickname = 'The Golden State',
	population -= 1000000,
	capital = (SELECT city_id FROM city WHERE city_name = 'Sacramento' AND state_abbreviation = 'CA')
WHERE state_name = 'California'

SELECT * FROM state WHERE state_name = 'California'

-- DELETE

-- Delete Hawkins, IN from the city table.
--DELETE  FROM city WHERE city_name = 'Hawkins' AND state_abbreviation = 'IN';

-- Delete all cities with a population of less than 1,000 people from the city table.
--DELETE FROM city WHERE population < 1000;


-- REFERENTIAL INTEGRITY

-- Try adding a city to the city table with "XX" as the state abbreviation.
INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES('Kevanaheim', 'XX', 1, 0.1);
-- doesn't work because state_abbreviation doesn't exist. it's a primary/foreign key problem. the XX would have to exist in the state table to exist in city.

-- Try deleting California from the state table.
DELETE FROM state WHERE state_abbreviation = 'CA' -- foreign key problem. doesn't work. 
			-- also doesn't work b/c it's referring to a bunch of other tables. since 'CA' is a foreign key elsewhere, it makes keys in another table null. 
			-- primary key on state, destroys relationship to other tables. 

-- Try deleting Disneyland from the park table. Try again after deleting its record from the park_state table.
DELETE FROM park WHERE park_name = 'Disneyland' -- can't do it first since it's referring to park_state.

DELETE FROM park_state WHERE park_id = (SELECT park_id FROM park WHERE park_name = 'Disneyland'); -- so we delete the relationship.


-- CONSTRAINTS

-- NOT NULL constraint
-- Try adding Smallville, KS to the city table without specifying its population or area.
INSERT INTO city (city_name, state_abbreviation)
VALUES ('Smallville', 'KS'); -- can't do it because column doesn't allow null values. the database will say whether or not a null value is allowed too.

-- DEFAULT constraint
-- Try adding Smallville, KS again, specifying an area but not a population.
INSERT INTO city (city_name, state_abbreviation, area)
VALUES ('Smallville', 'KS', 0.5); -- it automatically inserted a default population of 0. 

-- Retrieve the new record to confirm it has been given a default, non-null value for population.
SELECT * FROM city WHERE city_name = 'Smallville';  -- we have a 0 population. 

-- UNIQUE constraint
-- Try changing California's nickname to "Vacationland" (which is already the nickname of Maine).
UPDATE state SET state_nickname = 'Vacationland' WHERE state_abbreviation = 'CA'
-- can't do a duplicate since this is a key. 

-- CHECK constraint
-- Try changing the census region of Florida (FL) to "Southeast" (which is not a valid census region).
UPDATE state SET census_region = 'Southeast' WHERE state_name = 'Florida';
--checks to see if there's a condition being met. 


-- TRANSACTIONS

-- Delete the record for Smallville, KS within a transaction.
BEGIN TRANSACTION; --begins transaction, uses a semicolon
DELETE FROM city WHERE city_name = 'Smallville'; --this is a complete sql clause.
COMMIT; --committing a transaction makes the changes permanent. 

-- Delete all of the records from the park_state table, but then "undo" the deletion by rolling back the transaction.
BEGIN TRANSACTION;
DELETE FROM park_state; -- No qualifiers. 
SELECT COUNT(*) FROM park_state; -- count number of rows remaining in the table. should be 0. 
ROLLBACK; --roll back the transaction and throw out the changes. don't apply them.
SELECT COUNT(*) FROM park_state;

-- Update all of the cities to be in the state of Texas (TX), but then roll back the transaction.
BEGIN TRANSACTION;
UPDATE city SET state_abbreviation = 'TX' 
SELECT TOP 10 city_name, state_abbreviation FROM city;
ROLLBACK;
SELECT TOP 10 city_name, state_abbreviation FROM city;


-- Demonstrate two different SQL connections trying to access the same table where one is inside of a transaction but hasn't committed yet.
/*BEGIN TRANSACTION;
INSERT INTO city (city_name, state_abbreviation, population, area)
VALUES ('Schrodinger City', 'WV', 0, 0);
*/