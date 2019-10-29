using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}