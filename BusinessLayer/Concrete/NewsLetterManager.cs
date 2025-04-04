﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsLetterManager:INewsLetterService
	{
		INewsLetterDAL _newsLetterDal;

		public NewsLetterManager(INewsLetterDAL newsLetterDal)
		{
			_newsLetterDal = newsLetterDal;
		}

		public void AddNewsLetter(NewsLetter newsLetter)
		{
			_newsLetterDal.Insert(newsLetter);
		}
	}
}
