using Newtonsoft.Json.Linq;
using RestSharp;

namespace ETicaret.Web.Code.Rest
{
    public class UserRestClient
    {

        private string BASE_API_URI = "https://localhost:7179/api";

        public dynamic Login(string kullaniciAdi, string sifre)
        {
            RestClient client = new RestClient(BASE_API_URI);

            RestRequest req = new RestRequest("/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
