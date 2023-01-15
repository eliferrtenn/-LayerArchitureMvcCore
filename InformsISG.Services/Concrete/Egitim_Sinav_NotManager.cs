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
    public class Egitim_Sinav_NotManager : IEgitim_Sinav_NotService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_Sinav_NotManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_Sinav_NotDTO addObject, long createdByUserId)
        {
            //var exist =await _unitOfWork.egitim_Sinav_NotRepository.AnyAsync(x => x.Sinav_Ad == addObject.Sinav_Ad);
            //if (exist == false)
            //{
                var result = _mapper.Map<Egitim_Sinav_Not>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_Sinav_NotRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sınav notu başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{addObject.Egitim_Sinav_Id}  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_Sinav_NotRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sınav notu başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Sınav notu bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_Sinav_NotDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Sinav_NotDTO>>(resultObject);
                return new DataResult<IList<Egitim_Sinav_NotDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Sinav_NotDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Egitim_Sinav_NotDTO>>> GetSinav(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAllAsync(x => x.Egitim_Sinav_Id==Id );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Sinav_NotDTO>>(resultObject);
                return new DataResult<IList<Egitim_Sinav_NotDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Sinav_NotDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_Sinav_NotDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_Sinav_NotDTO>(resultObject);
                return new DataResult<Egitim_Sinav_NotDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_Sinav_NotDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.egitim_Sinav_NotRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sınav notu veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Sınav notu bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_Sinav_NotDTO updateObject, long modifiedByUserId)
        {
            //var exist = await _unitOfWork.egitim_Sinav_NotRepository.AnyAsync(x => x.Sinav_Ad == updateObject.Sinav_Ad && x.Id != updateObject.Id);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.egitim_Sinav_NotRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_Sinav_NotDTO,Egitim_Sinav_Not>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_Sinav_NotRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sınav notu başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Sınav notu bulunamadı.");
            }
            }
            // else
            //    {
            //        return new Result(ResultStatus.Error, $"{updateObject.Sinav_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //    }
            //}
    }
}
