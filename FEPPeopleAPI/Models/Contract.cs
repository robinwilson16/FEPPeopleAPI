using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FEPPeopleAPI.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int OrganisationID { get; set; }
        public int PersonID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public Decimal DayRate { get; set; }
        public bool IsExternal { get; set; }

        public ICollection<ContractDay>? ContractDay { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }
        public Organisation? Organisation { get; set; }
    }
}
