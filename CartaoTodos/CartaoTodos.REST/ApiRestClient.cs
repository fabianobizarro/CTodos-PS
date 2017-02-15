﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;
using System.Web.Script.Serialization;
using CartaoTodos.REST.Common;

namespace CartaoTodos.REST
{
    public class ApiRestClient : IApiRestClient
    {
        private string _endpoint;
        private RestClient _client;

        public ApiRestClient()
        {
            _endpoint = ConfigurationManager.AppSettings["API_ENDPOINT"];
            _client = new RestClient(_endpoint);
        }

        public IEnumerable<Perfil> ObterPerfis()
        {
            var request = new RestRequest("/Perfil", Method.GET);

            var response = _client.Execute<List<Perfil>>(request);

            return response.Data;
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            var request = new RestRequest("/Usuario", Method.GET);

            request.OnBeforeDeserialization = (res => {
                res.Content = res.Content.Replace("\"Perfis\":[]", "\"Perfis\": null");
            });

            var response = _client.Execute<List<Usuario>>(request);

            return response.Data;
        }

        public Usuario ObterUsuario(int idUsuario)
        {
            var request = new RestRequest("/Usuario", Method.GET);

            request.AddParameter("id", idUsuario);

            request.OnBeforeDeserialization = (res => {
                res.Content = res.Content.Replace("\"Perfis\":[]", "\"Perfis\": null");
            });

            var response = _client.Execute<Usuario>(request);

            return response.Data;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            var request = new RestRequest("/Usuario", Method.POST);

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Serialize(usuario);
            
            request.AddBody(usuario);

            var response = _client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //TODO: Estourar exceção
            }
        }
    }
}
