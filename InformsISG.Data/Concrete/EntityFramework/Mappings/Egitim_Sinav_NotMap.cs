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
    public class Egitim_Sinav_NotMap : IEntityTypeConfiguration<Egitim_Sinav_Not>
    {
        public void Configure(EntityTypeBuilder<Egitim_Sinav_Not> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Sinav_Not).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("egitim_sinav_not");

            builder.HasOne<Egitim_Sinav>(k => k.Egitim_Sinav).WithMany(b => b.Egitim_Sinav_Not).HasForeignKey(b => b.Egitim_Sinav_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Egitim_Sinav_Not).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
