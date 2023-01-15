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
    public class BirimManager : IBirimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BirimManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
     
        }
        public async Task<IResult> AddAsync(BirimDTO addObject, long createdByUserId)
        {
            bool exist = await _unitOfWork.birimRepository.AnyAsync(x => x.Birim_Ad == addObject.Birim_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Birim>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.birimRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Birim_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Birim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(BirimDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.birimRepository.AnyAsync(x => x.Birim_Ad == updateObject.Birim_Ad && x.Id != updateObject.Id && !x.isDeleted);
            
            if (exist == false)
            {         
                var resultObject = await _unitOfWork.birimRepository.GetAsync(x => x.Id == updateObject.Id);

                if (resultObject != null)
                {
                    var result = _mapper.Map<BirimDTO,Birim>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.birimRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Birim_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Birim_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Birim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
  
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.birimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.birimRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Birim_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Birim_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<BirimDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.birimRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<BirimDTO>>(resultObject);
                return new DataResult<IList<BirimDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<BirimDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<BirimDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.birimRepository. GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<BirimDTO>(resultObject);
                return new DataResult<BirimDTO>(ResultStatus.Success, result);
            }
            return new DataResult<BirimDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.birimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.birimRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Birim_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Birim_Ad} bulunamadı.");
        }


        }
}
