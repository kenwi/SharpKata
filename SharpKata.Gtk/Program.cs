using System;
using Gtk;
using SharpKata.MVP;

namespace SharpKata.Gtk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var view = new MainWindow ();
			var presenter = new ViewMainPresenter (view);
			presenter.Run ();
		}
	}
}
