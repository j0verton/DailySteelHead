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
            var result = repo.GetById(1);

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

            _context.Add(E9Tuning);

            //test updating with a new outcome and a new question 
            var Result1 = new Result()
            {
                Id = 1,
                Key = "C",
                TuningId = 1,
                Questions = new List<List<int>>(),
                Outcomes = new List<bool>{ true, true, true}
            };
            //ans = D/2
            Result1.Questions.Add(new List<int> { 11, 2 });
            //ans = C/1
            Result1.Questions.Add(new List<int> { 8, 8 });
            //ans = B/b7
            Result1.Questions.Add(new List<int> { 7, 4 });
            //ans = F/4
            Result1.Questions.Add(new List<int> { 18, 5 });

            //contains 10 questions 10 outcomes test adding an outcome and check for complete to become true
            var Result2 = new Result()
            {
                Id = 2,
                Key = "A",
                TuningId = 1,
                Questions = new List<List<int>>(),
                Outcomes = new List<bool>() { true, true, true, false, false, false, true, false, false, }
            };
            //ans = D/4
            Result2.Questions.Add(new List<int> { 11, 2 });
            //ans = C/b3
            Result2.Questions.Add(new List<int> { 8, 8 });
            //ans = B/2
            Result2.Questions.Add(new List<int> { 7, 4 });
            //ans = F/b6
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 }); 
            Result2.Questions.Add(new List<int> { 18, 5 });
            Result2.Questions.Add(new List<int> { 18, 5 });
            _context.Add(Result1);
            _context.Add(Result2);
        }



    }
}
