using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<tUsers>
    {
        public void Configure(EntityTypeBuilder<tUsers> builder)
        {
            builder.ToTable("tUsers");

            builder.HasKey(f => f.Id);
            builder.HasAlternateKey(f => f.cod_usuario);
            builder.Property(f => f.txt_user);
            builder.Property(f => f.txt_password);
            builder.Property(f => f.txt_nombre);
            builder.Property(f => f.txt_apellido);
            builder.Property(f => f.nro_doc);
            builder.Property(f => f.cod_rol);
            builder.Property(f => f.sn_activo);
        }
    }
}
