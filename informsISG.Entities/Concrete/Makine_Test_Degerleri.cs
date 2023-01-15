using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Test_Degerleri : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }

        //FK
        [ForeignKey("Makine")]
        public long Makine_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine Makine { get; set; }

    }
}
