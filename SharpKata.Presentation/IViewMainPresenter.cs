using System.Collections.Generic;

namespace SharpKata.MVP
{

	public interface IViewMainPresenter : IPresenter<IViewMain>
	{
		List<Contact> GetContacts();
		void AddContact (Contact contact);
	}

}
