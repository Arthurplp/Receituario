using Domínio.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.ConfiguracaoEntidades
{
    internal class EF_Vinculo
    {
        public void configure(EntityTypeBuilder<VinculoReceitaMaterial> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.HasOne(t => t.receita)
                .WithMany(t => t.Vinculos)
                .HasForeignKey(t => t.IdReceita);

            builder.HasOne(t => t.material)
                .WithMany(t => t.Vinculos)
                .HasForeignKey(t => t.IdMaterial);
        }
    }
}
