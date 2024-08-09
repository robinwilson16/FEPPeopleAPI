using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FEPPeopleAPI.Models
{
    public class PersonSpecialism
    {
        public int PersonSpecialismID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public int SpecialismID { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }

        public Specialism? Specialism { get; set; }
    }
}
