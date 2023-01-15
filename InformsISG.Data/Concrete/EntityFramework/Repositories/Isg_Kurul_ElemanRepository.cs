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
    public class Isg_Kurul_ElemanRepository : EntityRepositoryBase<Isg_Kurul_Eleman>,IIsg_Kurul_ElemanRepository
    {
        public Isg_Kurul_ElemanRepository(DbContext context) : base(context)
        {

        }
    }
}
