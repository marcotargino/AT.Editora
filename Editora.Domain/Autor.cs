using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Editora.Domain
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo Nome deve ter no máximo 50 caracteres")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo ultimoNome é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo ultimoNome deve ter no máximo 50 caracteres")]
        public String UltimoNome { get; set; }

        [StringLength(50, ErrorMessage = "Campo Email deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
