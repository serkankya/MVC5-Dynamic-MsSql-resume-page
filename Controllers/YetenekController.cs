using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<tbl_yeteneklerim> repo = new GenericRepository<tbl_yeteneklerim>();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(tbl_yeteneklerim p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            tbl_yeteneklerim yetenek = repo.Find(x => x.ID == id);
            repo.Tdelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            tbl_yeteneklerim yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekGetir(tbl_yeteneklerim p)
        {
            tbl_yeteneklerim deneyim = repo.Find(x => x.ID == p.ID);
            deneyim.Yetenek = p.Yetenek;
            deneyim.Oran = p.Oran;
            repo.Tupdate(deneyim);
            return RedirectToAction("Index");
        }

    }
}