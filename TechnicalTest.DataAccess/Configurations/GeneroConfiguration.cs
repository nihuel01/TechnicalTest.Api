using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Core.Model;

namespace TechnicalTest.DataAccess.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<tGenero>
    {
        public void Configure(EntityTypeBuilder<tGenero> builder)
        {
            builder.ToTable("tGenero");

            builder.HasKey(f => f.cod_genero);
            builder.Property(f => f.txt_desc);
        }
    }
}
