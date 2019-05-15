using System;
using Xunit;
using System.Collections.Generic;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using System.Linq;

namespace Mondial.DotNet.Library.Tests
{
    public class ContractRepoFactory
    {
        public static IContractRepository Create(IPlayerRepository playerRepository = null, ITeamRepository teamRepository = null)
            => new InMemoryContractRepository(playerRepository ?? new InMemoryPlayerRepository(), teamRepository ?? new InMemoryTeamRepository());
    }
    public class InMemoryContractRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var contractRepo = ContractRepoFactory.Create();
            
            var contract1 = contractRepo.Single(1);
            Assert.True(contract1.Id == 1);

            var nocontract = contractRepo.Single(42);
            Assert.True(nocontract == null);      
        }

        [Fact]
        public void UpdateUpdate()
        {
            var contractRepo = ContractRepoFactory.Create();
            var initialCount = contractRepo.Context
                .ToList()
                .Count();
                
            var contract = contractRepo.Single(1);
            contract.YearFrom = 2007;
            contract.YearTo = 2010;

            contractRepo.Update(contract);
            contractRepo.SaveChanges();

            var FinalCount = contractRepo.Context
                .ToList()
                .Count();

            var contractUpdated = 
                contractRepo.Single(contract.Id);
            Assert.True(contractUpdated.YearFrom == 2007);
            Assert.True(contractUpdated.YearTo == 2010);
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var contractRepo = ContractRepoFactory.Create();
            var initialCount = contractRepo.Context
                .ToList()
                .Count();
            var monptellier = new Contract() 
            {
                YearFrom = 2018,
                YearTo = null
            };
            contractRepo.Update(monptellier);
            contractRepo.SaveChanges();

            var FinalCount = contractRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var montpellierCreated = contractRepo.Single(3);
            Assert.True(montpellierCreated != null);
            Assert.True(montpellierCreated.YearFrom == 2018);
            Assert.True(montpellierCreated.YearTo == null);
            Assert.True(!montpellierCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var contractRepo = ContractRepoFactory.Create();
            var initialCount = contractRepo.Context
                .ToList()
                .Count();

            var contract = contractRepo.Single(1);
            contractRepo.Delete(contract);
            contractRepo.SaveChanges();
            var finalCount = contractRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(contractRepo.Single(0) == null);
        }

        [Fact]
        public void GetAll()
        {
            var contractRepo = ContractRepoFactory.Create();
            var contextCount = contractRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = contractRepo
                .GetAll()
                .ToList()
                .Count();

            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var contractRepo = ContractRepoFactory.Create();
            var query = contractRepo
                .Find(c => c.Signatory.FirstName.Contains("e"));
            var result = query.ToList();

            var countContractsFromQuery = 0;
            foreach(var c in contractRepo.Context.ToList())
            {
                if(c.Signatory.FirstName.Contains("e"))
                    countContractsFromQuery++;
            }
            Assert.True(result.Count == countContractsFromQuery);
        }
    }
}