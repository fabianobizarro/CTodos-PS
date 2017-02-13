using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CartaoTodos.WebAPI.Controllers
{
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
        public IHttpActionResult Post([FromBody]UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataInclusao = DateTime.Now;
                usuario.Ativo = true;
                _service.Add(usuario);
                return Created("Teste", usuario);
            }
            else
            {
                //TODO: Get validation Erros
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Usuario/5
        public IHttpActionResult Put(int id, [FromBody]UsuarioViewModel usuario)
        {
            return Ok();
        }

        // DELETE: api/Usuario/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
