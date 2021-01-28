USE [master]
GO
IF db_id('SteelDaily') IS NULL
  CREATE DATABASE [SteelDaily]
GO
USE [SteelDaily]
GO

DROP TABLE IF EXISTS [Tuning];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Key];
DROP TABLE IF EXISTS [Scale];


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
  
  CREATE TABLE [Scale](
[Id] integer PRIMARY KEY identity NOT NULL,
[Name] nvarchar(255) NOT NULL,
[Pattern] nvarchar(25) NOT NULL,
)
GO
SET IDENTITY_INSERT [Scale] ON
INSERT INTO [Scale]
  ([Id], [Name], [Pattern])
VALUES
  (1, 'major', '2,2,1,2,2,2,1'),
  (2, 'pentatonic', '2,2,3,2,3');
  SET IDENTITY_INSERT [Scale] OFF
  

CREATE TABLE [Key](
[Id] integer PRIMARY KEY identity NOT NULL,
[Root] nvarchar(25) NOT NULL,
)
GO
SET IDENTITY_INSERT [Key] ON
INSERT INTO [Key]
  ([Id], [Root])
VALUES
  (1, 'C'),
  (2, 'A');
  SET IDENTITY_INSERT [Key] OFF

