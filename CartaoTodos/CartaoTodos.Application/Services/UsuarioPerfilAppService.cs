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
    }
}
