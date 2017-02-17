using CartaoTodos.REST.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.REST.Client
{
    public class PerfilClient : BaseClient<Perfil>, IPerfilClient
    {
        public PerfilClient()
            :base("/Perfil")
        {

        }

        public IRestResponse<List<Perfil>> ObterPErfis(bool todos = false)
        {
            var request = new RestRequest("/Perfil", Method.GET);

            if (todos)
                request.AddParameter("all", true);

            return _client.Execute<List<Perfil>>(request);
        }
    }
}
