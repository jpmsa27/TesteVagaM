using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Views
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoUsersController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoUsersController(ToDoDBContext context)
        {
            _context = context;
        }

        // GET: api/ToDoUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoUsers>>> GetToDoUsers()
        {
            return await _context.ToDoUsers.ToListAsync();
        }

        // GET: api/ToDoUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoUsers>> GetToDoUsers(int id)
        {
            var toDoUsers = await _context.ToDoUsers.FindAsync(id);

            if (toDoUsers == null)
            {
                return NotFound();
            }

            return toDoUsers;
        }

        // PUT: api/ToDoUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoUsers(int id, ToDoUsers toDoUsers)
        {
            if (id != toDoUsers.user_Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoUsersExists(id))
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

        // POST: api/ToDoUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoUsers>> PostToDoUsers(ToDoUsers toDoUsers)
        {
            _context.ToDoUsers.Add(toDoUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoUsers", new { id = toDoUsers.user_Id }, toDoUsers);
        }

        // DELETE: api/ToDoUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoUsers(int id)
        {
            var toDoUsers = await _context.ToDoUsers.FindAsync(id);
            if (toDoUsers == null)
            {
                return NotFound();
            }

            _context.ToDoUsers.Remove(toDoUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoUsersExists(int id)
        {
            return _context.ToDoUsers.Any(e => e.user_Id == id);
        }
    }
}
