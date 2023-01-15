
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Radyasyon : EntityBase, IEntity
    {
        //Tablo alanları
        public DateTime Radyasyon_Tarih { get; set; }
        public bool Temas_Sekli1 { get; set; }
        public bool Temas_Sekli2 { get; set; }
        public string Temas_Sekli_Diger { get; set; }
        public bool Limit_Asim { get; set; }
        public string Limit_Asim_Aciklama { get; set; }
        public bool Radyasyon_Kaza { get; set; }
        public string Radyasyon_Kaza_Aciklama { get; set; }
        public bool Radyasyon_Maruz { get; set; }
        public string Radyasyon_Maruz_Aciklama { get; set; }
        public bool Ciltte_Solukluk { get; set; }
        public string Ciltte_Solukluk_Aciklama { get; set; }
        public bool Genel_Yorgunluk { get; set; }
        public string Genel_Yorgunluk_Aciklama { get; set; }
        public bool Bas_Donmesi { get; set; }
        public string Bas_Donmesi_Aciklama { get; set; }
        public bool Atesli_Hastalik { get; set; }
        public string Atesli_Hastalik_Aciklama { get; set; }
        public bool Uzun_Sure_Enfeksiyon { get; set; }
        public string Uzun_Sure_Enfeksiyon_Aciklama { get; set; }
        public bool Uzun_Suren_Kanama { get; set; }
        public string Uzun_Suren_Kanama_Aciklama { get; set; }
        public bool Dis_Eti_Kanama { get; set; }
        public string Dis_Eti_Kanama_Aciklama { get; set; }
        public bool Ciltte_Morluklar { get; set; }
        public string Ciltte_Morluklar_Aciklama { get; set; }
        public bool Kil_Donmesi { get; set; }
        public string Kil_Donmesi_Aciklama  { get; set; }
        public bool Ciltte_Bozukluk { get; set; }
        public string Ciltte_Bozukluk_Aciklama { get; set; }
        public bool Gorme_Bulaniklik { get; set; }

        [DisplayName("GÖRMEDE BULANIKLIK AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Gorme_Bulaniklik_Aciklama { get; set; }

        [DisplayName("LENF BÜYÜMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Lenf_Buyume { get; set; }
        public string Lenf_Buyume_Aciklama { get; set; }
        public bool Telenjiektazi { get; set; }
        public string Telenjiektazi_Aciklama { get; set; }
        public bool Hiperkeratoz { get; set; }
        public string Hiperkeratoz_Aciklama { get; set; }
        public bool Atrofi { get; set; }
        public string Atrofi_Aciklama { get; set; }
        public bool Kil_Dokulmesi2 { get; set; }
        public string Kil_Dokulmesi2_Aciklama { get; set; }
        public bool Tirnak_Bozukluk { get; set; }
        public string Tirnak_Bozukluk_Aciklama { get; set; }
        public bool Periferik_Lenfadenopatİ { get; set; }
        public string Periferik_Lenfadenopati_Aciklama { get; set; }
        public bool Hepatosplenomegali { get; set; }
        public string Hepatosplenomegali_Aciklama { get; set; }
        public string Beyaz_Kure { get; set; }
        public string Trombosit { get; set; }
        public string Hemoglobin { get; set; }
        public string Kirmizi_Kure { get; set; }
        public string Lenfosit { get; set; }
        public string Notrofil { get; set; }
        public string Monosit { get; set; }
        public string  Eozinofil{ get; set; }
        public string Bazofil { get; set; }
        public string Normal_Disi { get; set; }
        public bool Katarakt { get; set; }
        public string Goz_Uzman_Degerlendirme { get; set; }
        public string Aciklama { get; set; }
        public string Diger_Husus { get; set; }
        public string Ac_Grafisi { get; set; }
        public string Periferik_Yayma { get; set; }
        public string Hastalik_Oykusu { get; set; }
        public string Ek_Biyokimya { get; set; }
        public string Kullandigi_Ilaclar { get; set; }

        //FK
        public long Personel_Id { get; set; }
        public long Isveren_Id { get; set; }


        //FK Bağlantıları
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Isveren Isveren { get; set; }




    }
}
