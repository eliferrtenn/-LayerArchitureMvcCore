using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine : EntityBase, IEntity
    {
        public string Makine_Ad { get; set; }

        //FK Bağlantıları
        public virtual ICollection<Makine_Ekipman> Makine_Ekipman{ get; set; }
        public virtual ICollection<Makine_Kontrol_Kriter_Baslik> Makine_Kontrol_Kriter_Baslik { get; set; }
        public virtual ICollection<MakineVeEkipman_Kontrol> MakineVeEkipman_KontrolKriter { get; set; }
        public virtual ICollection<Makine_Bilgi_Baslik> Makine_Bilgi_Baslik { get; set; }
        public virtual ICollection<Makine_Olcum_Aleti_Bilgiler> Makine_Olcum_Aleti_Bilgiler { get; set; }
        public virtual ICollection<Makine_Test_Degerleri> Makine_Test_Degerleri { get; set; }

    }
}
