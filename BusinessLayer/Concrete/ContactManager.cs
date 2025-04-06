using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		IContactDAL _contactDal;

		public ContactManager(IContactDAL contactDal)
		{
			_contactDal = contactDal;
		}

		public void ContactAdd(Contact contact)
		{
			_contactDal.Insert(contact);
		}
	}
}
