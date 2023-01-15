using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_Analiz_TabloService
    {
        Task<IResult> AddAsync(Risk_Analiz_TabloDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_Analiz_TabloDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_Analiz_TabloDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_Analiz_TabloDTO>>> GetAllAsync();
        Task<IDataResult<IList<Risk_Analiz_TabloDTO>>> GetYuksekRisk();

        Task<IDataResult<Risk_Analiz_TabloDTO>> AddAndGetAsync(Risk_Analiz_TabloDTO addObject, long createdByUserId);

    }
}
