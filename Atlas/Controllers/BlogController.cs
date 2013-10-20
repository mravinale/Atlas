using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using Atlas.Infrastructure.EF;
using Atlas.Infrastructure.Helper;
using Atlas.Models;
using System.Threading.Tasks;
 

namespace Atlas.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(IDbContext context) : base(context) { }
        
        [HttpGet]
        public async Task<Post> GetPost(int id)
        {
            return await context.Entity<Post>().Where(i => i.id == id && i.type == "Post").SingleOrDefaultAsync();
        }

        [HttpGet]
        public async Task<IList<Post>> GetAllPost()
        {
            return await context.Entity<Post>().Where(i => i.type == "Post").OrderBy(i => i.id).ToListAsync();
        }

        [HttpPost]
        public async Task<Post> CreatePost()
        {
            var posts = await context.Entity<Post>().ToListAsync();
            
            var newId = posts.Max(i => i.id) + 1;
            var post = new Post {id = newId, type = "Post", content = InitData.PostContent, title = "Post " + newId };

            context.Entity<Post>().Add(post);
            context.SaveChanges();

            return post;   
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePost(int id, [FromBody]Post post)
        {
            var storedPost = await context.Entity<Post>().Where(x => x.id == id).SingleOrDefaultAsync();

            storedPost.title = post.title;
            storedPost.content = post.content;

            context.Entry(storedPost).State = EntityState.Modified;
            context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePost(int id)
        {
            var storedPost = await context.Entity<Post>().Where(x => x.id == id).SingleOrDefaultAsync();

            context.Entity<Post>().Remove(storedPost);
            context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}