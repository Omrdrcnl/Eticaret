using Eticaret.Model;
using Eticaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Eticaret.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController (RepositoryWrapper repo, IMemoryCache cache) : base (repo, cache) { }

        [HttpPost("Login")]
        public dynamic Login([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string kullaniciAd = json.KullaniciAdi;
            string sifre = json.Sifre;

            Kullanici item = repo.KullaniciRepository.FindByConditiation(k => k.KullaniciAdi == kullaniciAd && k.Sifre == sifre).SingleOrDefault<Kullanici>();

            if (item != null)
            {
                Rol rol = repo.RolRepository.FindByConditiation(r => r.Id== item.RolId).SingleOrDefault<Rol>();

                Dictionary<string, object> claims = new Dictionary<string, object>();
                claims.Add(ClaimTypes.Role, rol.Ad);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("ETicaretKeyVektorelAhlatciGrupDersi");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(10000),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new
                {
                    success = true,
                    data = tokenHandler.WriteToken(token),
                    rol = rol?.Ad
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanıcı adı veya şifre hatalı"
                };
            }

        }
    }
}
