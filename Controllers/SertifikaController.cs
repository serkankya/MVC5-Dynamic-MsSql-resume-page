using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<tbl_sertifikalarim> repo = new GenericRepository<tbl_sertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(tbl_sertifikalarim p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            tbl_sertifikalarim sertifika = repo.Find(x => x.ID == id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            tbl_sertifikalarim sertifika = repo.Find(x=>x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(tbl_sertifikalarim p)
        {
            tbl_sertifikalarim sertifika = repo.Find(x=>x.ID == p.ID);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.Tupdate(sertifika);
            return RedirectToAction("Index");
        }
    }
}