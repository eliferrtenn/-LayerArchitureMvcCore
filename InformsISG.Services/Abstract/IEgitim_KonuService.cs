using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_KonuService
    {
        Task<IResult> AddAsync(Egitim_KonuDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_KonuDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_KonuDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_KonuDTO>>> GetAllAsync();
    }
}
