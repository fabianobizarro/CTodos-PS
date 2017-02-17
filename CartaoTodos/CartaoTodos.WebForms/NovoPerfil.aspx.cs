﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class NovoPerfil : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btCadastrarPerfil_Click(object sender, EventArgs e)
        {
            var perfil = new REST.Common.Perfil()
            {
                Nome = Nome.Text,
                Ativo = Ativo.Checked
            };

            _apiClient.AdicionarPerfil(perfil);

            Response.Redirect("/Perfil");
        }
    }
}