using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Infra.Data.Maps
{
    public class ItemMap : IEntityTypeConfiguration<Itens>
    {
        public void Configure(EntityTypeBuilder<Itens>builder)
        {
            builder.ToTable("item");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("iditem")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("nome");

            builder.Property(x => x.Price)
                .HasColumnName("preco");

            #region Relacionamento
            builder.HasMany(x => x.Pedidos)
                .WithOne(p => p.Itens)
                .HasForeignKey(p => p.ItemId);
            #endregion

        }
    }
}
