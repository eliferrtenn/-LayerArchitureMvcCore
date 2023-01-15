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
    public class Kaza_DosyaManager : IKaza_DosyaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kaza_DosyaManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kaza_DosyaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kaza_DosyaRepository.AnyAsync(x => x.Kaza_Id == addObject.Kaza_Id && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza_Dosya>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_DosyaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza dosyası başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza dosyası zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kaza_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kaza_DosyaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza dosyası başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Kaza dosyası bulunamadı.");
        }

        public async Task<IDataResult<IList<Kaza_DosyaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kaza_DosyaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kaza_DosyaDTO>>(resultObject);
                return new DataResult<IList<Kaza_DosyaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kaza_DosyaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kaza_DosyaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_DosyaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_DosyaDTO>(resultObject);
                return new DataResult<Kaza_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
        public async Task<IDataResult<Kaza_DosyaDTO>> GetKazaAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_DosyaRepository.GetAsync(x => x.Kaza_Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_DosyaDTO>(resultObject);
                return new DataResult<Kaza_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kaza_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.kaza_DosyaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza dosyası veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Kaza dosyası bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kaza_DosyaDTO updateObject, long modifiedByUserId)
        {
            var exist =await  _unitOfWork.kaza_DosyaRepository.AnyAsync(x => x.Kaza_Id == updateObject.Kaza_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kaza_DosyaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_DosyaDTO,Kaza_Dosya>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_DosyaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kaza dosyası başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza dosyası bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"Kaza dosyası zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
