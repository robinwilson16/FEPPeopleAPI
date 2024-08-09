using FEPPeopleAPI.Models;
using FEPPeopleAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FEPPeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Person>> GetAll() =>
            _personService.GetAll();

        [HttpGet("{personID}")]
        [Authorize]
        public ActionResult<Person> Get(int personID)
        {
            var menu = _personService.Get(personID);

            if (menu == null)
                return NotFound();

            return menu;
        }

        [HttpGet("Forename/{forename}")]
        public ActionResult<List<Person>> GetByForename(string forename)
        {
            var people = _personService.GetByForename(forename);

            if (people == null)
                return NotFound();

            return people;
        }

        [HttpGet("Surname/{surname}")]
        public ActionResult<List<Person>> GetBySurname(string surname)
        {
            var people = _personService.GetBySurname(surname);

            if (people == null)
                return NotFound();

            return people;
        }

        [HttpGet("Specialism/{specialismID}")]
        public ActionResult<List<Person>> GetBySpecialism(int specialismID)
        {
            var people = _personService.GetBySpecialism(specialismID);

            if (people == null)
                return NotFound();

            return people;
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _personService.Add(person);
            return CreatedAtAction(nameof(Get), new { PersonID = person.PersonID }, person);
        }

        [HttpPut("{personID}")]
        public IActionResult Update(int personID, Person person)
        {
            if (personID != person.PersonID)
                return BadRequest();

            var existingPersonID = _personService.Get(personID);
            if (existingPersonID is null)
                return NotFound();

            _personService.Update(person);

            return NoContent();
        }

        [HttpDelete("{personID}")]
        public IActionResult Delete(int personID)
        {
            var person = _personService.Get(personID);

            if (person is null)
                return NotFound();

            _personService.Delete(personID);

            return NoContent();
        }
    }
}
