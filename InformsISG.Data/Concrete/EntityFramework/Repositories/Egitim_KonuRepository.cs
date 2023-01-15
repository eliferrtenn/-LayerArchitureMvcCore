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
    public class Egitim_KonuRepository : EntityRepositoryBase<Egitim_Konu> , IEgitim_KonuRepository
    {
        public Egitim_KonuRepository(DbContext context) : base(context)
        {

        }
    }
}
