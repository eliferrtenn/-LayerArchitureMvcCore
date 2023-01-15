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
    public class RadyasyonManager : IRadyasyonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RadyasyonManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(RadyasyonDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.radyasyonRepository.AnyAsync(x => x.Personel_Id == addObject.Personel_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Radyasyon>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.radyasyonRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Personel_Id} kişisinin radyasyon bilgileri başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Personel_Id} kişisinin radyasyon bilgileri zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(RadyasyonDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.AnyAsync(x => x.Personel_Id == updateObject.Personel_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.radyasyonRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<RadyasyonDTO,Radyasyon>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.radyasyonRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Personel_Bilgi.Ad_Soyad} kişisinin radyasyon bilgileri başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisinin radyasyon bilgileri bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisinin radyasyon bilgileri  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.radyasyonRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.radyasyonRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin radyasyon bilgileri veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin radyasyon bilgileri bulunamadı.");
        }
      
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.radyasyonRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.radyasyonRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin radyasyon bilgileri başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin radyasyon bilgileri bulunamadı.");
        }

        public async Task<IDataResult<IList<RadyasyonDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.radyasyonRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<RadyasyonDTO>>(resultObject);
                return new DataResult<IList<RadyasyonDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<RadyasyonDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<RadyasyonDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.radyasyonRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<RadyasyonDTO>(resultObject);
                return new DataResult<RadyasyonDTO>(ResultStatus.Success, result);
            }
            return new DataResult<RadyasyonDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


    }
}
