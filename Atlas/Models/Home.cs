using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atlas.Models
{
    public class Page
    {
        public int id { get; set; }
        public string title { get; set; } 
        public List<Post> posts{ get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string previewImage { get; set; }
        public int page_id { get; set; }
    }
     
     
}