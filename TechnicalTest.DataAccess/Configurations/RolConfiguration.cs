using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<tRol>
    {
        public void Configure(EntityTypeBuilder<tRol> builder)
        {
            builder.ToTable("tRol");

            builder.HasKey(f => f.cod_rol);
            builder.Property(f => f.txt_desc);
        }
    }
}
