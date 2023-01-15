using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_Personel_AtamaService
    {
        Task<IResult> AddAsync(Egitim_Personel_AtamaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_Personel_AtamaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_Personel_AtamaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_Personel_AtamaDTO>>> GetAllAsync();
        Task<IDataResult<IList<Egitim_Personel_AtamaDTO>>> GetPersonel(long Id);
        Task<IDataResult<IList<Egitim_Personel_AtamaDTO>>> GetEgitimAsync(long Id);
        Task<IDataResult<IList<Egitim_Personel_AtamaDTO>>> GetPersonelAsync(long Id);


    }
}
