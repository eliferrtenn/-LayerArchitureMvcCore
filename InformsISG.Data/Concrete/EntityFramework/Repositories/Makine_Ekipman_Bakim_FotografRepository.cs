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
    public class Makine_Ekipman_Bakim_FotografRepository : EntityRepositoryBase<Makine_Ekipman_Bakim_Fotograf>, IMakine_Ekipman_Bakim_FotografRepository
    {
        public Makine_Ekipman_Bakim_FotografRepository(DbContext context) : base(context)
        {

        }
    }
}
