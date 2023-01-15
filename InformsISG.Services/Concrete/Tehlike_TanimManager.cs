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
    public class Tehlike_TanimManager : ITehlike_TanimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Tehlike_TanimManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
     
        public async Task<IResult> AddAsync(Tehlike_TanimDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.tehlike_TanimRepository.AnyAsync(x => x.Tehlike_Tanim_Ad == addObject.Tehlike_Tanim_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Tehlike_Tanim>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.tehlike_TanimRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tehlike_Tanim_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Tehlike_Tanim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Tehlike_TanimDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.tehlike_TanimRepository.AnyAsync(x => x.Tehlike_Tanim_Ad == updateObject.Tehlike_Tanim_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.tehlike_TanimRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Tehlike_TanimDTO,Tehlike_Tanim>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.tehlike_TanimRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Tehlike_Tanim_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Tehlike_Tanim_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tehlike_Tanim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.tehlike_TanimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.tehlike_TanimRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tehlike_Tanim_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tehlike_Tanim_Ad} bulunamadı.");
        }
      
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.tehlike_TanimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.tehlike_TanimRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tehlike_Tanim_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tehlike_Tanim_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Tehlike_TanimDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.tehlike_TanimRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Tehlike_TanimDTO>>(resultObject);
                return new DataResult<IList<Tehlike_TanimDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Tehlike_TanimDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Tehlike_TanimDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.tehlike_TanimRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Tehlike_TanimDTO>(resultObject);
                return new DataResult<Tehlike_TanimDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Tehlike_TanimDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
