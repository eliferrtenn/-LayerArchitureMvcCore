using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_AnalizService
    {
        Task<IResult> AddAsync(Risk_AnalizDTO addObject, long createdByUserId);
        Task<IDataResult<Risk_AnalizDTO>> AddAndGetAsync(Risk_AnalizDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_AnalizDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_AnalizDTO>> GetAsync(long Id);
        Task<IDataResult<Risk_AnalizDTO>> GetSelectAsync();
        Task<IDataResult<IList<Risk_AnalizDTO>>> GetAllAsync(long Id);
    }
}
