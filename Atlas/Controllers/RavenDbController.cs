using Atlas.Models;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Atlas.Controllers
{
    public abstract class RavenDbController : ApiController
    {
        public IDocumentStore Store
        {
            get { return LazyDocStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Atlas"
            };

            docStore.Initialize();

            var commonContent = "<p >Suspendisse potenti. Donec egestas metus quis mauris ullamcorper eu consequat enim vulputate. Duis dictum ornare ante at accumsan. Mauris ornare sodales pretium.</p>" +
                                "<p><a class='btn' href='/Blog'>Model details &raquo;</a></p> ";

            var postContent = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur .</p>";

            using (var session = docStore.OpenSession())
            {
                var previews = session.Query<PreviewInfo>().Customize(x => x.WaitForNonStaleResults());
                foreach (var preview in previews) session.Delete(preview);
                session.SaveChanges();

                var posts = session.Query<Post>().Customize(x => x.WaitForNonStaleResults());
                foreach (var post in posts) session.Delete(post);
                session.SaveChanges();

                session.Store(new PreviewInfo { id = 1, type = "PreviewInfo", content = "<h2>Blog Post 1</h2>" + commonContent });
                session.Store(new PreviewInfo { id = 2, type = "PreviewInfo", content = "<h2>Blog Post 2</h2>" + commonContent });
                session.Store(new PreviewInfo { id = 3, type = "PreviewInfo", content = "<h2>Blog Post 3</h2>" + commonContent });

                session.Store(new Post { id = 1, type = "Post", content = postContent, title="Post1", image="http://quickimage.it/1200x400" });
                session.Store(new Post { id = 2, type = "Post", content = postContent, title="Post2", image="http://quickimage.it/1200x400" });
                session.Store(new Post { id = 3, type = "Post", content = postContent, title="Post3", image="http://quickimage.it/1200x400" });

                session.SaveChanges();
            }

            return docStore;
        });

        public IAsyncDocumentSession Session { get; set; }

        public async override Task<HttpResponseMessage> ExecuteAsync(
            HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}
