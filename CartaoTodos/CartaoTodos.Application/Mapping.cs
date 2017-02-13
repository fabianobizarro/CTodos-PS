using CartaoTodos.Application.ViewModels;
using CartaoTodos.Domain.Entities;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application
{
    public class Mapping
    {
        public static void RegisterMappings()
        {
            // Model => ViewModel
            TinyMapper.Bind<OperacaoUsuario, OperacaoUsuarioViewModel>();
            TinyMapper.Bind<Perfil, PerfilViewModel>();
            TinyMapper.Bind<Usuario, UsuarioViewModel>();
            TinyMapper.Bind<UsuarioPerfil, UsuarioPerfilViewModel>();

            // ViewModel => Model
            TinyMapper.Bind<OperacaoUsuarioViewModel, OperacaoUsuario>();
            TinyMapper.Bind<PerfilViewModel, Perfil>();
            TinyMapper.Bind<UsuarioViewModel, Usuario>(config => {
                config.Ignore(p => p.Operacoes);
            });
            TinyMapper.Bind<UsuarioPerfilViewModel, UsuarioPerfil>();
        }
    }
}
