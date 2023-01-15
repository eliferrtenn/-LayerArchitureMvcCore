using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Ramak_Kala_Dosya : EntityBase, IEntity
    {
        public string Dosya { get; set; }

        //FK
        [ForeignKey("Ramak_Kala")]
        public long Ramak_Kala_Id { get; set; }


        //FK Bağlantıları
        public virtual Ramak_Kala Ramak_Kala { get; set; }
    }
}
