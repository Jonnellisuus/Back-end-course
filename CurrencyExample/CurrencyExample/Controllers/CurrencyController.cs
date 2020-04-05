using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CurrencyExample.Models; // Needs to be added.
using CurrencyExample.Repositories; // Needs to be added.
using CurrencyExample.Services; // Needs to be added.

namespace CurrencyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        // Inject repository layer
        private readonly ICurrencyRepository _currencyRepository;

        // Inject service layer
        private readonly ICurrencyService _currencyService;

        // Define constructor
        public CurrencyController(ICurrencyRepository currencyRepository, ICurrencyService currencyService)
        {
            _currencyRepository = currencyRepository;
            _currencyService = currencyService;
        }

        // GET: api/Rate
        // Get all the rates in the list.
        [HttpGet]
        public IActionResult Get()
        {
            var getRates = _currencyRepository.Read();
            return new JsonResult(getRates);
        }

        // GET: api/Rate/5
        // Get a specific rate by country.
        [HttpGet("{country}", Name = "Get")] // If there is more than one controller -- Name = "Get" -- needs to be removed from every controller.
        public IActionResult Get(string country)
        {
            var getRate = _currencyService.Read(country);

            return new JsonResult(getRate);
        }

        // POST: api/Rate
        // Create a new rate.
        [HttpPost]
        public IActionResult Post([FromBody] RATE rate)
        {
            var createRate = _currencyService.Create(rate);
            return new JsonResult(createRate);
        }

        // PUT: api/Rate/5
        // Update a specific rate by country.
        [HttpPut("{country}")]
        public ActionResult Put([FromBody] RATE rate)
        {
            var updateRate = _currencyService.Update(rate);
            return new JsonResult(updateRate);
        }

        // DELETE: api/ApiWithActions/5
        // Delete a specific rate by country.
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _currencyService.Delete(id);
        }




        // GET: api/Rate/{amount}/{fromCurrency}/{toCurrency}
        // Currency converter.
        [HttpGet("{amount}/{fromCurrency}/{toCurrency}")]
        public IActionResult Get(decimal amount, string fromCurrency, string toCurrency)
        {
            var getCurrencyFrom = _currencyService.Read(fromCurrency);
            var getCurrencyTo = _currencyService.Read(toCurrency);

            var rateValue = getCurrencyTo.Rate1 / getCurrencyFrom.Rate1 * amount;

            var rateResult = new ForexResult
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Amount = amount,
                ConvertedCurrency = rateValue
            };

            return new JsonResult(rateResult);
        }
    }
}
