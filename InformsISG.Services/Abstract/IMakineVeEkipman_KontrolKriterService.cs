using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakineVeEkipman_KontrolKriterService
    {
        Task<IResult> AddAsync(MakineVeEkipman_KontrolDTO addObject, long createdByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IDataResult<IList<MakineVeEkipman_KontrolDTO>>> GetAllAsync();
    }
}
