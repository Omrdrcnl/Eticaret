using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private KategoriRepository repository;

        public KategoriController(KategoriRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            List<Kategori> items = repository.FindAll().ToList<Kategori>();
            return new
            {
                sucess = true,
                data = items
            };
        }
    }
}
