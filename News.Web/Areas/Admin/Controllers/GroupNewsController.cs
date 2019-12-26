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
    public class GroupNewsController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/GroupNews
        public ActionResult Index()
        {
            return View(db.GroupRepository.GetAll());
        }

        // GET: Admin/GroupNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNews groupNews = db.GroupRepository.GetById(id.Value);
            if (groupNews == null)
            {
                return HttpNotFound();
            }
            return PartialView(groupNews);
        }

        // GET: Admin/GroupNews/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/GroupNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Title")] GroupNews groupNews)
        {
            if (ModelState.IsValid)
            {
                db.GroupRepository.Insert(groupNews);
                db.Commit();

                return RedirectToAction("Index");
            }

            return PartialView(groupNews);
        }

        // GET: Admin/GroupNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNews groupNews = db.GroupRepository.GetById(id.Value);
            if (groupNews == null)
            {
                return HttpNotFound();
            }
            return PartialView(groupNews);
        }

        // POST: Admin/GroupNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Title")] GroupNews groupNews)
        {
            if (ModelState.IsValid)
            {
                db.GroupRepository.Update(groupNews);
                db.Commit();

                return RedirectToAction("Index");
            }
            return PartialView(groupNews);
        }

        // GET: Admin/GroupNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNews groupNews = db.GroupRepository.GetById(id.Value);
            if (groupNews == null)
            {
                return HttpNotFound();
            }
            return PartialView(groupNews);
        }

        // POST: Admin/GroupNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupNews groupNews = db.GroupRepository.GetById(id);
            db.GroupRepository.Delete(groupNews);
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
