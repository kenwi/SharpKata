using System;
using System.Collections.Generic;
using Gtk;
using SharpKata.MVP;

public partial class MainWindow: Gtk.Window, IViewMain
{
	private  IViewMainPresenter _presenter;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Application.Init();
		Build ();
	}

	public void Run ()
	{
		Show ();

		label2.Text = string.Format ("The contact list contains {0} items", Contacts.Count);

		Application.Run ();
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

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
