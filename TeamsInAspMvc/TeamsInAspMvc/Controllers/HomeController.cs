using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeamsInAspMvc.Commons.Interfaces;
using TeamsInAspMvc.Models.Objetos;

namespace TeamsInAspMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpMethod httpMethod;

        public HomeController(IHttpMethod _httpMethod)
        {
            httpMethod = _httpMethod;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoginTeams (string email, string password)
        {
            var respuesta = new Respuesta()
            {
                Resultado = await httpMethod.GetTokenAccess(email,password)
            };

           return Json(respuesta);
        }

    }
}