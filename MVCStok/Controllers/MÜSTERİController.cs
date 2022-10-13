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
    public class MÜSTERİController : Controller
    {
        // GET: MÜSTERİ
        MVCDbStokEntities2 db = new MVCDbStokEntities2();


        public ActionResult Index(string p2)
        {
            var deger = from d in db.MUSTERI select d;
            if (!string.IsNullOrEmpty(p2))
            {
                deger = deger.Where(x => x.MUSTERIAD.Contains(p2));
            }
            return View(deger.ToList());
            //var deger = db.MUSTERI.ToList();
            //return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMüsteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMüsteri(MUSTERI p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMüsteri");
            }
            db.MUSTERI.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.MUSTERI.Find(id);
            db.MUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var item = db.MUSTERI.Find(id);
            return View("MusteriGetir", item);

        }

        public ActionResult Güncelle(MUSTERI p2)
        {
            var item = db.MUSTERI.Find(p2.MUSTERID);
            item.MUSTERIAD = p2.MUSTERIAD;
            item.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}