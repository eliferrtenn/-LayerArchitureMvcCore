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
    public class Makine_Ekipman_Bakim_PlanlariMap : IEntityTypeConfiguration<Makine_Ekipman_Bakim_Planlari>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Bakim_Planlari> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Servis_Tarih).IsRequired();
            builder.Property(a => a.Bakim_Tip).IsRequired();
            builder.Property(a => a.Yapilan_Islem).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(250);
            builder.Property(a => a.Diger_Servis_Tarih).IsRequired();
            builder.Property(a => a.Durum).IsRequired();
            builder.Property(a => a.OnayIsgUzman).IsRequired();
            builder.Property(a => a.OnayBirimSorumlu).IsRequired();



            builder.ToTable("makine_ekipman_bakim_planlari");


            builder.HasOne<Makine_Ekipman>(k => k.Makine_Ekipman).WithMany(b => b.Makine_Ekipman_Bakim_Planlari).HasForeignKey(b => b.Makine_Ekipman_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
