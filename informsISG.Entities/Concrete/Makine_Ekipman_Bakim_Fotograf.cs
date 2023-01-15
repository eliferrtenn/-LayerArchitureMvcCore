using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Bakim_Fotograf : EntityBase,IEntity
    {

        public string Dosya { get; set; }

        //FK
        public long Makine_Ekipman_Bakim_Planlari_Id { get; set; }


        //FK Bağlantıları
        [ForeignKey("Makine_Ekipman_Bakim_Planlari_Id ")]
        public virtual Makine_Ekipman_Bakim_Planlari Makine_Ekipman_Bakim_Planlari { get; set; }

    }
}
