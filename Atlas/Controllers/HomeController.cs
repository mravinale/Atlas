using System.Data.Entity;
using System.Linq;
using Atlas.Infrastructure;
using Atlas.Infrastructure.EF;
using Atlas.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Atlas.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDbContext context) : base(context) { }
        
        [HttpGet]
        public async Task<IList<Editable>> PreviewInfo()
        {
            return await context.Entity<Editable>().Where(i => i.type == "PreviewInfo").OrderBy(i => i.id).ToListAsync();
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePreviewInfo(int id, [FromBody]Editable editable)
        {
            var result = await context.Entity<Editable>().Where(x => x.id == id).FirstOrDefaultAsync();

            result.content = editable.content;

            context.Entry(result).State = EntityState.Modified;
            context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
     
}