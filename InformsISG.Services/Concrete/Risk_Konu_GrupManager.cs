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
    public class Risk_Konu_GrupManager : IRisk_KonuGrupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_Konu_GrupManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_Konu_GrupDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.risk_Konu_GrupRepository.AnyAsync(x => x.Risk_Konu_Grup_Adi == addObject.Risk_Konu_Grup_Adi);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Konu_Grup>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_Konu_GrupRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Risk_Konu_Grup_Adi} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Risk_Konu_Grup_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_Konu_GrupRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_Konu_GrupRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Konu_Grup_Adi} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Konu_Grup_Adi} bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_Konu_GrupDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_Konu_GrupRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_Konu_GrupDTO>>(resultObject);
                return new DataResult<IList<Risk_Konu_GrupDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_Konu_GrupDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_Konu_GrupDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_Konu_GrupRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_Konu_GrupDTO>(resultObject);
                return new DataResult<Risk_Konu_GrupDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_Konu_GrupDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_Konu_GrupRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_Konu_GrupRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Konu_Grup_Adi} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Konu_Grup_Adi} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_Konu_GrupDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.risk_Konu_GrupRepository.AnyAsync(x => x.Risk_Konu_Grup_Adi == updateObject.Risk_Konu_Grup_Adi && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_Konu_GrupRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_Konu_GrupDTO, Risk_Konu_Grup>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_Konu_GrupRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Risk_Konu_Grup_Adi} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Risk_Konu_Grup_Adi} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Risk_Konu_Grup_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<IList<Risk_Konu_GrupDTO>>> GetAllKonuGrupAsync(long id)
        {
            var resultObject = await _unitOfWork.risk_Konu_GrupRepository.GetAllAsync(x => x.Risk_Ust_Grup_Id == id && !x.isDeleted);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<IList<Risk_Konu_GrupDTO>>(resultObject);

                return new DataResult<IList<Risk_Konu_GrupDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_Konu_GrupDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı.", null);
        }

    }
}

