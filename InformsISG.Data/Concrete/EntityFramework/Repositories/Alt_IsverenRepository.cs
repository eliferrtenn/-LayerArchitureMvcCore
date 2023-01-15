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
    public class Alt_IsverenRepository : EntityRepositoryBase<Alt_Isveren> ,IAlt_IsverenRepository
    {
        public Alt_IsverenRepository(DbContext context) : base(context)
        {

        }
    }
}
