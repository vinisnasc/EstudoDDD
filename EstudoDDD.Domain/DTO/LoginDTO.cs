using System.ComponentModel.DataAnnotations;

namespace EstudoDDD.Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para o login!")]
        [EmailAddress(ErrorMessage = "Email em formato invalido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres!")]
        public string Email { get; set; }
    }
}
