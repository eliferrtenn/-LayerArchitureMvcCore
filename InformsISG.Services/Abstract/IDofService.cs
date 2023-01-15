﻿using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IDofService
    {
        Task<IResult> AddAsync(DofDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(DofDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<DofDTO>> GetAsync(long Id);
        Task<IDataResult<IList<DofDTO>>> GetAllAsync(long Id);
        Task<IDataResult<DofDTO>> GetDofNoAsync(long Id);

    }
}
