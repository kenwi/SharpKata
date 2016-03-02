using System;
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
			Console.WriteLine ("Hello World!");
			Console.WriteLine ("The contact list contains {0} items", Contacts.Count);
		}
	}	
}
