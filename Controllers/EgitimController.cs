using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<tbl_egitimlerim> repo = new GenericRepository<tbl_egitimlerim>();       
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniEgitim(tbl_egitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniEgitim");
            }
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            tbl_egitimlerim egitim = repo.Find(x => x.ID == id);
            repo.Tdelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            tbl_egitimlerim egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(tbl_egitimlerim p)
        {
            tbl_egitimlerim egitim = repo.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.GNO = p.GNO;
            egitim.Tarih = p.Tarih;
            repo.Tupdate(egitim);
            return RedirectToAction("Index");
        }
    }
}