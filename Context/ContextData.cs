using Calculator.Model;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Context
{
    public class ContextData : DbContext
    {
        static string connection = @"Data Source  = SOLNB-5GX9F94\SQLEXPRESS; Initial Catalog = EFDemo; Integrated Security = True; Trust Server Certificate = True;";

        public DbSet<Calci> calculations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connection);
        }

    }
}
