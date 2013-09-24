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
        public async Task<IList<PreviewPost>> PreviewPost()
        {
            return await Session.Query<PreviewPost>().Customize(x => x.WaitForNonStaleResults()).OrderBy(i => i.id).ToListAsync();
        }

        [HttpGet]
        public async Task<Post> FullPost(int id)
        {
            return await Session.Query<Post>().Where(i=>i.id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<Post> CreateFullPost()
        {
            var posts = await Session.Query<Post>().ToListAsync();
            
            var newId = posts.Max(i => i.id) + 1;

            var post = new Post { id = newId, type = "Post", content = postContent, title = "Post " + newId };
            var postPreview = new PreviewPost { id = newId, type = "PreviewPost", content = previewPostContent, title = "Post " + newId };
            
            await Session.StoreAsync(post);
            await  Session.StoreAsync(postPreview);  
            
            return post;   
        }
        
        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePostPreview(int id, [FromBody]Editable editable)
        {
            var post = await Session.Query<Post>().Where(x => x.id == id).SingleOrDefaultAsync();

            post.content = editable.content;
            await Session.StoreAsync(post);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }       

    }
}