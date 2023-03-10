using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface ISgk_MeslekService
    {
        Task<IResult> AddAsync(Sgk_MeslekDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Sgk_MeslekDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Sgk_MeslekDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Sgk_MeslekDTO>>> GetAllAsync();
    }
}
