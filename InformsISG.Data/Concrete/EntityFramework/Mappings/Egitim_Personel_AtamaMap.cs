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
    public class Egitim_Personel_AtamaMap : IEntityTypeConfiguration<Egitim_Personel_Atama>
    {
        public void Configure(EntityTypeBuilder<Egitim_Personel_Atama> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Egitime_Katilim).IsRequired();
            builder.Property(a => a.Sertifika_Basildi).IsRequired();

            builder.ToTable("egitim_personel_atama");

            builder.HasOne<Egitim_Tanimla>(k => k.Egitim_Tanimla).WithMany(b => b.Egitim_Personel_Atama).HasForeignKey(b => b.Egitim_Tanimla_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Egitim_Personel_Atama).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
