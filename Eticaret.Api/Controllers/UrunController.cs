using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : BaseController
    {
        private RepositoryWrapper repo;
        
        public UrunController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
            
        }

        [HttpGet("TumUrunler/{kategoriId}")]
        public dynamic TumUrunler(int kategoriId)
        {
            List<Urun> items = repo.UrunRepository.UrunKategorileriniGetir(kategoriId);


            return new
            {
                success = true,
                data = items
            };

        }

        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Urun urun = new Urun()
            {
                Ad = json.Ad,
                Aciklama = json.Aciklama,
                Adet = json.Adet,
                Id = json.Id,
                Fiyat = json.Fiyat,
            };
            
            if(urun.Id > 5)
            {
                repo.UrunRepository.Update(urun);
            }
            else
            {
                foreach(var kategoriId in json.Kategoriler)
                {
                    urun.UrunKategoriler.Add(new UrunKategori() { KategoriId = kategoriId });
                }
                repo.UrunRepository.Create(urun);
            }
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            repo.UrunRepository.Sil(id);
            if(id < 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id"
                };
            }
            return new
            {
                success = true,
            };
        }

      
    }
}
