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
    public class Risk_KutuphaneMap : IEntityTypeConfiguration<Risk_Kutuphane>
    {
        public void Configure(EntityTypeBuilder<Risk_Kutuphane> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.ToTable("risk_kutuphane");


            builder.HasOne<Risk_Analiz>(k => k.Risk_Analiz).WithMany(b => b.Risk_Kutuphane).HasForeignKey(b => b.Risk_Analiz_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Kategori>(k => k.Risk_Kategori).WithMany(b => b.Risk_Kutuphane).HasForeignKey(b => b.Risk_Kategori_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Ust_Grup>(k => k.Risk_Ust_Grup).WithMany(b => b.Risk_Kutuphane).HasForeignKey(b => b.Risk_Ust_Grup_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Konu_Grup>(k => k.Risk_Konu_Grup).WithMany(b => b.Risk_Kutuphane).HasForeignKey(b => b.Risk_Konu_Grup_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Risk_Konu>(k => k.Risk_Konu).WithMany(b => b.Risk_Kutuphane).HasForeignKey(b => b.Risk_Konu_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
