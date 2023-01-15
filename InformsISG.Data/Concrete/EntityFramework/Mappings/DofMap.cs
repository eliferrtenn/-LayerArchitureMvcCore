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
    public class DofMap : IEntityTypeConfiguration<Dof>
    {
        public void Configure(EntityTypeBuilder<Dof> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Dof_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Tip);
            builder.Property(a => a.Geldigi_Kaynak);
            builder.Property(a => a.Uygunsuzluk_Tanim).HasMaxLength(1500);
            builder.Property(a => a.Tespit_Eden).HasMaxLength(150);
            builder.Property(a => a.Sorumlular).HasMaxLength(150);
            builder.Property(a => a.Acilis_Tarih);
            builder.Property(a => a.Cevap_Sure);
            builder.Property(a => a.Cevap_Sonlanma_Tarih);
            builder.Property(a => a.Sonlanma_Tarih);
            builder.Property(a => a.Dof_Acik);
            builder.Property(a => a.Dof_Ad).HasMaxLength(3000);

            builder.ToTable("dof");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Dof).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Dof).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Dof).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Dof).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
