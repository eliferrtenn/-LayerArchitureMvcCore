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
    public class MuayeneMap : IEntityTypeConfiguration<Muayene>
    {
        public void Configure(EntityTypeBuilder<Muayene> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Muayene_Tarih).IsRequired();
            builder.Property(a => a.Muayene_Tur).IsRequired();
            builder.Property(a => a.Kan_Grup).HasMaxLength(20).IsRequired();
            builder.Property(a => a.El_Kullanim).IsRequired();
            builder.Property(a => a.Kilo).IsRequired();
            builder.Property(a => a.Boy).IsRequired();
            builder.Property(a => a.Kitle_Endeks).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Kronik_Hastalik).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Is_Kolu1).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Yaptigi_Is1).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Giris_Cikis1).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Is_Kolu2).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Yaptigi_Is2).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Giris_Cikis2).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Is_Kolu3).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Yaptigi_Is3).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Giris_Cikis3).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Bagisiklik_Tetanoz).IsRequired();
            builder.Property(a => a.Bagisiklik_Hepatit).IsRequired();
            builder.Property(a => a.Bagisiklik_Diger).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Soygecmis_Anne).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Soygecmis_Baba).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Kardes).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Cocuk).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Nefes_Darligi).IsRequired();
            builder.Property(a => a.Balgamli_Oksuruk).IsRequired();
            builder.Property(a => a.Gogus_Agrisi).IsRequired();
            builder.Property(a => a.Carpinti).IsRequired();
            builder.Property(a => a.Sirt_Agrisi).IsRequired();
            builder.Property(a => a.Ishal_Kabizlik).IsRequired();
            builder.Property(a => a.Eklem_Agri).IsRequired();
            builder.Property(a => a.Kalp_Hastalik).IsRequired();
            builder.Property(a => a.Seker_Hastalik).IsRequired();
            builder.Property(a => a.Bobrek_Rahatsizlik).IsRequired();
            builder.Property(a => a.Sarilik).IsRequired();
            builder.Property(a => a.Mide_Ulser).IsRequired();
            builder.Property(a => a.Isitme_Kayip).IsRequired();
            builder.Property(a => a.Gorme_Bozukluk).IsRequired();
            builder.Property(a => a.Sinir_Sistemi).IsRequired();
            builder.Property(a => a.Deri_Hastalik).IsRequired();
            builder.Property(a => a.Besin_Zehirlenme).IsRequired();
            builder.Property(a => a.Kanser).IsRequired();
            builder.Property(a => a.Kas_Iskelet).IsRequired();
            builder.Property(a => a.Akciger_Solunum).IsRequired();
            builder.Property(a => a.Hastane_Yatis).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Ameliyat).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Is_Kazasi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Meslek_Hastalik).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Maluliyet).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Guncel_Tedavi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Guncel_Tedavi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Guncel_Tedavi).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Sigara).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Alkol).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Aliskanlik_Uyusturucu).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Fizik_Goz).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Kbb).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Deri).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Kardiyovaskuler).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Deri).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Solunum_Sistemi).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Sindirim_Sistemi).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Urogenital).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Kas_Iskelet).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Norolojik).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Fizik_Psikiyatri).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Tansiyon).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Nabiz).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Lab_Biyolojik_Kan).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Lab_Biyolojik_Idrar).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Lab_Radyolojik).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Lab_Fizyolojik_Odyometre).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Lab_Fizyolojik_Sft).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Lab_Psikolojik).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kanaat1).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Kanaat2).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Yuksekte_Calisma).IsRequired();
            builder.Property(a => a.Vardiyali_Calisma).IsRequired();
            builder.Property(a => a.Konsultasyon).IsRequired();

            builder.ToTable("muayene");

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Muayene).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Muayene).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
