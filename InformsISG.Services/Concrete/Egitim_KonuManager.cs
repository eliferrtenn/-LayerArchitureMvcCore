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
    public class Egitim_KonuManager : IEgitim_KonuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_KonuManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_KonuDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.egitim_KonuRepository.AnyAsync(x => x.Egitim_Ad == addObject.Egitim_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Egitim_Konu>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_KonuRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Egitim_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Egitim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_KonuRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_KonuRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Egitim_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Egitim_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_KonuDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.egitim_KonuRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_KonuDTO>>(resultObject);
                return new DataResult<IList<Egitim_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_KonuDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_KonuRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_KonuDTO>(resultObject);
                return new DataResult<Egitim_KonuDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_KonuDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.acil_Durum_Ekip_PersonelRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ekip_Lideri} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ekip_Lideri} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_KonuDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.egitim_KonuRepository.AnyAsync(x => x.Egitim_Ad == updateObject.Egitim_Ad && x.Id != updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.egitim_KonuRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_KonuDTO,Egitim_Konu>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_KonuRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Egitim_Ad} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Egitim_Ad} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Egitim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
