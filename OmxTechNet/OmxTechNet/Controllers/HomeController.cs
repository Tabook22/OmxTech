using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmxTechNet.Models.DB;
namespace OmxTechNet.Controllers
{
    public class HomeController : Controller
    {private OmxtechDbContext db = new OmxtechDbContext();
        public ActionResult Index()
        {
            int getCon = db.tbl_accounts.OrderBy(x => x.AID).Count();
            ViewBag.getCount = getCon;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}