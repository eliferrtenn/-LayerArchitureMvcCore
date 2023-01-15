﻿using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Ekipman_Kontrol_Kriter_BaslikService
    {
        Task<IResult> AddAsync(Makine_Ekipman_Kontrol_Kriter_BaslikDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Ekipman_Kontrol_Kriter_BaslikDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Ekipman_Kontrol_Kriter_BaslikDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Ekipman_Kontrol_Kriter_BaslikDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Ekipman_Kontrol_Kriter_BaslikDTO>>> GetAllMakineEkipmanAsync(long Id);

        Task<IDataResult<Makine_Ekipman_Kontrol_Kriter_BaslikDTO>> AddAndGetAsync(Makine_Ekipman_Kontrol_Kriter_BaslikDTO addObject, long createdByUserId);
    }
}
