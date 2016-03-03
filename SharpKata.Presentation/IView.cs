using System;

namespace SharpKata.MVP
{

	public interface IView<TPresenter>
	{
		TPresenter Presenter { get; set; }
		void Run();
	}

}
