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
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) 
        {
            builder.ToTable("cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idcliente")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("nome");

            builder.Property(c => c.Email)
                .HasColumnName("email");

            #region Relacionamento 
            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(c => c.ClienteId);
            #endregion
        }
    }
}
