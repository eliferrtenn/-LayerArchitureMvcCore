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
    public class HareketMap : IEntityTypeConfiguration<Hareket>
    {
        public void Configure(EntityTypeBuilder<Hareket> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Sayfa).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Hareket_Ad).HasMaxLength(100).IsRequired();

            builder.ToTable("hareket");
        }
    }
}
