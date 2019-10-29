using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvsApp.Models
{
    public class Blog
    {
        public int Id { get; set; }    //primary key
        public string Header { get; set; } 
        public string Explanation { get; set; }
        public string Content { get; set; }
        public DateTime AddingDate { get; set; }
        public bool Confirmation { get; set; }
        public bool HomePage { get; set; }      //anasayfaya çıkan blog olup olmadığına karar verme
        public string Image { get; set; }          //resmin ismi

        public int CategoryId { get; set; }     //navigation property   foreign key
        public Category Category { get; set; }      //blogun kategor bilgilerine ulaşmak için
    }
}