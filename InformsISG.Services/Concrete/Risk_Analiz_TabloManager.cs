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
    public class Risk_Analiz_TabloManager : IRisk_Analiz_TabloService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_Analiz_TabloManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_Analiz_TabloDTO addObject, long createdByUserId)
        {
            //var exist =await _unitOfWork.risk_Analiz_TabloRepository.AnyAsync(x => x.Risk_Analiz_Id == addObject.Risk_Analiz_Id);
            //if (exist == false)
            //{
                var result = _mapper.Map<Risk_Analiz_Tablo>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_Analiz_TabloRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"Veriler tabloya başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{addObject.Risk_Analiz_Id} tabloya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IDataResult<Risk_Analiz_TabloDTO>> AddAndGetAsync(Risk_Analiz_TabloDTO addObject, long createdByUserId)
        {

                var result = _mapper.Map<Risk_Analiz_Tablo>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_Analiz_TabloRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Risk_Analiz_TabloDTO>(result);

                return new DataResult<Risk_Analiz_TabloDTO>(ResultStatus.Success, result1);
        }


        public async Task<IResult> UpdateAsync(Risk_Analiz_TabloDTO updateObject, long modifiedByUserId)
        {
            //var exist =await _unitOfWork.risk_Analiz_TabloRepository.AnyAsync(x => !x.isDeleted);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_Analiz_TabloDTO,Risk_Analiz_Tablo>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_Analiz_TabloRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"Tablodaki veriler başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"Veri bulunamadı.");
                }
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{updateObject.Tehlike_Kaynagi} tabloda zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_Analiz_TabloRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Veri veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Veri tabloda bulunamadı.");
        }
      
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_Analiz_TabloRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Veri başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Veri tabloda bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_Analiz_TabloDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_Analiz_TabloDTO>>(resultObject);
                return new DataResult<IList<Risk_Analiz_TabloDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_Analiz_TabloDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Risk_Analiz_TabloDTO>>> GetYuksekRisk()
        {
            var resultObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAllAsync(x => x.Risk_Puan1>400 || x.Risk_Puan2>12);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_Analiz_TabloDTO>>(resultObject);
                return new DataResult<IList<Risk_Analiz_TabloDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_Analiz_TabloDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_Analiz_TabloDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_Analiz_TabloRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_Analiz_TabloDTO>(resultObject);
                return new DataResult<Risk_Analiz_TabloDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_Analiz_TabloDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


    }
}
