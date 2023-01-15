using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_KutuphaneService
    {
        Task<IResult> AddAsync(Risk_KutuphaneDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_KutuphaneDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_KutuphaneDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_KutuphaneDTO>>> GetAllAsync();
        Task<IDataResult<IList<Risk_KutuphaneDTO>>> GetAllRiskAsync(long Id);
    }
}
