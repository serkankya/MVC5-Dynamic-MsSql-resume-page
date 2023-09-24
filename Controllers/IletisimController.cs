using Mvc5.Models.Entity;
using Mvc5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<tbl_iletisim> repo = new GenericRepository<tbl_iletisim>();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}