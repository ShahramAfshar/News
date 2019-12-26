using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News.Data;
using News.Data.DatabaseContext;
using News.DomainModel;

namespace News.Web.Areas.Admin.Controllers
{
    public class NewsModelsController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/NewsModels
        public ActionResult Index()
        {
            return View(db.NewsRepository.GetAll());
        }

        // GET: Admin/NewsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsRepository.GetById(id.Value);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            return View(newsModel);
        }

        // GET: Admin/NewsModels/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title");
            return View();
        }

        // POST: Admin/NewsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,GroupId,Title,ShortNews,FullNews,IsShowSlider,ImageName,CreateDate,Visit")] NewsModel newsModel, HttpPostedFileBase imageNews)
        {
            if (ModelState.IsValid)
            {

              
                if (imageNews != null )
                {
                    newsModel.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageNews.FileName);
                    imageNews.SaveAs(Server.MapPath("/Images/Pages/" + newsModel.ImageName));
                }
                else 
                    newsModel.ImageName = "NoImages.jpg";

                newsModel.CreateDate = DateTime.Now;

                db.NewsRepository.Insert(newsModel);
                db.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", newsModel.GroupId);
            return View(newsModel);
        }

        // GET: Admin/NewsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsRepository.GetById(id.Value);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", newsModel.GroupId);
            return View(newsModel);
        }

        // POST: Admin/NewsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,GroupId,Title,ShortNews,FullNews,IsShowSlider,ImageName,CreateDate,Visit")] NewsModel newsModel, HttpPostedFileBase imageNews)
        {
            if (ModelState.IsValid)
            {
                if (imageNews != null )
                {
                    if (newsModel.ImageName != "NoImages.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Pages/" + newsModel.ImageName));
                    }

                    newsModel.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageNews.FileName);
                    imageNews.SaveAs(Server.MapPath("/Images/Pages/" + newsModel.ImageName));
                }


                db.NewsRepository.Update(newsModel);
                db.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", newsModel.GroupId);
            return View(newsModel);
        }

        // GET: Admin/NewsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsRepository.GetById(id.Value);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            return View(newsModel);
        }

        // POST: Admin/NewsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModel newsModel = db.NewsRepository.GetById(id);
            db.NewsRepository.Delete(newsModel);
            db.Commit();


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
