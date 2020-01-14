using PersonExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonExample.Repositories
{
	public interface IPersonRepository
	{
		Person Create(Person person);
		List<Person> Read();
		Person Read(string id);
		void Delete(Person person);
	}
}
