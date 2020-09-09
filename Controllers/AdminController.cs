using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Sınıflar;

namespace TravelProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Blogs.ToList();
            return View(list);
        }
        public ActionResult YeniBlog()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var deger = c.Blogs.Find(id);
            c.Blogs.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var list = c.Blogs.Find(id);
            return View("Guncelle",list);
        }
        [HttpPost]
        public ActionResult Guncelle(Blog p)
        {
            var deger = c.Blogs.Find(p.ID);
            deger.Baslik = p.Baslik;
            deger.Tarih = p.Tarih;
            deger.Aciklama = p.Aciklama;
            deger.BlogImage = p.BlogImage;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult YorumListesi()
        {
            var list = c.Comments.ToList();
            return View(list);
        }
        public ActionResult YorumGuncelle(int id)
        {
            var yorum = c.Comments.Find(id);
            return View("YorumGuncelle", yorum);
        }
        [HttpPost]
        public ActionResult YorumGuncelle(Comment p)
        {
            var deger = c.Comments.Find(p.ID);
            deger.KullaniciAdi = p.KullaniciAdi;
            deger.Mail = p.Mail;
            deger.Yorum = p.Yorum;
            c.SaveChanges();
            return RedirectToAction("yorumlistesi");
        }
        public ActionResult YorumSil(int id)
        {
            var deger = c.Comments.Find(id);
            c.Comments.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("yorumlistesi");
        }
    }
}