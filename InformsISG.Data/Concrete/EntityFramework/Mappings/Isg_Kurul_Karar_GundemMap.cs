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
    public class Isg_Kurul_Karar_GundemMap : IEntityTypeConfiguration<Isg_Kurul_Karar_Gundem>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul_Karar_Gundem> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Maddeler).HasMaxLength(200).IsRequired();

            builder.ToTable("isg_kurul_karar_gundem");

            builder.HasOne<Isg_Kurul_Karar>(k => k.Isg_Kurul_Karar).WithMany(b => b.Isg_Kurul_Karar_Gundem).HasForeignKey(b => b.Isg_Kurul_Karar_Id).OnDelete(DeleteBehavior.NoAction);
     

        }
    }
}
