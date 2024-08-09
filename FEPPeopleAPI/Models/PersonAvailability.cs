using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class PersonAvailability
    {
        public int PersonAvailabilityID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Range(1, 7, ErrorMessage = "Day must be between 1 and 7")]
        [Required]
        public int DayID { get; set; }
    }
}
