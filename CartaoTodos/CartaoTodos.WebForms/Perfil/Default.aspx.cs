﻿using CartaoTodos.IoC;
using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms.Perfil
{
    public partial class Default : BasePage
    {
        public IEnumerable<CartaoTodos.REST.Common.Perfil> Perfis { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Perfis = _apiClient.Perfil.ObterPErfis(todos: true).Data;
            if (Perfis == null)
                Perfis = new List<REST.Common.Perfil>();
        }
    }
}