using System;

namespace SharpKata.MVP
{
	
	public interface IPresenter<TView>
	{
		TView View { get; }
		void Run();
	}

}
