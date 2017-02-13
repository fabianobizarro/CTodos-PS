using Nelibur.ObjectMapper.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Perfis = new List<UsuarioPerfilViewModel>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter no máximo {1} caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(70, ErrorMessage = "Este campo deve conter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }

        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual ICollection<UsuarioPerfilViewModel> Perfis { get; set; }

        public virtual ICollection<OperacaoUsuarioViewModel> Operacoes { get; set; }
    }
}
