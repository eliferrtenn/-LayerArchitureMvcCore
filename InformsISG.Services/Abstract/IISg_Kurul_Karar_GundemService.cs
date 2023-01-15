using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IISg_Kurul_Karar_GundemService
    {
        Task<IResult> AddAsync(Isg_Kurul_Karar_GundemDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Isg_Kurul_Karar_GundemDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Isg_Kurul_Karar_GundemDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Isg_Kurul_Karar_GundemDTO>>> GetAllAsync();
    }
}
