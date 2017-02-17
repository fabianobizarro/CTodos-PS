using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.REST
{
    public interface IApiClient
    {
        IPerfilClient Perfil { get; set; }
        IPerfilUsuarioClient PerfilUsuario { get; set; }
        IUsuarioClient Usuario { get; set; }
    }
}
