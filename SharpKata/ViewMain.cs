using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SharpKata.MVP
{
	public class ViewMain : IViewMain
	{
		private  IViewMainPresenter _presenter;

		public ViewMain()
		{

		}

        public IViewMainPresenter Presenter
		{
			get
			{
				return _presenter;
			}
			set 
			{
				if (_presenter == null)
					_presenter = value;
			}
		}

		public List<Contact> Contacts
		{
			get { return _presenter.GetContacts (); }
		}

		public void Run ()
		{
			listAllContacts ();

			var first = Contacts.First();
			listContactDetails (first);

			createNewContact ("EvilCorp", "post@evilcorp.org");

			listAllContacts ();
		}

		private void createNewContact(string name, string email)
		{
			Console.WriteLine ("Creating new contact");
			var contact = new Contact {
				Name = name,
				Email = email
			};
			listContactDetails (contact);
			Presenter.AddContact (contact);
		}

		private void listAllContacts()
		{
			Console.WriteLine ("List of contacts");
			Console.WriteLine ("------------------");
			Contacts.ForEach (contact => Console.WriteLine ("* {0}",contact.Name));
		}

		private void listContactDetails(Contact contact)
		{
			Console.WriteLine ("Details about contact: {0}", contact.Name);
			Console.WriteLine ("------------------");
			Console.WriteLine ("* Name: {0}",contact.Name);
			Console.WriteLine ("* Email: {0}",contact.Email);
			Console.WriteLine ("------------------");
		}
	}	
}
