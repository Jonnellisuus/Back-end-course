using PersonExample.Data;
using PersonExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonExample.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		// Injected database 
		private readonly PhonepersondbContext _phonepersondbContext;

		// Define constructor
		public PersonRepository(PhonepersondbContext phonepersondbContext)
		{
			_phonepersondbContext = phonepersondbContext;
		}

		public Person Create(Person person)
		{
			_phonepersondbContext.Person.Add(person);
			_phonepersondbContext.SaveChanges();
			return person;
		}

		// Get all the persons in the list.
		public List<Person> Read()
		{
			var persons = _phonepersondbContext.Person.ToList();
			return persons;
		}

		// Get specific person by ID.
		public Person Read(string id)
		{
			var person = _phonepersondbContext.Person.FirstOrDefault(p => p.Id == id);
			return person;
		}
	}
}
