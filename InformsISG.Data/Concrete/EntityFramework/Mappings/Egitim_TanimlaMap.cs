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
    public class Egitim_TanimlaMap : IEntityTypeConfiguration<Egitim_Tanimla>
    {
        public void Configure(EntityTypeBuilder<Egitim_Tanimla> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Egitim_Sebep).IsRequired();
            builder.Property(a => a.Egitim_Tarih).IsRequired();
            builder.Property(a => a.Egitim_Tur).IsRequired();
            builder.Property(a => a.Egitim_Yer).HasMaxLength(1).IsRequired();
            builder.Property(a => a.Egitim_Yer_Ad).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Tekrar_Tarih).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();

            builder.ToTable("egitim_tanimla");

            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Egitim_Tanimla).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Egitim_Tanimla).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
