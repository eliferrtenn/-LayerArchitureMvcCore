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
    public class Yetkili_GormediManager : IYetkili_GormediService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Yetkili_GormediManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Yetkili_GormediDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.yetkili_GormediRepository.AnyAsync(x => x.Tablo_Adi == addObject.Tablo_Adi);
            if (exist == false)
            {
                var result = _mapper.Map<Yetkili_Gormedi>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yetkili_GormediRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tablo_Adi} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Tablo_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.yetkili_GormediRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.yetkili_GormediRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tablo_Adi} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tablo_Adi} bulunamadı.");
        }

        public async Task<IDataResult<IList<Yetkili_GormediDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.yetkili_GormediRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Yetkili_GormediDTO>>(resultObject);
                return new DataResult<IList<Yetkili_GormediDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Yetkili_GormediDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Yetkili_GormediDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.yetkili_GormediRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Yetkili_GormediDTO>(resultObject);
                return new DataResult<Yetkili_GormediDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Yetkili_GormediDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.yetkili_GormediRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.yetkili_GormediRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tablo_Adi} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tablo_Adi} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Yetkili_GormediDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.yetkili_GormediRepository.AnyAsync(x => x.Tablo_Adi == updateObject.Tablo_Adi  && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.yetkili_GormediRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Yetkili_GormediDTO,Yetkili_Gormedi>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.yetkili_GormediRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Tablo_Adi} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Tablo_Adi} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tablo_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
