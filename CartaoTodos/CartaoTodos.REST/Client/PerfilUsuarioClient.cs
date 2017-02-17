using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CartaoTodos.REST.Client
{
    public class PerfilUsuarioClient : BaseClient<Perfil>, IPerfilUsuarioClient
    {
        public PerfilUsuarioClient()
            :base("/Usuario/:id/perfil")
        {
        }

        public IRestResponse DesvincularPerfil(int usuarioId, int perfilId)
        {
            var request = new RestRequest($"/Usuario/{usuarioId}/perfil", Method.DELETE);
            request.AddParameter("id", perfilId);
            return _client.Execute(request);
        }

        public IRestResponse VincularPerfil(int usuarioId, Perfil perfil)
        {
            var request = new RestRequest($"/Usuario/{usuarioId}/perfil", Method.POST);
            request.AddJsonBody(perfil);
            return _client.Execute(request);
        }
    }
}
