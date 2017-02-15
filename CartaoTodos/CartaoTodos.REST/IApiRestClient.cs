using CartaoTodos.REST.Common;
using System.Collections.Generic;

namespace CartaoTodos.REST
{
    public interface IApiRestClient
    {
        IEnumerable<Perfil> ObterPerfis();

        IEnumerable<Usuario> ObterUsuarios();

        Usuario ObterUsuario(int idUsuario);
        void AdicionarUsuario(Usuario usuario);
    }
}
