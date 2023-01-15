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
    public class Personel_BilgiMap : IEntityTypeConfiguration<Personel_Bilgi>
    {
        public void Configure(EntityTypeBuilder<Personel_Bilgi> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();   
            builder.Property(a=>a.IsgUzmanMi);      
            builder.Property(a=>a.SertifikaNo).HasMaxLength(70);       
            builder.Property(a=>a.IsYeriHekimi);
            builder.Property(a => a.Fotograf).HasMaxLength(150);
            builder.Property(a => a.yerdegistiMi);

            builder.Property(a => a.Unvan).HasMaxLength(70);
            builder.Property(a => a.Ad_Soyad).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Sicil_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Sgk_No).HasMaxLength(50);
            builder.Property(a => a.Tc_No).HasMaxLength(11).IsRequired();
            builder.Property(a => a.Dogum_Tarih);
            builder.Property(a => a.Dogum_Yer).HasMaxLength(50);
            builder.Property(a => a.Cinsiyet);
            builder.Property(a => a.Is_Giris_Tarih);
            builder.Property(a => a.Medeni_Durum);
            builder.Property(a => a.Telefon1).HasMaxLength(20);
            builder.Property(a => a.Telefon2).HasMaxLength(20);
            builder.Property(a => a.Adres).HasMaxLength(250);
            builder.Property(a => a.Egitim);
            builder.Property(a => a.Egitim_Meslek);
            builder.Property(a => a.Eposta).HasMaxLength(150);
            builder.Property(a => a.Notlar).HasMaxLength(2000);
            //builder.HasIndex(a => a.Eposta).IsUnique();
            builder.Property(a => a.Is_Cikis_Tarih);
            builder.Property(a => a.Kadro_Durumu);


            builder.ToTable("personel_bilgi");

            builder.HasOne<Sgk_Meslek>(k => k.Sgk_Meslek).WithMany(b => b.Personel_Bilgi).HasForeignKey(b => b.Sgk_Meslek_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Personel_Bilgi).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);  
            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Personel_Bilgi).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);



            //builder.HasData(
            //    new Personel_Bilgi
            //    {
            //        Id = 1,
            //        Kullanici_Adi="Sadmin",
            //       Sifre="pass",
            //       Ad_Soyad="Super",
            //       Soyad_Ikinci="Admin",
            //       Eposta="sadmin@admin.com",
            //       isActive=true,
            //       isDeleted=false,
            //       Yaratilma_Tarihi=DateTime.Now,
            //       Degistirilme_Tarihi=DateTime.Now
            //    },

            //    new Personel_Bilgi
            //    {
            //        Id = 1,
            //        Personel_Tipi = "AŞÇI",
            //        Ad_Soyad = "Vahap SAYGIN"

            //    }
            //);

        }
    }
}
