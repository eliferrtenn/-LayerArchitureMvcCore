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
    public class Risk_Ust_GrupMap : IEntityTypeConfiguration<Risk_Ust_Grup>
    {
        public void Configure(EntityTypeBuilder<Risk_Ust_Grup> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Risk_Ust_Grup_Adi).HasMaxLength(150).IsRequired();

            builder.ToTable("kutuphane_ust_grup");

            builder.HasOne<Risk_Kategori>(k => k.Risk_Kategori).WithMany(b => b.Risk_Ust_Grup).HasForeignKey(b => b.Risk_Kategori_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
