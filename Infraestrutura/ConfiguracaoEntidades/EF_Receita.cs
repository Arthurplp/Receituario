using Domínio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.ConfiguracaoEntidades
{
    public class EF_Receita : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.ReceitaPai)
                .WithMany(t => t.SubReceitas)
                .HasForeignKey(t => t.IdReceitaPai);

            builder.HasMany(t => t.SubReceitas)
                .WithOne(t => t.ReceitaPai)
                .HasForeignKey(t => t.IdReceitaPai);

            builder.HasOne(t => t.UnidadeMedida)
                .WithMany()
                .HasForeignKey(t => t.IdUnidadeMedida);
        }
    }
}