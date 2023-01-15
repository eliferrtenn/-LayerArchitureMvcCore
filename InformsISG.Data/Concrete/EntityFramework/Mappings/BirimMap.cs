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
    public class BirimMap : IEntityTypeConfiguration<Birim>
    {
        public void Configure(EntityTypeBuilder<Birim> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Birim_Ad).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Nace_Kod).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Sgk_No).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("birim");

            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Birim).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Birim).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
