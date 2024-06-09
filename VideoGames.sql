/*
    This database will be used for the video game application
*/

USE [master]

IF EXISTS (
        SELECT *
        FROM sys.databases
        WHERE name = 'VideoGames'
        )
BEGIN
    DROP DATABASE [VideoGames]
END
GO

CREATE DATABASE [VideoGames]
GO

USE [VideoGames]
GO


CREATE TABLE [LogIn] (
    UserID      int             NOT NULL    IDENTITY(1,1),
    UserName    VARCHAR(50)     NOT NULL,
    [Password]  VARCHAR(50)     NOT NULL,

    CONSTRAINT PK_User  PRIMARY KEY (UserID)
);

CREATE TABLE Game (
    GameID          int             NOT NULL    IDENTITY (1,1),
    Title           VARCHAR(50)     NOT NULL,
    ReleaseDate     DateTime        NOT NULL,
    Publisher       VARCHAR(50)     NOT NULL,
    Price           decimal(19,2)   NOT NULL,
    Genre           VARCHAR(50)     NOT NULL,
    Rating          int             NOT NULL,
    DownloadSize    decimal(19,2)   NOT NULL,

    CONSTRAINT PK_Game PRIMARY KEY (GameID)
);

CREATE TABLE [Platform] (
    PlatformID      int             NOT NULL    IDENTITY(1,1),
    PlatformName    VARCHAR(50)     NOT NULL,
    ReleaseDate     DateTime        NOT NULL,
    Manufacturer    VARCHAR(50)     NOT NULL,
    [Description]   VARCHAR(50)     NOT NULL,
    Price           decimal(19,2)   NOT NULL,

    CONSTRAINT PK_Platform PRIMARY KEY (PlatformID)
);

CREATE TABLE Library_Games (
    GameID          int             NOT NULL,
    PlatformID      int             NOT NULL,

    CONSTRAINT FK_Games FOREIGN KEY (GameID) REFERENCES Game(GameID),
    CONSTRAINT FK_Platform FOREIGN KEY (PlatformID) REFERENCES Platform(PlatformID)
);

INSERT INTO Game
VALUES
('Call of duty: Modern Warfare 3' , '2024-10-25', 'Activision', 89.99, 'First Person Shooter', 3, 80.9),
('XDefiant' , '2024-05-21', 'Ubisoft', 0.00, 'First Person Shooter', 8, 34.4),
('Marvel''s Spider-Man 2', '2023-10-20', 'Sony Interactive Entertainment', 89.99, 'Action Adventure', 9, 50),
('God of War: Ragnarok', '2022-11-09', 'Sony Interactive Entertainment', 89.99, 'Action Adventure', 9, 60.4),
('NBA 2K24', '2023-09-08', '2K Sports', 89.99, 'Sports', 7, 100.45),
('Minecraft', '2018-09-11', 'Mojang', 30.99, 'Sandbox-Survival', 10, 2.9),
('Grand Theft Auto: V', '2013-09-17', 'Rockstar Games', 15.99, 'Action-Adventure', 9, 55.76),
('Assassin''s Creed Valhalla', '2020-11-11', 'Ubisoft', 59.99, 'Action RPG', 5, 45.43),
('Crash Bandicoot: The Wrath of Cortex', '2001-10-29', 'Konami', 9.99, 'Platformer', 8, 0.00),
('The Last of Us', '2013-06-14', 'Sony Interactive Entertainment', 10.99, 'Action-Adventure', 9, 20),
('Uncharted 4: A thief''s End', '2016-05-10', 'Sony Interactive Entertainment', 24.99, 'Action-Adventure', 10, 35),
('Super Smash Bros Melee', '2001-12-03', 'Nintendo', 5.99, 'Fighting', 8, 0.00);

INSERT INTO [Platform]
VALUES 
('PlayStation 1', '1994-12-03', 'Sony Interactive Entertainment', 'Pioneer Console', 299.00),
('PlayStation 2', '2000-03-04', 'Sony Interactive Entertainment', 'Multimedia Powerhouse', 299.00),
('PlayStation 3', '2006-11-11', 'Sony Interactive Entertainment', 'Entertainment Hub', 499.00),
('PlayStation 4', '2013-11-15', 'Sony Interactive Entertainment', 'Social Gaming', 399.00),
('PlayStation 5', '2020-11-12', 'Sony Interactive Entertainment', 'Next-Gen Innovation', 499.00),
('Xbox', '2001-11-15', 'Microsoft Corporation', 'Microsoft''s first gaming console', 299.00),
('Xbox 360', '2005-11-22', 'Microsoft Corporation', 'Enhanced graphics and online gaming', 299.00),
('Xbox One', '2013-11-22', 'Microsoft Corporation', 'Multimedia and entertainment', 499.00),
('Xbox Series X', '2020-11-10', 'Microsoft Corporation', 'Next-gen gaming powerhouse', 499.00),
('Nintendo Entertainment System (NES)', '1983-07-15', 'Nintendo', 'Revolutionary gaming console', 199.99);

INSERT INTO Library_Games (GameID, PlatformID)
VALUES
(1, 1),  
(1, 4),  
(2, 6),  
(2, 7),  
(3, 5),  
(3, 9),  
(4, 5),  
(4, 9),  
(5, 4),  
(5, 8),  
(6, 10), 
(6, 1),  
(6, 2),  
(6, 3),  
(6, 4),  
(6, 5),  
(6, 6),  
(6, 7),  
(6, 8),  
(6, 9),  
(7, 4),  
(7, 5),  
(7, 6),  
(7, 7),  
(7, 8),  
(7, 9),  
(8, 6),  
(8, 9),  
(9, 6),  
(10, 6), 
(11, 6), 
(12, 10);

INSERT INTO [LogIn] (UserName, [Password])
VALUES
('Kenaan7', 'Kn3n1234');
