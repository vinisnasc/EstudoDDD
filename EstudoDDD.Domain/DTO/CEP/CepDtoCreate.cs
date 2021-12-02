using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.DTO.CEP
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "O CEP é obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório!")]
        public string Logradouro { get; set; }
        
        public string Numero { get; set; }
       
        [Required(ErrorMessage = "Codigo de Municipio é obrigatório!")]
        public Guid MunicipioId { get; set; }
    }
}
