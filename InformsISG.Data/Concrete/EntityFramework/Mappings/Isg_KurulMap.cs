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
    public class Isg_KurulMap : IEntityTypeConfiguration<Isg_Kurul>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kurul_Ad).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Aciklama);
            builder.Property(a => a.Tehlike_Tip).IsRequired();

            builder.ToTable("isg_kurul");
        }
    }
}
