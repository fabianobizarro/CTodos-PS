using CartaoTodos.Domain.Entities;
using CartaoTodos.Domain.Interfaces.Repositories;
using CartaoTodos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Domain.Services
{
    public class PerfilService : BaseService<Perfil>, IPerfilService
    {
        public PerfilService(IPerfilRepository repo)
            : base(repo)
        {

        }
    }
}
