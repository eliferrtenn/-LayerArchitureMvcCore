using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IISg_Kurul_ElemanService
    {
        Task<IResult> AddAsync(Isg_Kurul_ElemanDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Isg_Kurul_ElemanDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Isg_Kurul_ElemanDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Isg_Kurul_ElemanDTO>>> GetAllAsync();
        Task<IDataResult<IList<Isg_Kurul_ElemanDTO>>> GetKurulKararAsync(long Id);
    }
}
