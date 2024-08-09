using FEPPeopleAPI.Data;
using FEPPeopleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FEPPeopleAPI.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _context;

        public List<Person> People { get; }

        public PersonService(ApplicationDbContext context)
        {
            _context = context;

            People = _context.Person
                .Include(person => person.PersonType)
                .Include(person => person.PersonSpecialism)
                !.ThenInclude(personSpecialism => personSpecialism.Specialism)
                .Include(person => person.PersonAvailability)
                .Include(person => person.Contract)
                !.ThenInclude(contract => contract.ContractDay)
                .Include(person => person.Contract)
                !.ThenInclude(contract => contract.Organisation)
                !.ThenInclude(organisation => organisation!.OrganisationType)
                .AsNoTracking()
                .ToList();
        }

        public List<Person> GetAll() => People;
        public Person? Get(int personID) => People.FirstOrDefault(person => person.PersonID == personID);
        public List<Person> GetByForename(string forename) => People.Where(person => person.Forename == forename).ToList();
        public List<Person> GetBySurname(string surname) => People.Where(person => person.Surname == surname).ToList();
        public List<Person> GetBySpecialism(int specialismID) => _context.Person
            .Include(person => person.PersonSpecialism)
            !.ThenInclude(personSpecialism => personSpecialism.Specialism!.SpecialismID == specialismID)
            .AsNoTracking() //Needed for Where
            .ToList();

        public void Add(Person person)
        {
            People.Add(person);
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void Delete(int personID)
        {
            var person = Get(personID);
            if (person is null)
                return;

            People.Remove(person);
            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            
            var index = People.FindIndex(p => p.PersonID == person.PersonID);
            if (index == -1)
                return;
            People[index] = person;

            _context.Attach(person).State = EntityState.Modified;
            //_context.Person.Update(person);
            _context.SaveChanges();
        }
    }
}
