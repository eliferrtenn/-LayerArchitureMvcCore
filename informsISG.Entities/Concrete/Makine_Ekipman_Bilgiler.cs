using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Bilgiler : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }
        public string Madde_Ad_Karsilik { get; set; }

        //FK
        [ForeignKey("Makine_Ekipman_Bilgi_Baslik")]
        public long Makine_Ekipman_Bilgi_Baslik_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman_Bilgi_Baslik Makine_Ekipman_Bilgi_Baslik { get; set; }
    }

}
