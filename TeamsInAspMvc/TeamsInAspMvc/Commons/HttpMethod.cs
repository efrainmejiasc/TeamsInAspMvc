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
        public async Task<bool> GetTokenAccess(string email , string password)
        {
            bool resultado = true;
            string respuesta = string.Empty;
            HttpResponse<string> response = Unirest.get("https://outlook.office365.com/api/v1.0/me/").basicAuth(email, password).asJson<string>();


            if (response.Code == 200)
               respuesta =  response.Body;
            else
                resultado = false;
            

            return resultado;
        }

    }
}