//Contextualização geral do banco de dados para a aplicação, utilizando Entity Framework Core.
using Domínio.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
