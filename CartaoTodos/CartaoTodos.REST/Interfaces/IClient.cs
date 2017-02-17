using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.REST
{
    public interface IClient<T>
    {
        IRestResponse<T> Get(int id);
        IRestResponse<List<T>> GetAll();
        IRestResponse Add(T model);
        IRestResponse Remove(int id);
        IRestResponse Update(int id, T model);
    }
}
