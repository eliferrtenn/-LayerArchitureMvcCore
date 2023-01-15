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
    public class Ramak_KalaMap : IEntityTypeConfiguration<Ramak_Kala>
    {
        public void Configure(EntityTypeBuilder<Ramak_Kala> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Ramak_Kala_No).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Tarih).IsRequired();
            builder.Property(a => a.Saat).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Gorev).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Olay).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Olay_Tam_Yer).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Oneri).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Amir_Gorus).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Igu_Gorus).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Igu_Gorus_Tarih).IsRequired();
            builder.Property(a => a.Termin_Sure).IsRequired();
            builder.Property(a => a.Is_Tanim).HasMaxLength(400).IsRequired();
            builder.Property(a => a.Tamamlandi).IsRequired();
            builder.Property(a => a.Tamamlandi_Tarih).IsRequired();

            builder.ToTable("ramak_kala");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Ramak_Kala).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Ramak_Kala).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Ramak_Kala).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Ramak_Kala).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);       
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Ramak_Kala).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
