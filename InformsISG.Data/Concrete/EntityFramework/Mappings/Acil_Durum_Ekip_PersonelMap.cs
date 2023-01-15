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
    public class Acil_Durum_Ekip_PersonelMap : IEntityTypeConfiguration<Acil_Durum_Ekip_Personel>
    {
        public void Configure(EntityTypeBuilder<Acil_Durum_Ekip_Personel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Ekip_Lideri).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("acil_durum_ekip_personel");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Acil_Durum_Ekip_Personel).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Acil_Durum_Ekip_Personel).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Acil_Durum_Ekipleri>(k => k.Acil_Durum_Ekipleri).WithMany(b => b.Acil_Durum_Ekip_Personel).HasForeignKey(b => b.Ekip_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
