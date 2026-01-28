using Domínio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.ConfiguracaoEntidades
{
    public class EF_Material : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.UnidadeMedida)
                .WithMany()
                .HasForeignKey(t => t.IdUnidadeMedida);
        }
    }
}