using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class ürünlerController : Controller
    {
        // GET: ürünler
        MVCDbStokEntities2 db = new MVCDbStokEntities2();
        public ActionResult Index()
        {
            var deger = db.URUNLER.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> deger = (from i in db.KATEGORILER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATEGORIAD,
                                              Value = i.KATEGORID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniÜrün(URUNLER p3)
        {
            var item = db.KATEGORILER.Where(x => x.KATEGORID == p3.KATEGORILER.KATEGORID).FirstOrDefault();
            p3.KATEGORILER = item;

            db.URUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var item = db.URUNLER.Find(id);
            List<SelectListItem> deger = (from i in db.KATEGORILER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATEGORIAD,
                                              Value = i.KATEGORID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger; 
            return View("UrunGetir", item);

        }
        public ActionResult Güncelle(URUNLER p3)
        {
            var item = db.URUNLER.Find(p3.URUNID);
            item.URUNADI = p3.URUNADI;
            item.MARKA = p3.MARKA;
            item.STOK = p3.STOK;
            item.FİYAT = p3.FİYAT;
            //item.URUNKATEGORI = p3.URUNKATEGORI;
            var urn = db.KATEGORILER.Where(x => x.KATEGORID == p3.KATEGORILER.KATEGORID).FirstOrDefault();
            item.URUNKATEGORI = urn.KATEGORID;
            db.SaveChanges();
            return RedirectToAction("Index");


        }





    }
    }
