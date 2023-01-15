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
    public class YetkiMap : IEntityTypeConfiguration<Yetki>
    {
        public void Configure(EntityTypeBuilder<Yetki> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Yetki_Ad).HasMaxLength(80).IsRequired();

            builder.ToTable("yetki");
        }
    }
}
