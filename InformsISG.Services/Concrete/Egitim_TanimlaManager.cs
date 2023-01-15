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
    public class Egitim_TanimlaManager : IEgitim_TanimlaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_TanimlaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_TanimlaDTO addObject, long createdByUserId)
        {
            bool exist = await _unitOfWork.egitim_TanimlaRepository.AnyAsync(x =>!x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Egitim_Tanimla>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_TanimlaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Eğitim başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Eğitim zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_TanimlaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_TanimlaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Eğitim başarılı bir şekilde listeden çıkarılmıştır.");
            }
            return new Result(ResultStatus.Error, $"Çıkartmak istediğiniz eğitim bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_TanimlaDTO>>> GetAllAsync()
        {

            var resultObject = await _unitOfWork.egitim_TanimlaRepository.GetAllAsync(x => x.isActive && !x.isDeleted );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_TanimlaDTO>>(resultObject);
                return new DataResult<IList<Egitim_TanimlaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_TanimlaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_TanimlaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_TanimlaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_TanimlaDTO>(resultObject);
                return new DataResult<Egitim_TanimlaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_TanimlaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.egitim_TanimlaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.egitim_TanimlaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Silmek istediğiniz eğitim veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Silmek istediğiniz eğitim bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_TanimlaDTO updateObject, long modifiedByUserId)
        {
            //var exist = await _unitOfWork.egitim_TanimlaRepository.AnyAsync(x => x.Egitim_Yer == updateObject.Egitim_Yer && x.Egitim_Saat == updateObject.Egitim_Saat
            //&& x.Id != updateObject.Id);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.egitim_TanimlaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_TanimlaDTO,Egitim_Tanimla>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_TanimlaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Eğitim başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Eğitim bulunamadı.");
            }
        //}
    //        else
    //        {
    //            return new Result(ResultStatus.Error, $"{updateObject.Egitim_Konu_Alt_Baslik_Id} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
    //}
}

        public async Task<IDataResult<Egitim_TanimlaDTO>> AddAndGetAsync(Egitim_TanimlaDTO addObject, long createdByUserId)
        {

                var result = _mapper.Map<Egitim_Tanimla>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_TanimlaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Egitim_TanimlaDTO>(result);

                return new DataResult<Egitim_TanimlaDTO>(ResultStatus.Success, result1);
 
        }

    }
}
