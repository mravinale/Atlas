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
    public class BlogController : RavenDbController
    {

        [HttpGet]
        public async Task<IList<Post>> PostPreview()
        {
            return await Session.Query<Post>().OrderBy(i => i.id).ToListAsync();
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePostPreview(int id, [FromBody]Editable editable)
        {
            var result = await Session.Query<Post>().Where(x => x.id == id).ToListAsync();

            result.FirstOrDefault().content = editable.content;
            await Session.StoreAsync(result.FirstOrDefault());


            return new HttpResponseMessage(HttpStatusCode.OK);
        }       

    }
}