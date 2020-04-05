using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExample.Models; // Needs to be added.

namespace CurrencyExample.Repositories
{
	public interface ICurrencyRepository // Remember to make the interface public.
	{
		RATE Create(RATE rate);
		List<RATE> Read();
		RATE Read(string country);
		RATE Update(RATE rate);
		void Delete(RATE rate);
	}
}
