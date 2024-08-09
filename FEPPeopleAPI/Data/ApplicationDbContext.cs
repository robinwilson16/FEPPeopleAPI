using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using FEPPeopleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FEPPeopleAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<ContractDay> ContractDay { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadDay> LeadDay { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<OrganisationStatus> OrganisationStatus { get; set; }
        public DbSet<OrganisationType> OrganisationType { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonAvailability> PersonAvailability { get; set; }
        public DbSet<PersonSpecialism> PersonSpecialism { get; set; }
        public DbSet<PersonType> PersonType { get; set; }
        public DbSet<Specialism> Specialism { get; set; }
    }
}
