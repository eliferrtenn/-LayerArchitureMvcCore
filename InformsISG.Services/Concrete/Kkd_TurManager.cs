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
    public class Kkd_TurManager : IKkd_TurService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kkd_TurManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kkd_TurDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kkd_TurRepository.AnyAsync(x => x.Kkd_Tur_Ad == addObject.Kkd_Tur_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Kkd_Tur>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkd_TurRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd_Tur_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Kkd_Tur_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kkd_TurRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kkd_TurRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd_Tur_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd_Tur_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Kkd_TurDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kkd_TurRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kkd_TurDTO>>(resultObject);
                return new DataResult<IList<Kkd_TurDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kkd_TurDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kkd_TurDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkd_TurRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kkd_TurDTO>(resultObject);
                return new DataResult<Kkd_TurDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kkd_TurDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kkd_TurRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kkd_TurRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd_Tur_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd_Tur_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kkd_TurDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.kkd_TurRepository.AnyAsync(x => x.Kkd_Tur_Ad == updateObject.Kkd_Tur_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kkd_TurRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                 var result = _mapper.Map<Kkd_TurDTO,Kkd_Tur>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkd_TurRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd_Tur_Ad} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_Tur_Ad} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_Tur_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
