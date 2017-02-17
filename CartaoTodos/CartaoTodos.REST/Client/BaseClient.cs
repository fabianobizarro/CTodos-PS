using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;

namespace CartaoTodos.REST.Client
{
    public class BaseClient<T> : IClient<T> where T : new()
    {
        protected string _apiEndpoint;
        protected RestClient _client;
        protected string _resourceUri;

        public BaseClient(string ApiEndpoint, string resourceUri)
        {
            _apiEndpoint = ApiEndpoint;
            _client = new RestClient(ApiEndpoint);
        }

        public BaseClient(string resourceUri)
            :this(ConfigurationManager.AppSettings["API_ENDPOINT"], resourceUri)
        {
        }

        public virtual IRestResponse Add(T model)
        {
            var request = new RestRequest(this._resourceUri, Method.POST);
            request.AddJsonBody(model);

            return _client.Execute(request);
        }

        public virtual IRestResponse<T> Get(int id)
        {
            var request = new RestRequest(_resourceUri, Method.GET);
            request.AddParameter("id", id);
            return _client.Execute<T>(request);
        }

        public virtual IRestResponse<List<T>> GetAll()
        {
            var request = new RestRequest(_resourceUri, Method.GET);
            return _client.Execute<List<T>>(request);
        }

        public virtual IRestResponse Remove(int id)
        {
            var request = new RestRequest(_resourceUri, Method.DELETE);
            request.AddParameter("id", id);
            return _client.Execute<T>(request);
        }

        public IRestResponse Update(int id, T model)
        {
            var request = new RestRequest(this._resourceUri, Method.PUT);

            request.AddParameter("id", id);
            request.AddJsonBody(model);

            return _client.Execute(request);
        }

    }
}
