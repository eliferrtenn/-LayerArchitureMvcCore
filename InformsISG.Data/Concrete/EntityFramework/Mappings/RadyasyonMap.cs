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
    public class RadyasyonMap : IEntityTypeConfiguration<Radyasyon>
    {
        public void Configure(EntityTypeBuilder<Radyasyon> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Radyasyon_Tarih).IsRequired();
            builder.Property(a => a.Temas_Sekli1).IsRequired();
            builder.Property(a => a.Temas_Sekli2).IsRequired();
            builder.Property(a => a.Temas_Sekli_Diger).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Limit_Asim).IsRequired();
            builder.Property(a => a.Limit_Asim_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Radyasyon_Kaza).IsRequired();
            builder.Property(a => a.Radyasyon_Kaza_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Radyasyon_Maruz).IsRequired();
            builder.Property(a => a.Radyasyon_Maruz_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ciltte_Solukluk).IsRequired();
            builder.Property(a => a.Ciltte_Solukluk_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Genel_Yorgunluk).IsRequired();
            builder.Property(a => a.Genel_Yorgunluk_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Bas_Donmesi).IsRequired();
            builder.Property(a => a.Bas_Donmesi_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Atesli_Hastalik).IsRequired();
            builder.Property(a => a.Atesli_Hastalik_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Uzun_Sure_Enfeksiyon).IsRequired();
            builder.Property(a => a.Uzun_Sure_Enfeksiyon_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Uzun_Suren_Kanama).IsRequired();
            builder.Property(a => a.Uzun_Suren_Kanama_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Dis_Eti_Kanama).IsRequired();
            builder.Property(a => a.Dis_Eti_Kanama_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ciltte_Morluklar).IsRequired();
            builder.Property(a => a.Ciltte_Morluklar_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kil_Donmesi).IsRequired();
            builder.Property(a => a.Kil_Donmesi_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ciltte_Bozukluk).IsRequired();
            builder.Property(a => a.Ciltte_Bozukluk_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Gorme_Bulaniklik).IsRequired();
            builder.Property(a => a.Gorme_Bulaniklik_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Lenf_Buyume).IsRequired();
            builder.Property(a => a.Lenf_Buyume_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Telenjiektazi).IsRequired();
            builder.Property(a => a.Telenjiektazi_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Hiperkeratoz).IsRequired();
            builder.Property(a => a.Hiperkeratoz_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Atrofi).IsRequired();
            builder.Property(a => a.Atrofi_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kil_Dokulmesi2).IsRequired();
            builder.Property(a => a.Kil_Dokulmesi2_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Tirnak_Bozukluk).IsRequired();
            builder.Property(a => a.Tirnak_Bozukluk_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Periferik_Lenfadenopatİ).IsRequired();
            builder.Property(a => a.Periferik_Lenfadenopati_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Hepatosplenomegali).IsRequired();
            builder.Property(a => a.Hepatosplenomegali_Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Beyaz_Kure).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Trombosit).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Hemoglobin).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Kirmizi_Kure).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Lenfosit).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Notrofil).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Monosit).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Eozinofil).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Bazofil).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Normal_Disi).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Katarakt).IsRequired();
            builder.Property(a => a.Goz_Uzman_Degerlendirme).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aciklama).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Diger_Husus).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ac_Grafisi).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Periferik_Yayma).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Hastalik_Oykusu).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Ek_Biyokimya).HasMaxLength(300).IsRequired();
            builder.Property(a => a.Kullandigi_Ilaclar).HasMaxLength(300).IsRequired();

            builder.ToTable("radyasyon");

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Radyasyon).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Radyasyon).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
