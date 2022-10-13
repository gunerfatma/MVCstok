using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        MVCDbStokEntities2 db = new MVCDbStokEntities2();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p4)
        {
            db.SATISLAR.Add(p4);
            db.SaveChanges();
            return View("Index");
        }
    }
}