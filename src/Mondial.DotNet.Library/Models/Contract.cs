using System;

namespace Mondial.DotNet.Library.Models
{
    public class Contract : BaseModel<Contract>
    {
        // Classe représentant un lien entre une joueuse et un club
        public Player Signatory { get; set; }
        public Team Employer { get; set; }
        public int YearFrom {get; set; }
        public int? YearTo { get; set; }
        // YearTo est null s'il s'agit du club actuel de la joueuse
    }
}