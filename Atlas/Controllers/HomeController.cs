using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas.Models;

namespace Atlas.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public List<Post> Posts()
        {
            var commonContent =   "<p >Suspendisse potenti. Donec egestas metus quis mauris ullamcorper eu consequat enim vulputate. Duis dictum ornare ante at accumsan. Mauris ornare sodales pretium.</p>" +
                                  "<p><a class='btn' href='/Blog'>Model details &raquo;</a></p> ";

            return  new List<Post>
                            {
                                new Post { id = 1, title = "Post1", page_id = 1, content="<h2>Blog Post 1</h2>"+commonContent, previewImage = ""},
                                new Post { id = 2, title = "Post2", page_id = 1, content="<h2>Blog Post 2</h2>"+commonContent, previewImage = ""},
                                new Post { id = 3, title = "Post3", page_id = 1, content="<h2>Blog Post 3</h2>"+commonContent, previewImage = ""}
                            };

          
        }

    }
}