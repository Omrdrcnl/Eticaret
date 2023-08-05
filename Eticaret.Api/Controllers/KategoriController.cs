using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        private RepositoryWrapper repo;

        public KategoriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        

        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            List<Kategori> items;

            if(!cache.TryGetValue("TumKategoriler", out items))
            {
                items = repo.KategoriRepository.FindAll().ToList<Kategori>();

                cache.Set("TumKategoriler", items, DateTimeOffset.UtcNow.AddSeconds(20));
            }

            
            return new
            {
                success = true,
                data = items
            };
        }

        [Authorize(Roles = "Admin,Personel")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kategori item = new Kategori()
            {
                Id = json.Id,
                Ad = json.Ad,
                Aktif = json.Aktif,
                Foto = json.Foto,
                Sira = json.Sira,
                UstKategori = json.UstKategori,
            };
            if(item.Id>0)
            {
                repo.KategoriRepository.Update(item);
            }
            else
            {
                repo.KategoriRepository.Create(item);
            }
            repo.SaveChanges();

            cache.Remove("TumKategoriler");

            return new
            {
                success = true
            };
        }


        [HttpGet("{Id}")]
        public dynamic Get(int Id)
        {
            Kategori item = repo.KategoriRepository.FindByConditiation(a => a.Id == Id).SingleOrDefault<Kategori>();
            return new
            {
                success = true,
                data = item
            };
        }

       
        [HttpGet("AnasayfaKategoriler")]
        public dynamic AnasayfaKategoriler()
        {



            List<Kategori> items = repo.KategoriRepository.AnaSayfaKategorileriniGetir();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("UstKategoriler")]
        public dynamic UstKategoriler()
        {
            Kategori item = repo.KategoriRepository.FindByConditiation(a => a.Id == null).SingleOrDefault<Kategori>();
            return new
            {
                success = true,
                data = item
            };
        }
        //[HttpGet("TumKategoriler")]
        //public dynamic TumKategoriler()
        //{
        //    List<Kategori> items = repo.KategoriRepository.FindAll().ToList<Kategori>();
        //    return new
        //    {
        //        success = true,
        //        data = items
        //    };
        //} 
        //[HttpGet("TumKategoriler")]
        //public dynamic TumKategoriler()
        //{
        //    List<Kategori> items = repo.KategoriRepository.FindAll().ToList<Kategori>();
        //    return new
        //    {
        //        success = true,
        //        data = items
        //    };
        //}
    };
}
