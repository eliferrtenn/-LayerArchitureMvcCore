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
    public class Kkd_Personel_AtamaMap : IEntityTypeConfiguration<Kkd_Personel_Atama>
    {
        public void Configure(EntityTypeBuilder<Kkd_Personel_Atama> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.ToTable("kkd_personel_atama");

            builder.HasOne<Kkd>(k => k.Kkd).WithMany(b => b.Kkd_Personel_Atama).HasForeignKey(b => b.Kkd_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Kkd_Personel_Atama).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
