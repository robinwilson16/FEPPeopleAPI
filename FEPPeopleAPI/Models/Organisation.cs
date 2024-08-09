using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEPPeopleAPI.Models
{
    public class Organisation
    {
        public int OrganisationID { get; set; }

        [StringLength(100)]
        public string? OrganisationName { get; set; }

        public int? OrganisationTypeID { get; set; }

        public int? OrganisationStatusID { get; set; }

        public OrganisationType? OrganisationType { get; set; }
        public OrganisationStatus? OrganisationStatus { get; set; }

    }
}
