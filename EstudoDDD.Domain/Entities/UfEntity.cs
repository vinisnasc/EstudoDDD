using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }
        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }
        public IEnumerable<MunicipioEntity> Municipios { get; set; }
    }
}
