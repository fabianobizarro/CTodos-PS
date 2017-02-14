using AutoMapper;
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
            Mapper.Initialize(config =>
            {

                // Model => ViewModel    
                config.CreateMap<OperacaoUsuario, OperacaoUsuarioViewModel>();
                config.CreateMap<Perfil, PerfilViewModel>();
                config.CreateMap<Usuario, UsuarioViewModel>();
                config.CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>();
                config.CreateMap<UsuarioPerfil, PerfilViewModel>()
                    .ForMember(member => member.Id, opts => opts.MapFrom(p => p.Perfil.Id))
                    .ForMember(member => member.Nome, opts => opts.MapFrom(p => p.Perfil.Nome))
                    .ForMember(member => member.Ativo, opts => opts.MapFrom(p => p.Ativo));

                // ViewModel => Model
                config.CreateMap<OperacaoUsuarioViewModel, OperacaoUsuario>();
                config.CreateMap<PerfilViewModel, Perfil>();
                config.CreateMap<UsuarioViewModel, Usuario>()
                    .ForMember(m => m.Operacoes, o => o.Ignore());
                config.CreateMap<UsuarioPerfilViewModel, UsuarioPerfil>();

            });
        }
    }
}
