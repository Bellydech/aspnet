using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mondial.DotNet.Library.Models
{
    public class Player : BaseModel<Player>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public override string Name 
        {
            get { return $"{FirstName} {LastName.ToUpper()}"; }
        }

        public DateTime? DateOfBirth { get; set; }
        public string Image { get; set; }
        public List<Contract> ContractCollection { get; set; } = new List<Contract>();

        public Player(string firstName, string lastName, DateTime dateOfBirth, string image) : this(firstName, lastName, dateOfBirth)
        {
            Image = image;
        }
        public Player(string firstName, string lastName, DateTime dateOfBirth) : this(firstName, lastName) 
        {
            DateOfBirth = dateOfBirth;
        }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Player()
        {
            
        }

        public override void Map(Player copy)
        {
            base.Map(copy);
            FirstName = copy.FirstName;
            LastName = copy.LastName;
            DateOfBirth = copy.DateOfBirth;
        }

        public override dynamic ToDynamic() 
        {
            var baseDynamic = base.ToDynamic();
            baseDynamic.firstName = FirstName;
            baseDynamic.lastName = LastName;
            baseDynamic.dateOfBirth = DateOfBirth.Value.ToShortDateString();
            return baseDynamic;
        }
    }
}