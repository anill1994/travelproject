using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Sınıflar;

namespace TravelProject.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Blogs.OrderByDescending(i=>i.ID).Take(4).ToList();
            return View(list);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult Partial1()
        {
            var list = c.Blogs.OrderByDescending(i=>i.ID).Take(2).ToList();
            return PartialView(list);
        }
        public PartialViewResult Partial2()
        {
            var list = c.Blogs.Where(i => i.ID==2).ToList();
            return PartialView(list);
        }
        public PartialViewResult Partial3()
        {
            var list = c.Blogs.OrderByDescending(i => i.ID).Take(10).ToList();
            return PartialView(list);
        }
        public PartialViewResult Partial4()
        {
            var list = c.Blogs.OrderBy(i => i.ID).Take(3).ToList();
            return PartialView(list);
        }
        public PartialViewResult Partial5()
        {
            var list = c.Blogs.OrderByDescending(i => i.ID).Take(3).ToList();
            return PartialView(list);
        }
    }
}