using OmxTechNet.Models;
using OmxTechNet.Models.DB;
using OmxTechNet.Models.ViewModel;
using OmxTechNet.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmxTechNet.Controllers
{
    public class HomeController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        public ActionResult Index()
        {
            var tba = db.tbl_articles.OrderBy(x=>x.a_order).Select(x => new ArticleViewData {
            a_date = x.a_date,
            a_title=x.a_title,
            a_source =x.a_source,
            a_desc=x.a_desc,
            a_link=x.a_link,
            a_img =x.a_img,
            a_type =x.a_type,
            a_mediatype =x.a_mediatype,
            a_meidatype_link=x.a_meidatype_link,
            a_order=x.a_order,
            a_loc =x.a_loc,
            a_status=x.a_status
            }).Where(x=>x.a_loc=="3" && x.a_status=="1").ToList();

            

            //var tba = db.tbl_articles.OrderBy(x => x.a_loc).Where(x => x.a_loc == "3" && x.a_status == "1");
            //var getImgGallery = db.tbl_articles.OrderBy(x => x.a_loc).Where(x => x.a_loc == "3" && x.a_status == "1").ToList().FirstOrDefault();
            var getheaderbg = db.tbl_articles.Where(x => x.a_loc == "1" && x.a_status == "1").FirstOrDefault();
            var getsitelogo = db.tbl_articles.Where(x => x.a_loc == "2" && x.a_status == "1").FirstOrDefault();

            ViewBag.About = getheaderbg.a_img; //header background
            ViewBag.bg = getheaderbg.a_img; //header background
            ViewBag.SiteLog = getsitelogo.a_img; //site logo


            return View(tba);

        }

        public ActionResult Aboutus()
        {
            //about the site or introduction the site

            var abt = db.tbl_articles.Select(x => new AboutusViewModel
            {
                a_title = x.a_title,
                a_desc = x.a_desc,
                a_link = x.a_link,
                a_img = x.a_img,
                a_order = x.a_order,
                a_loc = x.a_loc,
                a_status = x.a_status

            }).Where(x => x.a_loc == "4" && x.a_status == "1").ToList();
            return PartialView("Aboutus", abt);
        }
        public ActionResult About()
        {
          
            return View();
        }

        public ActionResult Contactus()
        {

            return View();
        }
        public ActionResult ContactusThanks()
        {

            return View();
        }
        //TODO:Add New Contact
        [HttpPost]
        public ActionResult Contactus(tbl_contact contact)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy h:mm");
            CultureInfo us = new CultureInfo("en-US");
            CultureInfo sa = new CultureInfo("ar-SA");
            string text = date;
            string format = "dd/MM/yyyy h:mm";
            var enDate = DateTime.ParseExact(text, format, us);
            if (ModelState.IsValid)//Check for validation errors
            {
                tbl_contact myContact = new tbl_contact();
                myContact.GDate = enDate;
                myContact.GName = contact.GName;
                myContact.GAddress = contact.GAddress;
                myContact.GEmail = contact.GEmail;
                myContact.GSubject = contact.GSubject;
                myContact.GData = contact.GData;

                db.tbl_contacts.Add(myContact);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Thank you for contacting us. Your Message Has been sent";

              
                
            }else
            {
                ViewBag.Message = "Please Checkout the Message Contents, !!";
                return View(contact);
            }
            return View();
        }
        public ActionResult Header()
        {
           
            return View();
        }

        //public ActionResult Slider()
        //{
        //    return View();
        //}


        //public ActionResult Aboutus()
        //{
        //    return View();
        //}

        public ActionResult Services()
        {
            var pvm = db.tbl_articles.Where(x => x.a_loc == "5" && x.a_status == "1").Select(x => new ProductViewModel
            {
                a_title = x.a_title,
                a_desc = x.a_desc,
                a_link = x.a_link,
                a_img = x.a_img,
                a_order = x.a_order,
                a_loc = x.a_loc,
                a_status = x.a_status
            }).ToList();
            //var getProducts = db.tbl_articles.Where(x => x.a_loc == "5" && x.a_status == "1").ToList();
            return View(pvm);
        }

        //public ActionResult ProductList()
        //{
        //    return View();
        //}

        //public  ActionResult Subscripe()
        //{
        //    return View();
        //}



        //public ActionResult Footer()
        //{
        //    return View();
        //}


        //download pdf
        public ActionResult DownloadPDF()
        {
            return File("~/Content/OMXProducts.pdf", "application/pdf", "OMXProducts.pdf");
        }
    }
}