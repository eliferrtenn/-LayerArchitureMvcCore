using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKullaniciService
    {
        Task<IResult> AddAsync(KullaniciDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(KullaniciDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<KullaniciDTO>> GetAsync(long Id);
        Task<IDataResult<KullaniciDTO>> GetKullanci(string mail, string sifre);
        Task<IDataResult<IList<KullaniciDTO>>> GetAllAsync();
        Task<IDataResult<KullaniciDTO>> GetYetkiliAsync(long Id);

    }
}
