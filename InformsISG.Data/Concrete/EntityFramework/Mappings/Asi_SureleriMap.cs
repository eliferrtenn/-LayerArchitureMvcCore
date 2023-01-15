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
    public class Asi_SureleriMap : IEntityTypeConfiguration<Asi_Sureleri>
    {
        public void Configure(EntityTypeBuilder<Asi_Sureleri> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Yas).IsRequired();
            builder.Property(a => a.Periyot_Birim).HasMaxLength(5).IsRequired();
            builder.Property(a => a.Surekli).IsRequired();
            builder.Property(a => a.Periyot1_1).IsRequired();
            builder.Property(a => a.Periyot1_2).IsRequired();
            builder.Property(a => a.Periyot2_1).IsRequired();
            builder.Property(a => a.Periyot2_2).IsRequired();
            builder.Property(a => a.Periyot3_1).IsRequired();
            builder.Property(a => a.Periyot3_2).IsRequired();
            builder.Property(a => a.Periyot4_1).IsRequired();
            builder.Property(a => a.Periyot4_2).IsRequired();
            builder.Property(a => a.Periyot5_1).IsRequired();
            builder.Property(a => a.Periyot5_2).IsRequired();

            builder.ToTable("asi_sureleri");

            builder.HasOne<Asi_Tur>(k => k.Asi_Tur).WithMany(b => b.Asi_Sureleri).HasForeignKey(b => b.Asi_Tur_Id).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
