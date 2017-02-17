using CartaoTodos.REST.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.REST
{
    public interface IPerfilClient : IClient<Perfil>
    {
        IRestResponse<List<Perfil>> ObterPErfis(bool todos = false);
    }
}
