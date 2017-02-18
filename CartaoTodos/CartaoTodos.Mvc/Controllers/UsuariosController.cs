using CartaoTodos.Mvc.Models;
using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IApiClient _client;

        public UsuariosController(IApiClient client)
        {
            _client = client;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = _client.Usuario.GetAll().Data;

            if (usuarios == null)
                usuarios = new List<Usuario>();

            return View(usuarios);
        }

        public ActionResult Novo()
        {
            var model = new CadastroUsuarioViewModel();
            model.Perfis = _client.Perfil.ObterPErfis().Data;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(CadastroUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PerfisUsuario != null)
                    model.Usuario.Perfis = model.PerfisUsuario.Select(p => new Perfil() { Id = p }).ToList();

                model.Usuario.Ativo = true;

                _client.Usuario.Add(model.Usuario);
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Detalhes(int id)
        {
            var usuario = _client.Usuario.Get(id).Data;

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
            model.Usuario = _client.Usuario.Get(id).Data;

            if (model.Usuario == null)
            {
                ViewBag.MensagemErro = "Usuário inexistente";
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                model.Perfis = _client.Perfil.GetAll().Data;
                TempData["Perfis"] = model.Perfis;
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CadastroUsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _client.Usuario.Update(model.Usuario.Id, model.Usuario);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Perfis = TempData["Perfis"] as IEnumerable<Perfil>;
                    TempData.Keep();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                model.Perfis = TempData["Perfis"] as IEnumerable<Perfil>;
                TempData.Keep();
                return View(model);
            }

        }

        public ActionResult Excluir(int id)
        {
            var usuario = _client.Usuario.Get(id).Data;

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
                _client.Usuario.Remove(model.Id);
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AdicionarPerfil(int usuarioId, int perfilId)
        {
            try
            {
                var novoPerfil = new Perfil() { Id = perfilId };
                _client.PerfilUsuario.VincularPerfil(usuarioId, novoPerfil);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult RemoverPerfil(int usuarioId, int perfilId)
        {
            try
            {
                _client.PerfilUsuario.DesvincularPerfil(usuarioId, perfilId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}