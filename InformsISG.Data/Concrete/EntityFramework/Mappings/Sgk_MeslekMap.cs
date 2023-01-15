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
    public class Sgk_MeslekMap : IEntityTypeConfiguration<Sgk_Meslek>
    {
        public void Configure(EntityTypeBuilder<Sgk_Meslek> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Isco08);
            builder.Property(a => a.Meslek_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("sgk_meslek");
        }
    }
}
