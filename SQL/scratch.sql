ALTER TABLE[UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Streak([UserProfileId])
GO

ALTER TABLE [Status] ADD FOREIGN KEY ([Id]) REFERENCES Challenge([StatusId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Results([UserProfileId])
GO

ALTER TABLE Game ADD FOREIGN KEY ([Id]) REFERENCES Results([GameId])
GO

ALTER TABLE [Key] ADD FOREIGN KEY ([Id]) REFERENCES Results([KeyId])
GO

ALTER TABLE Scale ADD FOREIGN KEY ([Id]) REFERENCES Results([ScaleId])
GO

ALTER TABLE [Tuning] ADD FOREIGN KEY ([Id]) REFERENCES Results([TuningId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Post([UserProfileId])
GO

ALTER TABLE Results ADD FOREIGN KEY ([Id]) REFERENCES Post([ResultId])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([Id]) REFERENCES Comment([UserProfileId])
GO

ALTER TABLE Post ADD FOREIGN KEY ([Id]) REFERENCES Comment([PostId])
GO


EXEC sp_rename 'Result.Public', 'Share', 'COLUMN';