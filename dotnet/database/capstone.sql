USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE decks (
	deck_id int IDENTITY(1,1) NOT NULL,
	deck_title varchar(100) NOT NULL,
	deck_tags varchar(50) NOT NULL,
	deck_desc varchar(200) NOT NULL,
	user_id int NOT NULL,
	CONSTRAINT PK_deck PRIMARY KEY (deck_id)
)

CREATE TABLE cards (
	card_id int IDENTITY(1,1) NOT NULL,
	deck_id int NOT NULL,
	term varchar(20) NOT NULL,
	definition varchar(300) NOT NULL,
	user_id int NOT NULL
	CONSTRAINT PK_card PRIMARY KEY (card_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--temp deck

INSERT INTO decks (deck_title, deck_tags, deck_desc, user_id) 
	VALUES ('Spanish greetings', 'Spanish', 'learn Spanish greetings with Sara', 1),
	('Brian Facts', 'Brian', 'learn Brian with Pendle', 2),
	('Somali Food', 'Food', 'learn Somali food with Abdi', 2)

--foreign key constraints

ALTER TABLE decks ADD CONSTRAINT user_id_FK_on_decks FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE cards ADD CONSTRAINT user_id_FK_on_cards FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE cards ADD CONSTRAINT deck_id_FK FOREIGN KEY (deck_id) REFERENCES decks(deck_id);

GO