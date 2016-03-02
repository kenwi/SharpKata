using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SharpKata.MVP
{
	public class ViewMainPresenter : IViewMainPresenter
	{
		private readonly IViewMain _view;
		private readonly ContactsRepository _repository;

		public ViewMainPresenter(IViewMain view)
		{
			_view = view;
			_view.Presenter = this;
			_repository = new ContactsRepository ();
		}

		public IViewMain View
		{
			get
			{
				return _view;
			}
		}

		public void Run ()
		{
			_view.Run ();
		}

		public List<Contact> GetContacts()
		{
			return _repository.All ().ToList ();
		}

		public void AddContact(Contact contact)
		{
			_repository.Add (contact);
		}
	}
}
