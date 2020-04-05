using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Needs to be added.
using CurrencyExample.Models; // Needs to be added.

namespace CurrencyExample.Repositories
{
	public class CurrencyRepository : ICurrencyRepository
	{
		// Inject database
		private readonly DtbankdbContext _dtbankdbContext;

		// Define constructor
		public CurrencyRepository(DtbankdbContext dtbankdbContext)
		{
			_dtbankdbContext = dtbankdbContext;
		}

		// Create a new rate.
		public RATE Create(RATE rate)
		{
			_dtbankdbContext.RATE.Add(rate);
			_dtbankdbContext.SaveChanges();
			return rate;
		}

		// Delete a specific rate by country.
		public void Delete(RATE rate)
		{
			_dtbankdbContext.RATE.Remove(rate);
			_dtbankdbContext.SaveChanges();
		}

		// Get all the rates in the list.
		public List<RATE> Read()
		{
			var rate = _dtbankdbContext.RATE.ToList();
			return rate;
		}

		// Get a specific rate by country.
		public RATE Read(string country)
		{
			var rate = _dtbankdbContext.RATE.FirstOrDefault(r => r.Country == country);
			return rate;
		}

		// Update a specific rate by country.
		public RATE Update(RATE rate)
		{
			_dtbankdbContext.RATE.Update(rate);
			_dtbankdbContext.SaveChanges();
			return rate;
		}
	}
}
