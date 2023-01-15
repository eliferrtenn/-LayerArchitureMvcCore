using InformsISG.Data.Abstract;
using InformsISG.Data.Concrete.EntityFramework.Contexts;
using InformsISG.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InformsISGContext _context;
        private IAcil_Durum_Ekip_PersonelRepository _acil_Durum_Ekip_PersonelRepository { get; }
        private IAcil_Durum_EkipleriRepository _acil_Durum_EkipleriRepository { get; }
        private IAcil_Eylem_PlaniRepository _acil_Eylem_PlaniRepository { get; }
        private IAcil_Durum_TatbikatRepository _acil_Durum_TatbikatRepository { get; }
        private IAlt_IsverenRepository _alt_IsverenRepository { get; }
        private IAsi_PersonelRepository _asi_PersonelRepository { get; }
        private IAsi_SureleriRepository _asi_SureleriRepository { get; }
        private IAsi_TurRepository _asi_TurRepository { get; }
        private IAyarlarRepository _ayarlarRepository { get; }
        private IBeden_BolgeRepository _beden_BolgeRepository { get; }
        private IBirimRepository _birimRepository { get; }
        private IDof_DosyaRepository _dof_DosyaRepository { get; }
        private IDofRepository _dofRepository { get; }
        private IEgitim_KonuRepository _egitim_KonuRepository { get; }
        private IEgitim_Konu_Alt_BaslikRepository _egitim_Konu_Alt_BaslikRepository { get; }
        private IEgitim_Personel_AtamaRepository _egitim_Personel_AtamaRepository { get; }
        private IEgitim_SinavRepository _egitim_Sinav_Repository { get; }
        private IEgitim_Sinav_NotRepository _egitim_Sinav_NotRepository { get; }
        private IEgitim_TanimlaRepository _egitim_TanimlaRepository { get; }                                        
        private IEgitim_Veren_PersonelRepository _egitim_Veren_PersonelRepository { get; }                    
        private IEgitim_Tanim_KonuRepository _egitim_Tanim_KonuRepository { get; }                    
        private IHareketRepository _hareketRepository { get; }
        private IIsg_KurulRepository _isg_KurulRepository { get; }
        private IIsg_Kurul_ElemanRepository _isg_Kurul_ElemanRepository { get; }
        private IIsg_Kurul_KararRepository _isg_Kurul_KararRepository { get; }
        private IIsg_Kurul_Karar_DosyaRepository _isg_Kurul_Karar_DosyaRepository { get; }
        private IIsg_Kurul_Karar_GundemRepository _isg_Kurul_Karar_GundemRepository { get; }
        private IIsg_Kurul_Karar2Repository _isg_Kurul_Karar2Repository { get; }
        private IIsverenRepository _isverenRepository { get; }
        private IKazaRepository _kazaRepository { get; }
        private IKaza_AyrintiRepository _kaza_AyrintiRepository { get; }
        private IKaza_DosyaRepository _kaza_DosyaRepository { get; }
        private IKaza_Personel_DisiRepository _kaza_Personel_DisiRepository { get; }
        private IKaza_Personel_Disi_DosyaRepository _kaza_Personel_Disi_DosyaRepository { get; }
        private IKkdRepository _kkdRepository { get; }
        private IKkd_Personel_AtamaRepository _kkd_Personel_AtamaRepository { get; }
        private IKkd_DosyaRepository _kkd_DosyaRepository { get; }
        private IKkd_TurRepository _kkd_TurRepository { get; }
        private IKkd_Tur_AltRepository _kkd_Tur_AltRepository { get; }
        private IKullanici_Repository _kullanici_Repository { get; }
        private IMakine_EkipmanRepository _makine_EkipmanRepository { get; }
        private IMakine_Ekipman_Bakim_PlanlariRepository _makine_Ekipman_Bakim_PlanlariRepository { get; } 
        private IMakine_Ekipman_Bakim_FotografRepository _makine_Ekipman_Bakim_FotografRepository { get; }
        private IMakine_Ekipman_KontrolRepository _makine_Ekipman_KontrolRepository { get; }   
        private IMakineRepository _makineRepository { get; }   
        private IMakine_Kontrol_Kriter_BaslikRepository _makine_Kontrol_Kriter_BaslikRepository { get; }   
        private IMakine_Kontrol_KriterRepository _makine_Kontrol_KriterRepository { get; }   
        private IMakineVeEkipman_KontrolKriterRepository _makineVeEkipman_KontrolKriterRepository { get; } 
        private IMakine_Bilgi_BaslikRepository _makine_Bilgi_BaslikRepository { get; }   
        private IMakine_BilgilerRepository _makine_BilgilerRepository { get; }   
        private IMakine_Olcum_Aleti_BilgilerRepository _makine_Olcum_Aleti_BilgilerRepository { get; }   
        private IMakine_Test_DegerleriRepository _makine_Test_DegerleriRepository { get; }

        private IMakine_Ekipman_Kontrol_Kriter_BaslikRepository _makine_Ekipman_Kontrol_Kriter_BaslikRepository { get; }
        private IMakine_Ekipman_Kontrol_KriterRepository _makine_Ekipman_Kontrol_KriterRepository { get; }
        private IMakine_Ekipman_Bilgi_BaslikRepository _makine_Ekipman_Bilgi_BaslikRepository { get; }
        private IMakine_Ekipman_BilgileriRepository _makine_Ekipman_BilgileriRepository { get; }
        private IMakine_Ekipman_Olcum_Aleti_BilgilerRepository _makine_Ekipman_Olcum_Aleti_BilgilerRepository { get; }
        private IMakine_Ekipman_Test_DegerleriRepository _makine_Ekipman_Test_DegerleriRepository { get; }
        private IMsdsRepository _msdsRepository { get; }
        private IMsds_DosyaRepository _msds_DosyaRepository { get; }
        private IMuayeneRepository _muayeneRepository { get; }
        private IOrtam_OlcumRepository _ortam_OlcumRepository { get; }
        private IPersonel_BilgiRepository _personel_BilgiRepository { get; }
        private IPersonel_AyrintiRepository _personel_AyrintiRepository { get; }
        private IRadyasyonRepository _radyasyonRepository { get; }
        private IRamak_KalaRepository _ramak_KalaRepository { get; }
        private IRamak_Kala_DosyaRepository _ramak_Kala_DosyaRepository { get; }
        private IRisk_AnalizRepository _risk_AnalizRepository { get; }
        private IRisk_Analiz_RiskRepository _risk_Analiz_RiskRepository { get; }
        private IRisk_Analiz_TabloRepository _risk_Analiz_TabloRepository { get; }
        private IRisk_Analiz_TehlikeRepository _risk_Analiz_TehlikeRepository { get; }
        private IRisk_GerceklesenRepository _risk_GerceklesenRepository { get; }
        private IRisk_YontemRepository _risk_YontemRepository { get; }
        private IRisk_KategoriRepository _risk_KategoriRepository { get; }
        private IRisk_Ust_GrupRepository _risk_Ust_GrupRepository { get; }
        private IRisk_Konu_GrupRepository _risk_Konu_GrupRepository { get; }
        private IRisk_KonuRepository _risk_KonuRepository { get; }
        private IRisk_KutuphaneRepository _risk_KutuphaneRepository { get; }
        private ISgk_MeslekRepository _sgk_MeslekRepository { get; }
        private ITali_BirimRepository _tali_BirimRepository { get; }
        private ITehlike_TanimRepository _tehlike_TanimRepository { get; }
        private IYaralanan_Vucut_BolgesiRepository _yaralanan_Vucut_BolgesiRepository { get; }
        private IYaralanma_SekliRepository _yaralanma_SekliRepository { get; }
        private IYetkiRepository _yetkiRepository { get; }
        private IYetkili_GormediRepository _yetkili_GormediRepository { get; }

        public UnitOfWork(InformsISGContext context)
        {
            _context = context;
        }
        public IAcil_Durum_Ekip_PersonelRepository acil_Durum_Ekip_PersonelRepository => _acil_Durum_Ekip_PersonelRepository ?? new Acil_Durum_Ekip_PersonelRepository(_context);

        public IAcil_Durum_EkipleriRepository acil_Durum_EkipleriRepository => _acil_Durum_EkipleriRepository ?? new Acil_Durum_EkipleriRepository(_context);

        public IAcil_Eylem_PlaniRepository acil_Eylem_PlaniRepository => _acil_Eylem_PlaniRepository ?? new Acil_Eylem_PlaniRepository(_context);

        public IAcil_Durum_TatbikatRepository acil_Durum_TatbikatRepository => _acil_Durum_TatbikatRepository ?? new Acil_Durum_TatbikatRepository(_context);

        public IAlt_IsverenRepository alt_IsverenRepository => _alt_IsverenRepository ?? new Alt_IsverenRepository(_context);

        public IAsi_PersonelRepository asi_PersonelRepository => _asi_PersonelRepository ?? new Asi_PersonelRepository(_context);

        public IAsi_SureleriRepository asi_SureleriRepository => _asi_SureleriRepository ?? new Asi_SureleriRepository(_context);

        public IAsi_TurRepository asi_TurRepository => _asi_TurRepository ?? new Asi_TurRepository(_context);

        public IAyarlarRepository ayarlarRepository => _ayarlarRepository ?? new AyarlarRepository(_context);

        public IBeden_BolgeRepository beden_BolgeRepository => _beden_BolgeRepository ?? new Beden_BolgeRepository(_context);

        public IBirimRepository birimRepository => _birimRepository ?? new BirimRepository(_context);

        public IDof_DosyaRepository dof_DosyaRepository => _dof_DosyaRepository ?? new Dof_DosyaRepository(_context);

        public IDofRepository dofRepository => _dofRepository ?? new DofRepository(_context);

        public IEgitim_KonuRepository egitim_KonuRepository => _egitim_KonuRepository ?? new Egitim_KonuRepository(_context);

        public IEgitim_Konu_Alt_BaslikRepository egitim_Konu_Alt_BaslikRepository => _egitim_Konu_Alt_BaslikRepository ?? new Egitim_Konu_Alt_BaslikRepository(_context);

        public IEgitim_Personel_AtamaRepository egitim_Personel_AtamaRepository => _egitim_Personel_AtamaRepository ?? new Egitim_Personel_AtamaRepository(_context);

        public IEgitim_SinavRepository egitim_SinavRepository => _egitim_Sinav_Repository ?? new Egitim_SinavRepository(_context);

        public IEgitim_Sinav_NotRepository egitim_Sinav_NotRepository => _egitim_Sinav_NotRepository ?? new Egitim_Sinav_NotRepository(_context);

        public IEgitim_TanimlaRepository egitim_TanimlaRepository => _egitim_TanimlaRepository ?? new Egitim_TanimlaRepository(_context);

        public IEgitim_Veren_PersonelRepository egitim_Veren_PersonelRepository => _egitim_Veren_PersonelRepository ?? new Egitim_Veren_PersonelRepository(_context);

        public IEgitim_Tanim_KonuRepository egitim_Tanim_KonuRepository => _egitim_Tanim_KonuRepository ?? new Egitim_Tanim_KonuRepository(_context);

        public IHareketRepository hareketRepository => _hareketRepository ?? new HareketRepository(_context);

        public IIsg_KurulRepository isg_KurulRepository => _isg_KurulRepository ?? new Isg_KurulRepository(_context);

        public IIsg_Kurul_ElemanRepository isg_Kurul_ElemanRepository => _isg_Kurul_ElemanRepository ?? new Isg_Kurul_ElemanRepository(_context);

        public IIsg_Kurul_KararRepository isg_Kurul_KararRepository => _isg_Kurul_KararRepository ?? new Isg_Kurul_KararRepository(_context);

        public IIsg_Kurul_Karar_DosyaRepository isg_Kurul_Karar_DosyaRepository => _isg_Kurul_Karar_DosyaRepository ?? new Isg_Kurul_Karar_DosyaRepository(_context);

        public IIsg_Kurul_Karar_GundemRepository isg_Kurul_Karar_GundemRepository => _isg_Kurul_Karar_GundemRepository ?? new Isg_Kurul_Karar_GundemRepository(_context);

        public IIsg_Kurul_Karar2Repository isg_Kurul_Karar2Repository => _isg_Kurul_Karar2Repository ?? new Isg_Kurul_Karar2Repository(_context);

        public IIsverenRepository isverenRepository => _isverenRepository ?? new IsverenRepository(_context);

        public IKazaRepository kazaRepository => _kazaRepository ?? new KazaRepository(_context);

        public IKaza_AyrintiRepository kaza_AyrintiRepository => _kaza_AyrintiRepository ?? new Kaza_AyrintiRepository(_context);

        public IKaza_DosyaRepository kaza_DosyaRepository => _kaza_DosyaRepository ?? new Kaza_DosyaRepository(_context);

        public IKaza_Personel_DisiRepository kaza_Personel_DisiRepository => _kaza_Personel_DisiRepository ?? new Kaza_Personel_DisiRepository(_context);

        public IKaza_Personel_Disi_DosyaRepository kaza_Personel_Disi_DosyaRepository => _kaza_Personel_Disi_DosyaRepository ?? new Kaza_Personel_Disi_DosyaRepository(_context);

        public IKkdRepository kkdRepository => _kkdRepository ?? new KkdRepository(_context);

 
        public IKkd_DosyaRepository kkd_DosyaRepository => _kkd_DosyaRepository ?? new Kkd_DosyaRepository(_context);

        public IKkd_TurRepository kkd_TurRepository => _kkd_TurRepository ?? new Kkd_TurRepository(_context);

        public IKkd_Tur_AltRepository kkd_Tur_AltRepository => _kkd_Tur_AltRepository ?? new Kkd_Tur_AltRepository(_context);

        public IKullanici_Repository kullanici_Repository => _kullanici_Repository ?? new KullaniciRepository(_context);

        public IMakine_EkipmanRepository makine_EkipmanRepository => _makine_EkipmanRepository ?? new Makine_EkipmanRepository(_context);

        public IMakine_Ekipman_Bakim_PlanlariRepository makine_Ekipman_Bakim_PlanlariRepository => _makine_Ekipman_Bakim_PlanlariRepository ?? new Makine_Ekipman_Bakim_PlanlariRepository(_context);

        public IMakine_Ekipman_Bakim_FotografRepository makine_Ekipman_Bakim_FotografRepository => _makine_Ekipman_Bakim_FotografRepository ?? new Makine_Ekipman_Bakim_FotografRepository(_context);  
        
        public IMakine_Ekipman_KontrolRepository makine_Ekipman_KontrolRepository => _makine_Ekipman_KontrolRepository ?? new Makine_Ekipman_KontrolRepository(_context);        

        public IMakineRepository makineRepository => _makineRepository ?? new MakineRepository(_context);   
        
        public IMakine_Kontrol_Kriter_BaslikRepository makine_Kontrol_Kriter_BaslikRepository => _makine_Kontrol_Kriter_BaslikRepository ?? new Makine_Kontrol_Kriter_BaslikRepository(_context);        
        public IMakine_Kontrol_KriterRepository makine_Kontrol_KriterRepository => _makine_Kontrol_KriterRepository ?? new Makine_Kontrol_KriterRepository(_context);        
        public IMakineVeEkipman_KontrolKriterRepository makineVeEkipman_Kontrol_KriterRepository => _makineVeEkipman_KontrolKriterRepository ?? new MakineVeEkipman_KontrolKriterRepository(_context);

        public IMakine_Bilgi_BaslikRepository makine_Bilgi_BaslikRepository => _makine_Bilgi_BaslikRepository ?? new Makine_Bilgi_BaslikRepository(_context);   
        
        public IMakine_BilgilerRepository makine_BilgilerRepository => _makine_BilgilerRepository ?? new Makine_BilgilerRepository(_context);       
        
        public IMakine_Olcum_Aleti_BilgilerRepository makine_Olcum_Aleti_BilgilerRepository => _makine_Olcum_Aleti_BilgilerRepository ?? new Makine_Olcum_Aleti_BilgilerRepository(_context);        
        public IMakine_Test_DegerleriRepository makine_Test_DegerleriRepository => _makine_Test_DegerleriRepository ?? new Makine_Test_DegerleriRepository(_context); 
        
        public IMakine_Ekipman_Kontrol_Kriter_BaslikRepository makine_Ekipman_Kontrol_Kriter_BaslikRepository => _makine_Ekipman_Kontrol_Kriter_BaslikRepository ?? new Makine_Ekipman_Kontrol_Kriter_BaslikRepository(_context);  
        
        public IMakine_Ekipman_Kontrol_KriterRepository makine_Ekipman_Kontrol_KriterRepository => _makine_Ekipman_Kontrol_KriterRepository ?? new Makine_Ekipman_Kontrol_KriterRepository(_context);   
        
        public IMakine_Ekipman_Bilgi_BaslikRepository makine_Ekipman_Bilgi_BaslikRepository => _makine_Ekipman_Bilgi_BaslikRepository ?? new Makine_Ekipman_Bilgi_BaslikRepository(_context);  
        
        public IMakine_Ekipman_BilgileriRepository makine_Ekipman_BilgileriRepository => _makine_Ekipman_BilgileriRepository ?? new Makine_Ekipman_BilgilerRepository(_context);     
        
        public IMakine_Ekipman_Olcum_Aleti_BilgilerRepository makine_Ekipman_Olcum_Aleti_BilgilerRepository => _makine_Ekipman_Olcum_Aleti_BilgilerRepository ?? new Makine_Ekipman_Olcum_Aleti_BilgilerRepository(_context);  
        
        public IMakine_Ekipman_Test_DegerleriRepository makine_Ekipman_Test_DegerleriRepository => _makine_Ekipman_Test_DegerleriRepository ?? new Makine_Ekipman_Test_DegerleriRepository(_context);   
        public IMsdsRepository msdsRepository => _msdsRepository ?? new MsdsRepository(_context);

        public IMsds_DosyaRepository msds_DosyaRepository => _msds_DosyaRepository ?? new Msds_DosyaRepository(_context);

        public IMuayeneRepository muayeneRepository => _muayeneRepository ?? new MuayeneRepository(_context);

        public IOrtam_OlcumRepository ortam_OlcumRepository => _ortam_OlcumRepository ?? new Ortam_OlcumRepository(_context);

        public IPersonel_BilgiRepository personel_BilgiRepository => _personel_BilgiRepository ?? new Personel_BilgiRepository(_context);

        public IPersonel_AyrintiRepository personel_AyrintiRepository => _personel_AyrintiRepository ?? new Personel_AyrintiRepository(_context);

        public IRadyasyonRepository radyasyonRepository => _radyasyonRepository ?? new RadyasyonRepository(_context);

        public IRamak_KalaRepository ramak_KalaRepository => _ramak_KalaRepository ?? new Ramak_KalaRepository(_context);
        
        public IRamak_Kala_DosyaRepository ramak_Kala_DosyaRepository => _ramak_Kala_DosyaRepository ?? new Ramak_Kala_DosyaRepository(_context);

        public IRisk_AnalizRepository risk_AnalizRepository => _risk_AnalizRepository ?? new Risk_AnalizRepository(_context);

        public IRisk_Analiz_RiskRepository risk_Analiz_RiskRepository => _risk_Analiz_RiskRepository ?? new Risk_Analiz_RiskRepository(_context);

        public IRisk_Analiz_TabloRepository risk_Analiz_TabloRepository => _risk_Analiz_TabloRepository ?? new Risk_Analiz_TabloRepository(_context);

        public IRisk_Analiz_TehlikeRepository risk_Analiz_TehlikeRepository => _risk_Analiz_TehlikeRepository ?? new Risk_Analiz_TehlikeRepository(_context);

        public IRisk_GerceklesenRepository risk_GerceklesenRepository => _risk_GerceklesenRepository ?? new Risk_GerceklesenRepository(_context);

        public IRisk_YontemRepository risk_YontemRepository => _risk_YontemRepository ?? new Risk_YontemRepository(_context);

        public IRisk_KategoriRepository risk_KategoriRepository => _risk_KategoriRepository ?? new Risk_KategoriRepository(_context);
        public IRisk_Ust_GrupRepository risk_Ust_GrupRepository => _risk_Ust_GrupRepository ?? new Risk_Ust_GrupRepository(_context);
        public IRisk_Konu_GrupRepository risk_Konu_GrupRepository => _risk_Konu_GrupRepository ?? new Risk_Konu_GrupRepository(_context);
        public IRisk_KonuRepository risk_KonuRepository => _risk_KonuRepository ?? new Risk_KonuRepository(_context); 
        
        public IRisk_KutuphaneRepository risk_KutuphaneRepository => _risk_KutuphaneRepository ?? new Risk_KutuphaneRepository(_context);

        public ISgk_MeslekRepository sgk_MeslekRepository => _sgk_MeslekRepository ?? new Sgk_MeslekRepository(_context);

        public ITali_BirimRepository tali_BirimRepository => _tali_BirimRepository ?? new Tali_BirimRepository(_context);

        public ITehlike_TanimRepository tehlike_TanimRepository => _tehlike_TanimRepository ?? new Tehlike_TanimRepository(_context);

        public IYaralanan_Vucut_BolgesiRepository yaralanan_Vucut_BolgesiRepository => _yaralanan_Vucut_BolgesiRepository ?? new Yaralanan_Vucut_BolgesiRepository(_context);

        public IYaralanma_SekliRepository yaralanma_SekliRepository => _yaralanma_SekliRepository ?? new Yaralanma_SekliRepository(_context);

        public IYetkiRepository yetkiRepository => _yetkiRepository ?? new YetkiRepository(_context);

        public IYetkili_GormediRepository yetkili_GormediRepository => _yetkili_GormediRepository ?? new Yetkili_GormediRepository(_context); 

        public IKkd_Personel_AtamaRepository kkd_Personel_AtamaRepository => _kkd_Personel_AtamaRepository ?? new Kkd_Personel_AtamaRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

    }
}
