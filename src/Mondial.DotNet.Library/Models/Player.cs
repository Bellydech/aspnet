using System;
using System.Collections.Generic;

namespace Mondial.DotNet.Library.Models
{
    public class Player : BaseModel<Player>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<Contract> ContractCollection { get; set; } = new List<Contract>();

        public Player(string firstName, string lastName, DateTime dateOfBirth) : this(firstName, lastName) 
        {
            DateOfBirth = dateOfBirth;
        }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}