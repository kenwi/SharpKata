using System;
using System.Collections.Generic;
using System.Collections;

namespace SharpKata.MVP
{
	public class ContactsRepository : IRepository
	{
		List<Contact> _entities;

		public ContactsRepository()
		{
			_entities = new List<Contact> () {
				new Contact() {Name = "Kenneth Wilhelmsen", Email = "kenneth@wilhelmsen.nu" },
				new Contact() {Name = "Foo Bar", Email = "foo@bar.com" }
			};
		}

		public IEnumerable<Contact> All()
		{
			return _entities;
		}

		public void Add(Contact contact)
		{
			_entities.Add (contact);
		}
	}
}
