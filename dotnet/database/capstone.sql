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
	term varchar(200) NOT NULL,
	definition varchar(300) NOT NULL,
	user_id int NOT NULL
	CONSTRAINT PK_card PRIMARY KEY (card_id)
)

CREATE TABLE cardxdeck (
	card_id int NOT NULL,
	deck_id int NOT NULL
	CONSTRAINT PK_cardxdeck PRIMARY KEY (card_id, deck_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--temp deck

INSERT INTO decks (deck_title, deck_tags, deck_desc, user_id) 
	VALUES ('Spanish greetings', 'Spanish', 'learn Spanish greetings with Sara', 1),
	('C# Basics', 'C#', 'learn the basics of the C# language', 2),
	('Circulatory System', 'Anatomy', 'learn about the circulatory system with Abdi', 1),
	('French greetings', 'French', 'learn French with Sara',1),
	('Exercise Basics', 'Physiology', 'learn the basics of exercising with Pendle',1),
	('Manchester United', 'Soccer', 'learn about the miserable state of Manchester United with Abdi', 1),
	('John Facts','Computer Science','learn John facts with Sara', 1)

INSERT INTO cards (term, definition, user_id)
	VALUES ('Hola', 'Hello', 1),
	('Buenas tardes', 'Good Evening', 1),
	('Buenos días', 'Good Morning', 1),
	('Buenas noches', 'Good Night', 1),
	('Adiós', 'Goodbye (Farewell)', 1),
	('Hasta luego', 'See you later', 1),
	('Qué gusto de verlo', 'What a pleasure to see you', 1),
	('Qué pasa', 'Whats up', 1),
	('Snake case','all lower case, underscore instead of spaces, no special characters',2),
	('Pascal case','Text that begins with an uppercase letter and uses an uppercase letter to start each new word. No spaces or underscores.',2),
	('Camel case','Text that begins with a lowercase letter and uses an uppercase letter to start each new word. No spaces or underscores.',2),
	('Ternary operator','A shorthand form of an if/else statement.',2),
	('Objects','An in-memory data structure that are essentially a collection of variables and/or methods',2),
	('Heap','The memory space where arrays and objects go; longterm storage',2),
	('Enumerators','Data type that allows you to move through a collection one item at a time',2),
	('Polymorphism','Principle that allows us to treat objects based on their similarities',2),
	('Encapsulation','Principle of hiding details of class behind limited access points; code within code',2),
	('Method overloading','Having lots of methods with the same name but they all take in different parameters',2),
	('Constructor','Special method that initializes an object of that class. They have the same name as the class they are in and have no return type',2),
	('Private (Keyword)','Keyword declaring that a property or method is only visible from within the class that it is declared in',2),
	('Namespaces','Way to organize classes similar to organizing files on a computer. Is not required but is considered best practice',2),
	('Abstract class','Class that you can not create an instance of. To use this type of class you must inherit from it',2),
	('Data access object','Similar to a class, encapsulates logic for connecting to a data source and returning data',2),
	('Capillaries','The site of exchange with tissues',1),
	('Portal veins','Veins that extend some distance between two capillary networks',1),
	('Arteriosclerosis','general term for degeneration changes in arteries making them less elastic',1),
	('Atherosclerosis','Term for deposition of plaque on walls',1),
	('Poiseulle`s Law','Flow decreases when resistance increases and vice versa',1),
	('Baroreceptor reflex','Changing HR or stoke volume in response to change in BP',1),
	('Chemoreceptor reflex','Sensory receptors detect oxygen, carbon dioxide and pH levels in the blood',1),
	('Ischemic response','Results from high carbon dioxide or low pH, increases peripheral resistance.',1),
	('Net filtration','Force responsible for moving fluid across capillary walls',1),
	('Artery','Muscular-walled tubes forming part of the circulation system by which oxygenated blood is conveyed',1),
	('Vein','tubes forming part of the blood circulation system of the body, carrying in most cases oxygen-depleted blood toward the heart',1),
	('Cómo estás', 'How are you', 1),
	('Hasta mañana', 'See you tommorow',1),
	('Var' ,'_____ is the devil. _____ is raisins to me.',1),
	('ToString()','_____ is my old drinking buddy',1),
	('REST','_____ is the wild west.',1),
	('watermelon','I try to avoid talking about religion, politics, and _____',1)
	








INSERT INTO cardxdeck (card_id, deck_id)
	VALUES (1,1),
	(2,1),
	(3,1),
	(4,1),
	(5,1),
	(6,1),
	(7,1),
	(8,1),
	(9,2),
	(10,2),		
	(11,2),
	(12,2),
	(13,2),
	(14,2),
	(15,2),	
	(16,2),
	(17,2),
	(18,2),
	(19,2),
	(20,2),
	(21,2),
	(22,2),
	(23,2),
	(24,3),
	(25,3),
	(26,3),
	(27,3),
	(28,3),
	(29,3),
	(30,3),
	(31,3),
	(32,3),
	(33,3),
	(34,3),
	(37,7),
	(38,7),
	(39,7),
	(40,7)







--foreign key constraints

ALTER TABLE decks ADD CONSTRAINT user_id_FK_on_decks FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE cards ADD CONSTRAINT user_id_FK_on_cards FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE cardxdeck ADD CONSTRAINT deck_id_FK FOREIGN KEY (deck_id) REFERENCES decks(deck_id);
ALTER TABLE cardxdeck ADD CONSTRAINT card_id_FK FOREIGN KEY (card_id) REFERENCES cards(card_id);

GO