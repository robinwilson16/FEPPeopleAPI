using Microsoft.AspNetCore.Identity;

namespace FEPPeopleAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public string? Forename { get; set; }
        public string? Surname { get; set; }
    }
}
