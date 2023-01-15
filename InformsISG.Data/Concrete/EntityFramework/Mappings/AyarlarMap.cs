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
    public class AyarlarMap : IEntityTypeConfiguration<Ayarlar>
    {
        public void Configure(EntityTypeBuilder<Ayarlar> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Tehlike_Tip).IsRequired();
            builder.Property(a => a.Egitim_Sure).IsRequired();
            builder.Property(a => a.Egitim_Sure_Periyot).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Risk_Sure).IsRequired();
            builder.Property(a => a.Risk_Sure_Periyot).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Saglik_Kontrol).IsRequired();
            builder.Property(a => a.Saglik_Kontrol_Periyot).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Igu_Sure).IsRequired();
            builder.Property(a => a.Igu_Sure_Periyot).HasMaxLength(25).IsRequired();
            builder.ToTable("ayarlar");
        }
    }
}
