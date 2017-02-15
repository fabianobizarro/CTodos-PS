using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.ViewModels;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CartaoTodos.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _service;


        public UsuarioController(IUsuarioAppService service)
        {
            _service = service;
        }

        // GET: api/Usuario
        public IEnumerable<UsuarioViewModel> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(int id)
        {
            var usuario = _service.GetEntity(p => p.Id == id);
            if (usuario != null)
                return Content<UsuarioViewModel>(HttpStatusCode.OK, usuario);
            else
                return NotFound();
        }

        // POST: api/Usuario
        public IHttpActionResult Post([FromBody]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var model = new UsuarioViewModel()
                {
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha,
                    Email = usuario.Email,
                    DataInclusao = DateTime.Now,
                    Ativo = true
                };

                if (usuario.Perfis != null)
                {
                    model.Perfis = usuario.Perfis.Select(p => new PerfilViewModel()
                    {
                        Id = p.Id,
                        Ativo = p.Ativo
                    }).ToList();
                }
                else
                    model.Perfis = new List<PerfilViewModel>();

                _service.Add(model);
                return Created("Teste", model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Usuario/5
        public IHttpActionResult Put(int id, [FromBody]UsuarioViewModel model)
        {
            var usuario = _service.GetEntity(p => p.Id == id);
            if (usuario == null)
                return NotFound();
            else
            {
                model.Id = id;
                _service.Update(model);
                return Ok("Usuário alterado com sucesso");
            }
        }

        // DELETE: api/Usuario/5
        public IHttpActionResult Delete(int id)
        {
            var usuario = _service.GetEntity(p => p.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                _service.Delete(usuario);
                return Ok("Usuário removido com sucesso");
            }
            
        }

    }
}
