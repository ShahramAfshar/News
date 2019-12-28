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
    public class SlidersController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(db.SliderRepository.GetAll());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,ImageName,IsShow,StartDate,EndDate,Caption,Url")] Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    slider.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/Sliders/" + slider.ImageName));
                }
                else
                    slider.ImageName = "NoImages.jpg";

                db.SliderRepository.Insert(slider);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,ImageName,IsShow,StartDate,EndDate,Caption,Url")] Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (slider.ImageName != "NoImages.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Sliders/" + slider.ImageName));
                    }

                    slider.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/Sliders/" + slider.ImageName));
                }

                db.SliderRepository.Update(slider);
                db.Commit();

                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.SliderRepository.GetById(id);


            if (slider.ImageName != "NoImages.jpg")
            {
                string physicalPath = Server.MapPath("/Images/Sliders/" + slider.ImageName);

                System.IO.File.Delete(physicalPath);
            }


            db.SliderRepository.Delete(slider);
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
