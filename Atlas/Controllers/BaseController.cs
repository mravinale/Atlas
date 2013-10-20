using Atlas.Infrastructure.EF;
using System.Web.Http;

namespace Atlas.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly IDbContext context;

        protected BaseController(IDbContext context)
        {
            this.context = context;
        }
    }
}
