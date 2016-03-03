using System;
using System.Collections.Generic;
using System.Collections;

namespace SharpKata.MVP
{
	public interface IRepository
	{
		IEnumerable<Contact> All();
		void Add (Contact contact);
	}	
}
