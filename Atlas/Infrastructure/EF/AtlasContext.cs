using System.Collections.Generic;
using System.Data.Entity;
using Atlas.Infrastructure.Helper;
using Atlas.Models;

namespace Atlas.Infrastructure.EF
{
    public class AtlasContext : DbContext, IDbContext
    {
        public DbSet<Editable> Editable { get; set; }
        public DbSet<Post> Post { get; set; }

        public AtlasContext() { }
        public AtlasContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }

        public DbSet<T> Entity<T>() where T : class { return this.Set<T>(); }
    }

    public class AtlasContextCustomInitializer : IDatabaseInitializer<AtlasContext>
    {
        public void InitializeDatabase(AtlasContext context)
        {
            if (context.Database.Exists() && context.Database.CompatibleWithModel(true)) return;

            context.Database.Delete();
            context.Database.Create();

            context.Entity<Editable>().AddRange(new List<Editable>(new[]{
                                           new Editable { id = 1, type = "PreviewInfo", content = "<h2>Blog Post 1</h2>" + InitData.CommonContent },
                                           new Editable { id = 2, type = "PreviewInfo", content = "<h2>Blog Post 2</h2>" + InitData.CommonContent},
                                           new Editable { id = 3, type = "PreviewInfo", content = "<h2>Blog Post 3</h2>" + InitData.CommonContent  }
                                      }));

            context.Entity<Editable>().AddRange(new List<Editable>(new[]{
                                           new Editable { id = 4, type = "Featurette", content = InitData.FeaturetteContent },
                                           new Editable { id = 5, type = "Featurette", content = InitData.FeaturetteContent },
                                           new Editable { id = 6, type = "Featurette", content = InitData.FeaturetteContent }
                                      }));

            context.Entity<Post>().AddRange(new List<Post>(new[]{
                                           new Post { id = 1, type = "Post", content = InitData.PostContent, title = "Post 1" },
                                           new Post { id = 2, type = "Post", content = InitData.PostContent, title = "Post 2" },
                                           new Post { id = 3, type = "Post", content = InitData.PostContent, title = "Post 3" },
                                      }));

            context.SaveChanges();
        }



    }

}