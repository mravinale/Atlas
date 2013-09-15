using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas.Models;

namespace Atlas.Controllers
{
    public class BlogController : RavenDbController
    {
        [HttpGet]
        public Post Preview()
        {
            return new Post();            
        }

    }
}