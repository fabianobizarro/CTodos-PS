using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CartaoTodos.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PerfilController : ApiController
    {
        protected readonly IPerfilAppService _service;

        public PerfilController(IPerfilAppService service)
        {
            _service = service;
        }

        // GET: api/Perfil
        public IEnumerable<PerfilViewModel> Get(bool all = false)
        {
            if (all)
                return _service.GetAll();
            else
                return _service.GetAll().Where(p => p.Ativo);
        }

        // GET: api/Perfil/5
        [ResponseType(typeof(PerfilViewModel))]
        public IHttpActionResult Get(int id)
        {
            var perfil = _service.GetEntity(p => p.Id == id);
            if (perfil == null)
                return NotFound();
            else
                return Content(HttpStatusCode.OK, perfil);
        }

        //POST: api/Perfil
        public IHttpActionResult Post([FromBody]PerfilViewModel perfil)
        {
            if (ModelState.IsValid)
            {
                _service.Add(perfil);
                return Ok("Perfil Cadastrado");
            }
            else
                return BadRequest(ModelState);
        }

        // PUT: api/Perfil/5
        public IHttpActionResult Put(int id, [FromBody]PerfilViewModel perfil)
        {
            var entity = _service.GetEntity(p => p.Id == id);
            if (entity == null)
                return NotFound();
            else
            if (ModelState.IsValid)
            {
                perfil.Id = id;
                _service.Update(perfil);
                return Ok("Perfil atualizado.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Perfil/5
        public IHttpActionResult Delete(int id)
        {
            var perfil = _service.GetEntity(p => p.Id == id);
            if (perfil == null)
                return NotFound();
            else
            {
                _service.Delete(perfil);
                return Ok("Perfil excluído");
            }
        }
    }
}
