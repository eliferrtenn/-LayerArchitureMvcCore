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
    public class Isg_Kurul_Karar_DosyaManager : IISg_Kurul_Karar_DosyaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Isg_Kurul_Karar_DosyaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Isg_Kurul_Karar_DosyaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.isg_Kurul_Karar_DosyaRepository.AnyAsync(x => x.Isg_Kurul_Karar_Id == addObject.Isg_Kurul_Karar_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Isg_Kurul_Karar_Dosya>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_Karar_DosyaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.isg_Kurul_Karar_DosyaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Dosya bulunamadı.");
        }

        public async Task<IDataResult<IList<Isg_Kurul_Karar_DosyaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_Karar_DosyaDTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_Karar_DosyaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_Karar_DosyaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Isg_Kurul_Karar_DosyaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_Karar_DosyaDTO>(resultObject);
                return new DataResult<Isg_Kurul_Karar_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Isg_Kurul_Karar_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.isg_Kurul_Karar_DosyaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Dosya veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Dosya bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Isg_Kurul_Karar_DosyaDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.AnyAsync(x => x.Isg_Kurul_Karar_Id == updateObject.Isg_Kurul_Karar_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.isg_Kurul_Karar_DosyaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_Karar_DosyaDTO,Isg_Kurul_Karar_Dosya>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_Karar_DosyaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
