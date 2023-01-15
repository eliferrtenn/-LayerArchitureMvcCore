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
    public class Makine_Ekipman_Kontrol_Kriter_BaslikMap : IEntityTypeConfiguration<Makine_Ekipman_Kontrol_Kriter_Baslik>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Kontrol_Kriter_Baslik> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Madde_Ad).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Notlar).HasMaxLength(3500);

            builder.ToTable("makine_ekipman_kontrol_kriter_baslik");

            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.Makine_Ekipman_Kontrol_Kriter_Baslik).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
