
using InformsISG.Data.Abstract;
using InformsISG.Data.Concrete;
using InformsISG.Data.Concrete.EntityFramework.Contexts;
using InformsISG.Services.Abstract;
using InformsISG.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Extensions
{//static newleemeye gerek yok
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<InformsISGContext>(ServiceLifetime.Transient);
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddMemoryCache();//Tüm verileri memory de tut
            serviceCollection.AddScoped<IAcil_Durum_Ekip_PersonelService,Acil_Durum_Ekip_PersonelManager>();
            serviceCollection.AddScoped<IAcil_Durum_EkipleriService,Acil_Durum_EkipleriManager>();
            serviceCollection.AddScoped<IAcil_Eylem_PlaniService,Acil_Eylem_PlaniManager>();
            serviceCollection.AddScoped<IAcil_Durum_TatbikatService,Acil_Durum_TatbikatManager>();
            serviceCollection.AddScoped<IAlt_IsverenService,Alt_IsverenManager>();
            serviceCollection.AddScoped<IAsi_PersonelService,Asi_PersonelManager>();
            serviceCollection.AddScoped<IAsi_SureleriService,Asi_SureleriManager>();
            serviceCollection.AddScoped<IAsi_TurService,Asi_TurManager>();
            serviceCollection.AddScoped<IAyarlarService,AyarlarManager>();
            serviceCollection.AddScoped<IBeden_BolgeService,Beden_BolgeManager>();
            serviceCollection.AddScoped<IBirimService,BirimManager>();
            serviceCollection.AddScoped<IDof_DosyaService,Dof_DosyaManager>();
            serviceCollection.AddScoped<IDofService,DofManager>();
            serviceCollection.AddScoped<IEgitim_KonuService,Egitim_KonuManager>();
            serviceCollection.AddScoped<IEgitim_Konu_Alt_BaslikService,Egitim_Konu_Alt_BaslikManager>();
            serviceCollection.AddScoped<IEgitim_Personel_AtamaService,Egitim_Personel_AtamaManager>();
            serviceCollection.AddScoped<IEgitim_Veren_PersonelService,Egitim_Veren_PersonelManager>();
            serviceCollection.AddScoped<IEgitim_SinavService,Egitim_SinavManager>();
            serviceCollection.AddScoped<IEgitim_Sinav_NotService,Egitim_Sinav_NotManager>();
            serviceCollection.AddScoped<IEgitim_TanimlaService,Egitim_TanimlaManager>();
            serviceCollection.AddScoped<IEgitim_Tanim_KonuService,Egitim_Tanim_KonuManager>();
            serviceCollection.AddScoped<IHareketService,HareketManager>();
            serviceCollection.AddScoped<IISg_Kurul_ElemanService,Isg_Kurul_ElemanManager>();
            serviceCollection.AddScoped<IISg_Kurul_Karar_DosyaService,Isg_Kurul_Karar_DosyaManager>();
            serviceCollection.AddScoped<IISg_Kurul_KararService,Isg_Kurul_KararManager>();
            serviceCollection.AddScoped<IISg_Kurul_Karar_GundemService, Isg_Kurul_Karar_GundemManager>();
            serviceCollection.AddScoped<IISg_KurulService,Isg_KurulManager>();
            serviceCollection.AddScoped<IIsg_Kurul_Karar2Service,Isg_Kurul_Karar2Manager>();
            serviceCollection.AddScoped<IIsverenService,IsverenManager>();
            serviceCollection.AddScoped<IKaza_AyrintiService,Kaza_AyrintiManager>();
            serviceCollection.AddScoped<IKaza_DosyaService,Kaza_DosyaManager>();
            serviceCollection.AddScoped<IKaza_Personel_Disi_DosyaService,Kaza_Personel_Disi_DosyaManager>();
            serviceCollection.AddScoped<IKaza_Personel_DisiService,Kaza_Personel_DisiManager>();
            serviceCollection.AddScoped<IKazaService,KazaManager>();
            serviceCollection.AddScoped<IKkd_DosyaService,Kkd_DosyaManager>();
            serviceCollection.AddScoped<IKkd_Tur_AltService,Kkd_Tur_AltManager>();
            serviceCollection.AddScoped<IKkd_TurService,Kkd_TurManager>();
            serviceCollection.AddScoped<IKkdService,KkdManager>();
            serviceCollection.AddScoped<IKkd_Personel_AtamaService,Kkd_PersonelAtamaManager>();
            serviceCollection.AddScoped<IKullaniciService,KullaniciManager>(); serviceCollection.AddScoped<IMakine_Ekipman_Bakim_PlanlariService,Makine_Ekipman_Bakim_PlanlariManager>();
            serviceCollection.AddScoped<IMakine_EkipmanService,Makine_EkipmanManager>();           serviceCollection.AddScoped<IMakine_Ekipman_Bakim_FotografService,Makine_Ekipman_Bakim_FotografManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_KontrolService,Makine_Ekipman_KontrolManager>();
            serviceCollection.AddScoped<IMakineService,MakineManager>();
            serviceCollection.AddScoped<IMakine_Kontrol_Kriter_BaslikService, Makine_Kontrol_Kriter_BaslikManager>();
            serviceCollection.AddScoped<IMakine_Kontrol_KriterService,Makine_Kontrol_KriterManager>();     serviceCollection.AddScoped<IMakineVeEkipman_KontrolKriterService,MakineVeEkipman_KontrolKriterManager>();
            serviceCollection.AddScoped<IMakine_Bilgi_BaslikService, Makine_Bilgi_BaslikManager>();
            serviceCollection.AddScoped<IMakine_BilgilerService, Makine_BilgilerManager>();
            serviceCollection.AddScoped<IMakine_Test_DegerleriService, Makine_Test_DegerleriManager>();
            serviceCollection.AddScoped<IMakine_Olcum_Aleti_BilgilerService, Makine_Olcum_AletiManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_Kontrol_Kriter_BaslikService, Makine_Ekipman_Kontrol_Kriter_BaslikManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_Kontrol_KriterService, Makine_Ekipman_Kontrol_KriterManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_Bilgi_BaslikService, Makine_Ekipman_Bilgi_BaslikManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_BilgilerService, Makine_Ekipman_BilgilerManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_Test_DegerleriService, Makine_Ekipman_Test_DegerleriManager>();
            serviceCollection.AddScoped<IMakine_Ekipman_Olcum_Aleti_BilgilerService, Makine_Ekipman_Olcum_Aleti_BilgilerManager>();
            serviceCollection.AddScoped<IMsds_DosyaService, Msds_DosyaManager>();
            serviceCollection.AddScoped<IMsdsService,MsdsManager>();
            serviceCollection.AddScoped<IMuayeneService,MuayeneManager>();
            serviceCollection.AddScoped<IOrtam_OlcumService,Ortam_OlcumManager>();
            serviceCollection.AddScoped<IPersonel_BilgiService,Personel_BilgiManager>();
            serviceCollection.AddScoped<IPersonel_AyrintiService,Personel_AyrintiManager>();
            serviceCollection.AddScoped<IRadyasyonService,RadyasyonManager>();
            serviceCollection.AddScoped<IRamak_KalaService,Ramak_KalaManager>();
            serviceCollection.AddScoped<IRamak_Kala_DosyaService,Ramak_Kala_DosyaManager>();
            serviceCollection.AddScoped<IRisk_Analiz_RiskService,Risk_Analiz_RiskManager>();
            serviceCollection.AddScoped<IRisk_Analiz_TabloService,Risk_Analiz_TabloManager>();
            serviceCollection.AddScoped<IRisk_Analiz_TehlikeService,Risk_Analiz_TehlikeManager>();
            serviceCollection.AddScoped<IRisk_AnalizService,Risk_AnalizManager>();
            serviceCollection.AddScoped<IRisk_GerceklesenService,Risk_GerceklesenManager>();
            serviceCollection.AddScoped<IRisk_YontemService,Risk_YontemManager>();
            serviceCollection.AddScoped<IRisk_KategoriService,Risk_KategoriManager>();
            serviceCollection.AddScoped<IRisk_Ust_GrupService,Risk_Ust_GrupManager>();
            serviceCollection.AddScoped<IRisk_KonuGrupService,Risk_Konu_GrupManager>();
            serviceCollection.AddScoped<IRisk_KonuService,Risk_KonuManager>();
            serviceCollection.AddScoped<IRisk_KutuphaneService,Risk_KutuphaneManager>();
            serviceCollection.AddScoped<ISgk_MeslekService,Sgk_MeslekManager>();
            serviceCollection.AddScoped<ITali_BirimService,Tali_BirimManager>();
            serviceCollection.AddScoped<ITehlike_TanimService,Tehlike_TanimManager>();
            serviceCollection.AddScoped<IYaralanan_Vucut_BolgesiService,Yaralanan_Vucut_BolgesiManager>();
            serviceCollection.AddScoped<IYaralanma_SekliService,Yaralanma_SekliManager>();
            serviceCollection.AddScoped<IYetkiService,YetkiManager>();
            serviceCollection.AddScoped<IYetkili_GormediService,Yetkili_GormediManager>();
      
            return serviceCollection;
        }
    }
}
