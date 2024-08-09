using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FEPPeopleAPI.Models
{
    public class Holiday
    {
        public int HolidayID { get; set; }
        public int PersonID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }
    }
}
