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
    public class Makine_Ekipman_Test_DegerleriMap : IEntityTypeConfiguration<Makine_Ekipman_Test_Degerleri>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Test_Degerleri> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Madde_Ad).HasMaxLength(150);
            builder.Property(a => a.Madde_Ad_Karsilik).HasMaxLength(30);

            builder.ToTable("makine_ekipman_test_degerleri");

            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.Makine_Ekipman_Test_Degerleri).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
