using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonExample.Models;
using PersonExample.Repositories; // Needs to be added
using PersonExample.Services;

namespace PersonExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // Inject repository layer
        private readonly IPersonRepository _personRepository;

        // Inject service layer
        private readonly IPersonService _personService;

        // Define constructor
        public PersonsController(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }

        // GET: api/Persons
        // Get all the persons in the list.
        [HttpGet]
        public IActionResult Get()
        {
            var result = _personRepository.Read();
            return new JsonResult(result);
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Persons/5
        // Get specific person by ID.
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var result = _personService.Read(id);
            return new JsonResult(result);
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var result = _personRepository.Create(person);
            return new JsonResult(result);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
