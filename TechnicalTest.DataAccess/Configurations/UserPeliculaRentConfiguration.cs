using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class UserPeliculaRentConfiguration : IEntityTypeConfiguration<tUserPeliculaRent>
    {
        public void Configure(EntityTypeBuilder<tUserPeliculaRent> builder)
        {
            builder.ToTable("tUserPeliculaRent");

            builder.HasKey(f => f.cod_userPeliculaRent);
            builder.Property(f => f.observaciones);
            builder.Property(f => f.precio_alquiler);
            builder.Property(f => f.fecha_alquiler);
            builder.Property(f => f.fecha_devolucion);
            builder.Property(f => f.devuelta);
            builder.Property(f => f.cod_usuario);
            builder.Property(f => f.cod_pelicula);
            builder.Property(f => f.fecha_limite);
        }
    }
}
