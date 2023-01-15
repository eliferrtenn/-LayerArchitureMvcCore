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
    public class Makine_Kontrol_KriterMap : IEntityTypeConfiguration<Makine_Kontrol_Kriter>
    {
        public void Configure(EntityTypeBuilder<Makine_Kontrol_Kriter> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Madde_Ad).HasMaxLength(500).IsRequired();


            builder.ToTable("makine_kontrol_kriter");

            builder.HasOne<Makine_Kontrol_Kriter_Baslik>(k => k. Makine_Kontrol_Kriter_Baslik).WithMany(b => b.Makine_Kontrol_Kriter).HasForeignKey(b => b.Makine_Kontrol_Kriter_Baslik_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
