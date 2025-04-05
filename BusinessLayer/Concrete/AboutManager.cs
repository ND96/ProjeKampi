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
	public class AboutManager : IAboutService
	{
		IAboutDAL _aboutDal;

		public AboutManager(IAboutDAL aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public List<About> GetList()
		{
			return _aboutDal.GetListAll();
		}
	}
}
