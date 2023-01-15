using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kaza_Personel_Disi : EntityBase, IEntity
    {
        //Tablo alanları
        public string Kaza_No { get; set; }
        public int Kaza_Kategori { get; set; }
        public DateTime Kaza_Tarih { get; set; }
        public string Kaza_Saat { get; set; }
        public string Personel_Disi_Tc_No { get; set; }
        public string Personel_Disi_Ad_Soyad { get; set; }
        public string Kaza_Yer { get; set; }
        public string Kaza_Olus_Sekil { get; set; }
        public string Kaza_Faktor { get; set; }
        public string Sonuc { get; set; }
        public string Kok_Neden { get; set; }
        public int Yapilan_Islem { get; set; }
        public string Dof1 { get; set; }
        public string Sorumlu1 { get; set; }
        public DateTime Acilis_Tarih1 { get; set; }
        public string Dof2 { get; set; }
        public string Sorumlu2 { get; set; }
        public DateTime Acilis_Tarih2 { get; set; }
        public string Dof3 { get; set; }
        public string Sorumlu3 { get; set; }
        public DateTime Acilis_Tarih3 { get; set; }

        //FK
        public long Yaralanma_Sekli_Id { get; set; }
        public long Risk_Analiz_Risk_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }
        public long Yaralanan_Vucut_Bolgesi_Id { get; set; }

        //FK Bağlantıları
        public virtual Yaralanma_Sekli Yaralanma_Sekli { get; set; }
        public virtual Risk_Analiz_Risk Risk_Analiz_Risk { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }
        public virtual Yaralanan_Vucut_Bolgesi Yaralanan_Vucut_Bolgesi { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Kaza_Personel_Disi_Dosya> Kaza_Personel_Disi_Dosya { get; set; }
    }
}
