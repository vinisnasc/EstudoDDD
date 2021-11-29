using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstudoDDD.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=EstudoDDD;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbContextOptionsBuilder<MyContext> optionBuilder = new();
            optionBuilder.UseSqlServer(connectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
