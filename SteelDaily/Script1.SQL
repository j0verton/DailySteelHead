USE [master]
GO
IF db_id('SteelDaily') IS NULL
  CREATE DATABASE [SteelDaily]
GO
USE [SteelDaily]
GO

DROP TABLE IF EXISTS [Tuning];
DROP TABLE IF EXISTS [UserProfile];

CREATE TABLE [Tuning](
[Id] integer PRIMARY KEY identity NOT NULL,
[Name] nvarchar(255) NOT NULL,
[Notes] nvarchar(25) NOT NULL,
)
GO
SET IDENTITY_INSERT [Tuning] ON
INSERT INTO [Tuning]
  ([Id], [Name], [Notes])
VALUES
  (1, 'E9', 'B,D,E,F#,G#,B,E,G#,D#,F#'),
  (2, 'E9AB', 'C#,D,E,F#,A,C#,E,A,D#,F#');
  SET IDENTITY_INSERT [Tuning] OFF
  

