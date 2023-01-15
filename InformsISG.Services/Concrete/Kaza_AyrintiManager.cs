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
    public class Kaza_AyrintiManager : IKaza_AyrintiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kaza_AyrintiManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kaza_AyrintiDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.kaza_AyrintiRepository.AnyAsync(x => x.Kaza_Id == addObject.Kaza_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza_Ayrinti>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_AyrintiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza ayrıntısı  başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza ayrıntısı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kaza_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kaza_AyrintiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza ayrıntısı  başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Kaza ayrıntısı bulunamadı.");
        }

        public async Task<IDataResult<IList<Kaza_AyrintiDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kaza_AyrintiRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kaza_AyrintiDTO>>(resultObject);
                return new DataResult<IList<Kaza_AyrintiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kaza_AyrintiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kaza_AyrintiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_AyrintiDTO>(resultObject);
                return new DataResult<Kaza_AyrintiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_AyrintiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kaza_AyrintiDTO>> GetKazaAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_AyrintiRepository.GetAsync(x => x.Kaza_Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_AyrintiDTO>(resultObject);
                return new DataResult<Kaza_AyrintiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_AyrintiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kaza_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kaza_AyrintiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza ayrıntısı veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Kaza ayrıntısı bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kaza_AyrintiDTO updateObject, long modifiedByUserId)
        {
            var exist =await  _unitOfWork.kaza_AyrintiRepository.AnyAsync(x => x.Kaza_Id == updateObject.Kaza_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kaza_AyrintiRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_AyrintiDTO,Kaza_Ayrinti>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_AyrintiRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza ayrıntısı başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza ayrıntısı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
