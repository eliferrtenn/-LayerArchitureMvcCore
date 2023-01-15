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
    public class Kkd_TurRepository : EntityRepositoryBase<Kkd_Tur> , IKkd_TurRepository
    {
        public Kkd_TurRepository(DbContext context) : base(context)
        {

        }
    }
}
