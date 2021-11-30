using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstudoDDD.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Integrated Security = SSPI;Persist Security Info=False;Initial Catalog=EstudoDDD;Data Source=DESKTOP-R9JFMSC\\SQLEXPRESS";
            DbContextOptionsBuilder<MyContext> optionBuilder = new();
            optionBuilder.UseSqlServer(connectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
