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
    public class Egitim_Konu_Alt_BaslikMap : IEntityTypeConfiguration<Egitim_Konu_Alt_Baslik>
    {
        public void Configure(EntityTypeBuilder<Egitim_Konu_Alt_Baslik> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Alt_Baslik_No).HasMaxLength(5).IsRequired();
            builder.Property(a => a.Alt_Baslik_Ad).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Tehlike_Tip).IsRequired();
            builder.Property(a => a.Sure).HasMaxLength(5).IsRequired();

            builder.ToTable("egitim_konu_alt_baslik");

            builder.HasOne<Egitim_Konu>(k => k.Egitim_Konu).WithMany(b => b.Egitim_Konu_Alt_Baslik).HasForeignKey(b => b.Egitim_Konu_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
