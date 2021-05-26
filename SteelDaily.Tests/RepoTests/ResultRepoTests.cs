using System;
using Xunit;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System.Collections.Generic;
using SteelDaily.Repositories;

namespace SteelDaily.Tests
{
    public class ResultsRepoTests : EFTestFixture
    {
        public ResultsRepoTests()
        {
            AddSampleData();
        }

        //[Fact]
        //public void Updating_With_Outcome_And_Question_Should_Create_Matching_Outcome_And_Question()
        //{
        //    var repo = new ResultRepository(_context);
        //    repo.Update
        
        //}

        [Fact]
        public void Result_With_Ten_Outcomes_Complete_Should_Return_True()
        {
            var repo = new ResultRepository(_context);
            var result = repo.GetById(2);

            Assert.True(result.Complete);
        }



        private void AddSampleData()
        {
            var E9Tuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,F#,G#,B,E,G#,D#,F#"
            };
            var chromScale = new Scale()
            {
                Id = 1,
                Name = "Chromatic"
            };

            _context.Add(E9Tuning);
            _context.Add(chromScale);

            //test updating with a new outcome and a new question 
            var Result1 = new Result()
            {
                Id = 1,
                TuningId = 1,
                Questions = "11,2,8,8,7,4,18,5",
                Answers = "2,1,b7,4",
                Complete = false
            };

            
            //contains 10 questions 10 outcomes test adding an outcome and check for complete to become true
            var Result2 = new Result()
            {
                Id = 2,
                TuningId = 1,
                Questions = "11,2,8,8,7,4,18,5,18,5,18,5,18,5,18,5,18,5,18,5",
                Answers = "2,1,b7,4",
                Complete = true
            };
            _context.Add(Result1);
            _context.Add(Result2);
            _context.SaveChanges();
        }



    }
}
