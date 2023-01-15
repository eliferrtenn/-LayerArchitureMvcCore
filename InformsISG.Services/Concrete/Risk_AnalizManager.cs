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
    public class Risk_AnalizManager : IRisk_AnalizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public Risk_AnalizManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_AnalizDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.risk_AnalizRepository.AnyAsync(x => x.Analiz_No == addObject.Analiz_No && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Analiz>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_AnalizRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Analiz_No} numaralı analiz başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Analiz_No} numaralı analiz  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_AnalizRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_AnalizRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Analiz_No} numaralı analiz  başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Analiz_No} numaralı analiz  bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_AnalizDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_AnalizRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_AnalizDTO>>(resultObject);
                return new DataResult<IList<Risk_AnalizDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_AnalizDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_AnalizDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_AnalizRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_AnalizDTO>(resultObject);
                return new DataResult<Risk_AnalizDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_AnalizDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<Risk_AnalizDTO>> GetSelectAsync()
        {
            var resultObject = await _unitOfWork.risk_AnalizRepository.GetAllAsync(x => !x.isDeleted, k1 => k1.Risk_Konu, k2 => k2.Risk_Konu.Risk_Konu_Grup,k3=>k3.Risk_Konu.Risk_Konu_Grup.Risk_Ust_Grup,k4=>k4.Risk_Konu.Risk_Konu_Grup.Risk_Ust_Grup.Risk_Kategori);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<Risk_AnalizDTO>(resultObject);
                return new DataResult<Risk_AnalizDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_AnalizDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_AnalizRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_AnalizRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Analiz_No} numaralı analiz  veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Analiz_No} numaralı analiz  bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_AnalizDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.risk_AnalizRepository.AnyAsync(x => x.Analiz_No == updateObject.Analiz_No && x.Id != updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_AnalizRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_AnalizDTO,Risk_Analiz>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_AnalizRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Analiz_No} numaralı analiz  başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Analiz_No} numaralı analiz  bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Analiz_No} numaralı analiz  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IDataResult<Risk_AnalizDTO>> AddAndGetAsync(Risk_AnalizDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.risk_AnalizRepository.AnyAsync(x => x.Analiz_No == addObject.Analiz_No && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Analiz>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_AnalizRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Risk_AnalizDTO>(result);

                return new DataResult<Risk_AnalizDTO>(ResultStatus.Success, result1);
            }
            else
            {
                return new DataResult<Risk_AnalizDTO>(ResultStatus.Error, "Veri zaten kayıtlıdır. Lütfen tekrar deneyiniz",
            null);
            }
        }



    }
}
