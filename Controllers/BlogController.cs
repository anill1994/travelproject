using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Sınıflar;

namespace TravelProject.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).OrderByDescending(i => i.ID).ToList();
            //var deger = c.Blogs.ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            //var list = c.Blogs.Where(i => i.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(i => i.ID == id).ToList();
            by.Deger2 = c.Comments.Where(i => i.Blogid == id).ToList();
            return View(by);
        }
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.Deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Comment p)
        {
            c.Comments.Add(p);
            c.SaveChanges();
            return PartialView();
        }
    }
}