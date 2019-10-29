using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class BlogContext : DbContext        //Entity framework codefirst yaklaşımını kullanabilmek için(veritabanı)
    {
        public BlogContext():base("blogDb")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<Blog> Blogs { get; set; }      //veritabanında blogs tablosu
        public DbSet<Category> Categories { get; set; }     //veritabanında categories tablosu
    }
}