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
    public class Risk_GerceklesenManager : IRisk_GerceklesenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_GerceklesenManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_GerceklesenDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.risk_GerceklesenRepository.AnyAsync(x => x.Risk_Gerceklesen_Ad == addObject.Risk_Gerceklesen_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Gerceklesen>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_GerceklesenRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Risk_Gerceklesen_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Risk_Gerceklesen_Ad}  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_GerceklesenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_GerceklesenRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Gerceklesen_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Gerceklesen_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_GerceklesenDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_GerceklesenRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_GerceklesenDTO>>(resultObject);
                return new DataResult<IList<Risk_GerceklesenDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_GerceklesenDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_GerceklesenDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_GerceklesenRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_GerceklesenDTO>(resultObject);
                return new DataResult<Risk_GerceklesenDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_GerceklesenDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_GerceklesenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.risk_GerceklesenRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Gerceklesen_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Gerceklesen_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_GerceklesenDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.risk_GerceklesenRepository.AnyAsync(x => x.Risk_Gerceklesen_Ad == updateObject.Risk_Gerceklesen_Ad && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_GerceklesenRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_GerceklesenDTO,Risk_Gerceklesen>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_GerceklesenRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Risk_Gerceklesen_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Risk_Gerceklesen_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Risk_Gerceklesen_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
