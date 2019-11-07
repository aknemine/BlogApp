using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }    
        public string Header { get; set; }
        public string Explanation { get; set; }
        public DateTime AddingDate { get; set; }
        public bool Confirmation { get; set; }
        public bool HomePage { get; set; }      
        public string Image { get; set; }  
        public int CategoryId { get; set; }

       

    }
}