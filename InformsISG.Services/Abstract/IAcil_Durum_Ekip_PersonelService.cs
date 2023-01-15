using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAcil_Durum_Ekip_PersonelService
    {
        Task<IResult> AddAsync(Acil_Durum_Ekip_PersonelDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Acil_Durum_Ekip_PersonelDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Acil_Durum_Ekip_PersonelDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetAllAsync(long Id);
        Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetBirimAsync(long Id);
        Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetEkip(long Id);
    }
}
