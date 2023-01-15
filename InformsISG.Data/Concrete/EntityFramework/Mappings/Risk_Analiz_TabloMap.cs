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
    public class Risk_Analiz_TabloMap : IEntityTypeConfiguration<Risk_Analiz_Tablo>
    {
        public void Configure(EntityTypeBuilder<Risk_Analiz_Tablo> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Faaliyet).HasMaxLength(1000);
            builder.Property(a => a.Rutin_Durum).IsRequired();
            builder.Property(a => a.Tehlike).HasMaxLength(1000);
            builder.Property(a => a.Risk).HasMaxLength(1000);
            builder.Property(a => a.Uygun_Durum);
            builder.Property(a => a.Yasal_Dayanak).HasMaxLength(1000);
            builder.Property(a => a.Duzeltici_Faaliyet).HasMaxLength(1000);
            builder.Property(a => a.Termin_Tarih);
            builder.Property(a => a.Sorumlular).HasMaxLength(400);
            builder.Property(a => a.Kontrol_Degerlendirme).HasMaxLength(1000);
            builder.Property(a => a.Etkinlik_Kontrol_Tarih);





            builder.Property(a => a.Olasilik1);
            builder.Property(a => a.Frekans1);
            builder.Property(a => a.Siddet1);
            builder.Property(a => a.Risk_Puan1);
            builder.Property(a => a.Risk_Seviye1).HasMaxLength(150);
            builder.Property(a => a.Olasilik2);
            builder.Property(a => a.Frekans2);
            builder.Property(a => a.Siddet2);
            builder.Property(a => a.Risk_Puan2);
            builder.Property(a => a.Risk_Seviye2).HasMaxLength(150);
            builder.Property(a => a.Resim).HasMaxLength(150);

            builder.ToTable("risk_analiz_tablo");

            builder.HasOne<Risk_Analiz>(k => k.Risk_Analiz).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Risk_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Analiz_Risk>(k => k.Risk_Analiz_Risk).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Risk_Analiz_Id).OnDelete(DeleteBehavior.NoAction);   
            builder.HasOne<Tehlike_Tanim>(k => k.Tehlike_Tanim).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Tehlike_Tanim_Id).OnDelete(DeleteBehavior.NoAction);     
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);    
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Risk_Analiz_Tablo).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
