
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
    public class Kaza_Personel_DisiMap : IEntityTypeConfiguration<Kaza_Personel_Disi>
    {
        public void Configure(EntityTypeBuilder<Kaza_Personel_Disi> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kaza_No).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Kaza_Kategori).IsRequired();
            builder.Property(a => a.Kaza_Tarih).IsRequired();
            builder.Property(a => a.Kaza_Saat).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Personel_Disi_Tc_No).HasMaxLength(11).IsRequired();
            builder.Property(a => a.Personel_Disi_Ad_Soyad).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Kaza_Yer).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Kaza_Olus_Sekil).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Kaza_Faktor).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Sonuc).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Kok_Neden).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Yapilan_Islem).IsRequired();
            builder.Property(a => a.Dof1).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu1).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih1).IsRequired();
            builder.Property(a => a.Dof2).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu2).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih2).IsRequired();
            builder.Property(a => a.Dof3).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu3).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih3).IsRequired();

            builder.ToTable("kaza_personel_disi");


            builder.HasOne<Yaralanma_Sekli>(k => k.Yaralanma_Sekli).WithMany(b => b.Kaza_Personel_Disi).HasForeignKey(b => b.Yaralanma_Sekli_Id).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne<Yaralanan_Vucut_Bolgesi>(k => k.Yaralanan_Vucut_Bolgesi).WithMany(b => b.Kaza_Personel_Disi).HasForeignKey(b => b.Yaralanan_Vucut_Bolgesi_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Kaza_Personel_Disi).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Kaza_Personel_Disi).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Analiz_Risk>(k => k.Risk_Analiz_Risk).WithMany(b => b.Kaza_Personel_Disi).HasForeignKey(b => b.Risk_Analiz_Risk_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
