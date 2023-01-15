using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKaza_Personel_DisiService
    {
        Task<IResult> AddAsync(Kaza_Personel_DisiDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kaza_Personel_DisiDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kaza_Personel_DisiDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Kaza_Personel_DisiDTO>>> GetAllAsync();
    }
}
