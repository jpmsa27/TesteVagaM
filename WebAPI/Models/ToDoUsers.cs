using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoUsers
    {
        [Key]
        public int user_Id { get; set; }
        [Required(ErrorMessage ="Nome obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string user_Name { get; set; }
        [Required(ErrorMessage = "preencha o e-mail")]
        [EmailAddress(ErrorMessage = "email invalido")]
        [Column(TypeName = "varchar(100)")]
        public string user_email { get; set; }

        [Required(ErrorMessage = "preencha a senha")]
        [Column(TypeName = "varchar(100)")]
        public string user_senha { get; set; }

    }
}
