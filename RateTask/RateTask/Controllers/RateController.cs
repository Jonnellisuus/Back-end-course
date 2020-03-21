using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateTask.Models; // Needs to be added.
using RateTask.Repositories; // Needs to be added.
using RateTask.Services; // Needs to be added.

namespace RateTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        // Inject repository layer
        private readonly IRateRepository _rateRepository;

        // Inject service layer
        private readonly IRateService _rateService;

        // Define constructor
        public RateController(IRateRepository rateRepository, IRateService rateService)
        {
            _rateRepository = rateRepository;
            _rateService = rateService;
        }

        // GET: api/Rate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rate
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rate/5
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
