using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvsApp.Models;

namespace BlogMvsApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string Keyword )
        {
            var blogs = db.Blogs
                .Where(i => i.Confirmation == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Header = i.Header.Length > 100 ? i.Header.Substring(0, 100) + "..." : i.Header,
                    Explanation = i.Explanation,
                    AddingDate = i.AddingDate,
                    HomePage = i.HomePage,
                    Confirmation = i.Confirmation,
                    Image = i.Image,
                    CategoryId=i.CategoryId
                }).AsQueryable();
            if(string.IsNullOrEmpty("Keyword")==false)
            {
                blogs = blogs.Where(i => i.Header.Contains(Keyword) || i.Explanation.Contains(Keyword));
            }

            if(id!=null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }
            return View(blogs.ToList());
        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category).OrderByDescending(i => i.AddingDate);
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Header,Explanation,Content,Image,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.AddingDate = DateTime.Now;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)       //nullable int kullanıldı
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Explanation,Content,Confirmation,HomePage,Image,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Header = blog.Header;
                    entity.Explanation = blog.Explanation;
                    entity.Image = blog.Image;
                    entity.Content = blog.Content;
                    entity.Confirmation = blog.Confirmation;
                    entity.HomePage = blog.HomePage;
                    entity.CategoryId = blog.CategoryId;
                    db.SaveChanges();
                    TempData["Blog"] = entity;      //bilgi taşıma
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
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
