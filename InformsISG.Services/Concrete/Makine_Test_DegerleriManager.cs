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
    public class Makine_Test_DegerleriManager : IMakine_Test_DegerleriService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_Test_DegerleriManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IResult> AddAsync(Makine_Test_DegerleriDTO addObject, long createdByUserId)
        {
            bool exist = await _unitOfWork.makine_Test_DegerleriRepository.AnyAsync(x => x.Madde_Ad == addObject.Madde_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Makine_Test_Degerleri>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Test_DegerleriRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Madde_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Madde_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Makine_Test_DegerleriDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.makine_Test_DegerleriRepository.AnyAsync(x => x.Madde_Ad == updateObject.Madde_Ad && x.Id != updateObject.Id && !x.isDeleted);

            if (exist == false)
            {
                var resultObject = await _unitOfWork.makine_Test_DegerleriRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Makine_Test_DegerleriDTO, Makine_Test_Degerleri>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.makine_Test_DegerleriRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Madde_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Madde_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Madde_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_Test_DegerleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_Test_DegerleriRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Test_DegerleriDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makine_Test_DegerleriRepository
                .GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Test_DegerleriDTO>>(resultObject);
                return new DataResult<IList<Makine_Test_DegerleriDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Test_DegerleriDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Makine_Test_DegerleriDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Test_DegerleriRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Test_DegerleriDTO>(resultObject);
                return new DataResult<Makine_Test_DegerleriDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_Test_DegerleriDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_Test_DegerleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.makine_Test_DegerleriRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Test_DegerleriDTO>>> GetAllMakineAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Test_DegerleriRepository
                .GetAllAsync(x => x.isActive && !x.isDeleted && x.Makine_Id == Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Test_DegerleriDTO>>(resultObject);
                return new DataResult<IList<Makine_Test_DegerleriDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Test_DegerleriDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


    }
}

