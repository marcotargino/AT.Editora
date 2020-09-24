using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Editora.WEB.Models.Livros
{
    public class ListarLivroViewModel
    {
        public String Titulo { get; set; }

        public String ISBN { get; set; }

        public int Ano { get; set; }

        [JsonIgnore]
        public Domain.Autor Autor { get; set; }

        public int AutorId { get; set; }
    }
}
