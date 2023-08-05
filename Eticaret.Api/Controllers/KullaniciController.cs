using Eticaret.Api.Code.Validation;
using Eticaret.Model;
using Eticaret.Model.Views;
using Eticaret.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {

        private RepositoryWrapper repo;

        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo,cache)
        {
            this.repo = repo;
        }

        [Authorize(Roles ="Admin, MusteriTemsilcisi, Personel")]
        [HttpPost("Getir")]
        public dynamic Getir([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());



            string KullaniciAdi = json.KullaniciAdi;
            string Sifre = json.Sifre;


            Kullanici item = repo.KullaniciRepository.FindByConditiation(a => a.KullaniciAdi == KullaniciAdi && a.Sifre == Sifre).SingleOrDefault<Kullanici>();

            if (item != null) { 
            return new
            {
                success = true,

            };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanici Adi veya Şifre Hatalı"
                };
            }

        }

        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string kullaniciAd = json.KullaniciAdi;
            string sifre = json.Sifre;

            Kullanici item = new Kullanici()
            {
                Aktif = true,
                KullaniciAdi = kullaniciAd,
                Sifre = sifre,
                RolId = Enums.Roller.Musteri
            };
            Kullanici? kullanici = repo.KullaniciRepository.FindByConditiation(k => k.KullaniciAdi == item.KullaniciAdi).SingleOrDefault<Kullanici>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu kullanıcı adı zaten kullanılıyor"
                };
            }

            KullaniciValidation validator = new KullaniciValidation();
            validator.ValidateAndThrow(item);

            repo.KullaniciRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }


        [Authorize(Roles ="Admin, Personel, MusteriTemsilcisi")]
        [HttpGet("AktifKullanicilar")]
        public dynamic AktifKullanicilar()
        {
            List<V_AktifKullanicilar> items = repo.KullaniciRepository.AktifKullanicilarGetir();

            return new
            {
                success = true,
                data = items
            };
        }

        

    }
}
