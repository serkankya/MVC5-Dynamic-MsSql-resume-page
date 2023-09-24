using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<tbl_admin> repo = new GenericRepository<tbl_admin>();
        public ActionResult Index()
        {
            var admin = repo.List();
            return View(admin);
        }

        [HttpGet]
        public ActionResult KullaniciGetir(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult KullaniciGetir(tbl_admin p)
        {
            var admin = repo.Find(x => x.ID == p.ID);
            admin.KullaniciAdi = p.KullaniciAdi;
            admin.Sifre = p.Sifre;
            repo.Tupdate(admin);
            return RedirectToAction("Index");
        }
    }
}