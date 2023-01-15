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
    public class Risk_KonuManager : IRisk_KonuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_KonuManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_KonuDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.risk_KonuRepository.AnyAsync(x => x.Risk_Konu_Adi == addObject.Risk_Konu_Adi);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Konu>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_KonuRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Risk_Konu_Adi} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Risk_Konu_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_KonuRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_KonuRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Konu_Adi} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Konu_Adi} bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_KonuDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_KonuRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_KonuDTO>>(resultObject);
                return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_KonuDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_KonuRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_KonuDTO>(resultObject);
                return new DataResult<Risk_KonuDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_KonuDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
     
        public async Task<IDataResult<IList<Risk_KonuDTO>>> GetSelectAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_KonuRepository.GetAllAsync(x => !x.isDeleted, k2 => k2.Risk_Konu_Grup, k1 => k1.Risk_Konu_Grup.Risk_Konu);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<IList<Risk_KonuDTO>>(resultObject);
                return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_KonuRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_KonuRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Konu_Adi} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Konu_Adi} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_KonuDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.risk_KonuRepository.AnyAsync(x => x.Risk_Konu_Adi == updateObject.Risk_Konu_Adi && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_KonuRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_KonuDTO, Risk_Konu>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_KonuRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Risk_Konu_Adi} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Risk_Konu_Adi} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Risk_Konu_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<IList<Risk_KonuDTO>>> GetAllKonuAsync(long id)
        {
            var resultObject = await _unitOfWork.risk_KonuRepository.GetAllAsync(x => x.Risk_Konu_Grup_Id == id && !x.isDeleted);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<IList<Risk_KonuDTO>>(resultObject);

                return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı.", null);
        }


    }
}

