using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_Analiz_RiskService
    {
        Task<IResult> AddAsync(Risk_Analiz_RiskDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_Analiz_RiskDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_Analiz_RiskDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_Analiz_RiskDTO>>> GetAllAsync();
    }
}
