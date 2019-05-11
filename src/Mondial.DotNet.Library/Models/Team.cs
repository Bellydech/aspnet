using System;
using System.Collections.Generic;

namespace Mondial.DotNet.Library.Models
{
    public class Team : BaseModel<Team>
    {
        public override int Id { get; set; }
        public string Name{ get; set; }
        public string Flag { get; set; }
        public string Address { get; set; }
        // Coordonnées GPS :
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public List<Contract> ContractCollection { get; set; } = new List<Contract>();
    }
}