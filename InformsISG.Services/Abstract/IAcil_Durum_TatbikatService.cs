using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAcil_Durum_TatbikatService
    {
        Task<IResult> AddAsync(Acil_Durum_TatbikatDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Acil_Durum_TatbikatDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Acil_Durum_TatbikatDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Acil_Durum_TatbikatDTO>>> GetAllAsync();
    }
}
