using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.DTO.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatorio!")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatorio!")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email é um campo obrigatorio!")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}
