
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
    public class Risk_Analiz_RiskMap : IEntityTypeConfiguration<Risk_Analiz_Risk>
    {
        public void Configure(EntityTypeBuilder<Risk_Analiz_Risk> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Aktif).IsRequired();


            builder.ToTable("risk_analiz_risk");
        }
    }
}
