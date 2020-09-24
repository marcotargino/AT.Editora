using Editora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Editora.WEB.Models.Autor
{
    public class ListarAutorViewModel
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String UltimoNome { get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
