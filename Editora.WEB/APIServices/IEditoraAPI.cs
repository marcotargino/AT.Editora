using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Editora.Web.APIServices
{
   public interface IEditoraAPI
    {
        
        Task<List<Domain.Autor>> GetAsync();

    }
}
