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
        void ExcluirUsuario(int usuarioId);
        void AdicionarPerfil(int usuarioId, int perfilId, bool ativo = true);
        void RemoverPerfil(int usuarioId, int perfilId);
        void EditarUsuario(Usuario usuario);
    }
}
