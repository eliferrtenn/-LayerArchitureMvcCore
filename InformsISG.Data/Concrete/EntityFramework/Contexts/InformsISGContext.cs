using InformsISG.Data.Concrete.EntityFramework.Mappings;
using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NO project = SET US AS PROJECT DATA
namespace InformsISG.Data.Concrete.EntityFramework.Contexts
{
    public class InformsISGContext : DbContext//dbContext veri tabanı bağlantısı olduğunu gösterir
    {
        //Salt string = @; $ = dışardan string alma
        public virtual DbSet<Acil_Durum_Ekip_Personel> Acil_Durum_Ekip_Personel { get; set; }
        public virtual DbSet<Acil_Durum_Ekipleri> Acil_Durum_Ekipleri { get; set; }
        public virtual DbSet<Acil_Eylem_Plani> Acil_Eylem_Plani { get; set; }
        public virtual DbSet<Acil_Durum_Tatbikat> Acil_Durum_Tatbikat { get; set; }
        public virtual DbSet<Alt_Isveren> Alt_Isveren { get; set; }
        public virtual DbSet<Asi_Personel> Asi_Personel { get; set; }
        public virtual DbSet<Asi_Sureleri> Asi_Sureleri { get; set; }
        public virtual DbSet<Asi_Tur> Asi_Tur { get; set; }
        public virtual DbSet<Ayarlar> Ayarlar { get; set; }
        public virtual DbSet<Beden_Bolge> Beden_Bolge { get; set; }
        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Dof> Dof { get; set; }
        public virtual DbSet<Dof_Dosya> Dof_Dosya { get; set; }
        public virtual DbSet<Egitim_Konu> Egitim_Konu { get; set; }
        public virtual DbSet<Egitim_Konu_Alt_Baslik> GetEgitim_Konu_Alt_Baslik { get; set; }
        public virtual DbSet<Egitim_Personel_Atama> Egitim_Personel_Atama { get; set; }
        public virtual DbSet<Egitim_Veren_Personel> Egitim_Veren_Personel { get; set; }
        public virtual DbSet<Egitim_Sinav> Egitim_Sinav { get; set; }
        public virtual DbSet<Egitim_Sinav_Not> Egitim_Sinav_Not { get; set; }
        public virtual DbSet<Egitim_Tanimla> Egitim_Tanimla { get; set; }
        public virtual DbSet<Hareket> Hareket { get; set; }
        public virtual DbSet<Isg_Kurul> Isg_Kurul { get; set; }
        public virtual DbSet<Isg_Kurul_Eleman> Isg_Kurul_Eleman { get; set; }
        public virtual DbSet<Isg_Kurul_Karar> Isg_Kurul_Karar { get; set; }
        public virtual DbSet<Isg_Kurul_Karar2> Isg_Kurul_Karar2 { get; set; }
        public virtual DbSet<Isg_Kurul_Karar_Dosya> Isg_Kurul_Karar_Dosya { get; set; }
        public virtual DbSet<Isg_Kurul_Karar_Gundem> Isg_Kurul_Karar_Gundem { get; set; }
        public virtual DbSet<Isveren> Isveren { get; set; }
        public virtual DbSet<Kaza> Kaza { get; set; }
        public virtual DbSet<Kaza_Ayrinti> Kaza_Ayrinti { get; set; }
        public virtual DbSet<Kaza_Dosya> Kaza_Dosya { get; set; }
        public virtual DbSet<Kaza_Personel_Disi> Kaza_Personel_Disi { get; set; }
        public virtual DbSet<Kaza_Personel_Disi_Dosya> Kaza_Personel_Disi_Dosya { get; set; }
        public virtual DbSet<Kkd> Kkd { get; set; }
        public virtual DbSet<Kkd_Personel_Atama> Kkd_Personel_Atama { get; set; }
        public virtual DbSet<Kkd_Dosya> Kkd_Dosya { get; set; }
        public virtual DbSet<Kkd_Tur> Kkd_Tur { get; set; }
        public virtual DbSet<Kkd_Tur_Alt> Kkd_Tur_Alt { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makine_Ekipman> Makine_Ekipman { get; set; }
        public virtual DbSet<Makine_Ekipman_Bakim_Planlari> Makine_Ekipman_Bakim_Planlari { get; set; }
        public virtual DbSet<Makine> Makine { get; set; }
        public virtual DbSet<Makine_Kontrol_Kriter_Baslik> GetMakine_Kontrol_Kriter_Baslik { get; set; }
        public virtual DbSet<Makine_Kontrol_Kriter> Makine_Kontrol_Kriter { get; set; }
        public virtual DbSet<MakineVeEkipman_Kontrol> MakineVeEkipman_KontrolKriter { get; set; }    
        public virtual DbSet<Makine_Bilgi_Baslik> Makine_Bilgi_Baslik { get; set; }
        public virtual DbSet<Makine_Bilgiler> Makine_Bilgiler { get; set; }
        public virtual DbSet<Makine_Olcum_Aleti_Bilgiler> Makine_Olcum_Aleti_Bilgiler { get; set; }
        public virtual DbSet<Makine_Test_Degerleri> Makine_Test_Degerleri { get; set; }
        public virtual DbSet<Makine_Ekipman_Kontrol_Kriter_Baslik> Makine_Ekipman_Kontrol_Kriter_Baslik { get; set; }  
        public virtual DbSet<Makine_Ekipman_Kontrol_Kriter> Makine_Ekipman_Kontrol_Kriter { get; set; }
        public virtual DbSet<Makine_Ekipman_Bilgi_Baslik> Makine_Ekipman_Bilgi_Baslik { get; set; }
        public virtual DbSet<Makine_Ekipman_Bilgiler> Makine_Ekipman_Bilgiler { get; set; }
        public virtual DbSet<Makine_Ekipman_Olcum_Aleti_Bilgiler> Makine_Ekipman_Olcum_Aleti_Bilgiler { get; set; }
        public virtual DbSet<Makine_Ekipman_Test_Degerleri> Makine_Ekipman_Test_Degerleri { get; set; }
        public virtual DbSet<Msds> Msds { get; set; }
        public virtual DbSet<Msds_Dosya> Msds_Dosya { get; set; }
        public virtual DbSet<Muayene> Muayene { get; set; }
        public virtual DbSet<Ortam_Olcum> Ortam_Olcum { get; set; }
        public virtual DbSet<Personel_Ayrinti> Personel_Ayrinti { get; set; }
        public virtual DbSet<Personel_Bilgi> Personel_Bilgi { get; set; }
        public virtual DbSet<Radyasyon> Radyasyon { get; set; }
        public virtual DbSet<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual DbSet<Ramak_Kala_Dosya> Ramak_Kala_Dosya { get; set; }
        public virtual DbSet<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual DbSet<Risk_Analiz_Risk> Risk_Analiz_Risk { get; set; }
        public virtual DbSet<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
        public virtual DbSet<Risk_Analiz_Tehlike> Risk_Analiz_Tehlike { get; set; }
        public virtual DbSet<Risk_Gerceklesen> Risk_Gerceklesen { get; set; }
        public virtual DbSet<Risk_Kategori> Risk_Kategori { get; set; }
        public virtual DbSet<Risk_Ust_Grup> Risk_Ust_Grup { get; set; }
        public virtual DbSet<Risk_Konu_Grup> Risk_Konu_Grup { get; set; }
        public virtual DbSet<Risk_Konu> Risk_Konu { get; set; }
        public virtual DbSet<Sgk_Meslek> Sgk_Meslek { get; set; }
        public virtual DbSet<Tali_Birim> Tali_Birim { get; set; }
        public virtual DbSet<Tehlike_Tanim> Tehlike_Tanim { get; set; }
        public virtual DbSet<Yaralanan_Vucut_Bolgesi> Yaralanan_Vucut_Bolgesi { get; set; }
        public virtual DbSet<Yaralanma_Sekli> Yaralanma_Sekli { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yetkili_Gormedi> Yetkili_Gormedi { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-411FIHT\SQLEXPRESS;Database=InformsISG;User Id=test;Password=test12345;").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //optionsBuilder.UseSqlServer(connectionString: @"Server=ISG-SERVER03\SQLEXPRESS;Database=InformsISG;User Id=sa1;Password=Meski1234.;").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //optionsBuilder.UseSqlServer(connectionString: @"Server=.;Database=InformsISG;User Id=sa;Password=MeskiInforms!.123;").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Acil_Durum_Ekip_PersonelMap());
            modelBuilder.ApplyConfiguration(new Acil_Durum_EkipleriMap());
            modelBuilder.ApplyConfiguration(new Acil_Eylem_PlaniMap());
            modelBuilder.ApplyConfiguration(new Acil_Durum_TatbikatMap());
            modelBuilder.ApplyConfiguration(new Alt_IsverenMap());
            modelBuilder.ApplyConfiguration(new Asi_PersonelMap());
            modelBuilder.ApplyConfiguration(new Asi_SureleriMap());
            modelBuilder.ApplyConfiguration(new Asi_TurMap());
            modelBuilder.ApplyConfiguration(new AyarlarMap());
            modelBuilder.ApplyConfiguration(new Beden_BolgeMap());
            modelBuilder.ApplyConfiguration(new BirimMap());
            modelBuilder.ApplyConfiguration(new DofMap());
            modelBuilder.ApplyConfiguration(new Dof_DosyaMap());
            modelBuilder.ApplyConfiguration(new Egitim_KonuMap());
            modelBuilder.ApplyConfiguration(new Egitim_Konu_Alt_BaslikMap());
            modelBuilder.ApplyConfiguration(new Egitim_Personel_AtamaMap());
            modelBuilder.ApplyConfiguration(new Egitim_Veren_PersonelMap());
            modelBuilder.ApplyConfiguration(new Egitim_SinavMap());
            modelBuilder.ApplyConfiguration(new Egitim_Sinav_NotMap());
            modelBuilder.ApplyConfiguration(new Egitim_TanimlaMap());
            modelBuilder.ApplyConfiguration(new HareketMap());
            modelBuilder.ApplyConfiguration(new Isg_KurulMap());
            modelBuilder.ApplyConfiguration(new Isg_Kurul_ElemanMap());
            modelBuilder.ApplyConfiguration(new Isg_Kurul_KararMap());
            modelBuilder.ApplyConfiguration(new Isg_Kurul_Karar2Map());
            modelBuilder.ApplyConfiguration(new Isg_Kurul_Karar_DosyaMap());
            modelBuilder.ApplyConfiguration(new Isg_Kurul_Karar_GundemMap());
            modelBuilder.ApplyConfiguration(new IsverenMap());
            modelBuilder.ApplyConfiguration(new KazaMap());
            modelBuilder.ApplyConfiguration(new Kaza_AyrintiMap());
            modelBuilder.ApplyConfiguration(new Kaza_DosyaMap());
            modelBuilder.ApplyConfiguration(new Kaza_Personel_DisiMap());
            modelBuilder.ApplyConfiguration(new Kaza_Personel_Disi_DosyaMap());
            modelBuilder.ApplyConfiguration(new KkdMap());
            modelBuilder.ApplyConfiguration(new Kkd_Personel_AtamaMap());
            modelBuilder.ApplyConfiguration(new Kkd_DosyaMap());
            modelBuilder.ApplyConfiguration(new Kkd_TurMap());
            modelBuilder.ApplyConfiguration(new Kkd_Tur_AltMap());
            modelBuilder.ApplyConfiguration(new KullaniciMap());
            modelBuilder.ApplyConfiguration(new Makine_EkipmanMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Bakim_PlanlariMap());
            modelBuilder.ApplyConfiguration(new MakineMap());
            modelBuilder.ApplyConfiguration(new Makine_Kontrol_Kriter_BaslikMap());
            modelBuilder.ApplyConfiguration(new Makine_Kontrol_KriterMap());
            modelBuilder.ApplyConfiguration(new MakineVeEkipman_KontrolMap()); 
            modelBuilder.ApplyConfiguration(new Makine_Bilgi_BaslikMap());
            modelBuilder.ApplyConfiguration(new Makine_BilgilerMap());
            modelBuilder.ApplyConfiguration(new Makine_Olcum_Aleti_BilgilerMap());
            modelBuilder.ApplyConfiguration(new Makine_Test_DegerleriMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Kontrol_Kriter_BaslikMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Kontrol_KriterMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Bilgi_BaslikMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_BilgilerMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Olcum_Aleti_BilgilerMap());
            modelBuilder.ApplyConfiguration(new Makine_Ekipman_Test_DegerleriMap());
            modelBuilder.ApplyConfiguration(new MsdsMap());
            modelBuilder.ApplyConfiguration(new Msds_DosyaMap());
            modelBuilder.ApplyConfiguration(new MuayeneMap());
            modelBuilder.ApplyConfiguration(new Ortam_OlcumMap());
            modelBuilder.ApplyConfiguration(new Personel_AyrintiMap());
            modelBuilder.ApplyConfiguration(new Personel_BilgiMap());
            modelBuilder.ApplyConfiguration(new RadyasyonMap());
            modelBuilder.ApplyConfiguration(new Ramak_KalaMap());
            modelBuilder.ApplyConfiguration(new Ramak_Kala_DosyaMap());
            modelBuilder.ApplyConfiguration(new Risk_AnalizMap());
            modelBuilder.ApplyConfiguration(new Risk_Analiz_RiskMap());
            modelBuilder.ApplyConfiguration(new Risk_Analiz_TabloMap());
            modelBuilder.ApplyConfiguration(new Risk_Analiz_TehlikeMap());
            modelBuilder.ApplyConfiguration(new Risk_GerceklesenMap());
            modelBuilder.ApplyConfiguration(new Risk_KategoriMap());
            modelBuilder.ApplyConfiguration(new Risk_Ust_GrupMap());
            modelBuilder.ApplyConfiguration(new Risk_Konu_GrupMap());
            modelBuilder.ApplyConfiguration(new Risk_KonuMap());
            modelBuilder.ApplyConfiguration(new Sgk_MeslekMap());
            modelBuilder.ApplyConfiguration(new Tali_BirimMap());
            modelBuilder.ApplyConfiguration(new Tehlike_TanimMap());
            modelBuilder.ApplyConfiguration(new Yaralanan_Vucut_BolgesiMap());
            modelBuilder.ApplyConfiguration(new Yaralanma_SekliMap());
            modelBuilder.ApplyConfiguration(new YetkiMap());
            modelBuilder.ApplyConfiguration(new Yetkili_GormediMap());

        }
    }
}
