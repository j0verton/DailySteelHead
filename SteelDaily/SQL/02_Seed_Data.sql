SET IDENTITY_INSERT [Tuning] ON
INSERT INTO [Tuning]
  ([Id], [Name], [Notes])
VALUES
  (1, 'E9', 'B,D,E,F#,G#,B,E,G#,D#,F#'),
  (2, 'E9AB', 'C#,D,E,F#,A,C#,E,A,D#,F#');
  SET IDENTITY_INSERT [Tuning] OFF
  

SET IDENTITY_INSERT [Scale] ON
INSERT INTO [Scale]
  ([Id], [Name], [Pattern])
VALUES
  (1, 'major', '2,2,1,2,2,2,1'),
  (2, 'pentatonic', '2,2,3,2,3');
  SET IDENTITY_INSERT [Scale] OFF
  

SET IDENTITY_INSERT [Key] ON
INSERT INTO [Key]
  ([Id], [Root])
VALUES
  (1, 'C'),
  (2, 'A');
  SET IDENTITY_INSERT [Key] OFF


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
