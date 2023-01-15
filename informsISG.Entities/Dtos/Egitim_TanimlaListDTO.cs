using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Egitim_TanimlaListDTO
    {
        public DataResult<IList<Egitim_Tanimla>> Egitim_TanimlaList { get; set; }

    }
}
