using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _codIBGE;

        public int CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }

        private Guid _ufId;

        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }

    }
}
