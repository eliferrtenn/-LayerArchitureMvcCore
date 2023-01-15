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
    public class Kkd_TurMap : IEntityTypeConfiguration<Kkd_Tur>
    {
        public void Configure(EntityTypeBuilder<Kkd_Tur> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kkd_Tur_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("kkd_tur");

        }
    }
}
