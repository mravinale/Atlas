using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas.Models;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Linq;
using System.Linq;

namespace Atlas.Controllers
{
    public class HomeController : RavenDbController
    {
         [HttpGet]
        public async Task<IList<Post>> Posts()
        {
            return await Session.Query<Post>().ToListAsync();
        }

          [HttpPut]
        public async Task<HttpResponseMessage> UpdatePost(int id, [FromBody]Post post)
        {
            var result = await Session.Query<Post>().Where(x => x.id == id).ToListAsync();
             
             result.FirstOrDefault().content = post.content;
             await Session.StoreAsync(result.FirstOrDefault());
                           

            return new HttpResponseMessage(HttpStatusCode.OK);
        }       

    }
     
}