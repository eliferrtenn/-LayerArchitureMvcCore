using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_Sinav_NotService
    {
        Task<IResult> AddAsync(Egitim_Sinav_NotDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_Sinav_NotDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_Sinav_NotDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_Sinav_NotDTO>>> GetAllAsync();
        Task<IDataResult<IList<Egitim_Sinav_NotDTO>>> GetSinav(long Id);
    }
}
