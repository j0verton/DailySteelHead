
USE [master]
GO

IF db_id('SteelDaily') IS NULL
  CREATE DATABASE [SteelDaily]
GO

USE [SteelDaily]
GO

DROP TABLE IF EXISTS [Scale];
DROP TABLE IF EXISTS [Game];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Result];
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS Challenge;
DROP TABLE IF EXISTS [Streak];
DROP TABLE IF EXISTS [Tuning];
DROP TABLE IF EXISTS [Key];
DROP TABLE IF EXISTS [UserProfile];
GO


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

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId),
  CONSTRAINT UQ_Email UNIQUE(Email)
)

CREATE TABLE [Tuning] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Notes] nvarchar(255)
)


CREATE TABLE [Streak] (
  [Id] int PRIMARY KEY IDENTITY,
  [Days] int,
  [UserProfileId] int,
  [DateBegun] date,
  [LastUpdate] date,

	CONSTRAINT [FK_Streak_UserProfile] FOREIGN KEY ([UserProfileId])
	REFERENCES [UserProfile] ([Id])
)

CREATE TABLE [Result] (
  [Id] int PRIMARY KEY IDENTITY,
  [UserProfileId] int,
  [GameId] int,
  [Key] nvarchar(5),
  [TuningId] int,
  [Questions] nvarchar(255),
  [Answers] nvarchar(255),
  [Date] date,
  [Complete] bit

  	CONSTRAINT [FK_Result_UserProfile] FOREIGN KEY ([UserProfileId])
		REFERENCES [UserProfile] ([Id]),
	CONSTRAINT [FK_Result_Tuning] FOREIGN KEY ([TuningId])
		REFERENCES [Tuning] ([Id])
)

CREATE TABLE [Game] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255)
)

GO


