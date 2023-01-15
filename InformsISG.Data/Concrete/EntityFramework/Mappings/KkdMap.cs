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
    public class KkdMap : IEntityTypeConfiguration<Kkd>
    {
        public void Configure(EntityTypeBuilder<Kkd> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kkd_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Kkd_Tanim).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Uretici).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Parca_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Standart).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Notlar).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kullanilma_Durumu).IsRequired();

            builder.ToTable("kkd");

            builder.HasOne<Kkd_Tur>(k => k.Kkd_Tur).WithMany(b => b.Kkd).HasForeignKey(b => b.Kkd_Tur_Id).OnDelete(DeleteBehavior.NoAction);    
            builder.HasOne<Kkd_Tur_Alt>(k => k.Kkd_Tur_Alt).WithMany(b => b.Kkd).HasForeignKey(b => b.Kkd_Tur_Alt_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Kkd).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Kkd).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
