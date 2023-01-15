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
    public class Tali_BirimMap : IEntityTypeConfiguration<Tali_Birim>
    {
        public void Configure(EntityTypeBuilder<Tali_Birim> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Tali_Birim_Ad).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aciklama);

            builder.ToTable("tali_birim");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Tali_Birim).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Tali_Birim).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
