using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface ITali_BirimService
    {
        Task<IResult> AddAsync(Tali_BirimDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Tali_BirimDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Tali_BirimDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Tali_BirimDTO>>> GetAllAsync(long Id);
        Task<IDataResult<IList<Tali_BirimDTO>>> GetAllAsyncTum();

        Task<IDataResult<IList<Tali_BirimDTO>>> GetAllTaliBirim(int Id);

    }
}
