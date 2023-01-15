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
    public class Kaza_Personel_Disi_DosyaMap : IEntityTypeConfiguration<Kaza_Personel_Disi_Dosya>
    {
        public void Configure(EntityTypeBuilder<Kaza_Personel_Disi_Dosya> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Dosya).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("kaza_personel_disi_dosya");

            builder.HasOne<Kaza_Personel_Disi>(k => k.Kaza_Personel_Disi).WithMany(b => b.Kaza_Personel_Disi_Dosya).HasForeignKey(b => b.Kaza_Personel_Disi_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Kaza_Personel_Disi_Dosya).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

