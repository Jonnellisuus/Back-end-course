using RateTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Needs to be added.
using System.Data; // Needs to be added.

namespace RateTask.Repositories
{
	public class RateRepository : IRateRepository
	{
		// Inject database
		private readonly DtbankdbV3Context _dtbankdbV3Context;

		// Define constructor
		public RateRepository(DtbankdbV3Context dtbankdbV3Context)
		{
			_dtbankdbV3Context = dtbankdbV3Context;
		}

		// Create a new rate.
		public RATE Create(RATE rate)
		{
			_dtbankdbV3Context.RATE.Add(rate);
			_dtbankdbV3Context.SaveChanges();
			return rate;
		}

		// Delete a specific rate by country.
		public void Delete(RATE rate)
		{
			_dtbankdbV3Context.RATE.Remove(rate);
			_dtbankdbV3Context.SaveChanges();
		}

		// Get all the rates in the list.
		public List<RATE> Read()
		{
			var rate = _dtbankdbV3Context.RATE.ToList();
			return rate;
		}

		// Get a specific rate by country.
		public RATE Read(string country)
		{
			var rate = _dtbankdbV3Context.RATE.FirstOrDefault(r => r.Country == country);
			return rate;
		}

		// Update a specific rate by country.
		public RATE Update(RATE rate)
		{
			_dtbankdbV3Context.RATE.Update(rate);
			_dtbankdbV3Context.SaveChanges();
			return rate;
		}
	}
}
