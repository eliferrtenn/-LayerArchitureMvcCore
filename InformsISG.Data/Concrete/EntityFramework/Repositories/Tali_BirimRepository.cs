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
    public class Tali_BirimRepository : EntityRepositoryBase<Tali_Birim> , ITali_BirimRepository
    {
        public Tali_BirimRepository(DbContext context) : base(context)
        {

        }
    }
}
