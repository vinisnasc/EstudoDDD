using EstudoDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder) 
        {
            builder.ToTable("Cep");

            builder.HasKey(i => i.Id);

            builder.HasIndex(c => c.Cep);

            builder.HasOne(m => m.Municipio)
                   .WithMany(c => c.Ceps);
        }
    }
}
