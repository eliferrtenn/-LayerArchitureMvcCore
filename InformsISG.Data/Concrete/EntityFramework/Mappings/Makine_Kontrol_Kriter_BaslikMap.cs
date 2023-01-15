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
    public class Makine_Kontrol_Kriter_BaslikMap : IEntityTypeConfiguration<Makine_Kontrol_Kriter_Baslik>
    {
        public void Configure(EntityTypeBuilder<Makine_Kontrol_Kriter_Baslik> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Baslik_Ad).HasMaxLength(300).IsRequired();

            builder.ToTable("makine_kontrol_kriter_baslik");

            builder.HasOne<Makine>(k => k.Makine).WithMany(b => b.Makine_Kontrol_Kriter_Baslik).HasForeignKey(b => b.Makine_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
