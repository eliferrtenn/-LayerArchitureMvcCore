using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Data.Abstract
{ //unitofwork kullanılmadığı zaman silinmesi için : IAsyncDisposable
    public interface IUnitOfWork : IAsyncDisposable
    {

        IAcil_Durum_Ekip_PersonelRepository acil_Durum_Ekip_PersonelRepository { get; }
        IAcil_Durum_EkipleriRepository acil_Durum_EkipleriRepository { get; }
        IAcil_Eylem_PlaniRepository acil_Eylem_PlaniRepository { get; }
        IAcil_Durum_TatbikatRepository acil_Durum_TatbikatRepository { get; }
        IAlt_IsverenRepository alt_IsverenRepository { get; }
        IAsi_PersonelRepository asi_PersonelRepository { get; }
        IAsi_SureleriRepository asi_SureleriRepository { get; }
        IAsi_TurRepository asi_TurRepository{ get; }
        IAyarlarRepository ayarlarRepository{ get; }
        IBeden_BolgeRepository beden_BolgeRepository{ get; }
        IBirimRepository birimRepository{ get; }
        IDof_DosyaRepository dof_DosyaRepository{ get; }
        IDofRepository dofRepository{ get; }
        IEgitim_KonuRepository egitim_KonuRepository{ get; }
        IEgitim_Konu_Alt_BaslikRepository egitim_Konu_Alt_BaslikRepository{ get; }
        IEgitim_Personel_AtamaRepository egitim_Personel_AtamaRepository{ get; }
        IEgitim_Veren_PersonelRepository egitim_Veren_PersonelRepository{ get; }
        IEgitim_SinavRepository egitim_SinavRepository{ get; }
        IEgitim_Sinav_NotRepository egitim_Sinav_NotRepository{ get; }
        IEgitim_TanimlaRepository egitim_TanimlaRepository{ get; }
        IEgitim_Tanim_KonuRepository egitim_Tanim_KonuRepository{ get; }
        IHareketRepository hareketRepository{ get; }
        IIsg_KurulRepository isg_KurulRepository{ get; }
        IIsg_Kurul_ElemanRepository isg_Kurul_ElemanRepository{ get; }
        IIsg_Kurul_KararRepository isg_Kurul_KararRepository{ get; }
        IIsg_Kurul_Karar_DosyaRepository isg_Kurul_Karar_DosyaRepository{ get; }
        IIsg_Kurul_Karar_GundemRepository isg_Kurul_Karar_GundemRepository{ get; }
        IIsg_Kurul_Karar2Repository isg_Kurul_Karar2Repository{ get; }
        IIsverenRepository isverenRepository{ get; }
        IKazaRepository kazaRepository{ get; }
        IKaza_AyrintiRepository kaza_AyrintiRepository{ get; }
        IKaza_DosyaRepository kaza_DosyaRepository{ get; }
        IKaza_Personel_DisiRepository kaza_Personel_DisiRepository{ get; }
        IKaza_Personel_Disi_DosyaRepository kaza_Personel_Disi_DosyaRepository{ get; }
        IKkdRepository kkdRepository{ get; }
        IKkd_Personel_AtamaRepository kkd_Personel_AtamaRepository{ get; }
        IKkd_DosyaRepository kkd_DosyaRepository{ get; }
        IKkd_TurRepository kkd_TurRepository{ get; }
        IKkd_Tur_AltRepository kkd_Tur_AltRepository{ get; }
        IKullanici_Repository kullanici_Repository{ get; }
        IMakine_EkipmanRepository makine_EkipmanRepository{ get; }
        IMakine_Ekipman_Bakim_PlanlariRepository makine_Ekipman_Bakim_PlanlariRepository{ get; }
        IMakine_Ekipman_Bakim_FotografRepository makine_Ekipman_Bakim_FotografRepository{ get; }
        IMakine_Ekipman_KontrolRepository makine_Ekipman_KontrolRepository{ get; }
        IMakineRepository makineRepository{ get; }
        IMakine_Kontrol_Kriter_BaslikRepository makine_Kontrol_Kriter_BaslikRepository{ get; }
        IMakine_Kontrol_KriterRepository makine_Kontrol_KriterRepository{ get; }
        IMakineVeEkipman_KontrolKriterRepository makineVeEkipman_Kontrol_KriterRepository { get; }    
        IMakine_Bilgi_BaslikRepository makine_Bilgi_BaslikRepository{ get; }
        IMakine_BilgilerRepository makine_BilgilerRepository{ get; }
        IMakine_Olcum_Aleti_BilgilerRepository makine_Olcum_Aleti_BilgilerRepository{ get; }
        IMakine_Test_DegerleriRepository makine_Test_DegerleriRepository { get; }
        IMakine_Ekipman_Kontrol_Kriter_BaslikRepository makine_Ekipman_Kontrol_Kriter_BaslikRepository { get; }
        IMakine_Ekipman_Kontrol_KriterRepository makine_Ekipman_Kontrol_KriterRepository { get; }
        IMakine_Ekipman_Bilgi_BaslikRepository makine_Ekipman_Bilgi_BaslikRepository { get; }
        IMakine_Ekipman_BilgileriRepository makine_Ekipman_BilgileriRepository { get; }
        IMakine_Ekipman_Olcum_Aleti_BilgilerRepository makine_Ekipman_Olcum_Aleti_BilgilerRepository { get; }
        IMakine_Ekipman_Test_DegerleriRepository makine_Ekipman_Test_DegerleriRepository { get; }
        IMsdsRepository msdsRepository{ get; }
        IMsds_DosyaRepository msds_DosyaRepository{ get; }
        IMuayeneRepository muayeneRepository{ get; }
        IOrtam_OlcumRepository ortam_OlcumRepository{ get; }
        IPersonel_BilgiRepository personel_BilgiRepository { get; }
        IPersonel_AyrintiRepository personel_AyrintiRepository { get; }
        IRadyasyonRepository radyasyonRepository{ get; }
        IRamak_KalaRepository ramak_KalaRepository{ get; }
        IRamak_Kala_DosyaRepository ramak_Kala_DosyaRepository{ get; }
        IRisk_AnalizRepository risk_AnalizRepository{ get; }
        IRisk_Analiz_RiskRepository risk_Analiz_RiskRepository{ get; }
        IRisk_Analiz_TabloRepository risk_Analiz_TabloRepository{ get; }
        IRisk_Analiz_TehlikeRepository risk_Analiz_TehlikeRepository{ get; }
        IRisk_GerceklesenRepository risk_GerceklesenRepository{ get; }
        IRisk_YontemRepository risk_YontemRepository{ get; }
        IRisk_KategoriRepository risk_KategoriRepository{ get; }
        IRisk_Ust_GrupRepository risk_Ust_GrupRepository{ get; }
        IRisk_Konu_GrupRepository risk_Konu_GrupRepository{ get; }
        IRisk_KonuRepository risk_KonuRepository { get; }
        IRisk_KutuphaneRepository risk_KutuphaneRepository { get; }
        ISgk_MeslekRepository sgk_MeslekRepository{ get; }
        ITali_BirimRepository tali_BirimRepository{ get; }
        ITehlike_TanimRepository tehlike_TanimRepository{ get; }
        IYaralanan_Vucut_BolgesiRepository yaralanan_Vucut_BolgesiRepository{ get; }
        IYaralanma_SekliRepository yaralanma_SekliRepository{ get; }
        IYetkiRepository yetkiRepository{ get; }
        IYetkili_GormediRepository yetkili_GormediRepository{ get; }

        Task<int> SaveAsync();
    }
}
