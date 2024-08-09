using System.ComponentModel.DataAnnotations;

namespace FEPPeopleAPI.Models
{
    public class LeadDay
    {
        public int LeadDayID { get; set; }

        [Required]
        public int LeadID { get; set; }

        [Range(1, 7, ErrorMessage = "Day must be between 1 and 7")]
        [Required]
        public int DayID { get; set; }
    }
}
