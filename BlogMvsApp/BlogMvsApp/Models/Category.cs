using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class Category
    {
        public int Id { get; set; }  //primary key
        public string CategoryName { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}