using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Concrete
{
    public class Acil_Durum_TatbikatManager : IAcil_Durum_TatbikatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Acil_Durum_TatbikatManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IResult> AddAsync(Acil_Durum_TatbikatDTO addObject, long createdByUserId)
        {
            bool exist = await _unitOfWork.acil_Durum_TatbikatRepository.AnyAsync(x => x.Tatbikat_Ad == addObject.Tatbikat_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Acil_Durum_Tatbikat>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.acil_Durum_TatbikatRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tatbikat_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Tatbikat_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Acil_Durum_TatbikatDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.acil_Durum_TatbikatRepository.AnyAsync(x => x.Tatbikat_Ad == updateObject.Tatbikat_Ad && x.Id != updateObject.Id && !x.isDeleted);

            if (exist == false)
            {
                var resultObject = await _unitOfWork.acil_Durum_TatbikatRepository.GetAsync(x => x.Id == updateObject.Id);

                if (resultObject != null)
                {
                    var result = _mapper.Map<Acil_Durum_TatbikatDTO, Acil_Durum_Tatbikat>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.acil_Durum_TatbikatRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Tatbikat_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Tatbikat_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tatbikat_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.acil_Durum_TatbikatRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.acil_Durum_TatbikatRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tatbikat_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tatbikat_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Acil_Durum_TatbikatDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.acil_Durum_TatbikatRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Acil_Durum_TatbikatDTO>>(resultObject);
                return new DataResult<IList<Acil_Durum_TatbikatDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Acil_Durum_TatbikatDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Acil_Durum_TatbikatDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_TatbikatRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Acil_Durum_TatbikatDTO>(resultObject);
                return new DataResult<Acil_Durum_TatbikatDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Acil_Durum_TatbikatDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.acil_Durum_TatbikatRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.acil_Durum_TatbikatRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tatbikat_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tatbikat_Ad} bulunamadı.");
        }


    }
}
