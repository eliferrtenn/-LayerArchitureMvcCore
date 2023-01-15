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
    public class Makine_Ekipman_Bilgi_BaslikMap : IEntityTypeConfiguration<Makine_Ekipman_Bilgi_Baslik>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Bilgi_Baslik> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Madde_Ad).HasMaxLength(150);

            builder.ToTable("makine_ekipman_bilgi_baslik");

            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.Makine_Ekipman_Bilgi_Baslik).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
