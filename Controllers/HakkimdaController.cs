using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepository<tbl_hakkimda> repo = new GenericRepository<tbl_hakkimda> ();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(tbl_hakkimda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.Tupdate(t);
            return RedirectToAction("Index");   
        }
    }
}