using Eticaret.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Eticaret.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;
        //Cache ekleme
        protected IMemoryCache cache;
        public BaseController(RepositoryWrapper repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }
    }
}
