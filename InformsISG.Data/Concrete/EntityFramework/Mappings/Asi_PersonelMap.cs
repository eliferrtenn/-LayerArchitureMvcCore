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
    public class Asi_PersonelMap : IEntityTypeConfiguration<Asi_Personel>
    {
        public void Configure(EntityTypeBuilder<Asi_Personel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Islem_Tarih).IsRequired();
            builder.Property(a => a.Uygulayan_Ad).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Asi_Doz).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Uygulama_Yer).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Uygulama_Sekil).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Uygulandi).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("asi_personel");

            builder.HasOne<Asi_Tur>(k => k.Asi_Tur).WithMany(b => b.Asi_Personel).HasForeignKey(b => b.Asi_Tur_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Asi_Personel).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
