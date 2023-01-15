using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_KonuGrupService
    {
        Task<IResult> AddAsync(Risk_Konu_GrupDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_Konu_GrupDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_Konu_GrupDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_Konu_GrupDTO>>> GetAllAsync();
        Task<IDataResult<IList<Risk_Konu_GrupDTO>>> GetAllKonuGrupAsync(long id);
    }
}
