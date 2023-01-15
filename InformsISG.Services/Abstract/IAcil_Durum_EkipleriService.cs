using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAcil_Durum_EkipleriService
    {
        Task<IResult> AddAsync(Acil_Durum_EkipleriDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Acil_Durum_EkipleriDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Acil_Durum_EkipleriDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Acil_Durum_EkipleriDTO>>> GetAllAsync();
    }
}
