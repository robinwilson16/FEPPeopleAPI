using System.ComponentModel.DataAnnotations;

namespace FEPPeopleAPI.Models
{
    public class PersonType
    {
        public int PersonTypeID { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool IsEnabled { get; set; }
    }
}
