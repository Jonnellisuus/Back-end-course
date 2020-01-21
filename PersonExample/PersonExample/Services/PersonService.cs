using PersonExample.Models;
using PersonExample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonExample.Services
{
	public class PersonService : IPersonService
	{
		// Inject repository layer
		private readonly IPersonRepository _personRepository;

		// Define constructor
		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public Person Create(Person person)
		{
			return _personRepository.Create(person);
		}

		public void Delete(string id)
		{
			Person removedPerson = _personRepository.Read(id);

			_personRepository.Delete(removedPerson);
		}

		public List<Person> Read()
		{
			return _personRepository.Read();
		}

		public Person Read(string id)
		{
			return _personRepository.Read(id);
		}

		public Person Update(string id, Person person)
		{
			var savedPerson = _personRepository.Read(id);

			if (savedPerson == null)
			{
				throw new Exception("Person not found");
			}

			else
			{
				return _personRepository.Update(id, person);
			}
		}
	}
}
