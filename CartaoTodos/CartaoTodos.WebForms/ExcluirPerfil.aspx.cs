using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class ExcluirPerfil : BasePage
    {
        protected REST.Common.Perfil Perfil;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPerfil = Convert.ToInt32(Request.QueryString["id"]);
                Perfil = _apiClient.ObterPerfil(idPerfil);

                if (Perfil == null)
                    Response.Redirect("/Perfil");

                IdPerdil.Value = idPerfil.ToString();
            }
        }

        protected void btExcluirPerfil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdPerdil.Value);

            _apiClient.RemoverPerfil(id);

            Response.Redirect("/Perfil");
        }
    }
}