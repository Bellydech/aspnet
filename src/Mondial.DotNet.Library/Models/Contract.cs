using System;

namespace Mondial.DotNet.Library.Models
{
    public class Contract : BaseModel<Contract>
    {
        // Classe représentant un lien entre une joueuse et un club
        public Player Signatory { get; set; }
        public Team Employer { get; set; }

        public int? SignatoryId { get; set; }
        public int? EmployerId { get; set; }
        public int YearFrom {get; set; }
        public int? YearTo { get; set; }
        // YearTo est null s'il s'agit du club actuel de la joueuse

        public Contract(Player signatory, Team employer, int yearFrom, int? yearTo)
        {
            Signatory = signatory;
            Employer = employer;
            YearFrom = yearFrom;
            YearTo = yearTo;
        }

        public Contract()
        {

        }

        public override void Map(Contract copy)
        {
            base.Map(copy);
            Signatory = copy.Signatory;
            Employer = copy.Employer;
            EmployerId = copy.EmployerId;
            SignatoryId = copy.SignatoryId;
            YearFrom = copy.YearFrom;
            YearTo = copy.YearTo;
        }

        public override dynamic ToDynamic() 
        {
            var baseDynamic = base.ToDynamic();
            baseDynamic.player = Signatory;
            baseDynamic.team = Employer;
            return baseDynamic;
        }
    }
}