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
    public class Yetkili_GormediMap : IEntityTypeConfiguration<Yetkili_Gormedi>
    {
        public void Configure(EntityTypeBuilder<Yetkili_Gormedi> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Tablo_Adi).HasMaxLength(200).IsRequired();

            builder.ToTable("yetkili_gormedi");

            builder.HasOne<Risk_Analiz_Tablo>(k => k.Risk_Analiz_Tablo).WithMany(b => b.Yetkili_Gormedi).HasForeignKey(b => b.Tablo_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
