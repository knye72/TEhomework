-- writing a thing

-- switch to using the system database.
USE master;
GO -- batch separator: run the command and then move on to the next step. if the next step fails, it'll still be on master. 

--check to see if the database already exists. if it does, drop it.  (drop = delete)
DROP DATABASE IF EXISTS ArtGallery;

--create DB
CREATE DATABASE ArtGallery; -- Can't create a database without using master.
GO

--in order to add tables to the artGallery DB, you want to be using the ARtGallery DB
USE ArtGallery;
GO

-- adding tables. all tables should be created or none of them, so use a transaction.
BEGIN TRANSACTION;
--making customer table.
CREATE TABLE customer (
-- column name, data type, maybe identity, Constraint
	customer_id INT IDENTITY(1,1), -- IDENTITY is a MS SQL server auto-incrementing thing, usually used for primary keys. 1,1 = start at 1 and increase by 1.
	customer_name VARCHAR(50) NOT NULL, --setting character limit of 50 on names.
	address VARCHAR(100) NOT NULL,
	phone VARCHAR(15) NOT NULL, 

	--ADD primary key constraint
	--CONSTRAINT (constraint name) TYPE (column name)
	CONSTRAINT pk_customer PRIMARY KEY (customer_id)
);

CREATE TABLE artist(
artist_id INT IDENTITY (1,1),
artist_name VARCHAR(50) NOT NULL,
address VARCHAR(100) NOT NULL,
phone VARCHAR(15) NOT NULL, 

CONSTRAINT pk_artist PRIMARY KEY (artist_id)
);

CREATE TABLE artwork(
artwork_id INT IDENTITY(1,1),
description VARCHAR(200) NULL, -- Can be null. 
title VARCHAR(100) NOT NULL,
artist_id INT NOT NULL,

CONSTRAINT pk_artwork PRIMARY KEY (artwork_id),
CONSTRAINT fk_artist FOREIGN KEY (artist_id) REFERENCES artist(artist_id)
--CONSTRAINT name FOREIGN KEY column name REFERENCES tablename(columnname)
);

CREATE TABLE artwork_customer (
customer_id INT NOT NULL, -- coming from someplace else so we dont need IDENTITY here
artwork_id INT NOT NULL,
purchase_date DATE NOT NULL,

CONSTRAINT pk_artwork_customer PRIMARY KEY (customer_id, artwork_id), --copmosite primary key based on two columns. surprisingly easy.
CONSTRAINT fk_artwork_customer_customer FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
CONSTRAINT fk_artwork_customer_artwork FOREIGN KEY (artwork_id) REFERENCES artwork(artwork_id)
);

COMMIT;
--homework info/criteria: script should build a DB. that's all. make sure it builds. try it occasionally ot make sure it runs.