using InformsISG.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Kontrol_Kriter : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }

        //FK
        [ForeignKey("Makine_Kontrol_Kriter_Baslik")]
        public long Makine_Kontrol_Kriter_Baslik_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Kontrol_Kriter_Baslik Makine_Kontrol_Kriter_Baslik { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<MakineVeEkipman_Kontrol> MakineVeEkipman_KontrolKriter { get; set; }
    }
}
