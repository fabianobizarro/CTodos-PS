using CartaoTodos.Mvc.Models;
using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IApiRestClient _client;

        public UsuariosController(IApiRestClient client)
        {
            _client = client;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = _client.ObterUsuarios();

            if (usuarios == null)
                usuarios = new List<Usuario>();

            return View(usuarios);
        }

        public ActionResult Novo()
        {
            var model = new CadastroUsuarioViewModel();
            model.Perfis = _client.ObterPerfis();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(CadastroUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Usuario.Perfis = model.PerfisUsuario.Select(p => new Perfil() { Id = p }).ToList();

                _client.AdicionarUsuario(model.Usuario);
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Detalhes(int id)
        {
            var usuario = _client.ObterUsuario(id);

            if (usuario == null)
            {
                // TODO: Usuário não existe
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(usuario);
            }
        }

        public ActionResult Editar(int id)
        {
            var model = new CadastroUsuarioViewModel();
            model.Usuario = _client.ObterUsuario(id);
            

            if (model.Usuario == null)
            {
                // TODO: Usuário não existe
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                model.Perfis = _client.ObterPerfis();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CadastroUsuarioViewModel model)
        {
            return View();
        }

        public ActionResult Excluir(int id)
        {
            var usuario = _client.ObterUsuario(id);

            if (usuario == null)
            {
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(Usuario model)
        {
            try
            {
                _client.ExcluirUsuario(model.Id);
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
    }
}