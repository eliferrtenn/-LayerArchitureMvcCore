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
    public class Isg_Kurul_Karar2Map : IEntityTypeConfiguration<Isg_Kurul_Karar2>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul_Karar2> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Karar_No).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Alinan_Kararlar).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Baslangic_Tarih).IsRequired();
            builder.Property(a => a.Bitis_Tarih).IsRequired();
            builder.Property(a => a.TamamlandiMi);

            builder.ToTable("isg_kurul_karar2");

            builder.HasOne<Isg_Kurul_Karar>(k => k.Isg_Kurul_Karar).WithMany(b => b.Isg_Kurul_Karar2).HasForeignKey(b => b.Isg_Kurul_Karar_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Isg_Kurul_Karar2).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
