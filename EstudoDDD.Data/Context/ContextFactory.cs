using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace EstudoDDD.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyContext> optionBuilder = new();
            optionBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SQL"));
            return new MyContext(optionBuilder.Options);
        }
    }
}
