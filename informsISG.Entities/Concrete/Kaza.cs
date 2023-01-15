using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kaza : EntityBase, IEntity
    {
        //Tablo alanları
        public string Kaza_No { get; set; }
        public DateTime Kaza_Tarih { get; set; }
        public string Kaza_Saat { get; set; }
        public DateTime Bildirim_Tarih { get; set; }
        public string Ise_Baslama_Saat { get; set; }
        public int Kaza_Hasar_Tipi { get; set; }
        public string Kaza_Anindaki_Faaliyet { get; set; }
        public string Kaza_Yer { get; set; }
        public string Yaralanmaya_Neden_Olan_Olay { get; set; }
        public string Yaralanmaya_Neden_Olan_Arac { get; set; }
        public bool Tibbi_Mudahele{ get; set; }
        public string Tibbi_Mudahele_Aciklama { get; set; }
        public bool Is_Gorememezlik { get; set; }
        public int Is_Gorememezlik_Gun_Sayi { get; set; }
        public string Kaza_Sonrasi_Calisan_Ne_Yapti { get; set; }
        public bool Mesleki_Egitim { get; set; }
        public bool Isg_Egitim { get; set; }
        public int Hasar_Buyuklugu { get; set; }
        public int Tekrarlanma_Olasiligi { get; set; }
        public int Gerceklesme_Frekansi { get; set; }
        public string Maruz_Kalan_Calisanin_Ifadesi { get; set; }
        public string Gorgu_Ifadesi { get; set; }
        public string Kaza_Yol_Acan_Sebepler { get; set; }
        public string Varolmasinda_Temel_Nedenler { get; set; }
        public string Birim_Sorumlu_Gorus_Oneri { get; set; }
        public string Isg_Uzmani_Degerlendirme { get; set; }
        public string Tanik_Tcno1 { get; set; }
        public string Tanik_Ad_Soyad1 { get; set; }
        public string Tanik_Eposta1 { get; set; }
        public string Tanik_Telefon1 { get; set; }
        public string Tanik_Adres1 { get; set; }
        public string Tanik_Tcno2 { get; set; }
        public string Tanik_Ad_Soyad2 { get; set; }
        public string Tanik_Eposta2 { get; set; }
        public string Tanik_Telefon2 { get; set; }
        public string Tanik_Adres2 { get; set; }
        public string Dof1 { get; set; }
        public string Sorumlu1 { get; set; }
        public DateTime Acilis_Tarih1 { get; set; }
        public DateTime Kapanis_Tarih1 { get; set; }
        public string Dof2 { get; set; }
        public string Sorumlu2 { get; set; }
        public DateTime Acilis_Tarih2 { get; set; }
        public DateTime Kapanis_Tarih2 { get; set; }
        public string Dof3 { get; set; }
        public string Sorumlu3 { get; set; }
        public DateTime Acilis_Tarih3 { get; set; }
        public DateTime Kapanis_Tarih3 { get; set; }

        //FK
        public long Personel_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Yaralanan_Vucut_Bolgesi_Id { get; set; }
        public long Yaralanma_Sekli_Id { get; set; }

        //FK Bağlantıları
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }
        public virtual Yaralanan_Vucut_Bolgesi Yaralanan_Vucut_Bolgesi { get; set; }
        public virtual Tali_Birim Tali_Birim{ get; set; }
        public virtual Yaralanma_Sekli Yaralanma_Sekli { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Kaza_Ayrinti> kaza_Ayrinti { get; set; }
        public virtual ICollection<Kaza_Dosya> Kaza_Dosya { get; set; }
    }
}
