using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Risk_KutuphaneDTO
    {
        public long Id { get; set; } = 0;


        [DisplayName("Risk Analiz"),
            ForeignKey("Risk_Analiz")]
        public long Risk_Analiz_Id { get; set; }


        [DisplayName("Kategori"),
            ForeignKey("Risk_Kategori")]
        public long Risk_Kategori_Id { get; set; }


        [DisplayName("Üst Grup"),
            ForeignKey("Risk_Ust_Grup")]
        public long Risk_Ust_Grup_Id { get; set; }


        [DisplayName("Konu Grup Adı"),
            ForeignKey("Risk_Konu_Grup")]
        public long Risk_Konu_Grup_Id { get; set; }


        [DisplayName("Konu Adı"),
            ForeignKey("Risk_Konu")]
        public long Risk_Konu_Id { get; set; }

    }
}
