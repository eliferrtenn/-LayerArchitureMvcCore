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
    public class Makine_BilgilerRepository : EntityRepositoryBase<Makine_Bilgiler>, IMakine_BilgilerRepository
    {
        public Makine_BilgilerRepository(DbContext context) : base(context)
        {

        }
    }
}
