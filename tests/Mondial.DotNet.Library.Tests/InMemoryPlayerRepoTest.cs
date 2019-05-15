using System;
using Xunit;
using System.Collections.Generic;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using System.Linq;

namespace Mondial.DotNet.Library.Tests
{
    public class PlayerRepoFactory
    {
        public static IPlayerRepository Create()
            => new InMemoryPlayerRepository();
    }
    public class InMemoryPlayerRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var playerRepo = PlayerRepoFactory.Create();
            
            var player1 = playerRepo.Single(1);
            Assert.True(player1.Id == 1);

            var noplayer = playerRepo.Single(42);
            Assert.True(noplayer == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var playerRepo = PlayerRepoFactory.Create();

            var leSommer = playerRepo.Single(1);
            Assert.True(leSommer.FirstName == "Eugénie");

            var fake = playerRepo.Single(42);
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();
                
            var leSommer = playerRepo.Single(1);
            leSommer.LastName = "Grandet";
            leSommer.DateOfBirth = new DateTime(1989, 5, 18);

            playerRepo.Update(leSommer);
            playerRepo.SaveChanges();

            var FinalCount = playerRepo.Context
                .ToList()
                .Count();

            var leSommerUpdated = 
                playerRepo.Single(leSommer.Id);
            Assert.True(leSommerUpdated.LastName == "Grandet");
            Assert.True(leSommerUpdated.DateOfBirth == new DateTime(1989, 5, 18));
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();
            var renard = new Player() 
            {
                FirstName = "Wendie",
                LastName = "Renard",
                DateOfBirth = new DateTime(1920, 8, 29)
            };
            playerRepo.Update(renard);
            playerRepo.SaveChanges();

            var FinalCount = playerRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var renardCreated = playerRepo.Single(3);
            Assert.True(renardCreated != null);
            Assert.True(renardCreated.FirstName == "Wendie");
            Assert.True(renardCreated.LastName == "Renard");
            Assert.True(!renardCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();

            var leSommer = playerRepo.Single(1);
            playerRepo.Delete(leSommer);
            playerRepo.SaveChanges();
            var finalCount = playerRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(playerRepo.Single(0) == null);
        }

        [Fact]
        public void GetAll()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var contextCount = playerRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = playerRepo
                .GetAll()
                .ToList()
                .Count();

            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var query = playerRepo
                .Find(c => c.FirstName.Contains("e"));
            var result = query.ToList();

            var countPlayersFromQuery = 0;
            foreach(var c in playerRepo.Context.ToList())
            {
                if(c.FirstName.Contains("e"))
                    countPlayersFromQuery++;
            }
            Assert.True(result.Count == countPlayersFromQuery);
        }
    }
}