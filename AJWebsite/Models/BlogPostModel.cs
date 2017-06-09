using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace AJWebsite.Models
{
    public class BlogPostModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        [Key]
        public int BlogId { get; set; }
    }
    //public class BlogManager
    //{
    //    private static string PostFile = HttpContext.Current.Server.MapPath("~/App_Data/Posts.json");
    //    private static List<BlogPostModel> posts = new List<BlogPostModel>();

        //public static void Create(string postJson)
        //{
        //    var obj = JsonConvert.DeserializeObject<BlogPostModel>(postJson);
        //    if (posts.Count > 0)
        //    {
        //        posts = (from p in posts
        //                 orderby p.Date
        //                 select p).ToList();
        //        obj.BlogId = posts.Last().BlogId + 1;
        //    }
        //    else
        //    {
        //        obj.BlogId = 1;
        //    }
        //    posts.Add(obj);
        //    save();
        //}
        //public static List<BlogPostModel> Read()
        //{
        //    if (!File.Exists(PostFile))
        //    {
        //        File.Create(PostFile).Close();
        //        File.WriteAllText(PostFile, "[]");
        //    }
        //    posts = JsonConvert.DeserializeObject<List<BlogPostModel>>(File.ReadAllText(PostFile));
        //    return posts;
        //}
        //public static void Update(int id, string postJson)
        //{
        //    Delete(id);
        //    //Create(postJson);
        //    save();
        //}
        //public static void Delete(int id)
        //{
        //    posts.Remove(posts.Find(p => p.BlogId == id));
        //    save();
        //}
        //public static void save()
        //{
        //    File.WriteAllText(PostFile, JsonConvert.SerializeObject(posts));
        //}

    //}
}