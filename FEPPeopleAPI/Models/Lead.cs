using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class Lead
    {
        public int LeadID { get; set; }
        public int OrganisationID { get; set; }
        public int PersonID { get; set; }
        public DateTime EnquiryDate { get; set; }
        public int EstimatedDays { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public Decimal EstimatedDayRate { get; set; }
        public ICollection<LeadDay>? LeadDay { get; set; }

        public ICollection<LeadSpecialism>? LeadSpecialism { get; set; }
    }
}
