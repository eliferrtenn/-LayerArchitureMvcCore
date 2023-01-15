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
    public class Alt_IsverenManager : IAlt_IsverenService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Alt_IsverenManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Alt_IsverenDTO addObject, long createdByUserId)
        {

            var exist =  await _unitOfWork.alt_IsverenRepository.AnyAsync(x => x.Alt_Isveren_Ad == addObject.Alt_Isveren_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Alt_Isveren>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.alt_IsverenRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Alt_Isveren_Ad} işveren başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Alt_Isveren_Ad} işveren zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.alt_IsverenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.alt_IsverenRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Alt_Isveren_Ad} işveren başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Alt_Isveren_Ad} işveren bulunamadı.");
        }

        public async  Task<IDataResult<IList<Alt_IsverenDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.alt_IsverenRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Alt_IsverenDTO>>(resultObject);
                return new DataResult<IList<Alt_IsverenDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Alt_IsverenDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Alt_IsverenDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.alt_IsverenRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Alt_IsverenDTO>(resultObject);
                return new DataResult<Alt_IsverenDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Alt_IsverenDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.alt_IsverenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.alt_IsverenRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Alt_Isveren_Ad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Alt_Isveren_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Alt_IsverenDTO updateObject, long modifiedByUserId)
        {
            bool exist = await _unitOfWork.alt_IsverenRepository.AnyAsync(x => x.Alt_Isveren_Ad == updateObject.Alt_Isveren_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.alt_IsverenRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Alt_Isveren>(updateObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.alt_IsverenRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Alt_Isveren_Ad} işveren başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Alt_Isveren_Ad} işveren bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Alt_Isveren_Ad} işveren zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }

        }
    }
}
