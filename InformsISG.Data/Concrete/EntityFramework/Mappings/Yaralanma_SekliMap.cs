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
    public class Yaralanma_SekliMap : IEntityTypeConfiguration<Yaralanma_Sekli>
    {
        public void Configure(EntityTypeBuilder<Yaralanma_Sekli> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Yaralanma_Sekli_Ad).HasMaxLength(200).IsRequired();

            builder.ToTable("yaralanma_sekli");
        }
    }
}
