using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateTask.Models; // Needs to be added.

namespace RateTask.Services
{
	public interface IRateService // Remember to make the interface pupblic.
	{
		RATE Create(RATE rate);
		List<RATE> Read();
		RATE Read(string id);
		RATE Update(RATE rate);
		void Delete(string id);
	}
}
