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
    public class Sgk_MeslekRepository : EntityRepositoryBase<Sgk_Meslek> , ISgk_MeslekRepository
    {
        public Sgk_MeslekRepository(DbContext context) : base(context)
        {

        }
    }
}
