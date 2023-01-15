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
    public class Acil_Eylem_PlaniRepository : EntityRepositoryBase<Acil_Eylem_Plani> , IAcil_Eylem_PlaniRepository
    {
        public Acil_Eylem_PlaniRepository(DbContext context) : base(context)
        {

        }
    }
}
