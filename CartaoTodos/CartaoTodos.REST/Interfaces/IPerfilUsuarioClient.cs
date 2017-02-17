using CartaoTodos.REST.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.REST
{
    public interface IPerfilUsuarioClient : IClient<Perfil>
    {
        IRestResponse VincularPerfil(int usuarioId, Perfil perfil);
        IRestResponse DesvincularPerfil(int usuarioId, int perfilId);

    }
}
