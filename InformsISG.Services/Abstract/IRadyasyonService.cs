using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRadyasyonService
    {
        Task<IResult> AddAsync(RadyasyonDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(RadyasyonDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<RadyasyonDTO>> GetAsync(long Id);
        Task<IDataResult<IList<RadyasyonDTO>>> GetAllAsync();
    }
}
