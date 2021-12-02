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
    public class UfImplementation: BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataset;

        public UfImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();
        }
    }
}
