using RateTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateTask.Repositories; // Needs to be added.

namespace RateTask.Services
{
	public class RateService : IRateService
	{
		// Inject repository layer
		private readonly IRateRepository _rateRepository;

		// Define constructor
		public RateService(IRateRepository rateRepository)
		{
			_rateRepository = rateRepository;
		}

		// Create a new rate.
		public RATE Create(RATE rate)
		{
			return _rateRepository.Create(rate);
		}

		// Delete a specific rate by country.
		public void Delete(string id)
		{
			RATE deleteRate = _rateRepository.Read(id);
			_rateRepository.Delete(deleteRate);
		}

		// Get all the rates in the list.
		public List<RATE> Read()
		{
			return _rateRepository.Read();
		}

		// Get a specific rate by country.
		public RATE Read(string country)
		{
			return _rateRepository.Read(country);
		}

		// Update a specific rate by country.
		public RATE Update(RATE rate)
		{
			return _rateRepository.Update(rate);
		}
	}
}
