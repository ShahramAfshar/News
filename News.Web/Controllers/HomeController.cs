using News.Data;
using News.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView();
        }
        public ActionResult LastNews()
        {
          var res=  db.NewsRepository.GetAll().OrderByDescending(n => n.NewsId).Take(5);
            return PartialView(res);
        }
        public ActionResult LastNewsTitle()
        {
            var res = db.NewsRepository.GetAll().OrderByDescending(n => n.NewsId).Take(5);
            return PartialView(res);
        }
        public ActionResult TopNews()
        {
            var res = db.NewsRepository.GetAll().OrderByDescending(n => n.Visit).Take(4);
            return PartialView(res);
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