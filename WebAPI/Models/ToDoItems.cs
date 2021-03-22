using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoItems
    {
        [Key]
        public int Atividade_Id { get; set; }
        [Required(ErrorMessage ="Preencha Qual é a atividade!")]
        [Column(TypeName= "varchar(100)")]
        public string Atividade_Titulo { get; set; }
        [Required(ErrorMessage = "preencha o dia e a hora!")]
        public DateTime Atividade_Dia_Hora { get; set; }
        [Required(ErrorMessage = "preencha o dia da semana!")]
        [Column(TypeName = "varchar(12)")]  
        public string Atividade_DiaSemana { get; set; }
        public bool Feito { get; set; }
    }
}
