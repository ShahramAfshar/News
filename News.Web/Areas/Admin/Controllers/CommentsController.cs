using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News.Data;
using News.Data.DatabaseContext;
using News.DomainModel;

namespace News.Web.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Comments
        public ActionResult Index()
        {
            // var comments = db.Comments.Include(c => c.NewsModel);
             var comments = db.CommentRepository.GetAll();
            return View(comments.ToList());
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentRepository.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.NewsId = new SelectList(db.NewsRepository.GetAll(), "NewsId", "Title");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,NewsId,ParentId,Name,Email,WebSite,Text,IsShow,CreateDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.CommentRepository.Insert(comment);
                db.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.NewsId = new SelectList(db.NewsRepository.GetAll(), "NewsId", "Title", comment.NewsId);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentRepository.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsId = new SelectList(db.NewsRepository.GetAll(), "NewsId", "Title", comment.NewsId);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,NewsId,ParentId,Name,Email,WebSite,Text,IsShow,CreateDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.CommentRepository.Update(comment);
                db.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.NewsId = new SelectList(db.NewsRepository.GetAll(), "NewsId", "Title", comment.NewsId);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentRepository.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.CommentRepository.GetById(id);
            db.CommentRepository.Delete(comment);
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
