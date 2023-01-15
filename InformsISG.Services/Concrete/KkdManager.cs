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
    public class KkdManager : IKkdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KkdManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(KkdDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kkdRepository.AnyAsync(x => x.Kkd_No == addObject.Kkd_No && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Kkd>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkdRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd_No} numaralı Kkd başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Kkd_No} numaralı Kkd zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kkdRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kkdRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd_No} numaralı Kkd başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd_No} numaralı Kkd bulunamadı.");
        }

        public async Task<IDataResult<IList<KkdDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kkdRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<KkdDTO>>(resultObject);
                return new DataResult<IList<KkdDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<KkdDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<KkdDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkdRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KkdDTO>(resultObject);
                return new DataResult<KkdDTO>(ResultStatus.Success, result);
            }
            return new DataResult<KkdDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);

        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kkdRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kkdRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd_No} numaralı Kkd veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd_No} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(KkdDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.kkdRepository.AnyAsync(x => x.Kkd_No == updateObject.Kkd_No && x.Id != updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kkdRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KkdDTO,Kkd>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkdRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd_No} numaralı KKd başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_No} numaralı Kkd bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_No} numaralı Kkd zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }



    }
}
