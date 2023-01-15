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
    public class Egitim_KonuMap : IEntityTypeConfiguration<Egitim_Konu>
    {
        public void Configure(EntityTypeBuilder<Egitim_Konu> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Egitim_Ad).HasMaxLength(100).IsRequired();

            builder.ToTable("egitim_konu");
        }
    }
}
