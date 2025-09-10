
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        //CategoryManager cm=new CategoryManager(new EfCategoryRepository());

        //public IViewComponentResult Invoke()
        //{
        //    var values = cm.GetList();
        //    return View(values);
        //}
        private readonly ICategoryService _categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetCategoriesWithBlogCount();
            return View(values);
        }
    }    
}
