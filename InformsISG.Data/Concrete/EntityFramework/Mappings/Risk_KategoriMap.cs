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
    public class Risk_KategoriMap : IEntityTypeConfiguration<Risk_Kategori>
    {
        public void Configure(EntityTypeBuilder<Risk_Kategori> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Kategori_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("kutuphane_kategori");

        }
    }
}
