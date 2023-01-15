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
    public class Risk_AnalizMap : IEntityTypeConfiguration<Risk_Analiz>
    {
        public void Configure(EntityTypeBuilder<Risk_Analiz> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Analiz_No).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Analiz_Tanim).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Analiz_Tarih).IsRequired();
            builder.Property(a => a.Bitis_Tarih).IsRequired();
            builder.Property(a => a.Notlar).HasMaxLength(500);
            builder.Property(a => a.Dosya).HasMaxLength(150);

            builder.ToTable("risk_analiz");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);  
            builder.HasOne<Risk_Yontem>(k => k.Risk_Yontem).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Risk_Yontem_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Kategori>(k => k.Risk_Kategori).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Risk_Kategori_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Ust_Grup>(k => k.Risk_Ust_Grup).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Risk_Ust_Grup_Id).OnDelete(DeleteBehavior.NoAction);  
            builder.HasOne<Risk_Konu_Grup>(k => k.Risk_Konu_Grup).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Risk_Konu_Grup_Id).OnDelete(DeleteBehavior.NoAction);   
            builder.HasOne<Risk_Konu>(k => k.Risk_Konu).WithMany(b => b.Risk_Analiz).HasForeignKey(b => b.Risk_Konu_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
