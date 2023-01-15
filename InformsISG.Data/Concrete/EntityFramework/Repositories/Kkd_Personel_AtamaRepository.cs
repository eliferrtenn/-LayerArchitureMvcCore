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
    public class Kkd_Personel_AtamaRepository : EntityRepositoryBase<Kkd_Personel_Atama>, IKkd_Personel_AtamaRepository
    {
        public Kkd_Personel_AtamaRepository(DbContext context) : base(context)
        {

        }
    }
}
