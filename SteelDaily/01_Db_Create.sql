
USE [master]
GO

IF db_id('SteelDaily') IS NULL
  CREATE DATABASE [SteelDaily]
GO

USE [SteelDaily]
GO


DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS Tuning;
DROP TABLE IF EXISTS [Key];
DROP TABLE IF EXISTS Streak;
DROP TABLE IF EXISTS Challenge;
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS Results;
DROP TABLE IF EXISTS Post;
DROP TABLE IF EXISTS Comment;
DROP TABLE IF EXISTS Game;
DROP TABLE IF EXISTS Scale;

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Username] nvarchar(255),
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(555) NOT NULL,
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [Description] nvarchar(255),

)
GO

CREATE TABLE [Tuning] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Notes] nvarchar(255)
)
GO

CREATE TABLE [Key] (
  [Id] int PRIMARY KEY IDENTITY,
  [Root] nvarchar(255)
)
GO

CREATE TABLE Streak (
  [Id] int PRIMARY KEY IDENTITY,
  [Days] int,
  [UserProfileId] int,
  [DateBegun] date,
  [LastUpdate] date
)
GO

CREATE TABLE Challenge (
  [Id] int PRIMARY KEY IDENTITY,
  [StatusId] int,
  [UserProfileIdOne] int,
  [UserProfileIdTwo] int
)
GO

CREATE TABLE [Status] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255)
)
GO

CREATE TABLE Results (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [GameId] int,
  [KeyId] int,
  [ScaleId] int,
  [TuningId] int,
  [Public] bit,
  [Date] date
)
GO

CREATE TABLE Post (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [Title] nvarchar(255),
  [Content] nvarchar(255),
  [ResultId] int
)
GO

CREATE TABLE Comment (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [PostId] int
)
GO

CREATE TABLE Game (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255)
)
GO

CREATE TABLE Scale (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Pattern] nvarchar(255)
)
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Streak ([UserProfileId])
GO

ALTER TABLE [Status] ADD FOREIGN KEY ([Id]) REFERENCES Challenge ([StatusId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Results ([UserProfileId])
GO

ALTER TABLE Game ADD FOREIGN KEY ([Id]) REFERENCES Results ([GameId])
GO

ALTER TABLE [Key] ADD FOREIGN KEY ([Id]) REFERENCES Results ([KeyId])
GO

ALTER TABLE Scale ADD FOREIGN KEY ([Id]) REFERENCES Results ([ScaleId])
GO

ALTER TABLE [Tuning] ADD FOREIGN KEY ([Id]) REFERENCES Results ([TuningId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Post ([UserProfileId])
GO

ALTER TABLE Results ADD FOREIGN KEY ([Id]) REFERENCES Post ([ResultId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Comment ([UserProfileId])
GO

ALTER TABLE Post ADD FOREIGN KEY ([Id]) REFERENCES Comment ([PostId])
GO