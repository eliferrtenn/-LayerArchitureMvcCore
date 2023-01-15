using InformsISG.Core.Data.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InformsISG.Data.Concrete.EntityFramework.Repositories
{
    public class Kkd_Tur_AltRepository : EntityRepositoryBase<Kkd_Tur_Alt> ,IKkd_Tur_AltRepository
    {
        public Kkd_Tur_AltRepository(DbContext context) : base(context)
        {

        }
    }
}
