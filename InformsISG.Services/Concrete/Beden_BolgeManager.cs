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
    public class Beden_BolgeManager : IBeden_BolgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Beden_BolgeManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Beden_BolgeDTO addObject, long createdByUserId)
        {

            var exist =await  _unitOfWork.beden_BolgeRepository.AnyAsync(x => x.Beden_Bolge_Ad == addObject.Beden_Bolge_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Beden_Bolge>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.beden_BolgeRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Beden_Bolge_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Beden_Bolge_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.beden_BolgeRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.beden_BolgeRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Beden_Bolge_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Beden_Bolge_Ad}  bulunamadı.");
        }

        public async Task<IDataResult<IList<Beden_BolgeDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.beden_BolgeRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Beden_BolgeDTO>>(resultObject);
                return new DataResult<IList<Beden_BolgeDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Beden_BolgeDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Beden_BolgeDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.beden_BolgeRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Beden_BolgeDTO>(resultObject);

                return new DataResult<Beden_BolgeDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Beden_BolgeDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.beden_BolgeRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.beden_BolgeRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Beden_Bolge_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Beden_Bolge_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Beden_BolgeDTO updateObject, long modifiedByUserId)
        {
            var exist =await  _unitOfWork.beden_BolgeRepository.AnyAsync(x => x.Beden_Bolge_Ad == updateObject.Beden_Bolge_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.beden_BolgeRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Beden_BolgeDTO,Beden_Bolge>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.beden_BolgeRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Beden_Bolge_Ad} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{resultObject.Beden_Bolge_Ad} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Beden_Bolge_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
