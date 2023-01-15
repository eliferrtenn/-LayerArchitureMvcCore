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
    public class Ramak_KalaManager : IRamak_KalaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Ramak_KalaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Ramak_KalaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.ramak_KalaRepository.AnyAsync(x => x.Ramak_Kala_No == addObject.Ramak_Kala_No);
            if (exist == false)
            {
                var result = _mapper.Map<Ramak_Kala>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.ramak_KalaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Ramak_Kala_No} numaralı ramak kala başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Ramak_Kala_No} numaralı ramak kala zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Ramak_KalaDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.ramak_KalaRepository.AnyAsync(x => x.Ramak_Kala_No == updateObject.Ramak_Kala_No && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.ramak_KalaRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Ramak_KalaDTO,Ramak_Kala>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.ramak_KalaRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Ramak_Kala_No} numaralı ramak kala başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Ramak_Kala_No} numaralı ramak kala bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Ramak_Kala_No} numaralı ramak kala zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
      
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.ramak_KalaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.ramak_KalaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ramak_Kala_No} numaralı ramak kala başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ramak_Kala_No} numaralı ramak kala bulunamadı.");
        }

        public async Task<IDataResult<IList<Ramak_KalaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.ramak_KalaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Ramak_KalaDTO>>(resultObject);
                return new DataResult<IList<Ramak_KalaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Ramak_KalaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Ramak_KalaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.ramak_KalaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Ramak_KalaDTO>(resultObject);
                return new DataResult<Ramak_KalaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Ramak_KalaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.ramak_KalaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.ramak_KalaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ramak_Kala_No} numaralı ramak kala veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ramak_Kala_No} numaralı ramak kala bulunamadı.");
        }


    }
}
