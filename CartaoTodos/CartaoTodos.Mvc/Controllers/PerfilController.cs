using CartaoTodos.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IApiRestClient _client;

        public PerfilController(IApiRestClient client)
        {
            _client = client;
        }

        // GET: Perfil
        public ActionResult Index()
        {
            var perfis = _client.ObterPerfis().ToList();
            return View(perfis);
        }
    }
}