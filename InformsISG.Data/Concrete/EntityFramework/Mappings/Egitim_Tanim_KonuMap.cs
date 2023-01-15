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
    public class Egitim_Tanim_KonuMap : IEntityTypeConfiguration<Egitim_Tanim_Konu>
    {
        public void Configure(EntityTypeBuilder<Egitim_Tanim_Konu> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.ToTable("egitim_tanim_konu");

            builder.HasOne<Egitim_Tanimla>(k => k.Egitim_Tanimla).WithMany(b => b.Egitim_Tanim_Konu).HasForeignKey(b => b.Egitim_Tanimla_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Egitim_Konu_Alt_Baslik>(k => k.Egitim_Konu_Alt_Baslik).WithMany(b => b.Egitim_Tanim_Konu).HasForeignKey(b => b.Egitim_Konu_Alt_Baslik_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
