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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Contract> ContractCollection { get; set; } = new List<Contract>();

        public Team(string name, string flag, string address, double latitude, double longitude)
        {
            Name = name;
            Flag = flag;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }
        public Team()
        {

        }

        public override void Map(Team copy)
        {
            base.Map(copy);
            Name = copy.Name;
            Flag = copy.Flag;
            Address = copy.Address;
            Latitude = copy.Latitude;
            Longitude = copy.Longitude;
        }
    }
}