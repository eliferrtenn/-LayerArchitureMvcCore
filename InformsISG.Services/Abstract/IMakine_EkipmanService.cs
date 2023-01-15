using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_EkipmanService
    {
        Task<IResult> AddAsync(Makine_EkipmanDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_EkipmanDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_EkipmanDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_EkipmanDTO>>> GetAllAsync(long Id);
        Task<IDataResult<Makine_EkipmanDTO>> ReadQRCOdeAsync(string QRCode);
        Task<IDataResult<Makine_EkipmanDTO>> ReadEkipmanKodAsync(string EkipmanKod);
        Task<IDataResult<Makine_EkipmanDTO>> AddAndGetAsync(Makine_EkipmanDTO addObject, long createdByUserId);

    }
}
