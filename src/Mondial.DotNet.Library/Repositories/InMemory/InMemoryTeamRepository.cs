using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryTeamRepository :
        BaseInMemoryRepository<Team>,
        ITeamRepository
    {      
        public override List<Team> SampleData =>
            new List<Team>()
            {
                new Team(){Id = 1, Name = "Olympique lyonnais"},
                new Team(){Id = 2, Name = "Paris Saint-Germain"}
            };
    }
}