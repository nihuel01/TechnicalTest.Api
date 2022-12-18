using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class UserPeliculaSellConfiguration : IEntityTypeConfiguration<tUserPeliculaSell>
    {
        public void Configure(EntityTypeBuilder<tUserPeliculaSell> builder)
        {
            builder.ToTable("tUserPeliculaSell");

            builder.HasKey(f => f.cod_userPeliculaSell);
            builder.Property(f => f.observaciones);
            builder.Property(f => f.precio_venta);
            builder.Property(f => f.fecha_venta);
            builder.Property(f => f.cod_usuario);
            builder.Property(f => f.cod_pelicula);
        }
    }
}
