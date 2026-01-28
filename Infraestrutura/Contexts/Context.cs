//Contextualização geral do banco de dados para a aplicação, utilizando Entity Framework Core.
using Domínio.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<UnidadeDeMedida> UnidadeDeMedida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}