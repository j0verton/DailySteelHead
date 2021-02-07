using System;
using Xunit;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System.Collections.Generic;
using SteelDaily.Repositories;

namespace SteelDaily.Tests
{
    public class StreakRepoTests : EFTestFixture
    {
        public StreakRepoTests()
        {
            AddSampleData();
        }
        [Fact]
        public void GetLongestStreaks_Should_Return_Oldest_Active_Streak_First()
        {
            var repo = new StreakRepository(_context);
            var results = repo.GetLongestStreaks();

            Assert.Equal(3, results[0].Id);        
        }
        [Fact]
        public void GetLongestStreaks_Should_Return_Second_Oldest_Active_Streak_Second()
        {
            var repo = new StreakRepository(_context);
            var results = repo.GetLongestStreaks();

            Assert.Equal(2, results[1].Id);
        }
        [Fact]

        public void GetLongestStreaks_Limits_Five_Return()
        {
            var repo = new StreakRepository(_context);
            var results = repo.GetLongestStreaks();

            Assert.Equal(5, results.Count);
        }
        private void AddSampleData()
        {
            var user1 = new UserProfile()
            {
                Id = 1,
                Username = "SampleGuy",
                FirstName ="sample",
                LastName ="Mcgee",
                Email = "sample@sample.com",
                FirebaseUserId = "sdfasdfaz"
            };

            var user2 = new UserProfile()
            {
                Id = 2,
                Username = "mack",
                FirstName = "sample",
                LastName = "Mcgee",
                Email = "sample@sample.com",
                FirebaseUserId = "sdfasdfssadsad"
            };
            var user3 = new UserProfile()
            {
                Id = 3,
                Username = "jeff",
                FirstName = "sample",
                LastName = "Mcgee",
                Email = "sample@sample.com",
                FirebaseUserId = "sdretwertewertwertaz"
            };
            var user4 = new UserProfile()
            {
                Id = 4,
                Username = "sue",
                FirstName = "sample",
                LastName = "Mcgee",
                Email = "sample@sample.com",
                FirebaseUserId = "2334tgergwsdfasdfaz"
            };
            var streak1 = new Streak()
            {
                Id = 1,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 12, 31),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            var streak7OldestButExpired = new Streak()
            {
                Id = 7,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 11, 21),
                LastUpdate = new DateTime(2021, 2,5)
            };
            var streak2ThirdOldest = new Streak()
            {
                Id = 2,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 12, 1),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            var streak3SecondOldest = new Streak()
            {
                Id = 3,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 11, 30),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            var streak4 = new Streak()
            {
                Id = 4,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 12, 31),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            var streak5 = new Streak()
            {
                Id = 5,
                UserProfileId = 1,
                DateBegun = new DateTime(2020, 12, 31),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            var streak6 = new Streak()
            {
                Id = 6,
                UserProfileId = 1,
                DateBegun = new DateTime(2021, 2, 1),
                LastUpdate = new DateTime(2021, 2, 7)
            };
            _context.Add(user1);
            _context.Add(user2);
            _context.Add(user3);
            _context.Add(user4);
            _context.Add(streak7OldestButExpired);
            _context.Add(streak6);
            _context.Add(streak5);
            _context.Add(streak4);
            _context.Add(streak3SecondOldest);
            _context.Add(streak2ThirdOldest);
            _context.Add(streak1);
            _context.SaveChanges();

        }
    }
}
