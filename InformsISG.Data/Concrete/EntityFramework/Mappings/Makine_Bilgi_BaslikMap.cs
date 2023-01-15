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
    public class Makine_Bilgi_BaslikMap : IEntityTypeConfiguration<Makine_Bilgi_Baslik>
    {
        public void Configure(EntityTypeBuilder<Makine_Bilgi_Baslik> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Madde_Ad).HasMaxLength(150);

            builder.ToTable("makine_bilgi_baslik");

            builder.HasOne<Makine>(k => k.Makine).WithMany(b => b.Makine_Bilgi_Baslik).HasForeignKey(b => b.Makine_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
