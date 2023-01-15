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
    public class Risk_Analiz_TehlikeManager : IRisk_Analiz_TehlikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_Analiz_TehlikeManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_Analiz_TehlikeDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.risk_Analiz_TehlikeRepository.AnyAsync(x => x.Tehlike == addObject.Tehlike);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Analiz_Tehlike>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_Analiz_TehlikeRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tehlike} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Tehlike} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Risk_Analiz_TehlikeDTO updateObject, long modifiedByUserId)
        {
            var exist =await  _unitOfWork.risk_Analiz_TehlikeRepository.AnyAsync(x => x.Tehlike == updateObject.Tehlike && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_Analiz_TehlikeRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_Analiz_TehlikeDTO,Risk_Analiz_Tehlike>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_Analiz_TehlikeRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Tehlike} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Tehlike} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tehlike} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_Analiz_TehlikeRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_Analiz_TehlikeRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tehlike} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tehlike} bulunamadı.");
        }
      
        public async  Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_Analiz_TehlikeRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_Analiz_TehlikeRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tehlike} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tehlike} bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_Analiz_TehlikeDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_Analiz_TehlikeRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_Analiz_TehlikeDTO>>(resultObject);
                return new DataResult<IList<Risk_Analiz_TehlikeDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_Analiz_TehlikeDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_Analiz_TehlikeDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_Analiz_TehlikeRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_Analiz_TehlikeDTO>(resultObject);
                return new DataResult<Risk_Analiz_TehlikeDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_Analiz_TehlikeDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


    }
}
