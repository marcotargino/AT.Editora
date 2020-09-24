using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Editora.Domain
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo login é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo login deve ter no máximo 50 caracteres")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [StringLength(10, ErrorMessage = "Campo senha deve ter no máximo 10 caracteres")]
        public String Password { get; set; }

    }
}
