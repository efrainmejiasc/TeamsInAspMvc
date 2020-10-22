using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeamsInAspMvc.Commons.Interfaces;
using unirest_net.http;

namespace TeamsInAspMvc.Commons
{
    public class HttpMethod : IHttpMethod
    {
        public bool GetTokenAccess(string email, string password)
        {
            bool resultado = true;
            string respuesta = string.Empty;
            HttpResponse<string> response = Unirest.get("https://login.microsoftonline.com/common/login").basicAuth(email, password).asJson<string>();


            if (response.Code == 200)
                respuesta = response.Body;
            else
                resultado = false;


            return resultado;
        }

        public async Task<bool> Login (string email, string password)
        {
            bool resultado = true;
            string respuesta = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(email + ":" + password);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Add("accept-language", "en_ES");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                Uri url = new Uri("https://login.microsoftonline.com/common/login", UriKind.Absolute);
                List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
                formData.Add(new KeyValuePair<string, string>("email", email));
                formData.Add(new KeyValuePair<string, string>("password", password));
                HttpContent content = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                
                }
            }

            return resultado;
        }

    }
}