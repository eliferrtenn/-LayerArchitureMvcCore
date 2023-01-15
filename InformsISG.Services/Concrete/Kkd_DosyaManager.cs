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
    public class Kkd_DosyaManager : IKkd_DosyaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kkd_DosyaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kkd_DosyaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kkd_DosyaRepository.AnyAsync(x => x.Kkd_Id == addObject.Kkd_Id && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Kkd_Dosya>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkd_DosyaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd.Kkd_No} numaralı dosya başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Kkd_Id} numaralı dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kkd_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kkd_DosyaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd.Kkd_No} nuamaralı dosya başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd.Kkd_No} nuamaralı dosya  bulunamadı.");
        }

        public async Task<IDataResult<IList<Kkd_DosyaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kkd_DosyaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kkd_DosyaDTO>>(resultObject);
                return new DataResult<IList<Kkd_DosyaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kkd_DosyaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kkd_DosyaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kkd_DosyaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kkd_DosyaDTO>(resultObject);
                return new DataResult<Kkd_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kkd_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kkd_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kkd_DosyaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kkd.Kkd_No} nuamaralı dosya  veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kkd.Kkd_No} nuamaralı dosya bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kkd_DosyaDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.kkd_DosyaRepository.AnyAsync(x => x.Kkd_Id == updateObject.Kkd_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kkd_DosyaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kkd_DosyaDTO,Kkd_Dosya>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kkd_DosyaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kkd.Kkd_No} numaralı dosya  başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_Id} numaralı dosya bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kkd_Id} numaralı dosya  zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
  
    
    }
}
