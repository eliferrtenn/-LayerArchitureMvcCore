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
    public class Risk_KutuphaneManager : IRisk_KutuphaneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_KutuphaneManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_KutuphaneDTO addObject, long createdByUserId)
        {
            //var exist = await _unitOfWork.risk_KutuphaneRepository.AnyAsync(x => x. == addObject.Risk_Konu_Adi);
            //if (exist == false)
            //{
                var result = _mapper.Map<Risk_Kutuphane>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_KutuphaneRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{addObject.Risk_Konu_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_KutuphaneRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_KutuphaneRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Öğe bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_KutuphaneDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_KutuphaneRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_KutuphaneDTO>>(resultObject);
                return new DataResult<IList<Risk_KutuphaneDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KutuphaneDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_KutuphaneDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_KutuphaneRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_KutuphaneDTO>(resultObject);
                return new DataResult<Risk_KutuphaneDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_KutuphaneDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_KutuphaneRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_KutuphaneRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Öğe veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Öğe bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_KutuphaneDTO updateObject, long modifiedByUserId)
        {
            //var exist = await _unitOfWork.risk_KonuRepository.AnyAsync(x => x.Risk_Konu_Ad == updateObject.Risk_Konu_Adi && x.Id != updateObject.Id);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.risk_KutuphaneRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_KutuphaneDTO, Risk_Kutuphane>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_KutuphaneRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"Başarrılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"Öğe bulunamadı.");
                }
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{updateObject.Risk_Konu_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }


        public async Task<IDataResult<IList<Risk_KutuphaneDTO>>> GetAllRiskAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_KutuphaneRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Risk_Analiz_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_KutuphaneDTO>>(resultObject);
                return new DataResult<IList<Risk_KutuphaneDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KutuphaneDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}

