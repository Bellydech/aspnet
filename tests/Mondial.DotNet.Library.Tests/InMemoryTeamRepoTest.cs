using System;
using Xunit;
using System.Collections.Generic;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using System.Linq;

namespace Mondial.DotNet.Library.Tests
{
    public class TeamRepoFactory
    {
        public static ITeamRepository Create()
            => new InMemoryTeamRepository();
    }
    public class InMemoryTeamRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var teamRepo = TeamRepoFactory.Create();
            
            var team1 = teamRepo.Single(1);
            Assert.True(team1.Id == 1);

            var noteam = teamRepo.Single(42);
            Assert.True(noteam == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var teamRepo = TeamRepoFactory.Create();

            var ol = teamRepo.Single("Olympique lyonnais");
            Assert.True(ol.Name == "Olympique lyonnais");

            var fake = teamRepo.Single(42);
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var teamRepo = TeamRepoFactory.Create();
            var initialCount = teamRepo.Context
                .ToList()
                .Count();
                
            var ol = teamRepo.Single(1);
            ol.Name = "FC Barcelone";
            ol.Flag = "Ecusson Barça";

            teamRepo.Update(ol);
            teamRepo.SaveChanges();

            var FinalCount = teamRepo.Context
                .ToList()
                .Count();

            var olUpdated = 
                teamRepo.Single(ol.Id);
            Assert.True(olUpdated.Name == "FC Barcelone");
            Assert.True(olUpdated.Flag == "Ecusson Barça");
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var teamRepo = TeamRepoFactory.Create();
            var initialCount = teamRepo.Context
                .ToList()
                .Count();
            var montpellier = new Team() 
            {
                Name = "Montpellier HSC",
                Flag = "Ecusson Montpellier",
                Address = "A côté du stade"
            };
            teamRepo.Update(montpellier);
            teamRepo.SaveChanges();

            var FinalCount = teamRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var montpellierCreated = teamRepo.Single(3);
            Assert.True(montpellierCreated != null);
            Assert.True(montpellierCreated.Name == "Montpellier HSC");
            Assert.True(montpellierCreated.Flag == "Ecusson Montpellier");
            Assert.True(!montpellierCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var teamRepo = TeamRepoFactory.Create();
            var initialCount = teamRepo.Context
                .ToList()
                .Count();

            var ol = teamRepo.Single(1);
            teamRepo.Delete(ol);
            teamRepo.SaveChanges();
            var finalCount = teamRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(teamRepo.Single(0) == null);
        }

        [Fact]
        public void GetAll()
        {
            var teamRepo = TeamRepoFactory.Create();
            var contextCount = teamRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = teamRepo
                .GetAll()
                .ToList()
                .Count();

            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var teamRepo = TeamRepoFactory.Create();
            var query = teamRepo
                .Find(c => c.Name.Contains("e"));
            var result = query.ToList();

            var countTeamsFromQuery = 0;
            foreach(var c in teamRepo.Context.ToList())
            {
                if(c.Name.Contains("e"))
                    countTeamsFromQuery++;
            }
            Assert.True(result.Count == countTeamsFromQuery);
        }
    }
}