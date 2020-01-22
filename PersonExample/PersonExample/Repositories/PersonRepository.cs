using Microsoft.EntityFrameworkCore;
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

		// Creates a new person.
		public Person Create(Person person)
		{
			// 1. INSERT Lisätään henkilö PERSON -tauluun.
			// 2. SELECT luetaan ja otetaan talteen uuden henkilön ID.
			// 3. INSERT lisätään puhelinnumero PHONE -tauluun viiteavaimena käytetään

			_phonepersondbContext.Person.Add(person);
			_phonepersondbContext.SaveChanges();
			return person;
		}

		// Deletes a specific person by ID.
		public void Delete(Person person)
		{
			_phonepersondbContext.Person.Remove(person);
			_phonepersondbContext.SaveChanges();
		}

		// Get all the persons in the list.
		public List<Person> Read()
		{
			var persons = _phonepersondbContext.Person
				.Include(p => p.Phone)
				.ToList();
			return persons;
		}
		
		// Get specific person by ID.
		public Person Read(string id)
		{
			var person = _phonepersondbContext.Person
				.Include(p => p.Phone)
				.FirstOrDefault(p => p.Id == id);
			return person;
		}

		public Person Update(string id, Person person)
		{

			var savedPerson = Read(id);
			if (savedPerson == null)
			{
				throw new Exception("Person not found");
			}

			else
			{
				_phonepersondbContext.Update(person);

				_phonepersondbContext.SaveChanges();
				return person;
			}
		}
	}
}
