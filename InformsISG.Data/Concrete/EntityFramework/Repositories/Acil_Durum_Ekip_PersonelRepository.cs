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
    public class Acil_Durum_Ekip_PersonelRepository : EntityRepositoryBase<Acil_Durum_Ekip_Personel>,IAcil_Durum_Ekip_PersonelRepository  {
        public Acil_Durum_Ekip_PersonelRepository(DbContext context) : base(context) {} }
}
