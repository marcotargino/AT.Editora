using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Editora.Domain
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo Titulo deve ter no máximo 50 caracteres")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Campo ISBN é obrigatório")]
        
        public String ISBN { get; set; }

        [Required(ErrorMessage = "Campo Ano é obrigatório")]
        public int Ano { get; set; }

        [JsonIgnore]
        public Autor Autor { get; set; }

        
        public int AutorId { get; set; }

    }
}
