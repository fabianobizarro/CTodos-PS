using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class NovoUsuario : BasePage
    {
        public IEnumerable<CartaoTodos.REST.Common.Perfil> ListaPerfis;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var listaPerfil = _apiClient.ObterPerfis();

                foreach (var perfil in listaPerfil)
                    Perfis.Items.Add(new ListItem(perfil.Nome, perfil.Id.ToString()));
            }
        }

        protected void btCadastrarUsuario_Click(object sender, EventArgs e)
        {
            var camposValidos = ValidarCampos();

            if (camposValidos)
            {

                var perfisSelecionados = new List<REST.Common.Perfil>();

                foreach (ListItem item in Perfis.Items)
                {
                    if (item.Selected)
                    {
                        perfisSelecionados.Add(new REST.Common.Perfil() { Id = Int32.Parse(item.Value), Nome = item.Text });
                    }
                }
                //var perfisSelecionado = Perfis.Items;

                var usuario = new Usuario()
                {
                    Nome = Nome.Text,
                    Email = Email.Text,
                    Login = Email.Text,
                    Senha = Senha.Text,
                    Perfis = perfisSelecionados
                };

                _apiClient.AdicionarUsuario(usuario);

                Response.Redirect("/Usuarios");

            }
        }

        private bool ValidarCampos()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Nome.Text))
            {
                MensagemNome.Text = "O nome é obrigatório";
                valid = false;
            }
            else if (Nome.Text.Length > 100)
            {
                MensagemNome.Text = "O nome deve conter no máximo 100 caracteres";
                valid = false;
            }

            if (string.IsNullOrEmpty(Email.Text))
            {
                MensagemEmail.Text = "O email é obrigatório";
                valid = false;
            }
            else if (Email.Text.Length > 70)
            {
                MensagemEmail.Text = "O nome deve conter no máximo 70 caracteres";
                valid = false;
            }

            if (string.IsNullOrEmpty(Login.Text))
            {
                MensagemLogin.Text = "O login é obrigatório";
                valid = false;
            }
            else if (Login.Text.Length > 50)
            {
                MensagemLogin.Text = "O login deve conter no máximo 50 caracteres";
                valid = false;
            }

            return valid;
        }
    }
}