using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJWebsite.Models;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace AJWebsite.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        private WebsiteDatabase db = new WebsiteDatabase();
        // GET: Blog
        [AllowAnonymous]
        public ActionResult BlogIndex()
        {
            ViewBag.NavClassBlog = "active";
            WebsiteDatabase db = new WebsiteDatabase();
            var posts = (from p in db.BlogPostModels
                        select p).ToList();

            return View(posts);

        }
        
        
        
        [HttpGet]
       
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Exclude = "BlogId")]BlogPostModel post, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                //BlogManager.Create(JsonConvert.SerializeObject(post));
                WebsiteDatabase db = new WebsiteDatabase();
                BlogPostModel b = new BlogPostModel();
                if (image != null)
                {
                    post.Image = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath(@"~\img\" + @"\" + post.Image));
                    ViewBag.Pic = image;
                    post.Date = DateTime.Now;
                    db.BlogPostModels.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("BlogIndex");
                }
                else
                {
                    post.Date = DateTime.Now;
                    db.BlogPostModels.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("BlogIndex");
                }
            }
            else
            {
                return View(post);
            }


        }

        [HttpGet]
       
        public ActionResult Edit(int id)
        {            
            BlogPostModel blog = db.BlogPostModels.Find(id);
            if (blog == null)
            {
               return HttpNotFound();
            }
                return View(blog);
           
        }
        [HttpPost]
        
        public ActionResult Edit(int id, FormCollection formValues )
        {
            BlogPostModel blog = db.BlogPostModels.Find(id);
            try
            {
                UpdateModel(blog);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = blog.BlogId });
            }
            catch
            {
                return View("BlogIndex");         
            }
            /*if (ModelState.IsValid)
            {
                UpdateModel(blog);
                db.SaveChanges();
                return RedirectToAction("BlogIndex");
            }
            return View(blog);*/
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            WebsiteDatabase db = new WebsiteDatabase();
            BlogPostModel bg = new BlogPostModel();
            var blog = (from b in db.BlogPostModels
                       where b.BlogId.Equals(id)
                       select b).FirstOrDefault<BlogPostModel>();
            if(blog.Image != null)
            {
                ViewBag.Pic = $"{Server.MapPath(@"~\img\" + @"\" + blog.Image)}";
            }
                
            return View(blog);
            
        }
        
        public ActionResult Delete(int id)
        {
            WebsiteDatabase db = new WebsiteDatabase();
            var blog = from b in db.BlogPostModels
                       where b.BlogId.Equals(id)
                       select b;
           
            foreach(var b in blog)
            {
                db.BlogPostModels.Remove(b);
            }
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("BlogIndex");
        }
    }
}