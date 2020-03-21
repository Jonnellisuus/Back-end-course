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
        // Get all the rates in the list.
        [HttpGet]
        public IActionResult Get()
        {
            var getRates = _rateRepository.Read();
            return new JsonResult(getRates);
        }

        // GET: api/Rate/5
        // Get a specific rate by country.
        [HttpGet("{country}", Name = "Get")] // If there is more than one controller -- Name = "Get" -- needs to be removed from every controller.
        public IActionResult Get(string country)
        {
            var getRate = _rateService.Read(country);
            return new JsonResult(getRate);
        }

        // POST: api/Rate
        // Create a new rate.
        [HttpPost]
        public IActionResult Post([FromBody] RATE rate)
        {
            var createRate = _rateService.Create(rate);
            return new JsonResult(createRate);
        }

        // PUT: api/Rate/5
        // Update a specific rate by country.
        [HttpPut("{country}")]
        public ActionResult Put([FromBody] RATE rate)
        {
            var updateRate = _rateService.Update(rate);
            return new JsonResult(updateRate);
        }

        // DELETE: api/ApiWithActions/5
        // Delete a specific rate by country.
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _rateService.Delete(id);
        }
    }
}
