using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPlayerRepository :
        BaseInMemoryRepository<Player>,
        IPlayerRepository
    {      
        public override List<Player> SampleData =>
            new List<Player>()
            {
                new Player() {Id = 1, FirstName = "Eugénie", LastName = "Le Sommer"},
                new Player() {Id = 2, FirstName = "Amandine", LastName = "Henry"}
            };
    }
}