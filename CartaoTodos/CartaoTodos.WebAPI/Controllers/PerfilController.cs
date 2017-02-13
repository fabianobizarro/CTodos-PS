using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CartaoTodos.WebAPI.Controllers
{
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

        // POST: api/Perfil
        //public void Post([FromBody]PerfilViewModel value)
        //{

        //}

        //// PUT: api/Perfil/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Perfil/5
        //public void Delete(int id)
        //{
        //}
    }
}
