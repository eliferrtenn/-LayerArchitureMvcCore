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
    public class Asi_TurRepository : EntityRepositoryBase<Asi_Tur> , IAsi_TurRepository
    {
        public Asi_TurRepository(DbContext context) : base(context){

        }
    }
}
