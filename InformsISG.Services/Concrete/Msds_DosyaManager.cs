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
    public class Msds_DosyaManager : IMsds_DosyaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Msds_DosyaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Msds_DosyaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.msds_DosyaRepository.AnyAsync(x => x.Msds_Id == addObject.Msds_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Msds_Dosya>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.msds_DosyaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Dosya başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.msds_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.msds_DosyaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Dosya başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Dosya bulunamadı.");
        }

        public async Task<IDataResult<IList<Msds_DosyaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.msds_DosyaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Msds_DosyaDTO>>(resultObject);
                return new DataResult<IList<Msds_DosyaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Msds_DosyaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Msds_DosyaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.msds_DosyaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Msds_DosyaDTO>(resultObject);
                return new DataResult<Msds_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Msds_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.msds_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.msds_DosyaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Dosya veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Dosya bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Msds_DosyaDTO updateObject, long modifiedByUserId)
        {
            //var exist =await _unitOfWork.msds_DosyaRepository.AnyAsync(x => x.Msds_Id == updateObject.Msds_Id  && x.Id != updateObject.Id);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.msds_DosyaRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Msds_DosyaDTO,Msds_Dosya>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.msds_DosyaRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, "Dosya başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, "Dosya bulunamadı.");
                }
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{updateObject.Msds_Id} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }
    }
}
