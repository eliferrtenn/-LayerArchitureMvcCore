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
    public class Sgk_MeslekManager : ISgk_MeslekService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Sgk_MeslekManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Sgk_MeslekDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.sgk_MeslekRepository.AnyAsync(x => x.Meslek_Ad == addObject.Meslek_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Sgk_Meslek>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.sgk_MeslekRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Meslek_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Meslek_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Sgk_MeslekDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.sgk_MeslekRepository.AnyAsync(x => x.Meslek_Ad == updateObject.Meslek_Ad && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.sgk_MeslekRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Sgk_MeslekDTO,Sgk_Meslek>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.sgk_MeslekRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Meslek_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Meslek_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Meslek_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.sgk_MeslekRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.sgk_MeslekRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Meslek_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Meslek_Ad} bulunamadı.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.sgk_MeslekRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.sgk_MeslekRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Meslek_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Meslek_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Sgk_MeslekDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.sgk_MeslekRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Sgk_MeslekDTO>>(resultObject);
                return new DataResult<IList<Sgk_MeslekDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Sgk_MeslekDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Sgk_MeslekDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.sgk_MeslekRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Sgk_MeslekDTO>(resultObject);
                return new DataResult<Sgk_MeslekDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Sgk_MeslekDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


    }
}
