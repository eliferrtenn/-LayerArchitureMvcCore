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
    public class Isg_Kurul_KararMap : IEntityTypeConfiguration<Isg_Kurul_Karar>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul_Karar> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Toplanti_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Tarih).IsRequired();
            builder.Property(a => a.Saat).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Yer).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Toplanti_Baskan).HasMaxLength(50);
            builder.Property(a => a.Raportor).HasMaxLength(50);

            builder.ToTable("isg_kurul_karar");

            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Isg_Kurul_Karar).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Isg_Kurul_Karar).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
