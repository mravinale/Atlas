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

            using (var session = docStore.OpenSession())
            {
                var docs = session.Query<Post>().Customize(x => x.WaitForNonStaleResults());
                foreach (var doc in docs)
                    session.Delete(doc);
                session.SaveChanges(); 

                session.Store(new Post { id = 1, title = "Post1", content = "<h2>Blog Post 1</h2>" + commonContent });
                session.Store(new Post { id = 2, title = "Post2", content = "<h2>Blog Post 2</h2>" + commonContent });
                session.Store(new Post { id = 3, title = "Post3", content = "<h2>Blog Post 3</h2>" + commonContent });
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
