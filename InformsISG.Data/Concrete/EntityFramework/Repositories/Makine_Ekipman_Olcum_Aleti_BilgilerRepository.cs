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
    public class Makine_Ekipman_Olcum_Aleti_BilgilerRepository : EntityRepositoryBase<Makine_Ekipman_Olcum_Aleti_Bilgiler>, IMakine_Ekipman_Olcum_Aleti_BilgilerRepository
    {
        public Makine_Ekipman_Olcum_Aleti_BilgilerRepository(DbContext context) : base(context)
        {

        }
    }
}

