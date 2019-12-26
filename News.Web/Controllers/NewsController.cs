using News.Data;
using News.Data.DatabaseContext;
using News.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Controllers
{
    public class NewsController : Controller
    {
        private UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        // GET: News
        public ActionResult Single(int id)
        {
            var news = db.NewsRepository.GetById(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            return View(news);
        }
        public ActionResult GetTagNews(int id)
        {
            var tag = db.TagRepository.SingleNews(id);
            return PartialView(tag);
        }
        public ActionResult RelativeNews(int groupId)
        {
            var news = db.NewsRepository.GetMany(n => n.GroupId == groupId).Take(4);
            return PartialView(news);
        }
        public ActionResult ShowComment(int newsId)
        {
            var comments = db.CommentRepository.GetMany(c => c.NewsId == newsId && c.IsShow == true).ToList();
            return PartialView(comments);
        }

        public ActionResult CreateComment(int newsId)
        {
            ViewBag.newsId = newsId;

            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {

            comment.CreateDate = DateTime.Now;
            db.CommentRepository.Insert(comment);
            db.Commit();

            return RedirectToAction("Single",new {id=comment.NewsId });
        }

    }
}