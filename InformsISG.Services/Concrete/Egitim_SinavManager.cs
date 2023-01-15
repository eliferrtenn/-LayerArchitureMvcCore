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
    public class Egitim_SinavManager : IEgitim_SinavService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_SinavManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_SinavDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.egitim_SinavRepository.AnyAsync(x => x.Sinav_Ad == addObject.Sinav_Ad && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Egitim_Sinav>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_SinavRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{addObject.Sinav_Ad} sınavı başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Sinav_Ad} sınavı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_SinavRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_SinavRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Sinav_Ad} sınavı başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Sinav_Ad} sınavı bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_SinavDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.egitim_SinavRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_SinavDTO>>(resultObject);
                return new DataResult<IList<Egitim_SinavDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_SinavDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_SinavDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_SinavRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_SinavDTO>(resultObject);
                return new DataResult<Egitim_SinavDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_SinavDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.egitim_SinavRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.egitim_SinavRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Sinav_Ad} sınavı veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Sinav_Ad} sınavı bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_SinavDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.egitim_SinavRepository.AnyAsync(x => x.Sinav_Ad == updateObject.Sinav_Ad && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.egitim_SinavRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Egitim_SinavDTO, Egitim_Sinav>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.egitim_SinavRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Sinav_Ad} sınavı başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{resultObject.Sinav_Ad} sınavı bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Sinav_Ad} sınavı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
