using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryContractRepository :
        BaseInMemoryRepository<Contract>,
        IContractRepository
    {      
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public InMemoryContractRepository(
            IPlayerRepository playerRepository, ITeamRepository teamRepository
        )
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        public override List<Contract> SampleData =>
            new List<Contract>()
            {
                new Contract() {Id = 1, Signatory = _playerRepository.Single(1), Employer = _teamRepository.Single(1)},
                new Contract() {Id = 2, Signatory = _playerRepository.Single(1), Employer = _teamRepository.Single(2)},
            };
    }
}