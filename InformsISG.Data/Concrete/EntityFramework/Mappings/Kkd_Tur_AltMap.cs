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
    public class Kkd_Tur_AltMap : IEntityTypeConfiguration<Kkd_Tur_Alt>
    {
        public void Configure(EntityTypeBuilder<Kkd_Tur_Alt> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kkd_Tur_Alt_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("kkd_tur_alt");

            builder.HasOne<Kkd_Tur>(k => k.Kkd_Tur).WithMany(b => b.Kkd_Tur_Alt).HasForeignKey(b => b.Kkd_Tur_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
