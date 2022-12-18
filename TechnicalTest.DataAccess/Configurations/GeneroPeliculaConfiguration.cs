using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class GeneroPeliculaConfiguration : IEntityTypeConfiguration<tGeneroPelicula>
    {
        public void Configure(EntityTypeBuilder<tGeneroPelicula> builder)
        {
            builder.ToTable("tGeneroPelicula");

            builder.HasNoKey();
            builder.Property(f => f.cod_pelicula);
            builder.Property(f => f.cod_genero);
        }
    }
}
