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
    public class Makine_EkipmanMap : IEntityTypeConfiguration<Makine_Ekipman>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Ekipman_Kodu).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Firma_Adi).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Periyodik_Kontrol_Tarih);
            builder.Property(a => a.Tekrar_Periyodik_Kontrol_Tarih);
            builder.Property(a => a.Periyodik_Kontrol_Adres).HasMaxLength(500);
            builder.Property(a => a.Telefon_No).HasMaxLength(11);
            builder.Property(a => a.E_Posta).HasMaxLength(20);
            builder.Property(a => a.Takip_Kontrol_Tarih);
            builder.Property(a => a.Rapor_Tarih).HasMaxLength(150);
            builder.Property(a => a.Periyodik_Kontrol_Method).HasMaxLength(150);
            builder.Property(a => a.Kimlik_Rapor_No).HasMaxLength(20);
            builder.Property(a => a.Kapsam);
            builder.Property(a => a.QRCode).HasMaxLength(50);

            builder.Property(a => a.Inceleme_Tespit_Edilen_Diger_Eksiklikler);
            builder.Property(a => a.Onay);
            builder.Property(a => a.Periyodik_Kontrol_Gorevlisi_Ad_Soyad).HasMaxLength(50);
            builder.Property(a => a.Periyodik_Kontrol_Gorevlisi_Meslek).HasMaxLength(50);
            builder.Property(a => a.Periyodik_Kontrol_Gorevlisi_Diploma_Tarihi_Numarasi).HasMaxLength(50);
            builder.Property(a => a.Periyodik_Kontrol_Gorevlisi_Bakanlik_Numara).HasMaxLength(50);   
            builder.Property(a => a.Birim_Sorumlusu_Ad_Soyad).HasMaxLength(50);
            builder.Property(a => a.Birim_Sorumlusu_Meslek).HasMaxLength(50);
            builder.Property(a => a.Birim_Sorumlusu_Diploma_Tarihi_Numarasi).HasMaxLength(50);
            builder.Property(a => a.Birim_Sorumlusu_Bakanlik_Numara).HasMaxLength(50);

            builder.ToTable("makine_ekipman");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Makine_Ekipman).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Makine_Ekipman).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Makine>(k => k.Makine).WithMany(b => b.Makine_Ekipman).HasForeignKey(b => b.Makine_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
