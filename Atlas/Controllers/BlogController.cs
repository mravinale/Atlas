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

namespace Atlas.Controllers
{
    public class BlogController : RavenDbController
    {
        
        [HttpGet]
        public async Task<Post> GetPost(int id)
        {
            return await Session.Query<Post>().Where(i=>i.id == id).SingleOrDefaultAsync();
        }

        [HttpGet]
        public async Task<IList<Post>> GetAllPost()
        {
            return await Session.Query<Post>().OrderBy(i=> i.id).ToListAsync();
        }

        [HttpPost]
        public async Task<Post> CreatePost()
        {
            var posts = await Session.Query<Post>().ToListAsync();
            
            var newId = posts.Max(i => i.id) + 1;
            var post = new Post { id = newId, type = "Post", content = postContent, title = "Post " + newId };
          
            await Session.StoreAsync(post);          
            
            return post;   
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePost(int id, [FromBody]Post post)
        {
            var storedPost = await Session.Query<Post>().Where(x => x.id == id).SingleOrDefaultAsync();

            storedPost.title = post.title;
            storedPost.content = post.content;

            await Session.StoreAsync(storedPost);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePost(int id)
        {
            var storedPost = await Session.Query<Post>().Where(x => x.id == id).SingleOrDefaultAsync();

            Session.Delete(storedPost);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}