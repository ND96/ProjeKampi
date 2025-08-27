using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var JsonWriters=JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findWriters = writers.FirstOrDefault(x=>x.Id==writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriters);
            return Json(jsonWriters);   
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters =JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id )
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass()
            {
                Id = 1,
                Name = "Ayşe"
            },
            new WriterClass()
            {
                Id = 2,
                Name = "Ahmet"
            },
            new WriterClass()
            {
                Id = 3,
                Name = "Buse"
            }
        };
    }
}
