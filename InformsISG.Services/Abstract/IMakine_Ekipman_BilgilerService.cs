using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Ekipman_BilgilerService
    {
        Task<IResult> AddAsync(Makine_Ekipman_BilgilerDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Ekipman_BilgilerDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Ekipman_BilgilerDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Ekipman_BilgilerDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Ekipman_BilgilerDTO>>> GetAllMakineEkipmanAsync(long Id);
    }
}

