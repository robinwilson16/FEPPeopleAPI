using FEPPeopleAPI.Models;
using FEPPeopleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FEPPeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonTypeController : ControllerBase
    {
        private readonly PersonTypeService _personTypeService;

        public PersonTypeController(PersonTypeService personTypeService)
        {
            _personTypeService = personTypeService;
        }

        [HttpGet]
        public ActionResult<List<PersonType>> GetAll() =>
            _personTypeService.GetAll();

        [HttpGet("{personID}")]
        public ActionResult<PersonType> Get(int personTypeID)
        {
            var menu = _personTypeService.Get(personTypeID);

            if (menu == null)
                return NotFound();

            return menu;
        }

        [HttpPost]
        public IActionResult Create(PersonType personType)
        {
            _personTypeService.Add(personType);
            return CreatedAtAction(nameof(Get), new { PersonTypeID = personType.PersonTypeID }, personType);
        }

        [HttpPut("{personID}")]
        public IActionResult Update(int personTypeID, PersonType personType)
        {
            if (personTypeID != personType.PersonTypeID)
                return BadRequest();

            var existingPersonTypeID = _personTypeService.Get(personTypeID);
            if (existingPersonTypeID is null)
                return NotFound();

            _personTypeService.Update(personType);

            return NoContent();
        }

        [HttpDelete("{personID}")]
        public IActionResult Delete(int personTypeID)
        {
            var personType = _personTypeService.Get(personTypeID);

            if (personType is null)
                return NotFound();

            _personTypeService.Delete(personTypeID);

            return NoContent();
        }
    }
}
