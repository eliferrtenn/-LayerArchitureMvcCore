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
    public class Makine_Ekipman_KontrolMap : IEntityTypeConfiguration<Makine_Ekipman_Kontrol>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Kontrol> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kontrol_Ad).HasMaxLength(150).IsRequired();

            builder.ToTable("makine_ekipman_kontrol");

            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.Makine_Ekipman_Kontrol).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}