using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IApiClient _client;

        public PerfilController(IApiClient client)
        {
            _client = client;
        }

        // GET: Perfil
        public ActionResult Index()
        {
            var perfis = _client.Perfil.ObterPErfis(true).Data;
            return View(perfis);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Perfil model)
        {
            if (ModelState.IsValid)
            {
                var response = _client.Perfil.Add(model);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ViewBag.MensagemErro = "Não foi possível cadastrar o perfil. \n" + response.ErrorMessage;
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            else
                return View(model);

        }

        public ActionResult Editar(int id)
        {
            var perfil = _client.Perfil.Get(id).Data;
            if (perfil == null)
            {
                ViewBag.MensagemErro = "O id informado é inválido";
                return RedirectToAction("Index");
            }
            else
                return View(perfil);

        }

        [HttpPost]
        public ActionResult Editar(Perfil model)
        {
            if (ModelState.IsValid)
            {
                var response = _client.Perfil.Update(model.Id, model);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ViewBag.MensagemErro = "Não foi possível completar a operação. \n " + response.ErrorMessage;
                    return View(model);
                }
                else
                    return RedirectToAction("Index");
            }
            else
                return View(model);

        }

        public ActionResult Detalhes(int id)
        {
            var perfil = _client.Perfil.Get(id).Data;
            if (perfil == null)
            {
                ViewBag.MensagemErro = "O id informado é inválido";
                return RedirectToAction("Index");
            }
            else
                return View(perfil);
        }

        public ActionResult Excluir(int id)
        {
            var perfil = _client.Perfil.Get(id).Data;
            if (perfil == null)
            {
                ViewBag.MensagemErro = "O id informado é inválido";
                return RedirectToAction("Index");
            }
            else
                return View(perfil);
        }

        [HttpPost]
        public ActionResult Excluir(Perfil model)
        {
            var response = _client.Perfil.Remove(model.Id);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.MensagemErro = "Não foi possível remover este perfil. \n" + response.ErrorMessage;
                return View(model);
            }
            else
                return RedirectToAction("Index");
        }

    }
}