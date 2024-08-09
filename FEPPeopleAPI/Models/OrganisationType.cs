using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class OrganisationType
    {
        public int OrganisationTypeID { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool IsEnabled { get; set; }
    }
}
