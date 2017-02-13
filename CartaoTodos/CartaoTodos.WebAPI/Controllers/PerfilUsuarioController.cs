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
            var usuario = _usuarioService.GetEntity(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                var result = usuario.Perfis == null ? new UsuarioPerfilViewModel[] { } : usuario.Perfis;
                return Content(HttpStatusCode.OK, result);
            }
        }

        // POST: api/Usuario/{usuarioId}/perfil
        public IHttpActionResult Post(int usuarioId, [FromBody]PerfilViewModel model)
        {
            var usuario = _usuarioService.GetEntity(p => p.Id == usuarioId);
            if (usuario == null)
                return NotFound();
            else
            {
                var usuarioPerfil = new UsuarioPerfilViewModel()
                {
                    Ativo = true,
                    IdPerfil = model.Id,
                    IdUsuario = usuarioId
                };
                _service.Add(usuarioPerfil);
                return Ok();
            }
        }

        // PUT: api/Usuario/{usuarioId}/perfil/5
        public void Put(int usuarioId, int id, [FromBody]PerfilViewModel model)
        {
        }

        // DELETE: api/Usuario/{usuarioId}/perfil/5
        public void Delete(int usuarioId, int id)
        {
        }

        private Action<int, Action> ValidateUsuario = (usuarioId, callback) =>
        {



        };

    }
}
