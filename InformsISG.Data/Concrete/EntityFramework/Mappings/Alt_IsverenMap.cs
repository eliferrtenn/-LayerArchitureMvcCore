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
    public class Alt_IsverenMap : IEntityTypeConfiguration<Alt_Isveren>
    {
        public void Configure(EntityTypeBuilder<Alt_Isveren> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Alt_Isveren_Ad).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Notlar).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kontrol_Edildi).IsRequired();

            builder.ToTable("alt_isveren");

            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Alt_Isveren).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
