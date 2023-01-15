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
    public class Isg_Kurul_KararRepository : EntityRepositoryBase<Isg_Kurul_Karar> , IIsg_Kurul_KararRepository
    {

        public Isg_Kurul_KararRepository(DbContext context) : base(context)
        {

        }
    }
}
