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
    public class Tehlike_TanimRepository :EntityRepositoryBase<Tehlike_Tanim> , ITehlike_TanimRepository
    {
        public Tehlike_TanimRepository(DbContext context) : base(context)
        {

        }
    }
}
