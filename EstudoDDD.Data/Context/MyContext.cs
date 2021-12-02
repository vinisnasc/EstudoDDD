using EstudoDDD.Data.Mapping;
using EstudoDDD.Data.Seeds;
using EstudoDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Data.Context
{
   public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            // Seeds de Usuario admin
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Vinicius",
                Email = "vini.souza00@gmail.com",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            });
            // Seeds de informações 
            UfSeeds.Ufs(modelBuilder);
        }
    }
}
