using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_Ust_GrupService
    {
        Task<IResult> AddAsync(Risk_Ust_GrupDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_Ust_GrupDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_Ust_GrupDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_Ust_GrupDTO>>> GetKategoriListAsync(long Id);
        Task<IDataResult<IList<Risk_Ust_GrupDTO>>> GetAllAsync();
        Task<IDataResult<IList<Risk_Ust_GrupDTO>>> GetAllUstGrup(long id);

    }
}
