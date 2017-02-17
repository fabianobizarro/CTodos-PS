using CartaoTodos.REST.Common;
using System.Collections.Generic;

namespace CartaoTodos.REST
{
    public interface IApiRestClient
    {
        IEnumerable<Perfil> ObterPerfis(bool todos = false);

        IEnumerable<Usuario> ObterUsuarios();

        Usuario ObterUsuario(int idUsuario);
        void AdicionarUsuario(Usuario usuario);
        void ExcluirUsuario(int usuarioId);
        void AdicionarPerfil(int usuarioId, int perfilId, bool ativo = true);
        Perfil ObterPerfil(int idPerfil);
        void RemoverPerfil(int usuarioId, int perfilId);
        void EditarUsuario(Usuario usuario);
        void AdicionarPerfil(Perfil perfil);
        void EditarPerfil(Perfil perfil);
        void RemoverPerfil(int id);
    }
}
