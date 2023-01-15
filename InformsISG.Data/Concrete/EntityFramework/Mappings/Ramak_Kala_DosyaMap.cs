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
    public class Ramak_Kala_DosyaMap : IEntityTypeConfiguration<Ramak_Kala_Dosya>
    {
        public void Configure(EntityTypeBuilder<Ramak_Kala_Dosya> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Dosya).HasMaxLength(150).IsRequired();

            builder.ToTable("ramak_kala_dosya");

            builder.HasOne<Ramak_Kala>(k => k.Ramak_Kala).WithMany(b => b.Ramak_Kala_Dosya).HasForeignKey(b => b.Ramak_Kala_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
