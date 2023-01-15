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
    public class Isg_KurulRepository : EntityRepositoryBase<Isg_Kurul> , IIsg_KurulRepository
    {
        public Isg_KurulRepository(DbContext context) : base(context)
        {

        }
    }
}
