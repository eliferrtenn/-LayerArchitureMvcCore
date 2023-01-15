using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAcil_Eylem_PlaniService
    {
        Task<IResult> AddAsync(Acil_Eylem_PlaniDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Acil_Eylem_PlaniDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Acil_Eylem_PlaniDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Acil_Eylem_PlaniDTO>>> GetAllAsync(long Id);
    }
}
