using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<tbl_hobilerim> repo = new GenericRepository<tbl_hobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(tbl_hobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama = p.Aciklama;
            t.Aciklama2 = p.Aciklama2;
            repo.Tupdate(t);
            return RedirectToAction("Index");
        }
    }
}