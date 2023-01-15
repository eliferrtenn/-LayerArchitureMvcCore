using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Bilgi_BaslikService
    {
        Task<IResult> AddAsync(Makine_Bilgi_BaslikDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Bilgi_BaslikDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Bilgi_BaslikDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Bilgi_BaslikDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Bilgi_BaslikDTO>>> GetAllMakineAsync(long Id);
    }
}
