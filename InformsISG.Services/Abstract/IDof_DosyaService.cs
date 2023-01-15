using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IDof_DosyaService
    {
        Task<IResult> AddAsync(Dof_DosyaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Dof_DosyaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Dof_DosyaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Dof_DosyaDTO>>> GetAllAsync();
    }
}
