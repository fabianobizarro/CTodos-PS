using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.ViewModels;
using CartaoTodos.Domain.Entities;
using CartaoTodos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.Services
{
    public class UsuarioPerfilAppService : BaseAppService<UsuarioPerfilViewModel, UsuarioPerfil>, IUsuarioPerfilAppService
    {
        public UsuarioPerfilAppService(IUsuarioPerfilService service)
            : base(service)
        {

        }

        public override void Update(UsuarioPerfilViewModel viewModel)
        {
            var usuarioPerfil = _service.GetEntity(p => p.IdPerfil == viewModel.IdPerfil && p.IdUsuario == viewModel.IdUsuario);

            usuarioPerfil.Ativo = viewModel.Ativo;
            _service.Update(usuarioPerfil);
        }

        public override void Delete(UsuarioPerfilViewModel viewModel)
        {
            var perfilUsuario = _service.GetAll().First(p => p.IdPerfil == viewModel.IdPerfil && p.IdUsuario == viewModel.IdUsuario);

            _service.Delete(perfilUsuario);
        }
    }
}
