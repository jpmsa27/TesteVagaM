
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        {

        }

        public DbSet<ToDoItems> ToDoItems { get; set; }
        public DbSet<ToDoUsers> ToDoUsers { get; set; }
        public DbSet<ToDoLista> ToDoLista { get; set; }
        public DbSet<ToDoCategorias> ToDoCategorias { get; set; }

    }
}
