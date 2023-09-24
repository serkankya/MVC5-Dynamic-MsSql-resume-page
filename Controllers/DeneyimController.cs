    using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();   
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(tbl_deneyimlerim p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            tbl_deneyimlerim deneyimlerim = repo.Find(x=>x.ID == id);
            repo.Tdelete(deneyimlerim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            tbl_deneyimlerim deneyim = repo.Find(x=>x.ID==id);
            return View(deneyim);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(tbl_deneyimlerim p)
        {
            tbl_deneyimlerim deneyim = repo.Find(x=>x.ID == p.ID);
            deneyim.Baslik = p.Baslik;
            deneyim.AltBaslik = p.AltBaslik;
            deneyim.Aciklama = p.Aciklama;
            deneyim.Tarih = p.Tarih; 
            repo.Tupdate(deneyim);
            return RedirectToAction("Index");
        }
    }
}