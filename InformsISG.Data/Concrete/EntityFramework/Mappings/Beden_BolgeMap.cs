using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Data.Concrete.EntityFramework.Mappings
{
    public class Beden_BolgeMap : IEntityTypeConfiguration<Beden_Bolge>
    {
        public void Configure(EntityTypeBuilder<Beden_Bolge> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Beden_Bolge_Ad).HasMaxLength(150).IsRequired();
            builder.ToTable("beden_bolge");
        }
    }
}
