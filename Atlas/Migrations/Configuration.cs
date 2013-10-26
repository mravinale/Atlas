using System.Collections.Generic;
using Atlas.Infrastructure.Helper;
using Atlas.Models;

namespace Atlas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Atlas.Infrastructure.EF.AtlasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Atlas.Infrastructure.EF.AtlasContext";
        }

        protected override void Seed(Atlas.Infrastructure.EF.AtlasContext context)
        {
            context.Entity<Editable>().AddRange(new List<Editable>(new[]{
                                           new Editable { id = 1, type = "PreviewInfo", content = InitData.GetMarketingContent("Images/marketing1.jpe") },
                                           new Editable { id = 2, type = "PreviewInfo", content = InitData.GetMarketingContent("Images/marketing2.jpe") },
                                           new Editable { id = 3, type = "PreviewInfo", content = InitData.GetMarketingContent("Images/marketing3.jpe") }
                                      }));

            context.Entity<Editable>().AddRange(new List<Editable>(new[]{
                                           new Editable { id = 4, type = "Featurette", content = InitData.GetFeaturetteContent("/Images/featurette1.jpe","pull-left") },
                                           new Editable { id = 5, type = "Featurette", content = InitData.GetFeaturetteContent("/Images/featurette2.jpe","pull-right") },
                                           new Editable { id = 6, type = "Featurette", content = InitData.GetFeaturetteContent("/Images/featurette3.jpe","pull-left") }
                                      }));

            context.Entity<Post>().AddRange(new List<Post>(new[]{
                                           new Post { id = 1, type = "Post", content = InitData.PostContent, title = "Post 1" },
                                           new Post { id = 2, type = "Post", content = InitData.PostContent, title = "Post 2" },
                                           new Post { id = 3, type = "Post", content = InitData.PostContent, title = "Post 3" },
                                      }));

        }
    }
}
