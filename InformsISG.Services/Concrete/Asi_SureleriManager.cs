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
    public class Asi_SureleriManager : IAsi_SureleriService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Asi_SureleriManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Asi_SureleriDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.asi_SureleriRepository.AnyAsync(x => x.Asi_Tur_Id == addObject.Asi_Tur_Id && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Asi_Sureleri>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.asi_SureleriRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Asi_Tur.Asi_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Asi_Tur_Id} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.asi_SureleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.asi_SureleriRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Asi_Tur.Asi_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Asi_Tur.Asi_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Asi_SureleriDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.asi_SureleriRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Asi_SureleriDTO>>(resultObject);
                return new DataResult<IList<Asi_SureleriDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Asi_SureleriDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Asi_SureleriDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.asi_SureleriRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Asi_SureleriDTO>(resultObject);
                return new DataResult<Asi_SureleriDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Asi_SureleriDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.asi_SureleriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.asi_SureleriRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Asi_Tur.Asi_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Asi_Tur.Asi_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Asi_SureleriDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.asi_SureleriRepository.AnyAsync(x => x.Asi_Tur_Id == updateObject.Asi_Tur_Id && x.Id != updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.asi_SureleriRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Asi_SureleriDTO, Asi_Sureleri>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.asi_SureleriRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Asi_Tur_Id} başarılı bir şekilde güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Asi_Tur_Id} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Asi_Tur_Id} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
