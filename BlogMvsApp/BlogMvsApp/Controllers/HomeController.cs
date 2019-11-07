using BlogMvsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvsApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var blogs = context.Blogs
                .Select(i=>new BlogModel()
                {
                    Id=i.Id,
                    Header=i.Header.Length > 100 ? i.Header.Substring(0,100) + "..." : i.Header,
                    Explanation=i.Explanation,
                    AddingDate=i.AddingDate,
                    HomePage=i.HomePage,
                    Confirmation=i.Confirmation,
                    Image=i.Image
                }).Where(i => i.Confirmation == true && i.HomePage == true);

            return View(blogs.ToList());
        }
    }
}