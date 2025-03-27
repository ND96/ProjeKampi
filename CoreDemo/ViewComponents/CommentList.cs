using CoreDemo.Models;

using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Nihat"
                },
                new UserComment
                {
                    ID=2,
                    Username= "Hakan"
                },
                new UserComment
                {
                    ID=3,
                    Username="Murat"
                }
            
            };
            return View(commentValues);
        }
    }
}
