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
    public class Risk_KonuMap : IEntityTypeConfiguration<Risk_Konu>
    {
        public void Configure(EntityTypeBuilder<Risk_Konu> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Konu_Adi).HasMaxLength(800).IsRequired();
  

            builder.ToTable("kutuphane_konu");

            builder.HasOne<Risk_Konu_Grup>(k => k.Risk_Konu_Grup).WithMany(b => b.Risk_Konu).HasForeignKey(b => b.Risk_Konu_Grup_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
