using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Concrete
{
    public class MakineVeEkipman_KontrolKriterManager : IMakineVeEkipman_KontrolKriterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MakineVeEkipman_KontrolKriterManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(MakineVeEkipman_KontrolDTO addObject, long createdByUserId)
        {

            var result = _mapper.Map<MakineVeEkipman_Kontrol>(addObject);
            DateTime dateTime = DateTime.Now;
            result.Kullanici_Id = createdByUserId;
            result.Yaratilma_Tarihi = dateTime;
            result.Degistirilme_Tarihi = dateTime;
            await _unitOfWork.makineVeEkipman_Kontrol_KriterRepository.AddAsync(result);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Başarılı bir şekilde eklenmiştir.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makineVeEkipman_Kontrol_KriterRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makineVeEkipman_Kontrol_KriterRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Veri bulunamadı.");
        }

        public async Task<IDataResult<IList<MakineVeEkipman_KontrolDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makineVeEkipman_Kontrol_KriterRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<MakineVeEkipman_KontrolDTO>>(resultObject);
                return new DataResult<IList<MakineVeEkipman_KontrolDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<MakineVeEkipman_KontrolDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

    
    }


}
