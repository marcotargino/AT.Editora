using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Editora.Domain;
using Editora.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Editora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AutorController : ControllerBase
    {
        private readonly EditoraContext _context;

        public AutorController(EditoraContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {
            return await _context.Autores.Include(x => x.Livros).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await _context.Autores.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpPost]
        public async Task<ActionResult<Autor>> Post(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autor>> Delete(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return autor;
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
