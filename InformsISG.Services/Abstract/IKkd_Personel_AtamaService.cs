using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKkd_Personel_AtamaService
    {
        Task<IResult> AddAsync(Kkd_Personel_AtamaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kkd_Personel_AtamaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kkd_Personel_AtamaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllAsync();
        Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllKkdAsync(long Id);
        Task<IDataResult<IList<Kkd_Personel_AtamaDTO>>> GetAllPersonelAsync(long Id);
    }
}
