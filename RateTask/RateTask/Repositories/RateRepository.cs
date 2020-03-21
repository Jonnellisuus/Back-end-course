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

		// Delete a specific rate by id.
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

		// Get a specific rate by ID.
		public RATE Read(string id)
		{
			var rate = _dtbankdbV3Context.RATE.FirstOrDefault(r => r.Id == id);
			return rate;
		}

		// Update a specific rate by id.
		public RATE Update(RATE rate)
		{
			_dtbankdbV3Context.RATE.Update(rate);
			_dtbankdbV3Context.SaveChanges();
			return rate;
		}
	}
}
