using EstudoDDD.Data.Context;
using EstudoDDD.Data.Repository;
using EstudoDDD.Domain.Entities;
using EstudoDDD.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _dataset;

        public CepImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(x => x.Municipio).ThenInclude(m => m.Uf).FirstOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
