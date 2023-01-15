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
    public class Egitim_SinavMap : IEntityTypeConfiguration<Egitim_Sinav>
    {
        public void Configure(EntityTypeBuilder<Egitim_Sinav> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Sinav_Ad).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Sinav_Tarih).IsRequired();
            builder.Property(a => a.Sinav_Saat).IsRequired();

            builder.ToTable("egitim_sinav");

            builder.HasOne<Egitim_Tanimla>(k => k.Egitim_Tanimla).WithMany(b => b.Egitim_Sinav).HasForeignKey(b => b.Egitim_Tanimla_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Egitim_Sinav).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Egitim_Sinav).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
