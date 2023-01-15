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
    public class Acil_Durum_EkipleriMap : IEntityTypeConfiguration<Acil_Durum_Ekipleri>
    {
        public void Configure(EntityTypeBuilder<Acil_Durum_Ekipleri> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Ekip_Ad).HasMaxLength(50).IsRequired();

            builder.ToTable("acil_durum_ekipleri");

        }
    }
}
