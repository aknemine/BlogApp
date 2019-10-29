using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)       //veritabanına test verileri ekleme imkanı sağlar
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName = "C#"},
                new Category(){CategoryName = "Asp.Net MVC"},
                new Category(){CategoryName = "Asp.net WebForm"},
                new Category(){CategoryName = "Windows Form"},
            };

            foreach(var item in categories) {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog(){Header="C# Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-10), HomePage=true, Confirmation=true, Content="Delegates hakkında C# Delegates Hakkında", Image="1.jpeg", CategoryId=1 },
                new Blog(){Header="C# Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-20), HomePage=false, Confirmation=true, Content="Delegates hakkında C# Delegates Hakkında", Image="1.jpeg", CategoryId=1 },
                new Blog(){Header="Asp.Net Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-10), HomePage=false, Confirmation=false, Content="Delegates hakkında C# Delegates Hakkında", Image="2.jpeg", CategoryId=2 },
                new Blog(){Header="Asp.Net Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-10), HomePage=true, Confirmation=true, Content="Delegates hakkında C# Delegates Hakkında", Image="2.jpeg", CategoryId=2 },
                new Blog(){Header="Asp.net WebForm Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-40), HomePage=true, Confirmation=false, Content="Delegates hakkında C# Delegates Hakkında", Image="3.jpeg", CategoryId=3 },
                new Blog(){Header="Windows Form Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-15), HomePage=true, Confirmation=false, Content="Delegates hakkında C# Delegates Hakkında", Image="4.jpeg", CategoryId=4 },
                new Blog(){Header="Windows Form Delegates", Explanation="Delegates hakkında C# Delegates Hakkında", AddingDate=DateTime.Now.AddDays(-70), HomePage=false, Confirmation=true, Content="Delegates hakkında C# Delegates Hakkında", Image="4.jpeg", CategoryId=4 },

            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}