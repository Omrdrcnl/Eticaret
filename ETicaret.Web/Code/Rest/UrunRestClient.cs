using Newtonsoft.Json.Linq;
using RestSharp;

namespace ETicaret.Web.Code.Rest
{
    public class UrunRestClient
    {
        private string BASE_API_URI = "https://localhost:7179/api";
        public dynamic Login(string kullaniciAdi, string sifre)
        {
            RestClient client = new RestClient(BASE_API_URI);

            RestRequest req = new RestRequest("/Urun/UrunKaydet", Method.Post);

            req.AddJsonBody(new
            {
               
            });

            RestResponse resp= client.Post(req);

            string msj = resp.Content.ToString();

            dynamic result = JObject.Parse(msj);

            return result;
        }
    }
}
