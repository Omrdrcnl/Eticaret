﻿using Eticaret.Model;
using Eticaret.Repository;
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

    }
}
