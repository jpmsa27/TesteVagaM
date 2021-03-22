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
    public class ToDoListasController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoListasController(ToDoDBContext context)
        {
            _context = context;
        }

        // GET: api/ToDoListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoLista>>> GetToDoLista()
        {
            return await _context.ToDoLista.ToListAsync();
        }

        // GET: api/ToDoListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoLista>> GetToDoLista(int id)
        {
            var toDoLista = await _context.ToDoLista.FindAsync(id);

            if (toDoLista == null)
            {
                return NotFound();
            }

            return toDoLista;
        }

        // PUT: api/ToDoListas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoLista(int id, ToDoLista toDoLista)
        {
            if (id != toDoLista.lista_Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListaExists(id))
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

        // POST: api/ToDoListas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoLista>> PostToDoLista(ToDoLista toDoLista)
        {
            _context.ToDoLista.Add(toDoLista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoLista", new { id = toDoLista.lista_Id }, toDoLista);
        }

        // DELETE: api/ToDoListas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoLista(int id)
        {
            var toDoLista = await _context.ToDoLista.FindAsync(id);
            if (toDoLista == null)
            {
                return NotFound();
            }

            _context.ToDoLista.Remove(toDoLista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoListaExists(int id)
        {
            return _context.ToDoLista.Any(e => e.lista_Id == id);
        }
    }
}
