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
using System.Threading.Tasks;

namespace InformsISG.Services.Concrete
{
    public class Personel_BilgiManager : IPersonel_BilgiService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Personel_BilgiManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<IResult> AddAsync(Personel_BilgiDTO addObject, long createdByUserId)
        {

            var exist = await _unitOfWork.personel_BilgiRepository.AnyAsync(x=>x.Tc_No==addObject.Tc_No || 
            x.Eposta==addObject.Eposta && !x.isDeleted);
            if (exist==false)
            {
                var result = _mapper.Map<Personel_Bilgi>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.personel_BilgiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Ad_Soyad} kişisi başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error,$"{addObject.Ad_Soyad} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<Personel_BilgiDTO>> AddAndGetAsync(Personel_BilgiDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.personel_BilgiRepository.AnyAsync(x => x.Tc_No == addObject.Tc_No ||
            x.Eposta == addObject.Eposta && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Personel_Bilgi>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.personel_BilgiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Personel_BilgiDTO>(result);

                return new DataResult<Personel_BilgiDTO>(ResultStatus.Success, result1);
            }
            else
            {
                return new DataResult<Personel_BilgiDTO>(ResultStatus.Error, "Veri zaten kayıtlıdır. Lütfen tekrar deneyiniz",
            null);
            }
        }


        public async Task<IResult> UpdateAsync(Personel_BilgiDTO updateObject, long modifiedByUserId)
        {

            var exist =await  _unitOfWork.personel_BilgiRepository.AnyAsync(x => x.Tc_No == updateObject.Tc_No && x.Id!=updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.personel_BilgiRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Personel_BilgiDTO,Personel_Bilgi>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.personel_BilgiRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Ad_Soyad} kişisi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Ad_Soyad} kişisi bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Ad_Soyad} kişisi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.personel_BilgiRepository.GetAsync(x => x.Id ==Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.personel_BilgiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ad_Soyad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ad_Soyad} kişisi bulunamadı.");

        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.personel_BilgiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {  
                await _unitOfWork.personel_BilgiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ad_Soyad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ad_Soyad} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<Personel_BilgiDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.personel_BilgiRepository.GetAllAsync(x=>x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Personel_BilgiDTO>>(resultObject);
                return new DataResult<IList<Personel_BilgiDTO>>(ResultStatus.Success,result);
            }
                return new DataResult<IList<Personel_BilgiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
                null);
        }

        public async Task<IDataResult<Personel_BilgiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.personel_BilgiRepository.GetAsync(x => x.Id == Id);
            if (resultObject!=null)
            {
                var result = _mapper.Map<Personel_BilgiDTO>(resultObject);
                return new DataResult<Personel_BilgiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Personel_BilgiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Personel_BilgiDTO>>> YerDegisenAllAsync()
        {
            var resultObject = await _unitOfWork.personel_BilgiRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.yerdegistiMi == true);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Personel_BilgiDTO>>(resultObject);
                return new DataResult<IList<Personel_BilgiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Personel_BilgiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

    }
}
