using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms.Perfil
{
    public partial class Editar : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPerfil = Convert.ToInt32(Request.QueryString["id"]);

                var perfil = _apiClient.Perfil.Get(idPerfil).Data;

                if (perfil == null)
                {
                    Response.Redirect("/Perfil");
                }
                else
                {
                    Nome.Text = perfil.Nome;
                    Ativo.Checked = perfil.Ativo;
                    IdPerfil.Value = perfil.Id.ToString();
                }
            }
            
        }

        protected void btEditarPerfil_Click(object sender, EventArgs e)
        {
            int idPerfil = Convert.ToInt32(IdPerfil.Value);

            var perfil = new REST.Common.Perfil()
            {
                Id = idPerfil,
                Nome = Nome.Text,
                Ativo = Ativo.Checked
            };

            var response = _apiClient.Perfil.Update(perfil.Id, perfil);

            Response.Redirect("/Perfil");

        }
    }
}