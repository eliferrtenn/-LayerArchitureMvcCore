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
    public class MakineVeEkipman_KontrolMap : IEntityTypeConfiguration<MakineVeEkipman_Kontrol>
    {
        public void Configure(EntityTypeBuilder<MakineVeEkipman_Kontrol> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Uygun);
            builder.Property(a => a.Degerlendirme);

            builder.ToTable("makine_ve_ekipman_kontrol");

            builder.HasOne<Makine>(k => k.Makine).WithMany(b => b.MakineVeEkipman_KontrolKriter).HasForeignKey(b => b.Makine_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.MakineVeEkipman_KontrolKriter).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne<Makine_Kontrol_Kriter_Baslik>(k => k.Makine_Kontrol_Kriter_Baslik).WithMany(b => b.MakineVeEkipman_KontrolKriter).HasForeignKey(b => b.Makine_Kontrol_Kriter_Baslik_Id).OnDelete(DeleteBehavior.NoAction);   
            builder.HasOne<Makine_Kontrol_Kriter>(k => k.Makine_Kontrol_Kriter).WithMany(b => b.MakineVeEkipman_KontrolKriter).HasForeignKey(b => b.Makine_Kontrol_Kriter_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
