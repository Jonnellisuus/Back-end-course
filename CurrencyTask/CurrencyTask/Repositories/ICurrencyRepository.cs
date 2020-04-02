using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTask.Models; // Needs to be added.

namespace CurrencyTask.Repositories
{
	public interface ICurrencyRepository // Remember to make the interface pupblic.
	{
		RATE Create(RATE rate);
		List<RATE> Read();
		RATE Read(string country);
		RATE Update(RATE rate);
		void Delete(RATE rate);
	}
}
