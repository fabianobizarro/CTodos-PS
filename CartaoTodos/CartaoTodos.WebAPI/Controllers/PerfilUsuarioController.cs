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
    [Route("api/Usuario/{usuarioId}/perfil")]
    public class PerfilUsuarioController : ApiController
    {
        private readonly IUsuarioPerfilAppService _service;
        private readonly IUsuarioAppService _usuarioService;

        public PerfilUsuarioController(IUsuarioPerfilAppService service, IUsuarioAppService usuarioService)
        {
            _service = service;
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario/{usuarioId}/perfil
        public IHttpActionResult Get(int usuarioId)
        {
            var usuario = _usuarioService.GetAll().FirstOrDefault(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                var result = usuario.Perfis == null ? new PerfilViewModel[] { } : usuario.Perfis;
                return Content(HttpStatusCode.OK, result);
            }
        }

        // POST: api/Usuario/{usuarioId}/perfil
        public IHttpActionResult Post(int usuarioId, [FromBody]Perfil perfil)
        {
            var usuario = _usuarioService.GetEntity(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                var usuarioPerfil = new UsuarioPerfilViewModel()
                {
                    Ativo = perfil.Ativo,
                    IdPerfil = perfil.Id,
                    IdUsuario = usuarioId
                };
                _service.Add(usuarioPerfil);
                return Ok("Perfil vinculado com sucesso");
            }
        }

        // PUT: api/Usuario/{usuarioId}/perfil/5
        public IHttpActionResult Put(int usuarioId, int id, [FromBody]bool ativo)
        {
            var usuario = _usuarioService.GetEntity(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                var perfil = usuario.Perfis.Where(p => p.Id == id).FirstOrDefault();
                if (perfil == null) return NotFound();

                _service.Update(new UsuarioPerfilViewModel()
                {
                    IdPerfil = id,
                    Ativo = ativo,
                    IdUsuario = usuarioId
                });

                return Ok("Perfil so usuário atualizado com sucesso");
            }
        }

        // DELETE: api/Usuario/{usuarioId}/perfil/5
        public IHttpActionResult Delete(int usuarioId, int id)
        {
            var usuario = _usuarioService.GetEntity(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                _service.Delete(new UsuarioPerfilViewModel()
                {
                    IdPerfil = id,
                    IdUsuario = usuarioId
                });

                return Ok("Perfil do usuário removido com sucesso");
            }
        }

    }
}
