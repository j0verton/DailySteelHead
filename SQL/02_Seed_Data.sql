SET IDENTITY_INSERT [Tuning] ON
INSERT INTO [Tuning]
  ([Id], [Name], [Notes])
VALUES
  (1, 'E9', 'Gb,Eb,Ab,E,B,Ab,Gb,E,D,B'),
  (2, 'E9AB', 'Gb,Eb,A,E,Db,A,Gb,E,D,Db'),
  (3, 'C6', 'G,E,C,A,G,E,C,A,F,C');

  SET IDENTITY_INSERT [Tuning] OFF
  
  SET IDENTITY_INSERT [Game] ON
INSERT INTO [Game]
  ([Id], [Name])
VALUES
  (1, 'Interval Flash Cards'),
  (2, 'Interval Fretboard'),
  (3, 'Find the Unisons'),
  (4, 'Find the Fifths'),
  (5, 'Play by Ear Challenge');
  SET IDENTITY_INSERT [Game] OFF


  set identity_insert [UserProfile] on
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (1, 'admin', 'Reina', 'Sandwith', 'admin@example.com', '2020-04-23', 'https://robohash.org/numquamutut.png?size=150x150&set=set1', 'HHhIydCh6cYHusJOurjxUGDlShA2');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (2, 'jeffjeffityjeff', 'Jeff', 'Jeff', 'jeff@jeff.com', '2020-04-20', 'https://robohash.org/nisiautemet.png?size=150x150&set=set1', 'qugdVHtN3qZPYtIkRLXkOWeB77r2');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (3, 'aotton2', 'Arnold', 'Otton', 'aotton2@ow.lyx', '2020-01-13', 'https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1', 'wqhvgdjxjqkqecuridpvjtwpoacc');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (4, 'agrzeskowski3', 'Aharon', 'Grzeskowski', 'agrzeskowski3@fc2.comx', '2020-04-12', 'https://robohash.org/doloremfugiatrerum.png?size=150x150&set=set1', 'exsjcqvnhydjofznqmtvecekcgno');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (5, 'ryakushkev4', 'Rosana', 'Yakushkev', 'ryakushkev4@weibo.comx', '2019-08-16', 'https://robohash.org/deseruntutipsum.png?size=150x150&set=set1', 'djwoicosfnhexpmmsnukgcsbnqod');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (6, 'tfigiovanni5', 'Tobi', 'Figiovanni', 'tfigiovanni5@baidu.comx', '2019-10-17', 'https://robohash.org/quiundedignissimos.png?size=150x150&set=set1', 'xiybslspeizewvkixqubnqjlwamz');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (7, 'gteanby6', 'Giuseppe', 'Teanby', 'gteanby6@craigslist.orgx', '2019-08-29', 'https://robohash.org/hicnihilipsa.png?size=150x150&set=set1', 'lzxmysyzqrmcwjzxsyrkbczhspup');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (8, 'cvanderweedenburg7', 'Cristabel', 'Van Der Weedenburg', 'cvanderweedenburg7@wikimedia.orgx', '2019-11-02', 'https://robohash.org/quidemearumtenetur.png?size=150x150&set=set1', 'jqqyiksxkocmhphkylikwcehuvky');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (9, 'ecornfoot8', 'Emmaline', 'Cornfoot', 'ecornfoot8@cargocollective.comx', '2020-02-17', 'https://robohash.org/blanditiismaioresest.png?size=150x150&set=set1','smzswoscvmfpvugpmgvkflihdmka');
insert into UserProfile (Id, Username, FirstName, LastName, Email, CreateDateTime, ImageLocation, FirebaseUserId) values (10, 'jmaruska9', 'Jody', 'Maruska', 'jmaruska9@netscape.comx', '2020-02-09', 'https://robohash.org/voluptatemexercitationemdignissimos.png?size=150x150&set=set1','abcnibyohfhukxngaegjxxzionyt');
set identity_insert [UserProfile] off

SET IDENTITY_INSERT [dbo].[Streak] ON
INSERT INTO [dbo].[Streak] ([Id], [Days], [UserProfileId], [DateBegun], [LastUpdate]) VALUES (1, 5, 2, '2/2/2021', '2/8/2021')
SET IDENTITY_INSERT [dbo].[Streak] OFF

SET IDENTITY_INSERT [dbo].[Result] ON
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root],[TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (1, 2, 1, 'Eb', 1, N'0,3,9,0,5,6,3,1,8,5,1,0,3,1,9,3,15,5,13,9', 'Four,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive','2021-02-07', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (2, 1, 1, 'C', 1, N'15,8,3,2,9,0,14,0,12,0,6,0,4,4,2,6,10,1,8,1', 'Four,Seven,FlatThree,FlatSix,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive', '2021-02-07', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (3, 3, 1, 'E', 1, N'0,7,3,4,12,1,7,8,8,7,7,6,4,8,2,0,16,0,16,1', 'One,Two,Four,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive','2021-02-07', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (4, 4, 1,'D', 1, N'8,2,11,0,16,7,13,9,14,7,11,6,7,3,6,0,0,3,2,1', 'Four,FlatFive,Three,Four,FlatFive,Four,FlatFive,FlatFive,Five,Five', '2021-02-07', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (5, 5, 1, 'D', 1, N'3,8,1,5,2,1,12,4,11,6,11,8,16,0,13,8,8,6,1,3', 'FlatFive,FlatSix,Six,Six,Six,Six,Six,Six,Six,Six', '2021-02-07', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (6, 1, 1,'Db', 1, N'14,9,5,2,9,3,14,5,9,6,0,6,15,1,16,4,7,3,3,2', 'Five,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive,FlatFive', '2021-02-08', 1)
INSERT INTO [dbo].[Result] ([Id], [UserProfileId], [GameId], [Root], [TuningId], [Questions], [Answers], [Date], [Complete]) VALUES (7, 2, 1, 'C', 1, N'6,5,15,5,15,4,3,6,12,9,11,9,3,6,14,9,16,8,3,8', 'Two,Seven,Two,Two,Four,Three,Six,One,Four,Four','2021-02-08', 1)
SET IDENTITY_INSERT [dbo].[Result] OFF

