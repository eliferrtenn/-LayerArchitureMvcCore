using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Asi_Sureleri : EntityBase, IEntity
    {
        //Tablo alanları
        public int Yas { get; set; }
        public string Periyot_Birim { get; set; }
        public int Surekli { get; set; }
        public int Periyot1_1 { get; set;}
        public int Periyot1_2 { get; set; }
        public int Periyot2_1 { get; set; }
        public int Periyot2_2{ get; set; }
        public int Periyot3_1 { get; set; }
        public int Periyot3_2 { get; set; }
        public int Periyot4_1 { get; set; }
        public int Periyot4_2 { get; set; }
        public int Periyot5_1 { get; set; }
        public int Periyot5_2 { get; set; }

        //FK 
        public long Asi_Tur_Id { get; set; }

        //FK BAĞLANTILARI
        public virtual Asi_Tur Asi_Tur { get; set; }

        
    }
}
