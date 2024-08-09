using FEPPeopleAPI.Data;
using FEPPeopleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FEPPeopleAPI.Services
{
    public class PersonTypeService
    {
        private readonly ApplicationDbContext _context;

        public List<PersonType> PersonTypes { get; }

        public PersonTypeService(ApplicationDbContext context)
        {
            _context = context;

            PersonTypes = _context.PersonType
                .Where(personType => personType.IsEnabled == true)
                .ToList();
        }

        public List<PersonType> GetAll() => PersonTypes;
        public PersonType? Get(int personTypeID) => PersonTypes.FirstOrDefault(personType => personType.PersonTypeID == personTypeID);
        public void Add(PersonType personType)
        {
            PersonTypes.Add(personType);
            _context.PersonType.Add(personType);
            _context.SaveChanges();
        }

        public void Delete(int personTypeID)
        {
            var personType = Get(personTypeID);
            if (personType is null)
                return;

            PersonTypes.Remove(personType);
            _context.PersonType.Remove(personType);
            _context.SaveChanges();
        }

        public void Update(PersonType personType)
        {
            
            var index = PersonTypes.FindIndex(pt => pt.PersonTypeID == personType.PersonTypeID);
            if (index == -1)
                return;
            PersonTypes[index] = personType;

            _context.Attach(personType).State = EntityState.Modified;
            //_context.PersonType.Update(personType);
            _context.SaveChanges();
        }
    }
}
