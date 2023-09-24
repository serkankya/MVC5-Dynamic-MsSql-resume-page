using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<tbl_sosyalmedya> repo = new GenericRepository<tbl_sosyalmedya> ();

        public ActionResult Index()
        {
            var sosyal = repo.List();
            return View(sosyal);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(tbl_sosyalmedya p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sayfa = repo.Find(x=>x.ID == id);
            return View(sayfa);
        }

        [HttpPost]
        public ActionResult SayfaGetir(tbl_sosyalmedya p)
        {
            var sosyal = repo.Find(x=>x.ID == p.ID);
            sosyal.PlatformAdi = p.PlatformAdi;
            if(sosyal.Durum == false)
            {
                p.Durum = true;
            }
            sosyal.Link = p.Link;
            sosyal.Icon = p.Icon;
            sosyal.Durum = p.Durum;
            repo.Tupdate(sosyal);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesapDurumu = repo.Find(x => x.ID == id);
            hesapDurumu.Durum = false;
            repo.Tupdate(hesapDurumu);
            return RedirectToAction("Index");
        }
    }
}