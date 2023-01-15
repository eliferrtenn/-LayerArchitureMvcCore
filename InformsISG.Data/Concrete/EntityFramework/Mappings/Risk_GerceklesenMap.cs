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
    public class Risk_GerceklesenMap : IEntityTypeConfiguration<Risk_Gerceklesen>
    {
        public void Configure(EntityTypeBuilder<Risk_Gerceklesen> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Gerceklesen_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("risk_gerceklesen");
        }
    }
}
