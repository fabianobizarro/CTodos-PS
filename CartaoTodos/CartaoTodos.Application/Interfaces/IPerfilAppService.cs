using CartaoTodos.Application.ViewModels;
using CartaoTodos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.Interfaces
{
    public interface IPerfilAppService :IBaseAppService<PerfilViewModel, Perfil>
    {
    }
}
