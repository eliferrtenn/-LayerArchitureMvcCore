using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Kaza_AyrintiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Ekipmanı yetkisiz kullanmak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler1 { get; set; }

        [DisplayName("Uyarıda bulunmada başarısızlık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler2 { get; set; }

        [DisplayName("KKD kullanmamak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler3 { get; set; }

        [DisplayName("Tehlikeli bir şekilde iş ekipmanı kullanmak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler4 { get; set; }

        [DisplayName("Emniyet tertibatını çalışamaz hale getirmek"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler5 { get; set; }

        [DisplayName("Kullanma talimatlarına uymamak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler6 { get; set; }

        [DisplayName("Kusurlu (Arızalı) ekipman kullanımı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler7 { get; set; }

        [DisplayName("Ekipmanı amacı dışında kullanmak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler8 { get; set; }

        [DisplayName("Koruyucu teçhizatı düzgün bir kullanmamak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler9 { get; set; }

        [DisplayName("Hatalı yükleme-yerleştirme-kaldırma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler10 { get; set; }

        [DisplayName("Azami ağırlıktan fazla yük taşıma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler11 { get; set; }

        [DisplayName("Kesici ve delicilerin uygun olmayan atık kutulara atılması"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler12 { get; set; }

        [DisplayName("Görevi dışındaki işe müdahale"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler13 { get; set; }

        [DisplayName("Çalışır durumdaki ekipmana bakım ve müdahale"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler14 { get; set; }

        [DisplayName("Şakalaşma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler15 { get; set; }

        [DisplayName("Alkol ve/veya uyuşturucu etkisi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler16 { get; set; }

        [DisplayName("İğne ucu kapatmak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler17 { get; set; }

        [DisplayName("Diğer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hareketler18 { get; set; }

        [DisplayName("Fiziki yetersizlik (çok küçük, çok büyük vs.)"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler1 { get; set; }

        [DisplayName("Yorgunluk / Uykusuzluk"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler2 { get; set; }

        [DisplayName("Duygular (Hüsran, kızgınlık, öfke)"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler3 { get; set; }

        [DisplayName("Deneyim eksikliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler4 { get; set; }

        [DisplayName("Yetersiz oryantasyon / eğitim"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler5 { get; set; }

        [DisplayName("Yetersiz bilgi tazeleme eğitimi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler6 { get; set; }

        [DisplayName("Yanlış anlaşılmış talimatlar"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler7 { get; set; }

        [DisplayName("Yetersiz tatbiki eğitim"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler8 { get; set; }

        [DisplayName("Yetersiz yönlendirme / talimat"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler9 { get; set; }

        [DisplayName("Dalgınlık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler10 { get; set; }

        [DisplayName("Acelecilik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler11 { get; set; }

        [DisplayName("Unutkanlık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler12 { get; set; }

        [DisplayName("Motivasyon eksikliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler13 { get; set; }

        [DisplayName("Dikkatsizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler14 { get; set; }

        [DisplayName("İhmalkarlık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler15 { get; set; }

        [DisplayName("Kayıtsızlık / Ciddiyetsizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler16 { get; set; }

        [DisplayName("Tükenmişlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler17 { get; set; }

        [DisplayName("Diğer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kisisel_Faktorler18 { get; set; }

        [DisplayName("Yetersiz koruma veya bariyer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari1 { get; set; }

        [DisplayName("Yetersiz veya yanlış koruyucu ekipman"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari2 { get; set; }

        [DisplayName("Kusurlu araç, ekipman veya malzeme"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari3 { get; set; }

        [DisplayName("Kaygan / Pürüzlü zemin"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari4 { get; set; }

        [DisplayName("Elektrik Tehlikesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari5 { get; set; }

        [DisplayName("Yangın ve patlama tehlikesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari6 { get; set; }

        [DisplayName("Fiziksel ve Sözel şiddete maruziyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari7 { get; set; }

        [DisplayName("Yüksekte çalışma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari8 { get; set; }

        [DisplayName("Yüksek sese maruz kalma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari9 { get; set; }

        [DisplayName("Radyasyona maruz kalma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari10 { get; set; }

        [DisplayName("Yüksek veya düşük ısıya maruz kalma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari11 { get; set; }

        [DisplayName("Termal konfor uygunsuzluğu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari12 { get; set; }

        [DisplayName("Biyolojik etkene maruziyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari13 { get; set; }

        [DisplayName("Kimyasal etkene maruziyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari14 { get; set; }

        [DisplayName("Hatalı depolama/ düzenleme/ istifleme"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari15 { get; set; }

        [DisplayName("Zeminde engel veya çukur"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari16 { get; set; }

        [DisplayName("Alçak tavan"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari17 { get; set; }

        [DisplayName("Sert ve sivri köşeler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari18 { get; set; }

        [DisplayName("Diğer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Calisma_Kosullari19 { get; set; }

        [DisplayName("Yönetsel iş bilgisinin yetersizliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri1 { get; set; }

        [DisplayName("Yetersiz yönetsel talimat"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri2 { get; set; }

        [DisplayName("Yolların/binaların vs. dizaynlarında yetersizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri3 { get; set; }

        [DisplayName("Sistemle ilgili değişikliklerin değerlendirilmesinde yetersizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri4 { get; set; }

        [DisplayName("Nakliye/ulaşımdaki yetersizlikler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri5 { get; set; }

        [DisplayName("Tehlikeli maddelerin saptanmasındaki yetersizlikler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri6 { get; set; }

        [DisplayName("Atıkların yanlış bir biçimde ortadan kaldırılması"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri7 { get; set; }

        [DisplayName("Yetersiz bakım ve tamir"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri8 { get; set; }

        [DisplayName("Birimlerin denetiminde yetersizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri9 { get; set; }

        [DisplayName("Fiziki alanda yetersizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri10 { get; set; }

        [DisplayName("Yetersiz alet ve ekipman/imalat hatalı sarf malzeme"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri11 { get; set; }

        [DisplayName("Prosedür ve uygulamaların geliştirilmesinde yetersizlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri12 { get; set; }

        [DisplayName("İletişim standartlarındaki yetersizlikler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri13 { get; set; }

        [DisplayName("Peryodik bakım ve kontrol eksikliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri14 { get; set; }

        [DisplayName("Aşırı aşınma ve eskime"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri15 { get; set; }

        [DisplayName("Suistimal veya yanlış kullanım"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri16 { get; set; }

        [DisplayName("Tertip ve düzen eksikliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri17 { get; set; }

        [DisplayName("Uyarıcı levha eksikliği"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri18 { get; set; }

        [DisplayName("Diğer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Faktorleri19 { get; set; }

        [DisplayName("Düşme"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu1 { get; set; }

        [DisplayName("Parça Düşmesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu2 { get; set; }

        [DisplayName("Sıkışma, Ezilme"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu3 { get; set; }

        [DisplayName("Kesici delici alet yaralanması"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu4 { get; set; }

        [DisplayName("Göze Madde Kaçması"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu5 { get; set; }

        [DisplayName("Yanma, yanık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu6 { get; set; }

        [DisplayName("Elektrik çarpması"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu7 { get; set; }

        [DisplayName("Çarpma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu8 { get; set; }

        [DisplayName("Sözlü Şiddet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu9 { get; set; }

        [DisplayName("Fiziksel Şiddet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu10 { get; set; }

        [DisplayName("Zehirlenme/ Kimyasal maruziyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu11 { get; set; }

        [DisplayName("Diğer"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kaza_Turu12 { get; set; }

        [DisplayName("Kafa"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar1 { get; set; }

        [DisplayName("Göz"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar2 { get; set; }

        [DisplayName("Kulak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar3 { get; set; }

        [DisplayName("Yüz"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar4 { get; set; }

        [DisplayName("El Parmağı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar5 { get; set; }

        [DisplayName("El"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar6 { get; set; }

        [DisplayName("Kol"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar7 { get; set; }

        [DisplayName("Gövde"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar8 { get; set; }

        [DisplayName("İç Organ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar9 { get; set; }

        [DisplayName("Bacak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar10 { get; set; }

        [DisplayName("Ayak"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar11 { get; set; }

        [DisplayName("Ayak Parmağı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yaralanan_Uzuvlar12 { get; set; }

        [DisplayName("KAZA BİRİMİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Kaza")]
        public long Kaza_Id { get; set; }

    }
}
