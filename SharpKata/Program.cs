using System;

namespace SharpKata.MVP
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var view = new ViewMain ();
			var presenter = new ViewMainPresenter (view);
			presenter.Run ();

            Console.ReadKey();
		}
	}
}
