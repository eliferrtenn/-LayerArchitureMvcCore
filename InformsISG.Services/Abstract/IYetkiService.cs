using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IYetkiService
    {
        Task<IResult> AddAsync(YetkiDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(YetkiDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<YetkiDTO>> GetAsync(long Id);
        Task<IDataResult<IList<YetkiDTO>>> GetAllAsync();
        Task<IDataResult<IList<YetkiDTO>>> GetNonSuperAdmin();

    }
}
