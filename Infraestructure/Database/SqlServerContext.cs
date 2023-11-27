using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure.Database
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //busca las clases con IEntityTypeConfiguration
        }
    }
}
