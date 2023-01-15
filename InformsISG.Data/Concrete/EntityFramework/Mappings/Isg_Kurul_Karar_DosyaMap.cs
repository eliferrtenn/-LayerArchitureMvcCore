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
    public class Isg_Kurul_Karar_DosyaMap : IEntityTypeConfiguration<Isg_Kurul_Karar_Dosya>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul_Karar_Dosya> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Dosya).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("isg_kurul_karar_dosya");

            builder.HasOne<Isg_Kurul_Karar>(k => k.Isg_Kurul_Karar).WithMany(b => b.Isg_Kurul_Karar_Dosya).HasForeignKey(b => b.Isg_Kurul_Karar_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Isg_Kurul_Karar_Dosya).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
