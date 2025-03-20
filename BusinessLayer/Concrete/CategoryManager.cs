using BusinessLayer.Abstract;
using BusinessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
			_categoryDal = categoryDAL;
        }

        public void CategoryAdd(Category category)
        {
			_categoryDal.Insert(category);

        }

        public void CategoryRemove(Category category)
        {
			_categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
			_categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
    }
}
