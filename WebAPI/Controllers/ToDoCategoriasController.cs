using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoCategoriasController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoCategoriasController(ToDoDBContext context)
        {
            _context = context;
        }

        // GET: api/ToDoCategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoCategorias>>> GetToDoCategorias()
        {
            return await _context.ToDoCategorias.ToListAsync();
        }

        // GET: api/ToDoCategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoCategorias>> GetToDoCategorias(int id)
        {
            var toDoCategorias = await _context.ToDoCategorias.FindAsync(id);

            if (toDoCategorias == null)
            {
                return NotFound();
            }

            return toDoCategorias;
        }

        // PUT: api/ToDoCategorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoCategorias(int id, ToDoCategorias toDoCategorias)
        {
            if (id != toDoCategorias.atividade_Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoCategorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoCategoriasExists(id))
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

        // POST: api/ToDoCategorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoCategorias>> PostToDoCategorias(ToDoCategorias toDoCategorias)
        {
            _context.ToDoCategorias.Add(toDoCategorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoCategorias", new { id = toDoCategorias.atividade_Id }, toDoCategorias);
        }

        // DELETE: api/ToDoCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoCategorias(int id)
        {
            var toDoCategorias = await _context.ToDoCategorias.FindAsync(id);
            if (toDoCategorias == null)
            {
                return NotFound();
            }

            _context.ToDoCategorias.Remove(toDoCategorias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoCategoriasExists(int id)
        {
            return _context.ToDoCategorias.Any(e => e.atividade_Id == id);
        }
    }
}
