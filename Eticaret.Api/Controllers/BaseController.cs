using Eticaret.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;
        public BaseController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }
    }
}
