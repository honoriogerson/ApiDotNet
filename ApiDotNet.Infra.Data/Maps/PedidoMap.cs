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
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idpedido")
                .UseIdentityColumn();

            builder.Property(x => x.ClienteId)
                .HasColumnName("idcliente");

            builder.Property(x => x.ItemId)
                .HasColumnName("iditem");

            builder.Property(x => x.Date)
                .HasColumnType("date")
                .HasColumnName("datapedido");

            builder.Property(x => x.NumeroPedido)
                .HasColumnName("numeropedido");

            #region Relacionamento
            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos);

            builder.HasOne(x => x.Itens)
                .WithMany(x => x.Pedidos);
            #endregion
        }
    }
    
}
