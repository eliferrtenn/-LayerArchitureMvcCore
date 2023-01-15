using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Kontrol_KriterService
    {
        Task<IResult> AddAsync(Makine_Kontrol_KriterDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Kontrol_KriterDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Kontrol_KriterDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Kontrol_KriterDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Kontrol_KriterDTO>>> GetAllMakineAsync(long Id);
    }
}
