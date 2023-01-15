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
    public class Egitim_Veren_PersonelMap : IEntityTypeConfiguration<Egitim_Veren_Personel>
    {
        public void Configure(EntityTypeBuilder<Egitim_Veren_Personel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.ToTable("egitim_veren_personel");

            builder.HasOne<Egitim_Tanimla>(k => k.Egitim_Tanimla).WithMany(b => b.Egitim_Veren_Personel).HasForeignKey(b => b.Egitim_Tanimla_Id).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Egitim_Veren_Personel).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Egitim_Veren_Personel).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);

        }
        }
}
