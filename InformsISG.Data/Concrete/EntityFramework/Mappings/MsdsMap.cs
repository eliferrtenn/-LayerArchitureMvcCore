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
    public class MsdsMap : IEntityTypeConfiguration<Msds>
    {
        public void Configure(EntityTypeBuilder<Msds> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Urun_Ad).HasMaxLength(50).IsRequired();

            builder.ToTable("msds");

            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Msds).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Msds).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
