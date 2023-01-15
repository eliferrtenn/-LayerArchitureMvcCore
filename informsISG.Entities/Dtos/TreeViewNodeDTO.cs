using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class TreeViewNodeDTO
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
    }
}
