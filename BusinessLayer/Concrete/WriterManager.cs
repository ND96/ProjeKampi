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
	public class WriterManager : IWriterService
	{
		IWriterDAL _writerdal;

		public WriterManager(IWriterDAL writerdal)
		{
			_writerdal = writerdal;
		}

		public void WriterAdd(Writer writer)
		{
			_writerdal.Insert(writer);
		}
	}
}
