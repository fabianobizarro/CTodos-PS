using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartaoTodos.REST.Common
{
    public class Usuario
    {
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

        public List<Perfil> Perfis { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

    }
}