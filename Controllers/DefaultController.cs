using Mvc5.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        Db_Mvc5Entities1 db = new Db_Mvc5Entities1();

        public ActionResult Index()
        {
            var degerler = db.tbl_hakkimda.ToList();
            return View(degerler); //yani değerler verilerimi listeleyecek
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.tbl_sosyalmedya.Where(x=>x.Durum == true).ToList();
            return PartialView(sosyalMedya);
        }

        public PartialViewResult Deneyim()
        {
            var degerler = db.tbl_deneyimlerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Egitim()
        {
            var degerler = db.tbl_egitimlerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var degerler = db.tbl_yeteneklerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Hobilerim()
        {
            var degerler = db.tbl_hobilerim.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Sertifikalarim()
        {
            var degerler = db.tbl_sertifikalarim.ToList();
            return PartialView(degerler);   
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(tbl_iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.tbl_iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}