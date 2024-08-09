using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class Specialism
    {
        public int SpecialismID { get; set; }

        [Display(Name = "Name of Specialism")]
        [StringLength(100)]
        public string? SpecialismName { get; set; }

        public bool? IsEnabled { get; set; } = true;
    }
}
