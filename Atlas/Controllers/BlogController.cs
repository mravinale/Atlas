using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas.Models;

namespace Atlas.Controllers
{
    public class BlogController : ApiController
    {
        [HttpGet]
        public Page Preview()
        { 
            return new Page { 
                id = 1, 
                title = "Preview Page", 
                posts = new List<Post>
                            {
                                new Post { id = 1, title = "Post1", page_id = 1, content="lorem ipsum 1", previewImage = ""},
                                new Post { id = 2, title = "Post2", page_id = 1, content="lorem ipsum 2", previewImage = ""},
                                new Post { id = 3, title = "Post3", page_id = 1, content="lorem ipsum 3", previewImage = ""}
                            } };

            
        }

    }
}