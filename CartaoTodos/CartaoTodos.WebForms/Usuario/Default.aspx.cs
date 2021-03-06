﻿using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms.Usuario
{
    public partial class Default : BasePage
    {
        public IEnumerable<REST.Common.Usuario> ListaUsuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuarios = _apiClient.Usuario.GetAll().Data;
        }
    }
}