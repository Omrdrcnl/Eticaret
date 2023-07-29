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
        private RepositoryWrapper repo;

        public KategoriController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }


        //public KategoriController(KategoriRepository repository)
        //{
        //    this.repository = repository;
        //}

        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            List<Kategori> items = repo.KategoriRepository.FindAll().ToList<Kategori>();
            return new
            {
                success = true,
                data = items
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
