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
    public class Risk_Konu_GrupMap : IEntityTypeConfiguration<Risk_Konu_Grup>
    {
        public void Configure(EntityTypeBuilder<Risk_Konu_Grup> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Konu_Grup_Adi).HasMaxLength(150).IsRequired();

            builder.ToTable("kutuphane_konu_grup");

            builder.HasOne<Risk_Ust_Grup>(k => k.Risk_Ust_Grup).WithMany(b => b.Risk_Konu_Grup).HasForeignKey(b => b.Risk_Ust_Grup_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
