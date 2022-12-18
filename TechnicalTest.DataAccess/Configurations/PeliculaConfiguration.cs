using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<tPelicula>
    {
        public void Configure(EntityTypeBuilder<tPelicula> builder)
        {
            builder.ToTable("tPelicula");

            builder.HasKey(f => f.cod_pelicula);
            builder.Property(f => f.txt_desc);
            builder.Property(f => f.cant_disponibles_alquiler);
            builder.Property(f => f.cant_disponibles_venta);
            builder.Property(f => f.precio_alquiler);
            builder.Property(f => f.precio_venta);
        }
    }
}
