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
    public class Acil_Durum_TatbikatMap : IEntityTypeConfiguration<Acil_Durum_Tatbikat>
    {
        public void Configure(EntityTypeBuilder<Acil_Durum_Tatbikat> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Tatbikat_Ad).HasMaxLength(50).IsRequired();
            builder.Property(a=>a.Tatbikat_Tarih).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Onay).IsRequired();

            builder.ToTable("acil_durum_tatbikat");

        }
    }
}
