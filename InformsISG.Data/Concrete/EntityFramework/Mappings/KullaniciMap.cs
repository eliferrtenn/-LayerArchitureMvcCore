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
    public class KullaniciMap : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Mail).HasMaxLength(80).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(32).IsRequired();

            builder.ToTable("kullanici");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Kullanici).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Yetki>(k => k.Yetki).WithMany(b => b.Kullanici).HasForeignKey(b => b.Yetki_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Kullanici).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(
            //    new Kullanici
            //    {
            //        Id = 1,
            //        Kullanici_Ad = "Sadmin",
            //        Sifre = "pass",
            //        Ad_Soyad = "Super Admin",
            //        Mail = "sadmin@admin.com",
            //        isActive = true,
            //        isDeleted = false,
            //        Yetki="1",
            //        Yaratilma_Tarihi = DateTime.Now,
            //        Degistirilme_Tarihi = DateTime.Now
            //    },

            //       new Kullanici
            //       {
            //           Id = 2,
            //           Kullanici_Ad = "Admin",
            //           Sifre = "pass",
            //           Ad_Soyad = "Admin",
            //           Mail = "admin@admin.com",
            //           isActive = true,
            //           isDeleted = false,
            //           Yetki="2",
            //           Yaratilma_Tarihi = DateTime.Now,
            //           Degistirilme_Tarihi = DateTime.Now
            //       }
            //);
        }
    }
}
