using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCDbStokEntities2 db = new MVCDbStokEntities2();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.KATEGORILER.ToList();
            var degerler = db.KATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(KATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.KATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var item = db.KATEGORILER.Find(id);
            return View("KategoriGetir", item);

        }

        public ActionResult Güncelle(KATEGORILER p1)
        {
            var item = db.KATEGORILER.Find(p1.KATEGORID);
            item.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}   