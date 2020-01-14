using PersonExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonExample.Services
{
	public interface IPersonService
	{
		List<Person> Read();
		Person Read(string id);
		void Delete(string id);
	}
}
