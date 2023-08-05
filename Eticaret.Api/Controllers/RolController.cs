using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Eticaret.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : BaseController
    {
        private RepositoryWrapper repo;

        public RolController(RepositoryWrapper repo, IMemoryCache cache) :base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("tumRoller")]
        public dynamic TumRoller()
        {
            List<Rol> items = repo.RolRepository.FindAll().ToList<Rol>();
            return new
            {
                success = true,
                item = items
            };
        }

        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Rol item = new Rol()
            {
                Id = json.Id,
                Ad = json.Ad
            };
            if(string.IsNullOrEmpty(json.Ad))
            {
                return new
                {
                    success = false,
                    message = "Ad alanı boş geçilemez"
                };
            }

            if (item.Id > 0)
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }

        [HttpDelete("Id")]
        public dynamic Delete(int id)
        {
            if(id < 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id"
                };
            }
            repo.RolRepository.RolSil(id);
            return new
            { success = true };
        }
    }
}
