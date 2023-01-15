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
    public class YetkiManager : IYetkiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public YetkiManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IResult> AddAsync(YetkiDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.yetkiRepository.AnyAsync(x => x.Yetki_Ad == addObject.Yetki_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Yetki>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yetkiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Yetki_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Yetki_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(YetkiDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.yetkiRepository.AnyAsync(x => x.Yetki_Ad == updateObject.Yetki_Ad && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.yetkiRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<YetkiDTO, Yetki>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.yetkiRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Yetki_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Yetki_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Yetki_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.yetkiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.yetkiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yetki_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yetki_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<YetkiDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.yetkiRepository.GetAllAsync(x => x.isActive && !x.isDeleted );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<YetkiDTO>>(resultObject);
                return new DataResult<IList<YetkiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<YetkiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<YetkiDTO>>> GetNonSuperAdmin()
        {
            var resultObject = await _unitOfWork.yetkiRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Id!=1);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<YetkiDTO>>(resultObject);
                return new DataResult<IList<YetkiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<YetkiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<YetkiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.yetkiRepository.GetAsync(x => x.Id == Id);

            if (resultObject != null)
            {
                var result = _mapper.Map<YetkiDTO>(resultObject);
                return new DataResult<YetkiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<YetkiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.yetkiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.yetkiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yetki_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yetki_Ad} bulunamadı.");
        }


    }
}
