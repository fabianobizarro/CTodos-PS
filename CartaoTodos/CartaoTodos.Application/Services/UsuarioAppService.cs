using AutoMapper;
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
    public class UsuarioAppService : BaseAppService<UsuarioViewModel, Usuario>, IUsuarioAppService
    {
        public UsuarioAppService(IUsuarioService service)
            : base(service)
        {

        }

        public override void Add(UsuarioViewModel viewModel)
        {
            var usuario = new Usuario()
            {
                DataInclusao = DateTime.Now,
                Ativo = true,
                Email = viewModel.Email,
                Login = viewModel.Login,
                Nome = viewModel.Nome,
                Senha = viewModel.Senha,

            };

            usuario.Perfis = viewModel.Perfis.ToList().Select(p => new UsuarioPerfil()
            {
                IdPerfil = p.Id,
                Ativo = p.Ativo
            }).ToList();

            _service.Add(usuario);
        }

        public override void Update(UsuarioViewModel viewModel)
        {
            var usuario = _service.GetEntity(p => p.Id == viewModel.Id);

            usuario.Nome = viewModel.Nome;
            usuario.Email = viewModel.Email;
            usuario.Login = viewModel.Login;
            usuario.Senha = viewModel.Senha;
            usuario.Ativo = viewModel.Ativo;

            _service.Update(usuario);
        }

        public override void Delete(UsuarioViewModel viewModel)
        {
            var usuario = _service.GetEntity(p => p.Id == viewModel.Id);

            _service.Delete(usuario);
        }
    }
}
