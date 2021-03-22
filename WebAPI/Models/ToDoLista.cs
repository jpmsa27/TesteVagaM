using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoLista
    {
        [Key]
        public int lista_Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string lista_Nome { get; set; }
        public int lista_CategoriaId { get; set; }
        public bool lista_Concluida { get; set; }
    }
}
