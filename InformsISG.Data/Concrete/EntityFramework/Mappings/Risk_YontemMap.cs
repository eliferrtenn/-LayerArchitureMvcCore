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
    public class Risk_YontemMap : IEntityTypeConfiguration<Risk_Yontem>
    {
        public void Configure(EntityTypeBuilder<Risk_Yontem> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Yontem_Ad).HasMaxLength(50).IsRequired();

            builder.ToTable("risk_yontem");
        }
    }
}
