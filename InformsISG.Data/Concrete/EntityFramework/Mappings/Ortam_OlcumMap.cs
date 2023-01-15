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
    public class Ortam_OlcumMap : IEntityTypeConfiguration<Ortam_Olcum>
    {
        public void Configure(EntityTypeBuilder<Ortam_Olcum> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Olcum_Tur).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Olcum_Tarih).IsRequired();
            builder.Property(a => a.Olcum_Sonuc).IsRequired();
            builder.Property(a => a.Olcum_Birim).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(250).IsRequired();

            builder.ToTable("ortam_olcum");

            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Ortam_Olcum).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Ortam_Olcum).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
