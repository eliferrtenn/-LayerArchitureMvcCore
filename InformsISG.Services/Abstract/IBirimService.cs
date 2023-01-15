using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IBirimService
    {
        Task<IResult> AddAsync(BirimDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(BirimDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<BirimDTO>> GetAsync(long Id);
        Task<IDataResult<IList<BirimDTO>>> GetAllAsync();
    }
}
