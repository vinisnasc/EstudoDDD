using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.DTO.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage ="Nome de municipio é obrigatório!")]
        [StringLength(60, ErrorMessage ="Nome de municipio deve ter no maximo {1} caracteres.")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage="Codigo invalido!")]
        public int CodIBGE { get; set; }
        [Required(ErrorMessage = "Codigo de UF é obrigatório!")]
        public Guid UfId { get; set; }
    }
}
