using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the surname")]
        public string? Surname { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the forename")]
        public string? Forename { get; set; }

        [Required(ErrorMessage = "Please select the person type")]
        public int? PersonTypeID { get; set; }

        public PersonType? PersonType { get; set; }

        public ICollection<PersonSpecialism>? PersonSpecialism { get; set; }
        public ICollection<PersonAvailability>? PersonAvailability { get; set; }

        public ICollection<Contract>? Contract { get; set; }
    }
}
