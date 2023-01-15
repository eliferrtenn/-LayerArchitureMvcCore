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
    public class KazaMap : IEntityTypeConfiguration<Kaza>
    {
        public void Configure(EntityTypeBuilder<Kaza> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Kaza_No).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Kaza_Tarih).IsRequired();
            builder.Property(a => a.Kaza_Saat).HasMaxLength(10).IsRequired();
            builder.Property(a => a.Bildirim_Tarih).IsRequired();
            builder.Property(a => a.Ise_Baslama_Saat).HasMaxLength(8).IsRequired();
            builder.Property(a => a.Kaza_Hasar_Tipi);
            builder.Property(a => a.Kaza_Anindaki_Faaliyet).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Kaza_Yer).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Yaralanmaya_Neden_Olan_Olay).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Yaralanmaya_Neden_Olan_Arac).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Tibbi_Mudahele).IsRequired();
            builder.Property(a => a.Tibbi_Mudahele_Aciklama).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Is_Gorememezlik).IsRequired();
            builder.Property(a => a.Is_Gorememezlik_Gun_Sayi).IsRequired();
            builder.Property(a => a.Kaza_Sonrasi_Calisan_Ne_Yapti).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Mesleki_Egitim).IsRequired();
            builder.Property(a => a.Isg_Egitim).IsRequired();
            builder.Property(a => a.Hasar_Buyuklugu).IsRequired();
            builder.Property(a => a.Tekrarlanma_Olasiligi).IsRequired();
            builder.Property(a => a.Gerceklesme_Frekansi).IsRequired();
            builder.Property(a => a.Maruz_Kalan_Calisanin_Ifadesi).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Gorgu_Ifadesi).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Kaza_Yol_Acan_Sebepler).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Varolmasinda_Temel_Nedenler).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Birim_Sorumlu_Gorus_Oneri).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Isg_Uzmani_Degerlendirme).HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Tanik_Tcno1).HasMaxLength(11).IsRequired();
            builder.Property(a => a.Tanik_Ad_Soyad1).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Tanik_Eposta1).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Tanik_Telefon1).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Tanik_Adres1).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Tanik_Tcno2).HasMaxLength(11).IsRequired();
            builder.Property(a => a.Tanik_Ad_Soyad2).HasMaxLength(75).IsRequired();
            builder.Property(a => a.Tanik_Eposta2).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Tanik_Telefon2).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Tanik_Adres2).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Dof1).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu1).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih1).IsRequired();
            builder.Property(a => a.Kapanis_Tarih1).IsRequired();
            builder.Property(a => a.Dof2).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu2).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih2).IsRequired();
            builder.Property(a => a.Kapanis_Tarih2).IsRequired();
            builder.Property(a => a.Dof3).HasMaxLength(3000).IsRequired();
            builder.Property(a => a.Sorumlu3).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Acilis_Tarih3).IsRequired();
            builder.Property(a => a.Kapanis_Tarih3).IsRequired();

            builder.ToTable("kaza");

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Kaza).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isg_Kurul>(k => k.Isg_Kurul).WithMany(b => b.Kaza).HasForeignKey(b => b.Isg_Kurul_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Kaza).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Yaralanan_Vucut_Bolgesi>(k => k.Yaralanan_Vucut_Bolgesi).WithMany(b => b.Kaza).HasForeignKey(b => b.Yaralanan_Vucut_Bolgesi_Id).OnDelete(DeleteBehavior.NoAction);  
            
            builder.HasOne<Tali_Birim>(k => k.Tali_Birim).WithMany(b => b.Kaza).HasForeignKey(b => b.Tali_Birim_Id).OnDelete(DeleteBehavior.NoAction);    
            
            builder.HasOne<Yaralanma_Sekli>(k => k.Yaralanma_Sekli).WithMany(b => b.Kaza).HasForeignKey(b => b.Yaralanma_Sekli_Id).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
