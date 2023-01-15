using InformsISG.Core.Entities.Abstract;
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
    public class Personel_AyrintiMap : IEntityTypeConfiguration<Personel_Ayrinti>
    {
        public void Configure(EntityTypeBuilder<Personel_Ayrinti> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Cocuk).IsRequired();
            builder.Property(a => a.Kardes).IsRequired();
            builder.Property(a => a.El_Kullanim).IsRequired();
            builder.Property(a => a.Kilo).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Boy).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Kitle_Endeks).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Acil_Durum).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Kan_Grup).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Bagisiklik_Tetanoz).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Bagisiklik_Hepatit).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Bagisiklik_Diger).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Soy_Kalp).IsRequired();
            builder.Property(a => a.Soy_Hipertansiyon).IsRequired();
            builder.Property(a => a.Soy_Seker).IsRequired();
            builder.Property(a => a.Nefes_Darligi).IsRequired();
            builder.Property(a => a.Carpinti).IsRequired();
            builder.Property(a => a.Sirt_Agrisi).IsRequired();
            builder.Property(a => a.Ishal_Kabizlik).IsRequired();
            builder.Property(a => a.Eklem_Agri).IsRequired();
            builder.Property(a => a.Kalp_Hastalik).IsRequired();
            builder.Property(a => a.Seker_Hastalik).IsRequired();
            builder.Property(a => a.Bobrek_Rahatsizlik).IsRequired();
            builder.Property(a => a.Sarilik).IsRequired();
            builder.Property(a => a.Ulser).IsRequired();
            builder.Property(a => a.Isitme_Kayip).IsRequired();
            builder.Property(a => a.Gorme_Bozukluk).IsRequired();
            builder.Property(a => a.Sinir_Sistemi).IsRequired();
            builder.Property(a => a.Deri_Hastalik).IsRequired();
            builder.Property(a => a.Besin_Zehirlenme).IsRequired();
            builder.Property(a => a.Hastane_Yatis).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ameliyat).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Is_Kazasi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Meslek_Hastalik).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Maluliyet).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Guncel_Tedavi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Sigara).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Alkol).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Uyusturucu).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Diger).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Personel_Not).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Engelli).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Eski_Hukumlu).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Agir_Tehlikeli).IsRequired();
            builder.Property(a => a.Yuksekte_Calisma).IsRequired();
            builder.Property(a => a.Gece_Vardiya).IsRequired();
            builder.Property(a => a.Uygunluk_Durumu).IsRequired();

            builder.ToTable("personel_ayrinti");

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b =>b.Personel_Ayrinti).HasForeignKey(b=>b.Personel_Id).OnDelete(DeleteBehavior.NoAction);

        }
    }
    
}
