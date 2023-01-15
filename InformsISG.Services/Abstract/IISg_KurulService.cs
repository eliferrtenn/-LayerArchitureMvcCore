using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IISg_KurulService
    {
        Task<IResult> AddAsync(Isg_KurulDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Isg_KurulDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Isg_KurulDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Isg_KurulDTO>>> GetAllAsync();
    }
}
