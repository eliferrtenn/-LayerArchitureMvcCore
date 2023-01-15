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
    public class Egitim_Konu_Alt_BaslikManager : IEgitim_Konu_Alt_BaslikService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_Konu_Alt_BaslikManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_Konu_Alt_BaslikDTO addObject, long createdByUserId)
        {
            bool exist = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.AnyAsync(x => x.Alt_Baslik_Ad == addObject.Alt_Baslik_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Egitim_Konu_Alt_Baslik>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_Konu_Alt_BaslikRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Alt_Baslik_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Alt_Baslik_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_Konu_Alt_BaslikRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Alt_Baslik_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Alt_Baslik_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Konu_Alt_BaslikDTO>>(resultObject);
                return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_Konu_Alt_BaslikDTO>> GetAsync(long Id)
        {

            var resultObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_Konu_Alt_BaslikDTO>(resultObject);
                return new DataResult<Egitim_Konu_Alt_BaslikDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_Konu_Alt_BaslikDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetSelected(long Id)
        {

            var resultObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAsync(x => x.Id == Id);
            if (resultObject!=null)
            {
                var result = _mapper.Map<IList<Egitim_Konu_Alt_BaslikDTO>>(resultObject);
                return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.egitim_Konu_Alt_BaslikRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Alt_Baslik_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Alt_Baslik_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_Konu_Alt_BaslikDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.AnyAsync(x => x.Alt_Baslik_Ad == updateObject.Alt_Baslik_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_Konu_Alt_BaslikDTO,Egitim_Konu_Alt_Baslik>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_Konu_Alt_BaslikRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Alt_Baslik_Ad} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Alt_Baslik_Ad} bulunamadı.");
            }
        }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Alt_Baslik_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
    }
}


        public async Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetAllEgitimKonuAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Konu_Alt_BaslikRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Egitim_Konu_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Konu_Alt_BaslikDTO>>(resultObject);
                return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Konu_Alt_BaslikDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
