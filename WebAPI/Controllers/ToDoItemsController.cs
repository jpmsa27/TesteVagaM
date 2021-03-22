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
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoItemsController(ToDoDBContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItems>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItems>> GetToDoItems(int id)
        {
            var toDoItems = await _context.ToDoItems.FindAsync(id);

            if (toDoItems == null)
            {
                return NotFound();
            }

            return toDoItems;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItems(int id, ToDoItems toDoItems)
        {
            toDoItems.Atividade_Id = id;

            _context.Entry(toDoItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemsExists(id))
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

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItems>> PostToDoItems(ToDoItems toDoItems)
        {
            _context.ToDoItems.Add(toDoItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItems", new { id = toDoItems.Atividade_Id }, toDoItems);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItems(int id)
        {
            var toDoItems = await _context.ToDoItems.FindAsync(id);
            if (toDoItems == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemsExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Atividade_Id == id);
        }
    }
}
