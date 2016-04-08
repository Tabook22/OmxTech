﻿using OmxTechNet.Models.DB;
using OmxTechNet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmxTechNet.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: AdminHome
        public ActionResult Index()
        {
            int getTotalNews = db.tbl_articles.Select(x => x.Id).Count();
            int getTotalPosts = db.tbl_posts.Select(x => x.Id).Count();
            ViewBag.getTotals = getTotalNews;
            ViewBag.getTotalPosts = getTotalPosts;
            return View();
;        }
    }
}