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
    public class Personel_AyrintiManager : IPersonel_AyrintiService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Personel_AyrintiManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Personel_AyrintiDTO addObject, long createdByUserId)
        {

            var exist =await _unitOfWork.personel_AyrintiRepository.AnyAsync(x => x.Personel_Id == addObject.Personel_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Personel_Ayrinti>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.personel_AyrintiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Personel_Bilgi.Ad_Soyad} kişisi başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Personel_Id} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Personel_AyrintiDTO updateObject, long modifiedByUserId)
        {

            var exist = await _unitOfWork.personel_AyrintiRepository.AnyAsync(x => x.Personel_Id == updateObject.Personel_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.personel_AyrintiRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Personel_AyrintiDTO,Personel_Ayrinti>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.personel_AyrintiRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Personel_Bilgi.Ad_Soyad} kişisi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisi bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.personel_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.personel_AyrintiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisi bulunamadı.");
        }
    
        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.personel_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.personel_AyrintiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<Personel_AyrintiDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.personel_AyrintiRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Personel_AyrintiDTO>>(resultObject);
                return new DataResult<IList<Personel_AyrintiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Personel_AyrintiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async  Task<IDataResult<Personel_AyrintiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.personel_AyrintiRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Personel_AyrintiDTO>(resultObject);
                return new DataResult<Personel_AyrintiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Personel_AyrintiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

   

    }
}
