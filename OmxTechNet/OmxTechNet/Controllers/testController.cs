using OmxTechNet.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmxTechNet.Controllers
{
    public class testController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: test
        public ActionResult Index()
        {
            var getall = db.tbl_articles.OrderBy(x => x.a_loc).Where(x=>x.a_loc=="3" && x.a_status=="1").ToList();

            return View(getall);

        }
    }
}