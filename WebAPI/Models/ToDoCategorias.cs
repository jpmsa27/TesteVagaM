using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoCategorias
    {
        [Key]
        public int atividade_Id { get; set; }
        [Required(ErrorMessage ="Nome obrigatorio")]
        [Column(TypeName = "varchar(300)")]
        public string atividade_Nome { get; set; }
    }
}
