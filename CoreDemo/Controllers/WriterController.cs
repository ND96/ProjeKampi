using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace CoreDemo.Controllers
{

	public class WriterController : Controller
	{

		WriterManager wm = new WriterManager(new EfWriterRepository());
		
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile ()
		{
			return View();
		}

		public IActionResult WriterMail()
		{
			return View();
		}


		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}


		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartila()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView(); 
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.TGetById(1);
			return View(writervalues);
		}
		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterEditProfile(Writer p)
		{  
			WriterValidator wl = new WriterValidator();
			ValidationResult results = wl.Validate(p);
			if (results.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction ("Dashboard","Index");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

    }
}
