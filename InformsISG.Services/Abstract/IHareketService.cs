using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IHareketService
    {
        Task<IResult> AddAsync(HareketDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(HareketDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<HareketDTO>> GetAsync(long Id);
        Task<IDataResult<IList<HareketDTO>>> GetAllAsync();
    }
}
