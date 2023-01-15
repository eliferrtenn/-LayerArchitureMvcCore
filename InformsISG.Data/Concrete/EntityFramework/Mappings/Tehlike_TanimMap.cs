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
    public class Tehlike_TanimMap : IEntityTypeConfiguration<Tehlike_Tanim>
    {
        public void Configure(EntityTypeBuilder<Tehlike_Tanim> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Tehlike_Tanim_Ad).HasMaxLength(200).IsRequired();

            builder.ToTable("tehlike_tanim");

        }
    }
}
