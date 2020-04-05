using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExample.Repositories; // Needs to be added.
using CurrencyExample.Models; // Needs to be added.

namespace CurrencyExample.Services
{
	public class CurrencyService : ICurrencyService
	{
		// Inject repository layer
		private readonly ICurrencyRepository _currencyRepository;

		// Define constructor
		public CurrencyService(ICurrencyRepository currencyRepository)
		{
			_currencyRepository = currencyRepository;
		}

		// Create a new rate.
		public RATE Create(RATE rate)
		{
			return _currencyRepository.Create(rate);
		}

		// Delete a specific rate by country.
		public void Delete(string id)
		{
			RATE deleteRate = _currencyRepository.Read(id);
			_currencyRepository.Delete(deleteRate);
		}

		// Get all the rates in the list.
		public List<RATE> Read()
		{
			return _currencyRepository.Read();
		}

		// Get a specific rate by country.
		public RATE Read(string country)
		{
			return _currencyRepository.Read(country);
		}

		// Update a specific rate by country.
		public RATE Update(RATE rate)
		{
			return _currencyRepository.Update(rate);
		}
	}
}
