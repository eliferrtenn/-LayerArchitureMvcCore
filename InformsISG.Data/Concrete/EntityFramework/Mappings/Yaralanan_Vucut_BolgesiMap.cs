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
    public class Yaralanan_Vucut_BolgesiMap : IEntityTypeConfiguration<Yaralanan_Vucut_Bolgesi>
    {
        public void Configure(EntityTypeBuilder<Yaralanan_Vucut_Bolgesi> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Yaralanan_Vucut_Bolgesi_Ad).HasMaxLength(200).IsRequired();

            builder.ToTable("yaralanan_vucut_bolgesi");

        }
    }
}
